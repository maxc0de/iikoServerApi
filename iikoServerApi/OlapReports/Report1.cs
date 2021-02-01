using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IikoServerApi
{
    public class Report1
    {
        public string Department { get; set; }

        public string Mounth { get; set; }

        public DateTime CloseTime { get; set; }

        public decimal DishDiscountSumInt { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static ReportModel GetReportModel()
        {
            var rep1 = new ReportModel("Количество чеков в диапазоне", nameof(Report1));
            rep1.AddCondition("Цена от:", 1000m);
            rep1.AddCondition("Цена до:", 100000m);

            return rep1;
        }

        public static async Task<DataTable> Create(RequestModel model)
        {
            IikoServerApi apiServer = new IikoServerApi(model.IikoServer);

            var reportRequest = GetReportRequest(model.From, model.To, model.Departments);
            var json = await apiServer.GetOlapReport(reportRequest);
            var olapReport = JsonConvert.DeserializeObject<OlapReport<Report1>>(json);

            var fromValue = Convert.ToDecimal(model.ReportModel.Conditions.First(y => y.Name == "Цена от:").Value);
            var toValue = Convert.ToDecimal(model.ReportModel.Conditions.First(y => y.Name == "Цена до:").Value);

            return ToDataTable(olapReport.Data.Where(x => x.DishDiscountSumInt >= fromValue && x.DishDiscountSumInt <= toValue));
        }

        private static ReportRequest GetReportRequest(DateTime from, DateTime to, string[] departments)
        {
            ReportRequest reportRequest = new ReportRequest();
            reportRequest.GroupByColFields.Add("Department");
            reportRequest.GroupByColFields.Add("Mounth");
            reportRequest.GroupByColFields.Add("CloseTime");
            reportRequest.AggregateFields.Add("DishDiscountSumInt");
            reportRequest.Filters.Add("OpenDate.Typed", new DateTimeFilter(PeriodType.CUSTOM, from, to));
            reportRequest.Filters.Add("DeletedWithWriteoff", new ValueFilter(FilterType.IncludeValues, "NOT_DELETED"));

            if (departments != null)
            {
                reportRequest.Filters.Add("Department", new ValueFilter(FilterType.IncludeValues, departments));
            }

            return reportRequest;
        }

        private static DataTable ToDataTable(IEnumerable<Report1> data)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ТП");
            table.Columns.Add("Месяц");
            table.Columns.Add("Количество чеков");
            table.Columns.Add("Сумма");

            var departmentGroups = data.GroupBy(x => x.Department);
            foreach (var departmentGroup in departmentGroups)
            {
                var months = departmentGroup.GroupBy(x => x.Mounth);
                foreach (var month in months)
                {
                    DataRow newRow = table.NewRow();
                    newRow["ТП"] = departmentGroup.Key;
                    newRow["Месяц"] = month.Key;
                    newRow["Количество чеков"] = month.Count();
                    newRow["Сумма"] = month.Sum(x => x.DishDiscountSumInt);

                    table.Rows.Add(newRow);
                }
            }

            return table;
        }
    }
}
