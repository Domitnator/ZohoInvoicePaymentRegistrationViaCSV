using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZohoInvoiceRecordings.Models.Zoho
{
    public class Payment
    {
        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("payment_mode")]
        public string PaymentMode { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("reference_number")]
        public string ReferenceNumber { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("invoices")]
        public List<PaymentInvoice> Invoices { get; set; }

        [JsonPropertyName("exchange_rate")]
        public int ExchangeRate { get; set; }

        [JsonPropertyName("bank_charges")]
        public int BankCharges { get; set; }
    }
}
