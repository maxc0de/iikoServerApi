using System;
using System.Text;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using IikoServerApi.Entities.Documents;
using IikoServerApi.Entities.Suppliers;

namespace IikoServerApi
{
    public class IikoServerApi
    {
        private readonly IikoRMS _iikoRMS;
        private readonly HttpClient _httpClient;


        public IikoServerApi(IikoRMS iikoServer)
        {
            _iikoRMS = iikoServer;
            _httpClient = new HttpClient() { BaseAddress = _iikoRMS.ServerUri, Timeout = TimeSpan.FromMinutes(5) };
        }


        public async Task<Employee[]> GetEmployeesAsync()
        {
            string employeesXml = await ApiRequestAsync($"/resto/api/employees?key={{0}}");

            return ReadFromXmlString<Employees>(employeesXml).EmployeeList;
        }

        public async Task<Supplier[]> GetSuppliersAsync()
        {
            string suppliersXml = await ApiRequestAsync($"/resto/api/suppliers?key={{0}}");

            return ReadFromXmlString<Suppliers>(suppliersXml).SupplierList;
        }

        public async Task<CorporateItemDto[]> GetDepartments()
        {
            string departmentsXml = await ApiRequestAsync($"/resto/api/corporation/departments?key={{0}}");

            return ReadFromXmlString<CorporateItemDtoes>(departmentsXml).CorporateItemDtoList;
        }

        public async Task<TerminalDto[]> GetTerminals(bool onlyFronts = true)
        {
            string terminalsXml = await ApiRequestAsync($"/resto/api/corporation/terminals?key={{0}}");

            return ReadFromXmlString<TerminalDtoes>(terminalsXml).TerminalDtoList.Where(x => !onlyFronts || !x.Anonymous).ToArray();
        }

        public async Task<Document[]> GetIncomingInvoice(DateTime from, DateTime to, Guid? supplierId = null)
        {
            string From = from.ToString("yyyy-MM-dd");
            string To = to.ToString("yyyy-MM-dd");

            string terminalsXml = await ApiRequestAsync($"/resto/api/documents/export/incomingInvoice?key={{0}}&from={From}&to={To}&supplierId={supplierId}");

            return ReadFromXmlString<IncomingInvoiceDtoes>(terminalsXml).DocumentList;
        }

        public async Task<CashShift[]> GetCashShifts(DateTime openDateFrom, DateTime openDateTo, CashShiftStatus status)
        {
            string From = openDateFrom.ToString("yyyy-MM-dd");
            string To = openDateTo.ToString("yyyy-MM-dd");

            string cashShiftsJson = await ApiRequestAsync($"/resto/api/v2/cashshifts/list?key={{0}}&openDateFrom={From}&openDateTo={To}&status={status}");

            return JsonConvert.DeserializeObject<CashShift[]>(cashShiftsJson);
        }

        public async Task<DocumentValidationResult> AddIncomingInvoiceAsync(Document document)
        {
            //var json = JsonConvert.SerializeObject(document);


            string s = WriteFromXmlString(document);
            var data = new StringContent(s, Encoding.UTF8, "application/xml"); //


            string documentValidationResult = await ApiRequestAsync($"/resto/api/documents/import/incomingInvoice?key={{0}}", HttpMethod.Post, data);

            return JsonConvert.DeserializeObject<DocumentValidationResult>(documentValidationResult);
        }

        public async Task<string> GetOlapReport(ReportRequest reportRequest)
        {
            if (reportRequest == null)
            {
                throw new ArgumentNullException();
            }

            await LogInAsync();

            string olapReport = null;
            try
            {
                string jsonReportRequest = JsonConvert.SerializeObject(reportRequest, new Newtonsoft.Json.Converters.StringEnumConverter());
                var contentReportRequest = new StringContent(jsonReportRequest, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"/resto/api/v2/reports/olap?key={{0}}", contentReportRequest);
                olapReport = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //await LogOutAsync("");
            }

            return olapReport;
        }

        public async Task<string> GetColumns()
        {
            await LogInAsync();

            string columns;
            try
            {
                var response = await _httpClient.GetAsync($"/resto/api/v2/reports/olap/columns?key={{0}}&reportType=SALES");
                response.EnsureSuccessStatusCode();

                columns = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //await LogOutAsync("");
            }

            return columns;
        }


        private async Task<string> ApiRequestAsync(string uri, HttpMethod httpMethod = null, StringContent content = null)
        {
            string key = await LogInAsync();

            HttpResponseMessage httpResponseMsg = null;
            try
            {
                if (httpMethod == HttpMethod.Get || httpMethod == null)
                {
                    httpResponseMsg = await _httpClient.GetAsync(string.Format(uri, key));
                }
                else if (httpMethod == HttpMethod.Post)
                {
                    httpResponseMsg = await _httpClient.PostAsync(string.Format(uri, key), content);
                }

                httpResponseMsg.EnsureSuccessStatusCode();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                LogOutAsync(key).Wait();
            }

            return await httpResponseMsg.Content.ReadAsStringAsync();
        }

        private async Task<string> LogInAsync()
        {
            var response = await _httpClient.GetAsync($"/resto/api/auth?login={_iikoRMS.Login}&pass={GetHash(_iikoRMS.Password)}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        private static string GetHash(string value)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.Default.GetBytes(value));

                var sb = new StringBuilder(hash.Length * 2);
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        private async Task LogOutAsync(string key)
        {
            var response = await _httpClient.GetAsync($"/resto/api/logout?key={key}");
            response.EnsureSuccessStatusCode();
        }

        private T ReadFromXmlString<T>(string value) where T : new()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));

            T obj;

            using (Stream fs = new MemoryStream(Encoding.UTF8.GetBytes(value)))
            {
                obj = (T)formatter.Deserialize(fs);
            }


            return obj;
        }

        private string WriteFromXmlString<T>(T value) where T : new()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));

            StringWriter writer;
            using (writer = new Utf8StringWriter())
            {
                formatter.Serialize(writer, value);
            }

            return writer.ToString();
        }
    }
}
