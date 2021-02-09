using System;
using System.Linq;
using IikoApi;
using IikoApi.Entities.Suppliers;

namespace ConsoleApp1
{
    class Program
    {
        private static readonly IikoRMS _rms = new IikoRMS("176.118.219.130", 18281, "Zx08365#");


        static void Main(string[] args)
        {

            IikoServerApi api = new IikoServerApi(_rms);
            
            var sup = api.GetSuppliersAsync().Result;

            Supplier supplier = sup[8]; //EntitySelect(sup, "Выберите поставщика:");


            var t = api.GetIncomingInvoicesAsync(DateTime.Now.AddMonths(-24), DateTime.Now).Result;


            var d = t.First();
            d.Id = Guid.NewGuid().ToString();


             //var r = api.AddIncomingInvoiceAsync(d).Result;




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
