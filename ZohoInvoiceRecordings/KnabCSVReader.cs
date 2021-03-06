using FileHelpers;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZohoInvoiceRecordings.Models;
using ZohoInvoiceRecordings.Models.Knab;

namespace ZohoInvoiceRecordings
{
    public class KnabCSVReader
    {
        private readonly FileHelperEngine<KnabCSV> _engine;
        private readonly ApplicationSettings _applicationSettings;

        public KnabCSVReader(IOptions<ApplicationSettings> applicationSettings)
        {
            _engine = new FileHelperEngine<KnabCSV>();
            _applicationSettings = applicationSettings.Value;
        }

        public List<KnabCSV> ReadRecords()
        {
            string filename = _applicationSettings.TransactionsFile;

            RemoveLastDelimiterFromEveryLine(filename);

            var records = _engine.ReadFile(filename);

            return records.ToList();
        }

        private void RemoveLastDelimiterFromEveryLine(string filename)
        {
            StringBuilder sb = new();
            string line;
            int counter = 0;
            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(filename);

            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                sb.AppendLine(line.TrimEnd(new char[] { ';' }));
                counter++;
            }

            file.Close();

            System.IO.File.WriteAllText(filename, sb.ToString());
        }
    }
}
