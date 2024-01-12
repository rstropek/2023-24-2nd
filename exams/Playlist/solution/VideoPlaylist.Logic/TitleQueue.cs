namespace VideoPlaylist.Logic;

/// <summary>
/// Represents a static library of available movies.
/// </summary>
public static class MovieLibrary
{
    /// <summary>
    /// Gets an array of strings representing the filenames of the available movies.
    /// </summary>
    /// <remarks>
    /// Note that these files are available for testing in the
    /// ../VideoPlaylist.Web/wwwroot/videos folder.
    /// </remarks>
    public static string[] AvailableMovies { get; } = new[] {
        "apres-ski.mp4",
        "deep-snow.mp4",
        "dronie.mp4",
        "on-the-lift.mp4",
        "on-the-piste.mp4",
        "panorama.mp4",
        "snowboard.mp4",
        "swing.mp4",
        "flyover.mp4",
        "ski-tour.mp4",
    };
}

/// <summary>
/// Represents a node in a title queue.
/// </summary>
public class TitleQueueNode
{
    /// <summary>
    /// Gets the name of the movie in this node.
    /// </summary>
    public string MovieName { get; }

    /// <summary>
    /// Gets or sets the next node in the title queue.
    /// </summary>
    public TitleQueueNode? Next { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TitleQueueNode"/> class.
    /// </summary>
    /// <param name="movieName">The name of the movie for this node.</param>
    public TitleQueueNode(string movieName)
    {
        MovieName = movieName;
    }
}

/// <summary>
/// Represents a queue of movie titles, implemented as a linked list.
/// </summary>
public class TitleQueue
{
    /// <summary>
    /// Gets the first node in the title queue.
    /// </summary>
    public TitleQueueNode? First { get; private set; }

    /// <summary>
    /// Gets the last node in the title queue.
    /// </summary>
    public TitleQueueNode? Last { get; private set; }

    /// <summary>
    /// Appends a new movie title to the end of the queue.
    /// </summary>
    /// <param name="movieName">The movie name to append.</param>
    public void Append(string movieName)
    {
        var node = new TitleQueueNode(movieName);

        if (First is null) { First = Last = node; }
        else
        {
            Last!.Next = node;
            Last = node;
        }
    }

    /// <summary>
    /// Inserts a new movie title immediately after the first node in the queue.
    /// </summary>
    /// <param name="movieName">The movie name to insert.</param>
    /// <remarks>
    /// If the queue is empty, this method will append the movie name to the end of the queue.
    /// This method makes sense in a playlist. There, the first movie is currently playing.
    /// By inserting a new movie after the first, the new movie will play next.
    /// </remarks>
    public void InsertAfterFirst(string movieName)
    {
        var node = new TitleQueueNode(movieName);

        if (First is null) { First = Last = node; }
        else
        {
            node.Next = First.Next;
            First.Next = node;
            if (node.Next == null) { Last = node; }
        }
    }

    /// <summary>
    /// Attempts to insert a new movie title before a specified existing title in the queue.
    /// </summary>
    /// <param name="newMovieName">The new movie name to insert.</param>
    /// <param name="existingMovieName">The existing movie name to insert before.</param>
    /// <returns>True if the insertion is successful; otherwise, false.</returns>
    /// <remarks>
    /// If the specified existing movie name is not found in the queue, this 
    /// method returns false.
    /// </remarks>
    public bool TryInsertBefore(string newMovieName, string existingMovieName)
    {
        if (!Contains(existingMovieName)) { return false; }

        if (First!.MovieName == existingMovieName)
        {
            var node = new TitleQueueNode(newMovieName) { Next = First };
            First = node;
            return true;
        }

        var current = First;
        while (current!.Next is not null)
        {
            if (current.Next.MovieName == existingMovieName)
            {
                var node = new TitleQueueNode(newMovieName) { Next = current.Next };
                current.Next = node;
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    /// <summary>
    /// Determines whether the queue contains a specific movie title.
    /// </summary>
    /// <param name="movieName">The movie name to locate in the queue.</param>
    /// <returns>True if the queue contains the specified title; otherwise, false.</returns>
    public bool Contains(string movieName)
    {
        if (First is null) { return false; }

        var current = First;
        while (current is not null)
        {
            if (current.MovieName == movieName) { return true; }
            current = current.Next;
        }

        return false;
    }

    /// <summary>
    /// Moves the first node to the end of the queue, effectively rotating the queue.
    /// </summary>
    /// <remarks>
    /// In a move player, this method would be called when the current movie ends or
    /// when the user clicks a "next" button. If the queue is empty or only contains 
    /// a single movie, this method does nothing.
    /// </remarks>
    public void Next()
    {
        if (First is null || First.Next is null) { return; }

        var first = First;
        First = First.Next;
        Last!.Next = first;
        Last = first;
        Last.Next = null;
    }

    /// <summary>
    /// Gets the movie name of the currently playing title 
    /// (the first node in the queue), or null if the queue is empty.
    /// </summary>
    public string? CurrentlyPlaying => First?.MovieName;
}
