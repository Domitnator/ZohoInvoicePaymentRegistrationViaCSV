using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZohoInvoiceRecordings.Models
{
    public class Invoice
    {
        [JsonPropertyName("invoice_id")]
        public string InvoiceId { get; set; }

        [JsonPropertyName("ach_payment_initiated")]
        public bool AchPaymentInitiated { get; set; }

        [JsonPropertyName("zcrm_potential_id")]
        public string ZcrmPotentialId { get; set; }

        [JsonPropertyName("zcrm_potential_name")]
        public string ZcrmPotentialName { get; set; }

        [JsonPropertyName("customer_name")]
        public string CustomerName { get; set; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("company_name")]
        public string CompanyName { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("color_code")]
        public string ColorCode { get; set; }

        [JsonPropertyName("current_sub_status_id")]
        public string CurrentSubStatusId { get; set; }

        [JsonPropertyName("current_sub_status")]
        public string CurrentSubStatus { get; set; }

        [JsonPropertyName("invoice_number")]
        public string InvoiceNumber { get; set; }

        [JsonPropertyName("reference_number")]
        public string ReferenceNumber { get; set; }

        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("due_date")]
        public string DueDate { get; set; }

        [JsonPropertyName("due_days")]
        public string DueDays { get; set; }

        [JsonPropertyName("currency_id")]
        public string CurrencyId { get; set; }

        [JsonPropertyName("schedule_time")]
        public string ScheduleTime { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("currency_symbol")]
        public string CurrencySymbol { get; set; }

        [JsonPropertyName("template_type")]
        public string TemplateType { get; set; }

        [JsonPropertyName("no_of_copies")]
        public int NoOfCopies { get; set; }

        [JsonPropertyName("show_no_of_copies")]
        public bool ShowNoOfCopies { get; set; }

        [JsonPropertyName("is_viewed_by_client")]
        public bool IsViewedByClient { get; set; }

        [JsonPropertyName("has_attachment")]
        public bool HasAttachment { get; set; }

        [JsonPropertyName("client_viewed_time")]
        public string ClientViewedTime { get; set; }

        [JsonPropertyName("invoice_url")]
        public string InvoiceUrl { get; set; }

        [JsonPropertyName("project_name")]
        public string ProjectName { get; set; }

        [JsonPropertyName("billing_address")]
        public BillingAddress BillingAddress { get; set; }

        [JsonPropertyName("shipping_address")]
        public ShippingAddress ShippingAddress { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("created_by")]
        public string CreatedBy { get; set; }

        //[JsonPropertyName("updated_time")]
        //public DateTime UpdatedTime { get; set; }

        [JsonPropertyName("transaction_type")]
        public string TransactionType { get; set; }

        [JsonPropertyName("total")]
        public decimal Total { get; set; }

        [JsonPropertyName("balance")]
        public double Balance { get; set; }

        //[JsonPropertyName("created_time")]
        //public DateTime CreatedTime { get; set; }

        //[JsonPropertyName("last_modified_time")]
        //public DateTime LastModifiedTime { get; set; }

        [JsonPropertyName("is_emailed")]
        public bool IsEmailed { get; set; }

        [JsonPropertyName("is_viewed_in_mail")]
        public bool IsViewedInMail { get; set; }

        [JsonPropertyName("mail_first_viewed_time")]
        public string MailFirstViewedTime { get; set; }

        [JsonPropertyName("mail_last_viewed_time")]
        public string MailLastViewedTime { get; set; }

        [JsonPropertyName("reminders_sent")]
        public int RemindersSent { get; set; }

        [JsonPropertyName("last_reminder_sent_date")]
        public string LastReminderSentDate { get; set; }

        [JsonPropertyName("payment_expected_date")]
        public string PaymentExpectedDate { get; set; }

        [JsonPropertyName("last_payment_date")]
        public string LastPaymentDate { get; set; }

        [JsonPropertyName("custom_fields")]
        public List<object> CustomFields { get; set; }

        [JsonPropertyName("custom_field_hash")]
        public CustomFieldHash CustomFieldHash { get; set; }

        [JsonPropertyName("template_id")]
        public string TemplateId { get; set; }

        [JsonPropertyName("documents")]
        public string Documents { get; set; }

        [JsonPropertyName("salesperson_id")]
        public string SalespersonId { get; set; }

        [JsonPropertyName("salesperson_name")]
        public string SalespersonName { get; set; }

        [JsonPropertyName("shipping_charge")]
        public double ShippingCharge { get; set; }

        [JsonPropertyName("adjustment")]
        public double Adjustment { get; set; }

        [JsonPropertyName("write_off_amount")]
        public decimal WriteOffAmount { get; set; }

        [JsonPropertyName("exchange_rate")]
        public double ExchangeRate { get; set; }
    }
}
