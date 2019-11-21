  using System;
    using System.Collections.Generic;
namespace NetFlask.Entities
{
  
    
    public partial class User
    { 
        private int _idUser ;
        private string _firstName ;
        private string _lastName ;
        private  IEnumerable<Rating> _ratings ;

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

        public IEnumerable<Rating> Ratings
        {
            get
            {
                return _ratings;
            }

            set
            {
                _ratings = value;
            }
        }
    }
}
