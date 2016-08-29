using System.Collections.Generic;

namespace BookLib.Web.Models
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public string Publisher { get; set; }

        public string Description { get; set; }

        public List<string> Authors { get; set; }
    }
}
