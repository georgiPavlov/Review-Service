using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Content { get; set; }


        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public User  User{ get; set; }




    }
}
