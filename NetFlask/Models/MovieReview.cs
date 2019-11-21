using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetFlask.Models
{
    public class MovieReview
    {
        #region Fields
        private string _title, _author, _picture, _summary;
        private List<string> _cast;
        private List<string> _director;
        private List<string> _genre;
        private DateTime _dateReview;
        private DateTime? _release;
        private int _duration;
        private Double _rating;
        private Double _critic;
        #endregion

        public MovieReview()
        {
            Cast = new List<string>();
            Director = new List<string>();
            Genre = new List<string>();
        }
        #region Properties
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

        public string Author
        {
            get
            {
                return _author;
            }

            set
            {
                _author = value;
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

        public List<string> Cast
        {
            get
            {
                return _cast;
            }

            set
            {
                _cast = value;
            }
        }

        public List<string> Director
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

        public List<string> Genre
        {
            get
            {
                return _genre;
            }

            set
            {
                _genre = value;
            }
        }

        public DateTime DateReview
        {
            get
            {
                return _dateReview;
            }

            set
            {
                _dateReview = value;
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

        public double Critic
        {
            get
            {
                return _critic;
            }

            set
            {
                _critic = value;
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

        public DateTime? Release
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
        #endregion
    }

    }