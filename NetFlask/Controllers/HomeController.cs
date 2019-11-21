using NetFlask.DAL;
using NetFlask.Entities;
using NetFlask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetFlask.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Current = "Index";            

            return View(new HomeViewModel());
        }

        [HttpPost]
        public ActionResult SimpleSearch(string txtSearch)
        {
            ViewBag.SearchString = txtSearch;

            MovieRepository rm = new MovieRepository();
            List<Movie> liste = rm.getMoviesFromTitle(txtSearch);
            List<MovieReview> listeView = new List<MovieReview>();
            foreach (Movie movie in liste)
            {
                listeView.Add(new MovieReview()
                {
                    Picture = movie.Picture,
                    Title = movie.Title,
                    Duration = movie.Duration,
                    Summary = movie.Summary,
                    Release = movie.ReleaseDate,
                }
                );
            }

            return View("resultat",listeView);
        }



        public ActionResult Videos(int id = 1)
        {
            ViewBag.Current = "Videos";
            ViewBag.NextPageNmb = id + 1;
            MovieRepository mr = new MovieRepository();
            List<Movie> liste = mr.getTrailerPagination(id);

            List<MovieInfo> listeView = new List<MovieInfo>();
            foreach (Movie movie in liste)
            {
                listeView.Add(new MovieInfo()
                {
                    IdMovie = movie.IdMovie,
                    Picture = movie.Picture,
                    Title = movie.Title,
                    Summary = movie.Summary,
                    Release = movie.ReleaseDate.Value,
                    Video = (movie.Trailer).Replace("watch?v=", "embed/"),
                }
                );
            }


            return View(listeView);
        }

        public ViewResult Reviews()
        {
            ViewBag.Current = "Reviews";
            List<MovieReview> movrev = new List<MovieReview>();
            movrev = FakeDb.LoadData();
            //string CastString = convertToString(movrev.Cast);
            //ViewBag.CastString = CastString;
            //BERK BERK BERK BERK!!!!!!!!!!!!!! 
            return View(movrev);
        }

        private string convertToString(List<string> casts)
        {if (casts.Count() == 0) return "";
            string retour = "";
            foreach (string item in casts)
            {
                retour += item + ",";

            }
            return retour.Substring(0, retour.Length - 1);
        }
    }
}