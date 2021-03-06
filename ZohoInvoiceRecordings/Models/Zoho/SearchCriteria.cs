using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZohoInvoiceRecordings.Models
{
    public class SearchCriteria
    {
        [JsonPropertyName("column_name")]
        public string ColumnName { get; set; }

        [JsonPropertyName("search_text")]
        public string SearchText { get; set; }

        [JsonPropertyName("search_text_formatted")]
        public string SearchTextFormatted { get; set; }

        [JsonPropertyName("comparator")]
        public string Comparator { get; set; }
    }
}
