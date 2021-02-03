using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IikoServerApi;

namespace ConsoleApp1
{
    class Program
    {
        private static readonly IikoRMS _rms = new IikoRMS("176.118.219.130", 18281, "Zx08365#");


        static void Main(string[] args)
        {
            using (IikoServerApi.IikoServerApi api = new IikoServerApi.IikoServerApi(_rms))
            {
                api.GetEmployeesAsync().Wait();
            }
        }
    }
}
