using Library.Models.Catalog;
using Library.Models.CheckoutModels;
using LibraryData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class MovieController : Controller
    {
        private IMovie _movies;
      

        // create a constructor
        public MovieController(IMovie movies)
        {
            // save assets param off into a private field 
            // to have access in the rest of the controller
            _movies = movies;
          
        }

        public IActionResult Index()
        {
            var models = _movies.GetAll();
           

            var listingResult = models
                .Select(a => new CatalogIndex
                {
                    Id = a.Id,
                    ImageUrl = a.ImageUrl,
                    Author = _movies.Get(a.Id).Author,
                    Title = _movies.Get(a.Id).Title,
                }).ToList();

            var model = new  Catalog()
            {
                Movies = listingResult
            };

            return View(model);
        }



        public IActionResult Detail(int id)
        {
            var movie = _movies.Get(id);


            CatalogDetail model = new CatalogDetail();
;            
          
           
            model.Author = movie.Author;
            model.Title = movie.Title;
            model.Date = movie.Date;
            model.Content = movie.Content;
            model.ImageUrl = movie.ImageUrl;




            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
