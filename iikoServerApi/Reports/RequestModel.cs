using System;

namespace iikoAPIServer
{
    public class RequestModel
    {
        public IikoServer IikoServer { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public ReportModel ReportModel { get; set; }

        public string[] Departments { get; set; }

        public RequestModel(IikoServer iikoServer, DateTime from, DateTime to, ReportModel reportModel, params string[] departments)
        {
            IikoServer = iikoServer;
            From = from;
            To = to;
            ReportModel = reportModel;
            Departments = departments;
        }
    }
}
