using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ECommerceAppDemo.API.Models;

namespace ECommerceAppDemo.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;

        public AccountController()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44368/api/")
            };
        }

        // GET: Account/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(User model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var response = await _httpClient.PostAsJsonAsync("users/login", model);
            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadAsAsync<User>();

                // Store user information in session
                Session["UserId"] = user.UserId;
                Session["UserName"] = user.UName;


                System.Diagnostics.Debug.WriteLine($"UserName set to: {Session["UserName"]}");

                // Set authentication cookie
                FormsAuthentication.SetAuthCookie(user.Email, false);

                // Redirect to the original URL or to the Products index page
                if (Url.IsLocalUrl(returnUrl) && !string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Products");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }

        // POST: Account/Logout
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            // Clear the session
            Session.Clear();
            Session.Abandon();

            // Sign out the user
            FormsAuthentication.SignOut();

            // Redirect to the Login page
            return RedirectToAction("Login", "Account");
        }


        // GET: Account/Register
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(User model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var response = await _httpClient.PostAsJsonAsync("users/register", model);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }

            ModelState.AddModelError("", "Registration failed. Please try again.");
            return View(model);
        }

    }


}
