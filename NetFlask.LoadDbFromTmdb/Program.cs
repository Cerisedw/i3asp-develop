using NetFlask.LoadDbFromTmdb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.TMDb;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using E = NetFlask.Entities;
namespace NetFlask.LoadDbFromTmdb
{
    class Program
    {
        static Dictionary<int, string> lcrew = new Dictionary<int, string>();
        static Dictionary<int, string> lcast = new Dictionary<int, string>();
        static void Main(string[] args)
        {
           // generateInsertGenre();
            generateInsertMovie();
            //generateInsertGenre();

            string FilePath = Path.Combine("SqlFiles", "Cast.sql");
            string FilePath2 = Path.Combine("SqlFiles", "Crew.sql");
            foreach (var item in lcast)
            {
                File.AppendAllLines(FilePath, new[] { item.Value });
            }

            foreach (var item in lcrew)
            {
                File.AppendAllLines(FilePath2, new[] { item.Value });
            }


            // GetAllMovies(new CancellationToken());
            Console.ReadLine();
        }

        private static void generateInsertMovie()
        {
            string FilePath = Path.Combine("SqlFiles", "Movies.sql");
            string FilePath2 = Path.Combine("SqlFiles", "MoviesGenre.sql");
            using (var client = new ServiceClient("1a85f5aeaf961ae4ee8a30df575d2baa"))
            {
                for (int i = 1, count = 39; i <= count; i++)
                {
                    try
                    {
                        var movies = client.Movies.GetPopularAsync(null, i, new CancellationToken()).Result;
                        count = movies.PageCount; // keep track of the actual page count

                        foreach (Movie m in movies.Results)
                        {
                            string video = "";
                            getTrailer(m.Id);
                            
                            //string shorttext = "";
                            //if (m.Overview.Length > 30)
                            //{
                            //    shorttext = m.Overview.Substring(0, 30)+"...".Replace("'","''");
                            //}
                            //else
                            //{
                            //    shorttext = m.Overview.Replace("'", "''");
                            //}

                            //string query = $"INSERT INTO [dbo].[Movie] VALUES ({m.Id}, '{m.Title.Replace("'", "''")}',0,'{m.Poster}','{video}', '" + m.ReleaseDate.GetValueOrDefault().ToString("yyyy-MM-dd") + "','" + m.Overview.Replace("'", "''") + "','" + shorttext.Replace("'", "''") + "')";
                            //File.AppendAllLines(FilePath, new[] { query });
                            
                            //generateInsertCast(m.Id);
                            //if(m.Genres!=null)
                            //{ 
                            //foreach(var item in m.Genres)
                            //{
                            //    string queryGenre = $"INSERT INTO [dbo].[MovieGenre] VALUES ({m.Id}, {item.Id})";
                            //    File.AppendAllLines(FilePath2, new[] { queryGenre });
                            //}
                            //}






                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }

                 
            }
        }

       

        private static void generateInsertGenre()
        {
            string FilePath = Path.Combine("SqlFiles", "Genre.sql");
            using (var client = new ServiceClient("1a85f5aeaf961ae4ee8a30df575d2baa"))
            {
                 
                List<Genre> lg = client.Genres.GetAsync(DataInfoType.Movie, new CancellationToken()).Result.ToList();
                foreach (var item in lg)
                {
                    string query = $"INSERT INTO [dbo].[Genre] VALUES ({item.Id}, '{item.Name.Replace("'","''")}')";
                    File.AppendAllLines(FilePath, new[] { query });
                }
            }
        }

        private static void getTrailer(int id)
        {
            string query = "https://api.themoviedb.org/3/movie/" + id + "?api_key=1a85f5aeaf961ae4ee8a30df575d2baa&append_to_response=videos";
            string FilePath = Path.Combine("SqlFiles", "Trailers.sql");
            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = client.GetAsync(query).Result;

                string responseBody = response.Content.ReadAsStringAsync().Result;

                Movie mm = JsonConvert.DeserializeObject<Movie>(responseBody);

                if (mm.Videos != null && mm.Videos.Results != null && mm.Videos.Results.Count() > 0)
                {
                    string video = "https://www.youtube.com/watch?v="+mm.Videos.Results.FirstOrDefault().Key;
                    string quer = "UPDATE MOVIE set Trailer='" + video + "' where IdMovie=" + id;
                    File.AppendAllLines(FilePath, new[] { quer });
                }
            }
        }
         

