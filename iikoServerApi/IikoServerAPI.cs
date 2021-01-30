using System;
using System.Text;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;

namespace iikoAPIServer
{
    public class IikoServerAPI
    {
        private readonly IikoServer _iikoServer;
        private readonly HttpClient _httpClient = new HttpClient();
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private static string _key;

        public IikoServerAPI(IikoServer iikoServer)
        {
            _iikoServer = iikoServer;
            _httpClient.Timeout = TimeSpan.FromMinutes(5);
        }

        public async Task<string> RequestMethod(Uri uri)
        {
            await LogIn();

            string response;
            try
            {
                var httpResponseMsg = await _httpClient.GetAsync(uri);
                httpResponseMsg.EnsureSuccessStatusCode();

                response = await httpResponseMsg.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw ex;
            }
            finally
            {
                await LogOut();
            }

            return response;
        }

        public async Task<string> GetEmployees()
        {
            await LogIn();

            string employees;
            try
            {
                var response = await _httpClient.GetAsync($"{_iikoServer.Url}/api/employees?key={_key}");
                response.EnsureSuccessStatusCode();

                employees = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw ex;
            }
            finally
            {
                await LogOut();
            }

            return employees;
        }

        public async Task<string> GetOlapReport(ReportRequest reportRequest)
        {
            if (reportRequest == null)
            {
                throw new ArgumentNullException();
            }

            await LogIn();

            string olapReport = null;
            try
            {
                string jsonReportRequest = JsonConvert.SerializeObject(reportRequest, new Newtonsoft.Json.Converters.StringEnumConverter());
                var contentReportRequest = new StringContent(jsonReportRequest, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"{_iikoServer.Url}/api/v2/reports/olap?key={_key}", contentReportRequest);
                olapReport = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();
                _logger.Info("Report received");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, olapReport);
                throw ex;
            }
            finally
            {
                await LogOut();
            }

            return olapReport;
        }

        public async Task<string> GetColumns()
        {
            await LogIn();

            string columns;
            try
            {
                var response = await _httpClient.GetAsync($"{_iikoServer.Url}/api/v2/reports/olap/columns?key={_key}&reportType=SALES");
                response.EnsureSuccessStatusCode();

                columns = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw ex;
            }
            finally
            {
                await LogOut();
            }

            return columns;
        }

        public async Task<string> GetDepartments()
        {
            await LogIn();

            string departments = null;
            try
            {
                var response = await _httpClient.GetAsync($"{_iikoServer.Url}/api/corporation/departments?key={_key}&reportType=SALES");
                departments = await response.Content.ReadAsStringAsync();

                response.EnsureSuccessStatusCode();
                _logger.Info("Departments received");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, departments);
                throw ex;
            }
            finally
            {
                await LogOut();
            }

            return departments;
        }


        private async Task LogIn()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_iikoServer.Url}/api/auth?login={_iikoServer.Login}&pass={GetHash(_iikoServer.Password)}");
                _key = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                _logger.Trace($"Connection received: {_key}");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, _key);
                throw ex;
            }
        }

        private async Task LogOut()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_iikoServer.Url}/api/logout?key={_key}");
                response.EnsureSuccessStatusCode();
                _logger.Trace($"Connection released: {_key}");
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw ex;
            }
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
    }
}
