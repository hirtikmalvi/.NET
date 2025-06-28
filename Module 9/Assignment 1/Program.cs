using Assignment_1;

internal class Program
{
    static void Main(string[] args)
    {
        IMovieService service = new MovieService();

        // Step 1: List all directors
        service.ShowAllDirectors();

        // Step 2: Take director name input
        Console.Write("\nEnter a director's name: ");
        string directorName = Console.ReadLine();
        service.ShowMoviesByDirector(directorName);

        // Step 3: Show all movie names and take movie input
        Console.Write("\nEnter a movie name to see its actors: ");
        string movieName = Console.ReadLine();
        service.ShowActorsByMovie(movieName);

        // Step 4: Show movies where director is also actor
        service.ShowMoviesWithDirectorsAlsoActor();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
