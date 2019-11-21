    using System;
    using System.Collections.Generic;
    
namespace NetFlask.Entities
{
 
    public   class Movie
    {
        private int _idMovie ;
        private string _title ;
        private int _duration ;
        /// <summary>
        /// https://image.tmdb.org/t/p/w200/
        /// https://image.tmdb.org/t/p/w500/
        /// https://image.tmdb.org/t/p/original/
        /// </summary>
        private string _picture ;
        private string _trailer ;
        private DateTime? _releaseDate ;
        private string _summary ;
        private string _shortDescription ; 
    
        private   IEnumerable<Critics> _critics ;
        private   IEnumerable<Rating> _rating ;
        private    IEnumerable<Crew> _crew ;
        private IEnumerable<Cast> _cast ;
        private IEnumerable<Genre> _genre ;
        

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

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
            }
        }

        public int Duration
        {
            get
            {
                return _duration;
            }

            set
            {
                _duration = value;
            }
        }

        public string Picture
        {
            get
            {
                return _picture;
            }

            set
            {
                _picture = value;
            }
        }

        public string Trailer
        {
            get
            {
                return _trailer;
            }

            set
            {
                _trailer = value;
            }
        }

        public DateTime? ReleaseDate
        {
            get
            {
                return _releaseDate;
            }

            set
            {
                _releaseDate = value;
            }
        }

        public string Summary
        {
            get
            {
                return _summary;
            }

            set
            {
                _summary = value;
            }
        }

        public string ShortDescription
        {
            get
            {
                return _shortDescription;
            }

            set
            {
                _shortDescription = value;
            }
        }

        public IEnumerable<Critics> Critics
        {
            get
            {
                return _critics=_critics?? new List<Critics>();
            }

            set
            {
                _critics = value;
            }
        }

        public IEnumerable<Rating> Rating
        {
            get
            {
                return _rating=_rating?? new List<Rating>();
            }

            set
            {
                _rating = value;
            }
        }

        public IEnumerable<Crew> Crews
        {
            get
            {
                return _crew=_crew?? new List<Crew>();
            }

            set
            {
                _crew = value;
            }
        }

        public IEnumerable<Cast> Cast
        {
            get
            {
                return _cast=_cast??new List<Cast>();
            }

            set
            {
                _cast = value;
            }
        }

        public IEnumerable<Genre> Genre
        {
            get
            {
                return _genre = _genre ?? new List<Genre>();
            }

            set
            {
                _genre = value;
            }
        }

         
    }
}
