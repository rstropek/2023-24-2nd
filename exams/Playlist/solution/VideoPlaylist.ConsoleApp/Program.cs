using VideoPlaylist.Logic;

var titleQueue = new TitleQueue();
bool exit = false;

while (!exit)
{
    Console.WriteLine("\nChoose an option:");
    Console.WriteLine("1. Append a movie to the queue");
    Console.WriteLine("2. Insert a movie after the first movie");
    Console.WriteLine("3. Insert a movie before a specific movie");
    Console.WriteLine("4. Move to the next movie");
    Console.WriteLine("5. Show currently playing movie");
    Console.WriteLine("6. View all movies in the queue");
    Console.WriteLine("7. Exit");
    Console.Write("Enter your choice: ");

    string choice = Console.ReadLine() ?? string.Empty;

    switch (choice)
    {
        case "1":
            AppendMovie(titleQueue);
            ViewAllMovies(titleQueue);
            break;
        case "2":
            InsertAfterFirst(titleQueue);
            ViewAllMovies(titleQueue);
            break;
        case "3":
            InsertBefore(titleQueue);
            break;
        case "4":
            titleQueue.Next();
            ViewAllMovies(titleQueue);
            break;
        case "5":
            Console.WriteLine($"Currently playing: {titleQueue.CurrentlyPlaying}");
            break;
        case "6":
            ViewAllMovies(titleQueue);
            break;
        case "7":
            exit = true;
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }
}

void AppendMovie(TitleQueue queue)
{
    Console.Write("Enter the movie name to append: ");
    string movieName = Console.ReadLine() ?? string.Empty;
    queue.Append(movieName);
    Console.WriteLine($"Movie '{movieName}' appended to the queue.");
}

void InsertAfterFirst(TitleQueue queue)
{
    Console.Write("Enter the movie name to insert after the first movie: ");
    string movieName = Console.ReadLine() ?? string.Empty;
    queue.InsertAfterFirst(movieName);
    Console.WriteLine($"Movie '{movieName}' inserted after the first movie.");
}

void InsertBefore(TitleQueue queue)
{
    Console.Write("Enter the new movie name: ");
    string newMovieName = Console.ReadLine() ?? string.Empty;
    Console.Write("Enter the existing movie name to insert before: ");
    string existingMovieName = Console.ReadLine() ?? string.Empty;

    if (queue.TryInsertBefore(newMovieName, existingMovieName))
    {
        Console.WriteLine($"Movie '{newMovieName}' inserted before '{existingMovieName}'.");
    }
    else
    {
        Console.WriteLine($"Could not find movie '{existingMovieName}' to insert before.");
    }
}

void ViewAllMovies(TitleQueue queue)
{
    var current = queue.First;
    if (current == null)
    {
        Console.WriteLine("No movies in the queue.");
        return;
    }

    Console.WriteLine("Movies in the queue:");
    while (current != null)
    {
        Console.WriteLine($" - {current.MovieName}");
        current = current.Next;
    }
}