        private static void generateInsertCast(int id)
        {


            string query = "https://api.themoviedb.org/3/movie/" + id + "/credits?api_key=1a85f5aeaf961ae4ee8a30df575d2baa";

            string FilePath3 = Path.Combine("SqlFiles", "CastMovie.sql");
            string FilePath4 = Path.Combine("SqlFiles", "CrewMovie.sql");


            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response =   client.GetAsync(query).Result;
              
                string responseBody =  response.Content.ReadAsStringAsync().Result;
                CastMovie d = JsonConvert.DeserializeObject<CastMovie>(responseBody);
                foreach (var item in d.cast)
                {
                    try
                    {
                        string[] info = item.name.ToString().Split(' ');
                        string nom = "";
                        string prenom = "";
                        if (info.Length > 1) { nom = info[1]; prenom = info[0]; }
                        else nom = item.name;
                        if(!lcast.ContainsKey(item.cast_id))
                        {
                            string querycast = $"INSERT INTO [dbo].[Cast] VALUES ({item.cast_id},'{nom}', '{prenom}')";
                            lcast.Add(item.cast_id, querycast);

                        } 
                        string queryinsert = $"INSERT INTO [dbo].[MoviCast] VALUES ({item.cast_id},{id})";
                        File.AppendAllLines(FilePath3, new[] { queryinsert });
                    }
                    catch (Exception)
                    { 
                    }
                }

                foreach (var item in d.crew)
                {
                    try
                    {
                        string[] info = item.name.ToString().Split(' ');
                        string nom = "";
                        string prenom = "";
                        if (info.Length > 1) { nom = info[1]; prenom = info[0]; }
                        else nom = item.name;
                        if(!lcrew.ContainsKey(item.id))
                        {
                            string querycrew = $"INSERT INTO [dbo].[crew] VALUES ({item.id},'{nom}', '{prenom}', '{item.job}')";
                            lcrew.Add(item.id, querycrew);
                        }
                        
                        string queryinsert = $"INSERT INTO [dbo].[CrewMovie] VALUES ({id}, {item.id})";
                        File.AppendAllLines(FilePath4, new[] { queryinsert });
                    }
                    catch (Exception)
                    {
                         
                    }
                }


            }
        }

        private static void generateInsertDirector(int id)
        {
            string FilePath = Path.Combine("SqlFiles", "Director.sql");
            using (var client = new ServiceClient("1a85f5aeaf961ae4ee8a30df575d2baa"))
            {

                Person item = client.People.GetAsync(id, true, new CancellationToken()).Result;

                string query = $"INSERT INTO [dbo].[Director] VALUES ({item.Id},'', '{item.Name}')";
                File.AppendAllLines(FilePath, new[] { query });

            }
        }

        #region Commented
        //static async Task Sample(CancellationToken cancellationToken)
        //{
        //    using (var client = new ServiceClient("1a85f5aeaf961ae4ee8a30df575d2baa"))
        //    {
        //        for (int i = 1, count = 1000; i <= count; i++)
        //        {
        //            var movies = await client.Movies.GetTopRatedAsync(null, i, cancellationToken);
        //            count = movies.PageCount; // keep track of the actual page count

        //            foreach (Movie m in movies.Results)
        //            {
        //                var movie = await client.Movies.GetAsync(m.Id, null, true, cancellationToken);




        //                var personIds = movie.Credits.Cast.Select(s => s.Id)
        //                    .Union(movie.Credits.Crew.Select(s => s.Id));

