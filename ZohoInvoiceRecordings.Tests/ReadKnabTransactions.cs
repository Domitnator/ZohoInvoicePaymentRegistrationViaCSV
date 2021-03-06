using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using ZohoInvoiceRecordings.Client;

namespace ZohoInvoiceRecordings.Tests
{
    [TestClass]
    public class ReadKnabTransactions: Base.BaseTest
    {
        [TestMethod]
        public void ReadCSVRecords()
        {
            KnabCSVReader reader = new KnabCSVReader(Options.Create(applicationSettings));

            var records = reader.ReadRecords();

            Assert.IsNotNull(records);
        }
    }
}
