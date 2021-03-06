using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ZohoInvoiceRecordings.Client;
using ZohoInvoiceRecordings.Models;
using ZohoInvoiceRecordings.Models.Knab;
using ZohoInvoiceRecordings.Models.Zoho;

namespace ZohoInvoiceRecordings
{
    public class ZohoInvoicesService
    {
        private readonly ZohoClient client;
        private readonly ApplicationSettings applicationSettings;

        public ZohoInvoicesService(ZohoClient client, IOptions<ApplicationSettings> applicationSettings)
        {
            this.client = client;
            this.applicationSettings = applicationSettings.Value;
        }

        public async Task<InvoiceRoot> GetInvoice(string invoicenumber)
        {
            var invoice = await client.GetInvoice(invoicenumber);

            if(!String.IsNullOrEmpty(invoice))
            {
                return JsonSerializer.Deserialize<InvoiceRoot>(invoice);
            }

            return null;
        }

        public async Task<List<ImportOutput>> RecordPayments(List<KnabCSV> knabrecords)
        {
            List<ImportOutput> outputs = new();
            ImportOutput output = null;
            int recordNumber = 1;

            foreach (var item in knabrecords)
            {
                recordNumber++;

                output = new ImportOutput()
                {
                    CSVRecord = item,
                    InvoiceNumber = item.ExtractInvoiceNumber(),
                    LineNumber = recordNumber
                };

                Console.WriteLine($"Processing invoice {output.InvoiceNumber} for linenumber {output.LineNumber}");

                if (String.IsNullOrEmpty(output.InvoiceNumber))
                {
                    output.ImportStatus = Enums.ImportStatus.NoInvoiceSubstractedFromKnabCSV.ToString();
                    outputs.Add(output);
                    continue;
                }

                InvoiceRoot invoice;

                try
                {
                    invoice = await this.GetInvoice(output.InvoiceNumber);
                }
                catch
                {
                    output.ImportStatus = Enums.ImportStatus.ErrorDuringInvoiceRetrievalFromZoho.ToString();
                    outputs.Add(output);
                    continue;
                }

                if(invoice.Message == "success" && invoice.Invoices != null && invoice.Invoices.Count == 1 && invoice.Invoices.First().Status == Enums.InvoiceStatus.paid.ToString())
                {
                    output.ImportStatus = Enums.ImportStatus.InvoiceAlreadyPaid.ToString();
                    outputs.Add(output);
                    continue;
                }

                if (invoice.Message == "success" && invoice.Invoices != null && invoice.Invoices.Count == 1 && invoice.Invoices.First().Total != item.GetAmount())
                {
                    output.ImportStatus = Enums.ImportStatus.PaymentRecievedButAmountIsIncorrect.ToString();
                    outputs.Add(output);
                    continue;
                }

                if (invoice.Message == "success" && invoice.Invoices.Count == 0)
                {
                    output.ImportStatus = Enums.ImportStatus.InvoiceNotFoundInZoho.ToString();
                    outputs.Add(output);
                    continue;
                }

                if (invoice.Message == "success" && invoice.Invoices != null && invoice.Invoices.Count == 1)
                {
                    Payment payment = new()
                    {
                        Amount = item.GetAmount(),
                        BankCharges = 0,
                        CustomerId = this.applicationSettings.CustomerId,
                        Date = DateTime.Parse(item.Boekdatum.Trim(new char[] { '"' })).ToString("yyy-MM-dd"),
                        Description = $"Betaling ontvangen voor factuur {output.InvoiceNumber}",
                        Invoices = new List<PaymentInvoice>
                        {
                              new PaymentInvoice
                              {
                                   AmountApplied = item.GetAmount(),
                                   InvoiceId = invoice.Invoices.First().InvoiceId
                              }
                        },
                        PaymentMode = "banktransfer",
                        ExchangeRate = 0,
                        ReferenceNumber = item.Referentie.Trim(new char[] { '"' })
                    };

                    string json = JsonSerializer.Serialize(payment);

                    var result = await this.CreatePayment(payment);

                    if(result.Code == 0)
                    {
                        output.ImportStatus = Enums.ImportStatus.PaymentRecorded.ToString();
                    }
                    else
                    {
                        output.ImportStatus = Enums.ImportStatus.ErrorDuringPaymentCreation.ToString();
                        output.Error = result.Message;
                    }

                    outputs.Add(output);
                }
            }

            System.IO.File.WriteAllText(this.applicationSettings.OutputFile, JsonSerializer.Serialize(outputs));

            return outputs;
        }

        private async Task<PaymentResponse> CreatePayment(Payment payment)
        {
            var result = await this.client.CreatePayment(payment);

            if (!String.IsNullOrEmpty(result))
                return JsonSerializer.Deserialize<PaymentResponse>(result);

            return null;
        }
    }
}
