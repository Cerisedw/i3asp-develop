using System;
using System.Collections.Generic;
namespace NetFlask.Entities
{
    public class Cast
    {      
    
        private int _idCast ;
        private string _firstName ;
        private string _lastName ;
        private   IEnumerable<Movie> _Movies ;

        public int IdCast
        {
            get
            {
                return _idCast;
            }

            set
            {
                _idCast = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
            }
        }

        public IEnumerable<Movie> Movies
        {
            get
            {
                return _Movies;
            }

            set
            {
                _Movies = value;
            }
        }
    }
}
