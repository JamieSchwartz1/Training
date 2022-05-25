using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            //to show list of movie and all customers
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //returns view of movie and customers
            return View(viewModel);
        }
        [Route("Movies/Released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" + id);
        //}
        //movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue) pageIndex = 1;
        //    if (string.IsNullOrWhiteSpace(sortBy)) sortBy = "name";
        //    return Content(string.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}
        ////[Route("movies/released/{year:regex(\\d{4})}/{month:range(1, 12)}")]        year not strictly 4 digits
        //[Route("movies/released/{year:regex(^\\d{4}$)}/{month:range(1, 12)}")]      //year is strictly 4 digits

    }
}