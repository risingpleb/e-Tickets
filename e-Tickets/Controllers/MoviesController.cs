﻿using e_Tickets.Data;
using e_Tickets.Data.Services;
using e_Tickets.Data.Static;
using e_Tickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_Tickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(x => x.Cinema);
            return View(allMovies);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(x => x.Cinema);
            if(!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || 
                string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allMovies);
        }

        //Get:Movies/Details/{id}
        [AllowAnonymous]
        public async Task<ActionResult> Details(int id)
        {
            var movieDetail = await _service.GetMovieByIdAsync(id);
            return View(movieDetail);
        }

        //GET:Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdown = await _service.GetNewMovieDropDownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdown.Cinemas, "Id", "Name");
            ViewBag.Producers= new SelectList(movieDropdown.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdown.Actors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if(!ModelState.IsValid)
            {
                var movieDropdown = await _service.GetNewMovieDropDownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdown.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdown.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdown.Actors, "Id", "FullName");
                return View(movie);
            }

            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        //GET:Movies/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);

            if (movieDetails == null)
            {
                return View("NotFound");
            }

            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageUrl = movieDetails.ImageUrl,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList()
            };

            var movieDropdown = await _service.GetNewMovieDropDownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdown.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdown.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdown.Actors, "Id", "FullName");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if(id != movie.Id )
            {
                return View("NotFound");
            }

            if (!ModelState.IsValid)
            {
                var movieDropdown = await _service.GetNewMovieDropDownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdown.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdown.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdown.Actors, "Id", "FullName");
                return View(movie);
            }

            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
