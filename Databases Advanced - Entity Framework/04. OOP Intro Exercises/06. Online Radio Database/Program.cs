using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        List<Song> playlist = new List<Song>();

        int songsCount = int.Parse(Console.ReadLine());

        for(int i=0; i<songsCount; i++)
        {
            try
            {
                var tokens = Console.ReadLine().Split(';');
                var length = tokens[2].Split(':');
                int minutes;
                int seconds;

                if(length.Length != 2 || !int.TryParse((length[0]), out minutes) || !int.TryParse((length[1]), out seconds))
                {
                    throw new ArgumentException("Invalid song length.");
                }

                playlist.Add(new Song(tokens[0], tokens[1], minutes, seconds));
                Console.WriteLine("Song added.");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        var totalLenthInSeconds = playlist.Select(s => s.Minutes).Sum() * 60 + playlist.Select(s => s.Seconds).Sum();

        Console.WriteLine($"Songs added: {playlist.Count}");
        Console.WriteLine($"Playlist length: {totalLenthInSeconds / 3600}h {totalLenthInSeconds / 60 % 60}m {totalLenthInSeconds % 60}s");
    }
}
