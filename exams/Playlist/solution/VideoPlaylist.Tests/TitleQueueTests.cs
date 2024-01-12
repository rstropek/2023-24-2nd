namespace VideoPlaylist.Tests;

public class TitleQueueTests
{
    [Fact]
    public void Append_EmptyQueue_SetsFirstAndLast()
    {
        var queue = new TitleQueue();
        queue.Append("movie1.mp4");

        Assert.NotNull(queue.First);
        Assert.Equal("movie1.mp4", queue.First.MovieName);
        Assert.Same(queue.First, queue.Last);
    }

    [Fact]
    public void Append_NonEmptyQueue_AddsToEnd()
    {
        var queue = new TitleQueue();
        queue.Append("movie1.mp4");
        queue.Append("movie2.mp4");

        Assert.NotNull(queue.First);
        Assert.NotNull(queue.First.Next);
        Assert.NotNull(queue.Last);
        Assert.Equal("movie1.mp4", queue.First.MovieName);
        Assert.Equal("movie2.mp4", queue.Last.MovieName);
        Assert.Equal("movie2.mp4", queue.First.Next.MovieName);
    }

    [Fact]
    public void InsertAfterFirst_EmptyQueue_SetsFirstAndLast()
    {
        var queue = new TitleQueue();
        queue.InsertAfterFirst("movie1.mp4");

        Assert.NotNull(queue.First);
        Assert.Equal("movie1.mp4", queue.First.MovieName);
        Assert.Same(queue.First, queue.Last);
    }

    [Fact]
    public void InsertAfterFirst_NonEmptyQueue_AddsAfterFirst()
    {
        var queue = new TitleQueue();
        queue.InsertAfterFirst("movie1.mp4");
        queue.InsertAfterFirst("movie3.mp4");
        queue.InsertAfterFirst("movie2.mp4");

        Assert.NotNull(queue.First);
        Assert.NotNull(queue.First.Next);
        Assert.NotNull(queue.First.Next.Next);
        Assert.Equal("movie1.mp4", queue.First.MovieName);
        Assert.Equal("movie2.mp4", queue.First.Next.MovieName);
        Assert.Equal("movie3.mp4", queue.First.Next.Next.MovieName);
    }

    [Fact]
    public void InsertAfterFirst_UpdatesLast()
    {
        var queue = new TitleQueue();
        queue.InsertAfterFirst("movie1.mp4");

        Assert.NotNull(queue.First);
        Assert.Equal(queue.First, queue.Last);

        queue.InsertAfterFirst("movie2.mp4");
        Assert.NotNull(queue.First);
        Assert.NotNull(queue.Last);
        Assert.Equal(queue.First.Next, queue.Last);

        queue.InsertAfterFirst("movie3.mp4");
        Assert.NotNull(queue.First.Next);
        Assert.Equal(queue.First.Next.Next, queue.Last);
    }

    [Fact]
    public void Next_EmptyQueue_NoChange()
    {
        var queue = new TitleQueue();
        queue.Next();

        Assert.Null(queue.First);
        Assert.Null(queue.Last);
    }

    [Fact]
    public void Next_SingleItemQueue_NoChange()
    {
        var queue = new TitleQueue();
        queue.Append("movie1.mp4");
        queue.Next();

        Assert.NotNull(queue.First);
        Assert.Same(queue.First, queue.Last);
        Assert.Equal("movie1.mp4", queue.First.MovieName);
    }

    [Fact]
    public void Contains_EmptyQueue_ReturnsFalse()
    {
        var queue = new TitleQueue();
        Assert.False(queue.Contains("movie1.mp4"));
    }

    [Fact]
    public void Contains_ExistingMovie_ReturnsTrue()
    {
        var queue = new TitleQueue();
        queue.Append("movie1.mp4");
        Assert.True(queue.Contains("movie1.mp4"));
    }

    [Fact]
    public void Contains_NonExistingMovie_ReturnsFalse()
    {
        var queue = new TitleQueue();
        queue.Append("movie1.mp4");
        Assert.False(queue.Contains("nonexisting.mp4"));
    }

    [Fact]
    public void Next_MultipleItemsQueue_RotatesQueue()
    {
        var queue = new TitleQueue();
        queue.Append("movie1.mp4");
        queue.Append("movie2.mp4");
        queue.Append("movie3.mp4");
        queue.Next();

        Assert.NotNull(queue.First);
        Assert.NotNull(queue.First.Next);
        Assert.NotNull(queue.Last);
        Assert.Null(queue.Last.Next);
        Assert.Equal("movie2.mp4", queue.First.MovieName);
        Assert.Equal("movie2.mp4", queue.CurrentlyPlaying);
        Assert.Equal("movie3.mp4", queue.First.Next.MovieName);
        Assert.Equal("movie1.mp4", queue.Last.MovieName);
        Assert.Equal(queue.First.Next.Next, queue.Last);
    }

    [Fact]
    public void CurrentlyPlaying_EmptyQueue_ReturnsNull()
    {
        var queue = new TitleQueue();
        var current = queue.CurrentlyPlaying;

        Assert.Null(current);
    }

    [Fact]
    public void CurrentlyPlaying_NonEmptyQueue_ReturnsFirstItem()
    {
        var queue = new TitleQueue();
        queue.Append("movie1.mp4");
        var current = queue.CurrentlyPlaying;

        Assert.Equal("movie1.mp4", current);
    }

    [Fact]
    public void TryInsertBefore_FirstMovie_InsertsCorrectly()
    {
        var queue = new TitleQueue();
        queue.Append("movie1.mp4");
        bool result = queue.TryInsertBefore("newMovie.mp4", "movie1.mp4");

        Assert.True(result);
        Assert.NotNull(queue.First);
        Assert.NotNull(queue.First.Next);
        Assert.Equal("newMovie.mp4", queue.First.MovieName);
        Assert.Equal("movie1.mp4", queue.First.Next.MovieName);
    }

    [Fact]
    public void TryInsertBefore_MiddleMovie_InsertsCorrectly()
    {
        var queue = new TitleQueue();
        queue.Append("movie1.mp4");
        queue.Append("movie2.mp4");
        queue.Append("movie3.mp4");
        bool result = queue.TryInsertBefore("newMovie.mp4", "movie2.mp4");

        Assert.True(result);
        Assert.NotNull(queue.First);
        Assert.NotNull(queue.First.Next);
        Assert.NotNull(queue.First.Next.Next);
        Assert.Equal("movie1.mp4", queue.First.MovieName);
        Assert.Equal("newMovie.mp4", queue.First.Next.MovieName);
        Assert.Equal("movie2.mp4", queue.First.Next.Next.MovieName);
    }

    [Fact]
    public void TryInsertBefore_NonExistentMovie_ReturnsFalse()
    {
        var queue = new TitleQueue();
        queue.Append("movie1.mp4");
        bool result = queue.TryInsertBefore("newMovie.mp4", "nonexistent.mp4");

        Assert.False(result);
    }

    [Fact]
    public void TryInsertBefore_EmptyQueue_ReturnsFalse()
    {
        var queue = new TitleQueue();
        bool result = queue.TryInsertBefore("newMovie.mp4", "movie1.mp4");

        Assert.False(result);
    }
}
