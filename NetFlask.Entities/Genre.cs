   using System;
    using System.Collections.Generic;
namespace NetFlask.Entities
{
  
    
    public   class Genre
    {
        
        private int _idGenre ;
        private string _label ;

        private   IEnumerable<Movie> _movies ;

        public int IdGenre
        {
            get
            {
                return _idGenre;
            }

            set
            {
                _idGenre = value;
            }
        }

        public string Label
        {
            get
            {
                return _label;
            }

            set
            {
                _label = value;
            }
        }

        public IEnumerable<Movie> Movies
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
