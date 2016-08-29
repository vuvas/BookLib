using System.Collections.Generic;
using System.Web.Mvc;
using BookLib.Web.Models;
using BookLib.Web.Service;

namespace BookLib.Web.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IApiService ApiService = new ApiService();
       
        
        public ActionResult Index()
        {
            var model = new SearchResultViewModel
            {
                SearchResults = new List<Book>(),
                SearchKey = "",
                FilterTypes = ApiService.GetFilterTypes()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(string selectedFilterType, string searchKey)
        {
            var usr = Session["Username"]??"";
            var model = new SearchResultViewModel
            {
                SearchResults = ApiService.SeachBooks(searchKey, selectedFilterType),
                FilterTypes = ApiService.GetFilterTypes(),
                SearchKey = searchKey,
                Username = usr.ToString()

            };

            return View(model);
        }
       

        public ActionResult PlaceDemand(string bookID)
        {
            var user = ApiService.GetUserByUsername(Session["Username"].ToString());
            if (user != null && bookID != null)
            {
                ApiService.PlaceDemand(user.Id, bookID);
            }

            ViewBag.Book = bookID;
            return View();
        }

    }
}