using Library.Models.Catalog;
using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class LoginController : Controller
    {
        #region Protected Members

        /// <summary>
        /// The scoped Application context
        /// </summary>
        protected LibraryDbContext mContext;

        /// <summary>
        /// The manager for handling user creation, deletion, searching, roles etc...
        /// </summary>
        protected UserManager<User> mUserManager;

        /// <summary>
        /// The manager for handling signing in and out for our users
        /// </summary>
        protected SignInManager<User> mSignInManager;
        private string _externalCookieScheme;

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context">The injected context</param>
        public LoginController(
            LibraryDbContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            mContext = context;
            mUserManager = userManager;
            mSignInManager = signInManager;
        }

        #endregion

        /// <summary>
        /// Basic welcome page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            // Make sure we have the database
            mContext.Database.EnsureCreated();
            
        
           

            return View();
        }


        public IActionResult Post() {
            var model = new User();
            return View(model);
        }

        /// <summary>
        /// Creates our single user for now
        /// </summary>
        /// <returns></returns>
        [Route("create")]
        public async Task<IActionResult> CreateUserAsync()
        {
            var result = await mUserManager.CreateAsync(new User
            {
                UserName = "angelsix",
                Email = "contact@angelsix.com"
            }, "password");
            

            if (result.Succeeded)
                return Content("User was created", "text/html");

            return Content("User creation failed", "text/html");
        }

        /// <summary>
        /// Private area. No peeking
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("private")]
        public IActionResult Private()
        {
            return Content($"This is a private area. Welcome {HttpContext.User.Identity.Name}", "text/html");
        }

        /// <summary>
        /// Log the user out
        /// </summary>
        /// <returns></returns>
        [Route("logout")]
        public async Task<IActionResult> SignOutAsync()
        {
           
       
            await HttpContext.Authentication.SignOutAsync(_externalCookieScheme);
            return Content("done");
        }

        /// <summary>
        /// An auto-login page for testing
        /// </summary>
        /// <param name="returnUrl">The url to return to if successfully logged in</param>
        /// <returns></returns>
        [HttpPost("/login")]
        public async Task<IActionResult> LoginAsync(LoginCredentials returnUrl)
        {
       

            // Sign user in with the valid credentials
            var result = await mSignInManager.PasswordSignInAsync(returnUrl.Username, returnUrl.Password, true, false);
            

            // If successful...
            if (result.Succeeded)
            {
                // If we have no return URL...
                if (string.IsNullOrEmpty("/Login"))
                    // Go to home
                    return RedirectToAction(nameof(Index));

                // Otherwise, go to the return url
                return Redirect("/Login");
            }

            return Content("Failed to login", "text/html");
        }

        [HttpPost("/login/LogIn")]
        public IActionResult LogIn(User user)
        {
            if (this.ModelState.IsValid)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName) };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                var result =  mSignInManager.PasswordSignInAsync("angelsix", "password", true, false);

                // Enable ajax to send authentication cookie in subsequent requests
                this.HttpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                this.HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST, GET");
            }

            return this.Json(new { IsAuthenticated = this.User.Identity.IsAuthenticated });
        }

        [HttpGet("/login/LogOff")]
        [Authorize(ActiveAuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        public async Task<IActionResult> LogOff()
        {
            await HttpContext.Authentication.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return this.Json(new { IsAuthenticated = this.User.Identity.IsAuthenticated });
        }
    }
}
