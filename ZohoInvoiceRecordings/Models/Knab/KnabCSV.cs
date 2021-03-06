using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZohoInvoiceRecordings.Models.Knab
{
    [DelimitedRecord(";")]
    [IgnoreFirst(1)]
    public class KnabCSV
    {
        public string Rekeningnummer { get; set; }

        public string Transactiedatum { get; set; }

        public string Valutacode { get; set; }

        public string CreditDebet { get; set; }

        public string Bedrag { get; set; }

        public string Tegenrekeningnummer { get; set; }

        public string Tegenrekeninghouder { get; set; }

        public string Valutadatum { get; set; }

        public string Betaalwijze { get; set; }

        public string Omschrijving { get; set; }

        public string TypeBetaling { get; set; }

        public string Machtigingsnummer { get; set; }

        public string IncassantID { get; set; }

        public string Adres { get; set; }

        public string ExtractInvoiceNumber()
        {
            var match = Regex.Match(this.Omschrijving, "INV-\\d+");

            if (match.Success)
            {
                return match.Value;
            }
            else
            {
                var match2 = Regex.Match(this.Omschrijving, "(2021|2020|2019)\\d{4}");

                if (match2.Success)
                {
                    return "INV-" + match2.Value;
                }

            }
            return String.Empty;
        }

        public string Referentie { get; set; }

        public string Boekdatum { get; set; }

        public decimal GetAmount()
        {
            return decimal.Parse(this.Bedrag.Trim(new char[] { '"' }));
        }

        public int GetAmountInCents()
        {
            return int.Parse(String.Format("{0:0}", this.GetAmount() * 100));
        }
    }
}
