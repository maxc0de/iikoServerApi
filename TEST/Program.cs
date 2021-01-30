using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iikoAPIServer;
using System.Xml.Serialization;
using System.IO;

namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            IikoServerAPI iikoAPI = new IikoServerAPI(new IikoServer("admin", "Zx08365#", "176.118.219.130", 18281));

            var emp = iikoAPI.GetEmployees().Result;






        }
    }
}
