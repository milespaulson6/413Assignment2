
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _413Assignment2.Models
{
    public class EFMovieRepository : IMovieRepository
    {
        private MovieListContext _context;

        public EFMovieRepository(MovieListContext context)
        {
            _context = context;
        }

        public IQueryable<MovieResponse> Movies => _context.Movies;
    }
}
