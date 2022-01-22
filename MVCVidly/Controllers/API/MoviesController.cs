using AutoMapper;
using MVCVidly.App_Start;
using MVCVidly.DTOs;
using MVCVidly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCVidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _context;
        private readonly Mapper _mapper; 

        public MoviesController()
        {
            _context = new ApplicationDbContext();
            var config = new MapperConfiguration(cnfg => cnfg.AddProfile<MappingProfile>());
            _mapper = new Mapper(config);
        }
        // GET: api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.ToList().Select(_mapper.Map<Movie, MovieDto>);
        }

        // GET: api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if(movie == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Movie, MovieDto>(movie));
        }
    }
}
