using NetFlask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Database;
namespace NetFlask.DAL
{
    public class MovieRepository
    {
        static Random rnd = new Random();
        private Connection _oconn;
        private string _cnstr = @"Data Source=WAD-12\ADMINSQL;Initial Catalog=NetFlask;User ID=aspuser;Password=test1234=;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public MovieRepository()
        {
            _oconn = new Connection(_cnstr);
        }

        public List<string> getFirstSix()
        {
            IEnumerable<string> images = new List<string>();
            Command cmd = new Command("SELECT TOP 6 Picture FROM MOVIE");
            images =_oconn.ExecuteReader<string>(cmd, d=>d["Picture"].ToString());

            return images.ToList();
        }

        public List<string> getFromTitle(string search)
        {
            IEnumerable<string> images = new List<string>();
            Command cmd = new Command($"SELECT * FROM MOVIE where title like '%{search}%'");
            images = _oconn.ExecuteReader<string>(cmd, d => d["Picture"].ToString());

            return images.ToList();
        }

        public List<Movie> getMoviesFromTitle(string search)
        {
            IEnumerable<Movie> movies = new List<Movie>();
            Command cmd = new Command($"SELECT * FROM Movie WHERE Title LIKE '%{search}%'");
            movies = _oconn.ExecuteReader(cmd,
                d => new Movie()
                {
                    IdMovie = (int)d["IdMovie"],
                    Picture = d["Picture"].ToString(),
                    Title = d["Title"].ToString(),
                    Duration = (int)d["Duration"],
                    Summary = d["Summary"].ToString(),
                    ReleaseDate = (DateTime)d["ReleaseDate"],
                    // TODO : Mapping des autres colonnes
                }
                );
            return movies.ToList();
        }

        public List<string> getRandom()
        {
            int skip = rnd.Next(0, 990);

            IEnumerable<string> images = new List<string>();
            Command cmd = new Command($"SELECT   Picture FROM MOVIE order by IdMovie  OFFSET ({skip}) ROWS FETCH NEXT (6) ROWS ONLY");
            images = _oconn.ExecuteReader<string>(cmd, d => d["Picture"].ToString());

            return images.ToList();
        }

        public List<Movie> getTrailer()
        {
            IEnumerable<Movie> movies = new List<Movie>();
            Command cmd = new Command($"SELECT TOP 50 * FROM Movie");
            movies = _oconn.ExecuteReader(cmd,
                d=> new Movie()
                {
                    IdMovie = (int)d["IdMovie"],
                    Picture = d["Picture"].ToString(),
                    Title = d["Title"].ToString(),
                    Duration = (int)d["Duration"],
                    Summary = d["Summary"].ToString(),
                    ReleaseDate = (DateTime)d["ReleaseDate"],
                    Trailer = d["Trailer"].ToString()
                });
            return movies.ToList();
        }

        public List<Movie> getTrailerPagination(int ipage)
        {
            IEnumerable<Movie> movies = new List<Movie>();
            Command cmd = new Command($"SELECT * FROM Movie ORDER BY IdMovie  OFFSET {50 * (ipage - 1)} ROWS FETCH NEXT (50) ROWS ONLY");
            movies = _oconn.ExecuteReader(cmd,
                d => new Movie()
                {
                    IdMovie = (int)d["IdMovie"],
                    Picture = d["Picture"].ToString(),
                    Title = d["Title"].ToString(),
                    Duration = (int)d["Duration"],
                    Summary = d["Summary"].ToString(),
                    ReleaseDate = (DateTime)d["ReleaseDate"],
                    Trailer = d["Trailer"].ToString()
                }
                );
            return movies.ToList();
        }

    }
}
