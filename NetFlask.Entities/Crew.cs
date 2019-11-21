  using System;
    using System.Collections.Generic;
    
namespace NetFlask.Entities
{
   
    public class Crew
    { 
        private int _idCrew ;
        private string _firstName;
        private string _lastName;
        private string _job;

        private   IEnumerable<Movie> _movies ;

        public int IdCrew
        {
            get
            {
                return _idCrew;
            }

            set
            {
                _idCrew = value;
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
                return _movies;
            }

            set
            {
                _movies = value;
            }
        }

        public string Job
        {
            get
            {
                return _job;
            }

            set
            {
                _job = value;
            }
        }
    }
}
