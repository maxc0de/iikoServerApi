using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using IikoApi;

namespace IikoServerApi_Tests
{
    public class IikoServerApi_Tests
    {
        private readonly IikoRMS _rms = new IikoRMS("176.118.219.130", 18281, "Zx08365#");

        [Test]
        public async Task Test1()
        {
            IikoServerApi iikoServerApi = new IikoServerApi(_rms);

            var e = await iikoServerApi.GetEmployeesAsync();

            Assert.NotNull(e.First().Id);
        }
    }
}