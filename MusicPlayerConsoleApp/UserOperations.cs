using ConsoleTable;
namespace MusicPlayerConsoleApp
{
    internal class UserOperations
    {


        private static string CreatedTDate { get; set; } = $"{DateTime.Now.ToLongDateString()} by {DateTime.Now.ToLongTimeString()}";
     
       public static List<SongModel> Songs { get; set; } = new List<SongModel>()
            {
                new SongModel(1, "Kelly Presh", "Purity", CreatedTDate),
                new SongModel(2, "Kizz Daniel", "Buga", CreatedTDate),
                new SongModel(3, "Kizz Daniel", "Cough", CreatedTDate),
                new SongModel(4, "Tekno", "Go", CreatedTDate),
                new SongModel(5, "Jusin Bieber", "Love Your Forever", CreatedTDate)
            };

        public static void ErrorMessage()
        {
                Console.WriteLine("Input was empty or not valid");

        }


        public static void ViewListOfSongs()
        {

            Console.WriteLine("Available Song lists");
            /* var table = new ConsoleTable("No.", "Artist", "Song", "Added Date");*/
            foreach (SongModel song in Songs)
            {
                Console.WriteLine($"{song.SongId}\t {song.Artist}\t {song.SongName}\t {song.SongDate}");
            }
        }

        public static void AddSong()
        {
        Start: Console.WriteLine("Enter song name");
            string? songName = Console.ReadLine();
            //validate input
            if (string.IsNullOrWhiteSpace(songName))
            {
                ErrorMessage();
                goto Start;
            }
        Artist: Console.WriteLine("Enter Artist Name");
            string? ArtistName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ArtistName))
            {
                ErrorMessage();
                goto Artist;
            }
            int NewSongId = Songs.Last().SongId + 1;
            Songs.Add(new SongModel(NewSongId, ArtistName, songName, CreatedTDate));
            Console.WriteLine("Song successfully added to list");
            ViewListOfSongs();
        }

        public static void RemoveSong()
        {
            Console.WriteLine("Enter the number of songs you want to remove");
            if (int.TryParse(Console.ReadLine(), out int songId))
            {
                var songView = Songs.FirstOrDefault(song => song.SongId == songId);
                Console.WriteLine($"Are you sure you want to delete {songView.SongName} by {songView.Artist}");
                string userAnswer = Console.ReadLine() ?? string.Empty;
                if (userAnswer.ToUpper() == "YES")
                {
                    Songs.Remove(songView);
                }else if(userAnswer.ToUpper() == "NO")
                {
                    Console.Clear();
                    Console.WriteLine($"{songView.SongName} was not deleted");
                    Program.Main();
                }
                else
                {
                    Console.WriteLine("Sorry we could'nt delete the song. ");
                }
            }
          }
        }
}


           
