using System.Web.Mvc;
using System.Web.Security;
using BookLib.Web.Models;
using BookLib.Web.Service;

namespace BookLib.Web.Controllers
{
    public class AccountController : Controller
    {
       
        static readonly IApiService ApiService = new ApiService();

        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerModel);
            }
            ApiService.SaveUser(registerModel.Username, registerModel.Password);
            return RedirectToAction("Index","Home");

        }
       
       
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginModel, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(loginModel);
            }
            var result = ApiService.AuthenticateUser(loginModel.Username, loginModel.Password);

            if (result.Success)
            {
                FormsAuthentication.SetAuthCookie(loginModel.Username, true);
                Session["Username"] = loginModel.Username;
            }
            else
            {
                ModelState.AddModelError("", "Login data is incorrect!");
            }


            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}