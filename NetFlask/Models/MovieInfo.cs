using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetFlask.Models
{
    public class MovieInfo
    {
            private int _idMovie;
            private string _title,_director, _age, _gender, _summary, _video, _picture;
            private double _rating;        
            private DateTime _release;
            public string Picture
            {
                get { return _picture; }
                set { _picture = value; }
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

            public string Age
            {
                get
                {
                    return _age;
                }

                set
                {
                    _age = value;
                }
            }
            public string Gender
            {
                get
                {
                    return _gender;
                }

                set
                {
                    _gender = value;
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
            public string Video
            {
                get
                {
                    return _video;
                }

                set
                {
                    _video = value;
                }
            }

        public string Director
        {
            get
            {
                return _director;
            }

            set
            {
                _director = value;
            }
        }
        public double Rating
            {
                get
                {
                    return _rating;
                }

                set
                {
                    _rating = value;
                }
            }
            public DateTime Release
            {
                get
                {
                    return _release;
                }

                set
                {
                    _release = value;
                }
            }

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
    }
    
}