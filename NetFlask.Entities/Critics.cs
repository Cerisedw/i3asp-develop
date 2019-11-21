 
namespace NetFlask.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Critics
    {
        private int _idMovie ;
        private int _idCriticsAuthor ;
        private double _score ;

        private CriticsAuthor _criticsAuthor ;
        private Movie _movies ;

        public int IdMovie
        {
            get
            {
                return _idMovie;
            }

            set
            {
                _idMovie = value;
            }
        }

        public int IdCriticsAuthor
        {
            get
            {
                return _idCriticsAuthor;
            }

            set
            {
                _idCriticsAuthor = value;
            }
        }

        public double Score
        {
            get
            {
                return _score;
            }

            set
            {
                _score = value;
            }
        }

        public CriticsAuthor CriticsAuthor
        {
            get
            {
                return _criticsAuthor;
            }

            set
            {
                _criticsAuthor = value;
            }
        }

        public Movie Movies
        {
            get
            {
                return _movies;
            }

            set
            {
                _movies = value;
            }
        }
    }
}
