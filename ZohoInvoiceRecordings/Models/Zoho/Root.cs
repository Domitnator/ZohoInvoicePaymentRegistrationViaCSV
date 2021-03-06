using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZohoInvoiceRecordings.Models
{
    public class InvoiceRoot
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("invoices")]
        public List<Invoice> Invoices { get; set; }

        [JsonPropertyName("page_context")]
        public PageContext PageContext { get; set; }
    }
}
