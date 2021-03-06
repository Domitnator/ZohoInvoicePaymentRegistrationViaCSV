using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using ZohoInvoiceRecordings.Client;
using ZohoInvoiceRecordings.Models;

namespace ZohoInvoiceRecordings.Tests
{
    [TestClass]
    public class RecordPayments: Base.BaseTest
    {
        [TestMethod]
        public async Task ShouldRecordPayments()
        {
            KnabCSVReader reader = new KnabCSVReader(Options.Create(applicationSettings));
            var client = new ZohoClient(Options.Create(applicationSettings));
            var invoiceService = new ZohoInvoicesService(client, Options.Create(applicationSettings));

            var outputs = await invoiceService.RecordPayments(reader.ReadRecords());

            Assert.IsNotNull(outputs);
        }
    }
}
