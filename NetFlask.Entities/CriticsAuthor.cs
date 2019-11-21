   using System;
    using System.Collections.Generic;
    
namespace NetFlask.Entities
{
  
    public   class CriticsAuthor
    {
       
    
        private int _idCriticsAuthor;
        private string _name;

        private   IEnumerable<Critics> _critics;

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

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public IEnumerable<Critics> Critics
        {
            get
            {
                return _critics;
            }

            set
            {
                _critics = value;
            }
        }
    }
}
