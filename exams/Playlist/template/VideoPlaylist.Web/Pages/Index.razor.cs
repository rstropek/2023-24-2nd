using Blazored.Video;
using Blazored.Video.Support;
using Microsoft.AspNetCore.Components;
using VideoPlaylist.Logic;

namespace VideoPlaylist.Web.Pages;

public partial class Index
{
    private TitleQueue Playlist { get; } = new();

    public string? SelectedMovieName { get; set; } = "";

    public BlazoredVideo? Video { get; set; }

    public string InsertBeforeTitle { get; set; } = "";

    protected override void OnParametersSet()
    {
        SelectedMovieName = AvailableMovies.First();
        base.OnParametersSet();
    }

    private void PlaylistChanged()
    {
        if (Video!.ReadyState != ReadyState.HAVE_ENOUGH_DATA)
        {
            Video?.SetSrcAsync(CurrentlyPlayingUrl!);
            Video?.StartPlayback();
        }

        SelectedMovieName = AvailableMovies.FirstOrDefault();
    }

    public void AddMovie()
    {
        if (SelectedMovieName == null) { return; }
        Playlist.Append(SelectedMovieName);
        PlaylistChanged();
    }

    public void PlayNext()
    {
        if (SelectedMovieName == null) { return; }
        Playlist.InsertAfterFirst(SelectedMovieName);
        PlaylistChanged();
    }

    public string? CurrentlyPlayingUrl => Playlist.CurrentlyPlaying != null ? $"../videos/{Playlist.CurrentlyPlaying}" : null;

    public string? CurrentlyPlayingName => Playlist.First?.MovieName;

    public void Ended()
    {
        Playlist.Next();
        Video?.SetSrcAsync(CurrentlyPlayingUrl!);
        Video?.StartPlayback();
    }

    public IEnumerable<string> AvailableMovies => MovieLibrary.AvailableMovies.Where(m => !Playlist.Contains(m)).OrderBy(m => m);

    public void SelectedMovieChanged(ChangeEventArgs ea)
    {
        if (ea.Value != null)
        {
            SelectedMovieName = ea.Value.ToString();
        }
    }

    public void InsertBefore()
    {
        if (!string.IsNullOrEmpty(InsertBeforeTitle))
        {
            if (Playlist.TryInsertBefore(SelectedMovieName!, InsertBeforeTitle))
            {
                PlaylistChanged();
            }
        }
    }
}
