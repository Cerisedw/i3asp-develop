  using System;
    using System.Collections.Generic;
    
namespace NetFlask.Entities
{
   
    public  class Rating
    {
        private  int _idMovie ;
        private  int _idUser ;
        private  double _score ;
        private  DateTime _dateRating ;
    
        private    Movie _movie ;
        private    User _user ;

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

        public int IdUser
        {
            get
            {
                return _idUser;
            }

            set
            {
                _idUser = value;
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

        public DateTime DateRating
        {
            get
            {
                return _dateRating;
            }

            set
            {
                _dateRating = value;
            }
        }

        public Movie Movie
        {
            get
            {
                return _movie;
            }

            set
            {
                _movie = value;
            }
        }

        public User User
        {
            get
            {
                return _user;
            }

            set
            {
                _user = value;
            }
        }
    }
}
