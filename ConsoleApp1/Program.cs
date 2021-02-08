using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IikoServerApi;
using IikoServerApi.Entities.Documents;
using IikoServerApi.Entities.Suppliers;

namespace ConsoleApp1
{
    class Program
    {
        private static readonly IikoRMS _rms = new IikoRMS("176.118.219.130", 18281, "Zx08365#");


        static void Main(string[] args)
        {

            IikoServerApi.IikoServerApi api = new IikoServerApi.IikoServerApi(_rms);
            
            var sup = api.GetSuppliersAsync().Result;

            Supplier supplier = EntitySelect(sup, "Выберите поставщика:");

            Document document = new Document(supplier.Id);

            var t = api.GetIncomingInvoice(DateTime.Now.AddMonths(-24), DateTime.Now, supplier.Id).Result;


            var d = t.First();
            d.DocumentNumber = 3;

            var r = api.AddIncomingInvoiceAsync(d).Result;




        }

        private static T EntitySelect<T>(T[] entities, string message)
        {
            Console.WriteLine(message);
            for (int i = 0; i < entities.Length; i++)
            {
                Console.WriteLine($"{i} {entities[i]}");
            }

            int result;
            while (!int.TryParse(Console.ReadLine(), out result)) { }

            return entities[result];
        }
    }
}
