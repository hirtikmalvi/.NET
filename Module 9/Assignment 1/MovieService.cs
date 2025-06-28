using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Assignment_1
{
    public class MovieService : IMovieService
    {
        private List<Movie> Movies;
        private Info Info;

        public MovieService()
        {
            Movies = JsonConvert.DeserializeObject<List<Movie>>(File.ReadAllText(@"E:\.NET\Module 9\Assignment 1\files\movie.json"));

            Info = JsonConvert.DeserializeObject<Info>(File.ReadAllText(@"E:\.NET\Module 9\Assignment 1\files\info.json"));
        }

        public void ShowAllDirectors()
        {
            Console.WriteLine(Info.Directors.Aggregate("\nAll Directors: ", (str, d) => str += $"\n\tDirectorName: {d}, "));
        }

        public void ShowActorsByMovie(string movieName)
        {
            var actors = Movies.Where(m => m.MovieName.ToLower() == movieName.ToLower()).ToList();

            if (actors.Count == 0)
            {
                Console.WriteLine($"No Actors found for this movie: {movieName}");
                return;
            }
            Console.WriteLine(actors.Aggregate($"\nActors In {movieName}: ", (str, a) => str += $"\n\tActorNames: {string.Join(", ", a.Details.ActorsNames)}"));
        }

        public void ShowMoviesByDirector(string directorName)
        {
            var movies = Movies.Where(m => m.Details.DirectorName.ToLower() == directorName.ToLower()).ToList();

            if (movies.Count == 0)
            {
                Console.WriteLine($"No movies found for this director: {directorName}");
                return;
            }
            Console.WriteLine(movies.Aggregate($"\nMovies By Director: {directorName}: ", (str, m) => str += $"Movie: {m.MovieName}, "));
        }

        public void ShowMoviesWithDirectorsAlsoActor()
        {
            var movies = Movies.Where(m => m.Details.ActorsNames.Contains(m.Details.DirectorName)).ToList();

            if (movies.Count == 0)
            {
                Console.WriteLine($"No movies found where Director is also an Actor.");
                return;
            }
            Console.WriteLine(movies.Aggregate($"\nMovies where is also an Actor: ", (str, m) => str += $"\n\tMovie: {m.MovieName}, Director: {m.Details.DirectorName}, "));
        }
    }
}
