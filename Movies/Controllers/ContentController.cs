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
    public class ContentController : Controller
    {

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



            public  ContentController(
           LibraryDbContext context,
           UserManager<User> userManager,
           SignInManager<User> signInManager)
            {
                mContext = context;
                mUserManager = userManager;
                mSignInManager = signInManager;
            }


            /// <summary>
            /// Basic welcome page
            /// </summary>
            /// <returns></returns>
            public IActionResult Index()
            {
                // Make sure we have the database
              



                return View();
            }


            public IActionResult Post()
            {
                var model = new User();
                return View(model);
            }

 

        }
    }
