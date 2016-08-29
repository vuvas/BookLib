using System.Collections.Generic;
using System.Web.Mvc;

namespace BookLib.Web.Models
{
    public class SearchResultViewModel
    {
        public IEnumerable<Book> SearchResults { get; set; }
        public List<SelectListItem> FilterTypes { get; set; }

        public SelectListItem SelectedFilterType { get; set; }
        public string SearchKey { get; set; }
        public string Username { get; set; }
        public string UserID { get; set; }

    }
}