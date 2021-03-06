using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoInvoiceRecordings.Enums
{
    public enum ImportStatus
    {
        PaymentRecorded,
        InvoiceAlreadyPaid,
        InvoiceNotFoundInZoho,
        ErrorDuringInvoiceRetrievalFromZoho,
        NoInvoiceSubstractedFromKnabCSV,
        PaymentRecievedButAmountIsIncorrect,
        ErrorDuringPaymentCreation
    }
}
