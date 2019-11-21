using NetFlask.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetFlask.Models
{
    public class HomeViewModel
    {
        private List<string> _ListeUne, _ListDeux;
        
        private MovieInfo _HighLighMovie;



        public HomeViewModel()
        {
            ListeUne = new List<string>();
            ListDeux = new List<string>();
            // for (int i = 1; i < 7; i++)
            //{
            //   // ListeUne.Add("r" + i + ".jpg");

            //     //1- connexion db
            //     //2- Récupération des 6 premiers films
            //     //3- Ajout de l'image dans la liste ==>ListeUne

            //}

            MovieRepository mr = new MovieRepository();
            ListeUne = mr.getFirstSix();
            ListDeux = mr.getRandom();
            //for (int i = 1; i < 5; i++)
            //{
            //    ListDeux.Add("m" + i + ".jpg");
            //}

            MovieInfo M = new MovieInfo();
            M.Title = "Frozen II";
            M.Picture = "Frozen2.jpg";
            M.Gender = "Animation, Aventure, Comédie";
            M.Rating = 4;
            M.Age = "All Age";
            M.Director = " Chris Buck, Jennifer Lee";
            M.Release = new DateTime(2019, 10, 22);
            M.Summary = "Anna, Elsa, Kristoff, Olaf et Sven quittent Arendelle pour se rendre dans une ancienne forêt enchantée bordée par l'automne. Ils se sont mis en quête de l'origine des pouvoirs d'Elsa afin de sauver leur royaume.";
            M.Video = "https://www.youtube.com/embed/XEWZw_5yIrs";
            this.HighLighMovie = M;

        }

        public List<string> ListeUne
        {
            get
            {
                return _ListeUne;
            }

            set
            {
                _ListeUne = value;
            }
        }

        public List<string> ListDeux
        {
            get
            {
                return _ListDeux;
            }

            set
            {
                _ListDeux = value;
            }
        }

         

        public MovieInfo HighLighMovie
        {
            get
            {
                return _HighLighMovie;
            }

            set
            {
                _HighLighMovie = value;
            }
        }
    }
}