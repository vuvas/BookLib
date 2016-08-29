using System.Collections.Generic;
using System.Web.Mvc;
using BookLib.Web.Models;

namespace BookLib.Web.Service
{
    public class FakeService
    {
        public SearchModel GetSearchParameters()
        {
            return new SearchModel
            {
                FilterType = GetFilterTypes(),
                SearchKey = "",
                TopDemandBooks = GetFakeTopDemandedBooks(),
                SearchResults = new List<SearchResultModel>()
            };
            
        }


        public List<SearchResultModel> GetFakeTopDemandedBooks()
        {
            return new List<SearchResultModel>
            {
                new SearchResultModel()
                {
                    Title = "Book Title One",
                    Publisher = "Mega Mesihaft Medebir",
                    Description = "bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla",
                    Authors = "author 1 , author 2"
                },
                new SearchResultModel()
                {
                    Title = "Book Title Two",
                    Publisher = "Mega Mesihaft Medebir",
                    Description = "bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla",
                    Authors = "author 1 , author 2"
                },
                new SearchResultModel()
                {
                    Title = "Book Title Three",
                    Publisher = "Mega Mesihaft Medebir",
                    Description = "bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla",
                    Authors = "author 1 , author 2"
                },
                new SearchResultModel()
                {
                    Title = "Book Title Four",
                    Publisher = "Mega Mesihaft Medebir",
                    Description = "bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla",
                    Authors = "author 1 , author 2"
                }
            };
        }

        public List<SelectListItem> GetFilterTypes()
        {
            var listItems = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "All",
                    Value = "All",
                    Selected = true
                },
                new SelectListItem
                {
                    Text = "Title",
                    Value = "Title"
                },
                new SelectListItem
                {
                    Text = "Author",
                    Value = "Author"
                },
                new SelectListItem
                {
                    Text = "Publisher",
                    Value = "Publisher"
                },
                new SelectListItem
                {
                    Text = "Description",
                    Value = "Description"
                }
            };

            return listItems;
        }

        public List<SearchResultModel> GetFakeSearchResults()
        {
            var results = new List<SearchResultModel>
            {
               new SearchResultModel()
                {
                    Title = "Book Title One",
                    Publisher = "Mega Mesihaft Medebir",
                    Description = "bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla",
                    Authors = "author 1 , author 2"
                },
                new SearchResultModel()
                {
                    Title = "Book Title Two",
                    Publisher = "Mega Mesihaft Medebir",
                    Description = "bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla",
                    Authors = "author 1 , author 2"
                },
                new SearchResultModel()
                {
                    Title = "Book Title Three",
                    Publisher = "Mega Mesihaft Medebir",
                    Description = "bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla",
                    Authors = "author 1 , author 2"
                },
                new SearchResultModel()
                {
                    Title = "Book Title Four",
                    Publisher = "Mega Mesihaft Medebir",
                    Description = "bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla",
                    Authors = "author 1 , author 2"
                }
            };
            return results;
        }
        
    }
}