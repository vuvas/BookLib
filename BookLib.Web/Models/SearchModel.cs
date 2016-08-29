using System.Collections.Generic;
using System.Web.Mvc;

namespace BookLib.Web.Models
{
    public class SearchModel
    {
        public List<SelectListItem> FilterType { get; set; }
        public SelectListItem SelectedFilterType { get; set; }
        public string SearchKey { get; set; }
        public List<SearchResultModel> TopDemandBooks { get; set; }
    }
}