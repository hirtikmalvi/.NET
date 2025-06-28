using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public MovieDetails Details { get; set; }

    }
    public class MovieDetails
    {
        public string DirectorName {  get; set; }
        public List<string> ActorsNames {  get; set; }
        public string VideoLink {  get; set; }
    }

    public class Info
    {
        public List<string> Directors {  get; set; }
        public List<Movie> Movies { get; set; }
        public List<string> Actors { get; set; }
    }
    public class InfoMovies
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
    }

    public interface IMovieService
    {
        public void ShowAllDirectors();
        public void ShowMoviesByDirector(string directorName);
        public void ShowActorsByMovie(string movieName);
        public void ShowMoviesWithDirectorsAlsoActor();
    }
}
