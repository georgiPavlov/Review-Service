using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface IMovie
    {
        IEnumerable<Movie> GetAll();
        IEnumerable<Movie> GetByAuthor(string author);
        IEnumerable<Movie> GetByUser(string user);
        IEnumerable<Movie> GetByTitle(string user);
        Movie Get(int id);
        void Add(Movie newMovie);
    }
}
