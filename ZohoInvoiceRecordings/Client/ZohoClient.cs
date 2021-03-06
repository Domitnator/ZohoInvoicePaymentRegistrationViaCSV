using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using ZohoInvoiceRecordings.Models;
using ZohoInvoiceRecordings.Models.Zoho;

namespace ZohoInvoiceRecordings.Client
{
    public class ZohoClient : WebClient
    {
        private readonly ApplicationSettings _applicationSettings;

        public ZohoClient(IOptions<ApplicationSettings> applicationSettings)
        {
            this._applicationSettings = applicationSettings.Value;

            this.BaseAddress = "https://invoice.zoho.com";
            this.Headers.Add("Authorization", $"Zoho-oauthtoken {_applicationSettings.AccessToken}");
        }

        public async Task<string> GetInvoice(string invoicenumber)
        {
            return await this.DownloadStringTaskAsync($"api/v3/invoices?invoice_number={invoicenumber}");
        }

        public async Task<string> GetInvoicePayments(string invoiceID)
        {
             return await this.DownloadStringTaskAsync($"api/v3/invoices/{invoiceID}/payments/");
        }

        public async Task<string> CreatePayment(Payment payment)
        {
            return await this.UploadStringTaskAsync("api/v3/customerpayments", JsonSerializer.Serialize(payment));
        }
    }
}
