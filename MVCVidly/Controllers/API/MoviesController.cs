using AutoMapper;
using MVCVidly.App_Start;
using MVCVidly.DTOs;
using MVCVidly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
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
        public IHttpActionResult GetMovies()
        {
            var movieDtos = _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(_mapper.Map<Movie, MovieDto>);

            return Ok(movieDtos);
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

        // POST: api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = _mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT: api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);

            _mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE: api/movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if(movieInDb == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