        //                foreach (var id in personIds)
        //                {
        //                    var person = await client.People.GetAsync(id, true, cancellationToken);

        //                    //foreach (var img in person.Images.Results)
        //                    //{
        //                    //    //string filepath = Path.Combine("People", img.FilePath.TrimStart('/'));
        //                    //    //await DownloadImage(img.FilePath, filepath, cancellationToken);
        //                    //}



        //                }
        //                //saveMovie(movie);
        //            }
        //        }
        //    }
        //}


        //static void GetAllMovies(CancellationToken cancellationToken)
        //{
        //    using (var client = new ServiceClient("1a85f5aeaf961ae4ee8a30df575d2baa"))
        //    {
        //        for (int i = 1, count = 40; i < count; i++)
        //        {
        //            var movies = client.Movies.GetNowPlayingAsync(null, i, cancellationToken).Result;
        //            // count = movies.PageCount;
        //            foreach (Movie m in movies.Results)
        //            {
        //                E.Movie Dbm = new E.Movie();
        //                Dbm.IdMovie = m.Id;
        //                Dbm.Title = m.Title;
        //                Dbm.Age = m.Adult ? "Adult" : "All Age";
        //                Dbm.Duration = 0;
        //                Dbm.ReleaseDate = m.ReleaseDate;
        //                if (m.Images != null && m.Images.Posters != null && m.Images.Posters.Count() > 0)
        //                {
        //                    Dbm.Picture = m.Images.Posters.FirstOrDefault().FilePath;
        //                }
        //                else
        //                {
        //                    Dbm.Picture = "NoPicture.jpg";
        //                }
        //                Dbm.Genre = GetGenre(m);
        //                Dbm.Cast = GetCast(m, client);
        //                Dbm.Rating = GetRating(m, client);
        //                lm.Add(Dbm);
        //            }


        //        }
        //    }
        //}

        //private static IEnumerable<E.Rating> GetRating(Movie m, ServiceClient client)
        //{
        //    client.Genres.GetAsync();
        //}

        //private static IEnumerable<E.Genre> GetGenre(Movie m)
        //{
        //    if (m.Genres == null) return new List<E.Genre>();
        //    return m.Genres.Select(g => new E.Genre() { IdGenre = g.Id, Label = g.Name });
        //}

        //private static IEnumerable<E.Cast> GetCast(Movie movie, ServiceClient client)
        //{
        //    if (movie.Credits == null) return new List<E.Cast>();
        //    List<E.Cast> lc = new List<E.Cast>();
        //    var personIds = movie.Credits.Cast.Select(s => s.Id)
        //                   .Union(movie.Credits.Crew.Select(s => s.Id));

        //    foreach (var id in personIds)
        //    {
        //        var person = client.People.GetAsync(id, true, new CancellationToken()).Result;
        //        lc.Add(new E.Cast() { IdCast = person.Id, FirstName = "", LastName = person.Name });
        //        foreach (var img in person.Images.Results)
        //        {
        //            string filepath = Path.Combine("People", img.FilePath.TrimStart('/'));

        //            DownloadImage(img.FilePath, filepath, new CancellationToken()).Wait();
        //        }



        //    }
        //    return lc;
        //}

        #endregion
        static async Task DownloadImage(string filename, string localpath, CancellationToken cancellationToken)
        {
            if (!File.Exists(localpath))
            {
                string folder = Path.GetDirectoryName(localpath);
                Directory.CreateDirectory(folder);

                var storage = new StorageClient();
                using (var fileStream = new FileStream(localpath, FileMode.Create,
                    FileAccess.Write, FileShare.None, short.MaxValue, true))
                {
                    try { await storage.DownloadAsync(filename, fileStream, cancellationToken); }
                    catch (Exception ex) { System.Diagnostics.Trace.TraceError(ex.ToString()); }
                }
            }
        }
    }
}
