using System.Web.Mvc;
using BookLib.Web.Models;
using BookLib.Web.Service;

namespace BookLib.Web.Controllers
{
    public class HomeController : Controller
    {
        public FakeService FakeService = new FakeService();
        static readonly IApiService ApiService = new ApiService();

        public ActionResult Index()
        {
         
            //ApiService.PlaceDemand("57c3f858eeb574254ab8080d", "57c3f858eeb574254ab8080c");
            var model = FakeService.GetSearchParameters();
            return View(model);
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel registerModel)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchResult(string selectedFilterType, string searchKey)
        {

            var model = new SearchResultViewModel
            {
                SearchResults = ApiService.SeachBooks(searchKey,selectedFilterType),
                FilterTypes = FakeService.GetFilterTypes(),
                SearchKey = searchKey
            };

            //return View(model);
            return PartialView("SearchResult", model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginModel,string returnUrl)
        {
            return View();
        }

        public ActionResult PlaceDemand(string book)
        {
            ViewBag.Book = book;
            return View();
        }

    }
}