using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using ZohoInvoiceRecordings.Client;
using ZohoInvoiceRecordings.Models;

namespace ZohoInvoiceRecordings.Tests
{
    [TestClass]
    public class ReadInvoicesFromZoho: Base.BaseTest
    {
        private readonly string invoiceNumber = "";

        [TestMethod]
        public async Task ShoulReturnInvoiceFromZoho()
        {
            var client = new ZohoClient(Options.Create(applicationSettings));
            var invoiceService = new ZohoInvoicesService(client, Options.Create<ApplicationSettings>(applicationSettings));

            var invoice = await invoiceService.GetInvoice(invoiceNumber);
            
            Assert.AreEqual(invoiceNumber, invoice.Invoices.FirstOrDefault()?.InvoiceNumber);
        }
    }
}
