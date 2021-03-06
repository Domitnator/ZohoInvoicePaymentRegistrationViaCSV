using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoInvoiceRecordings.Models
{
    public class ApplicationSettings
    {
        public string AccessToken { get; set; }

        public string CustomerId { get; set; }

        public string TransactionsFile { get; set; }

        public string OutputFile { get; set; }
    }
}
