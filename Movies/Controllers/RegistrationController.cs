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
    public class RegistrationController :Controller
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
        public RegistrationController(
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


        public IActionResult Post()
        {
            var model = new User();
            return View(model);
        }

        /// <summary>
        /// Creates our single user for now
        /// </summary>
        /// <returns></returns>
        [HttpPost("/registration")]
        public async Task<IActionResult> CreateUserAsync(Registration registration)
        {
            var result = await mUserManager.CreateAsync(new User
            {
                UserName = registration.Username,
                Email = registration.Email
           
            }, registration.Password);


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
      

    
    }
}
