using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _413Assignment2.Models
{
    public interface IMovieRepository
    {
        IQueryable<MovieResponse> Movies { get; }
    }
}
