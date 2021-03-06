using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZohoInvoiceRecordings.Models
{
    public class PageContext
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("per_page")]
        public int PerPage { get; set; }

        [JsonPropertyName("has_more_page")]
        public bool HasMorePage { get; set; }

        [JsonPropertyName("report_name")]
        public string ReportName { get; set; }

        [JsonPropertyName("applied_filter")]
        public string AppliedFilter { get; set; }

        [JsonPropertyName("sort_column")]
        public string SortColumn { get; set; }

        [JsonPropertyName("sort_order")]
        public string SortOrder { get; set; }

        [JsonPropertyName("search_criteria")]
        public List<SearchCriteria> SearchCriteria { get; set; }
    }

}
