using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Playlist
{
    private List<Song> songs = new List<Song>();

    public string AddSong(Song song)
    {
        songs.Add(song);

        return "Song added.";
    }

    public override string ToString()
    {
        int totalLength = songs.Select(s => s.GetLengthInSeconds()).Sum();
        var builder = new StringBuilder();

        builder.AppendLine($"Songs added: {songs.Count}")
            .Append($"Playlist length: {totalLength / 3600}h {totalLength / 60 % 60}m {totalLength % 60}s");

        return builder.ToString();
    }
}