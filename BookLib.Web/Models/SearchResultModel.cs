using System.Collections.Generic;
using System.Web.Mvc;

namespace BookLib.Web.Models
{
    public class SearchResultModel
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Description { get; set; }
        public string Authors  { get; set; }
        
    }

    public class SearchResultViewModel
    {
        public List<SearchResultModel> SearchResults { get; set; }
        public List<SelectListItem> FilterTypes { get; set; }

        public SelectListItem SelectedFilterType { get; set; }
        public string SearchKey { get; set; }

    }
}