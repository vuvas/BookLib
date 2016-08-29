using System.Web.Mvc;
using BookLib.Web.Models;
using BookLib.Web.Service;

namespace BookLib.Web.Controllers
{
    public class HomeController : Controller
    {
        public FakeService FakeService = new FakeService();

        public ActionResult Index()
        {
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
                SearchResults = FakeService.GetFakeSearchResults(),
                FilterTypes = FakeService.GetFilterTypes(),
                SearchKey = searchKey
            };

            return View(model);
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