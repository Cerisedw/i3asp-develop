using NetFlask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetFlask.DAL
{
    public static class FakeDb
    {
        public static List<MovieReview> LoadData()
        {
            List<MovieReview> Lr = new List<MovieReview>();

            Lr.Add(new MovieReview()
            {
                Author = "Moi",
                Cast = new List<string>() { "Moi", "Lui", "Elle", "Nous" },
                Critic = 8,
                DateReview = DateTime.Now,
                Director = new List<string>() { "Nicole" },
                Duration = 165,
                Genre = new List<string>() { "Comédie", "Horreur", "Sci-fy" },
                Picture = "",
                Rating = 6,
                Title = "Un jour d'Asp avant les vacances"
            });

            Lr.Add(new MovieReview()
            {
                Author = "Moi",
                Cast = new List<string>() { "Moi", "Lui", "Elle", "Nous" },
                Critic = 8,
                DateReview = DateTime.Now,
                Director = new List<string>() { "Nicole" },
                Duration = 165,
                Genre = new List<string>() {  "Horreur", "Sci-fy" },
                Picture = "",
                Rating = 6,
                Title = "Un jour d'Asp après les vacances"
            });

            return Lr;
        }
    }
}