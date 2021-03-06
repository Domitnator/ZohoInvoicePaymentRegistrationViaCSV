using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZohoInvoiceRecordings.Enums;
using ZohoInvoiceRecordings.Models.Knab;

namespace ZohoInvoiceRecordings.Models
{
    public class ImportOutput
    {
        public string InvoiceNumber { get; set; }

        public KnabCSV CSVRecord { get; set; }

        public string ImportStatus { get; set; }

        public int LineNumber { get; set; }

        public string Error { get; set; }
    }
}
