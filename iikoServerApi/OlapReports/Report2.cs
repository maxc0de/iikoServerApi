using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IikoServerApi
{
    public class Report2
    {
        public string Department { get; set; }

        public string Mounth { get; set; }

        public string DishName { get; set; }

        public decimal DishAmountInt { get; set; }

        public decimal DishDiscountSumInt { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static ReportModel GetReportModel()
        {
            var reportModel = new ReportModel("Цена за единицу блюда", nameof(Report2));
            reportModel.AddCondition("Блюдо", string.Empty);

            return reportModel;
        }

        public static async Task<DataTable> Create(RequestModel model)
        {
            IikoServerApi apiServer = new IikoServerApi(model.IikoServer);

            var reportRequest = GetReportRequest(model.From, model.To, model.Departments, (string)model.ReportModel.Conditions.First().Value);
            var json = await apiServer.GetOlapReport(reportRequest);

            var olapReport = JsonConvert.DeserializeObject<OlapReport<Report2>>(json);

            return ToDataTable(olapReport.Data);
        }

        public static ReportRequest GetReportRequest(DateTime from, DateTime to, string[] departments, string dish)
        {
            ReportRequest reportRequest = new ReportRequest();
            reportRequest.GroupByColFields.Add("Department");
            reportRequest.GroupByColFields.Add("Mounth");
            reportRequest.GroupByColFields.Add("DishName");
            reportRequest.AggregateFields.Add("DishAmountInt");
            reportRequest.AggregateFields.Add("DishDiscountSumInt");
            reportRequest.Filters.Add("OpenDate.Typed", new DateTimeFilter(PeriodType.CUSTOM, from, to));
            reportRequest.Filters.Add("DeletedWithWriteoff", new ValueFilter(FilterType.IncludeValues, "NOT_DELETED"));

            if (!string.IsNullOrEmpty(dish))
            {
                reportRequest.Filters.Add("DishName", new ValueFilter(FilterType.IncludeValues, dish));
            }

            if (departments != null)
            {
                reportRequest.Filters.Add("Department", new ValueFilter(FilterType.IncludeValues, departments));
            }

            return reportRequest;
        }

        private static DataTable ToDataTable(IEnumerable<Report2> data)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ТП");
            table.Columns.Add("Месяц");
            table.Columns.Add("Блюдо");
            table.Columns.Add("Количество");
            table.Columns.Add("Сумма");
            table.Columns.Add("За единицу");

            var departmentGroups = data.GroupBy(x => x.Department);
            foreach (var departmentGroup in departmentGroups)
            {
                var months = departmentGroup.GroupBy(x => x.Mounth).ToList();
                foreach(var month in months)
                {
                    for (int i = 0; i < month.Count(); i++)
                    {
                        var reports = month.ToArray();

                        DataRow newRow = table.NewRow();
                        newRow["ТП"] = departmentGroup.Key;
                        newRow["Месяц"] = month.Key;
                        newRow["Блюдо"] = reports[i].DishName;
                        newRow["Количество"] = reports[i].DishAmountInt;
                        newRow["Сумма"] = reports[i].DishDiscountSumInt;
                        newRow["За единицу"] = reports[i].DishAmountInt > 0 ? Math.Round(reports[i].DishDiscountSumInt / reports[i].DishAmountInt, 2) : reports[i].DishDiscountSumInt;

                        table.Rows.Add(newRow);
                    }
                }
            }

            return table;
        }
    }
}
