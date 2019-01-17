using LibraryData;
using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryService
{
    public class MovieService : IMovie
    {
        private LibraryDbContext _context; // private field to store the context.

        public MovieService(LibraryDbContext context)
        {
            _context = context;
        }

        IEnumerable<Movie> IMovie.GetAll()
        {
            return _context.Movies;
        }

        public IEnumerable<Movie> GetByAuthor(string author)
        {
            return _context.Movies.Where(a => a.Author.Contains(author));
        }

        public IEnumerable<Movie> GetByTitle(string title)
        {
            return _context.Movies.Where(a => a.Title.Contains(title));
        }

        public void Add(Movie newMovie)
        {
            _context.Add(newMovie);
            _context.SaveChanges();
        }

        public Movie Get(int id)
        {
            return _context.Movies.FirstOrDefault(v => v.Id == id);
        }

        public IEnumerable<Movie> GetByUser(string user)
        {
            return _context.Movies.Where(a => a.User.UserName.Contains(user));
        }
    }
}
