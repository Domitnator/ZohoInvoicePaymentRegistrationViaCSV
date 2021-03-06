using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZohoInvoiceRecordings.Models.Zoho
{
    public class PaymentInvoice
    {
        [JsonPropertyName("invoice_id")]
        public string InvoiceId { get; set; }

        [JsonPropertyName("amount_applied")]
        public decimal AmountApplied { get; set; }
    }
}
