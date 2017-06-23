﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek"};
            
            return View(movie);
        }

        [Route("movies/released/{year}/{month:regex(\\{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            string yearAbbr = year.ToString().Substring(2, 2);
            return Content(month + "/" + yearAbbr);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //Movies index page
        //Question mark makes it a nullable integer
        public ActionResult Index(int? pageIndex, String sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
    }
}