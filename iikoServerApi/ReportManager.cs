using System;
using System.Data;
using System.Threading.Tasks;

namespace iikoAPIServer
{
    public static class ReportManager
    {
        public async static Task<DataTable> GetReport(RequestModel model)
        {
            if(model.ReportModel.InvariantName == "Report1")
            {
                return await Report1.Create(model);
            }
            else if (model.ReportModel.InvariantName == "Report2")
            {
                return await Report2.Create(model);
            }

            return null;
        }
    }
}
