using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05OnlineRadioDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfLines; i++)
            {

                try
                {
                    string[] songData = Console.ReadLine().Split(';');

                    string artistName = songData[0];
                    string songName = songData[1];

                    int[] minutesAndSeconds = songData[2].Split(':').Select(int.Parse).ToArray();
                    int minutes = minutesAndSeconds[0];
                    int seconds = minutesAndSeconds[1];

                    Artist artist = new Artist(artistName);
                    Song song = new Song(songName, minutes, seconds);
                    Playlist.AddSong(song);
                    Console.WriteLine("Song added.");
                }
                catch (InvalidSongException iex)
                {
                    Console.WriteLine(iex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid song length.");
                }
            }
            Console.WriteLine(Playlist.GetLength());
        }
    }

    public class InvalidSongException : Exception
    {
        private new const string Message = "Invalid song.";

        public InvalidSongException() : base (Message) 
        {

        }
        public InvalidSongException(string message) : base(message)
        {

        }

    }

    public class InvalidArtistNameException : InvalidSongException
    {
        public new const string Message = "Artist name should be between 3 and 20 symbols.";
        public InvalidArtistNameException() : base(Message)
        {

        }

        public InvalidArtistNameException(string message) : base(message)
        {

        }

    }

    public class InvalidSongNameException : InvalidSongException
    {
        public new const string Message = "Song name should be between 3 and 30 symbols.";

        public InvalidSongNameException() : base (Message)
        {

        }
    }

    public class InvalidSongLengthException : InvalidSongException
    {
        public new const string Message = "Invalid song length.";

        public InvalidSongLengthException() : base(Message)
        {

        }

        public InvalidSongLengthException(string message) : base(message)
        {

        }
    }

    public class InvalidSongMinuteException : InvalidSongLengthException
    {
        public new const string Message = "Song minutes should be between 0 and 14.";

        public InvalidSongMinuteException() : base(Message)
        {

        }

    }

    public class InvalidSongSecondsException : InvalidSongLengthException
    {
        public new const string Message = "Song seconds should be between 0 and 59.";

        public InvalidSongSecondsException() : base (Message)
        {

        }
    }

    public class Artist
    {
        private string name;

        public Artist(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameException();
                }
                this.name = value;
            }
        }
    }

    public class Song
    {
        private string name;
        private int minutes;
        private int seconds;

        public Song(string name, int minutes, int seconds)
        {
            this.Name = name;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongNameException();
                }
                this.name = value;
            }
        }

        public int Minutes
        {
            get
            {
                return this.minutes;
            }
            private set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinuteException();
                }
                this.minutes = value;
            }
        }

        public int Seconds
        {
            get
            {
                return this.seconds;
            }
            private set
            {
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }
                this.seconds = value;
            }
        }
    }

    public static class Playlist
    {
        private static int songsCount;
        private static int seconds;
        private static int minutes;
        private static int hours;

        public static void AddSong(Song song)
        {
            seconds += song.Seconds;
            minutes += song.Minutes;

            minutes += seconds / 60;
            seconds = seconds % 60;
            hours += minutes / 60;
            minutes = minutes % 60;
            songsCount++;
        }

        public static string GetLength()
        {
            string length = $"Songs added: {songsCount}\nPlaylist length: {hours}h {minutes}m {seconds}s";
            return length;
        }
    }
}
