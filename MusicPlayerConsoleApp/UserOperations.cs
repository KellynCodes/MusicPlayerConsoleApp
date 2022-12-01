namespace MusicPlayerConsoleApp
{
    public partial class UserOperations
    {
        private static int SongFrequency { get; set; } = 1000;
        private static int SongDuration { get; set; } = 200;
        private static int LoopSleepDuration { get; set; } = 500;
        private static int Minutes { get; set;} = 60;

        private static string CreatedTDate { get; set; } = $"{DateTime.Now.ToLongDateString()} by {DateTime.Now.ToLongTimeString()}";

        public static List<SongModel> Songs { get; set; } = new List<SongModel>()
            {
                new SongModel(1, "Kelly Presh", "Purity", 0.5, CreatedTDate),
                new SongModel(2, "Kizz Daniel", "Buga", 1, CreatedTDate),
                new SongModel(3, "Kizz Daniel", "Cough", 0.1, CreatedTDate),
                new SongModel(4, "Tekno", "Go", 2, CreatedTDate),
                new SongModel(5, "Jusin Bieber", "Love You Forever", 1.5, CreatedTDate)
            };

        public static void ErrorMessage()
        {
            Console.WriteLine("Input was empty or not valid");

        }


        public static void ViewListOfSongs()
        {

            Console.WriteLine("Available Song lists\n");
            /* var table = new ConsoleTable("No.", "Artist", "Song", "Added Date");*/
            foreach (SongModel song in Songs)
            {
                Console.WriteLine($"{song.SongId}\t {song.Artist}\t {song.SongName}\t {song.SongDate}  {song.SongDuration}");
            }
        }

        public static void AddSong()
        {
        Start: Console.WriteLine("Enter song name");
            string? songName = Console.ReadLine();
            //validate input
            if (string.IsNullOrWhiteSpace(songName))
            {
                Console.Clear();
                ErrorMessage();
                goto Start;
            }
        Artist: Console.WriteLine("Enter Artist Name");
            string? ArtistName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ArtistName))
            {
                Console.Clear();
                ErrorMessage();
                goto Artist;
            }
        SongDuation: Console.WriteLine("Enter song Duration");
            if (double.TryParse(Console.ReadLine(), out double songDuration))
            {
                int NewSongId = Songs.Last().SongId + 1;
                Songs.Add(new SongModel(NewSongId, ArtistName, songName, songDuration, CreatedTDate));
                Console.WriteLine("Song successfully added to list");
                ViewListOfSongs();
            }
            else
            {
                Console.Clear();
                ErrorMessage();
                goto SongDuation;
            }
        }

        public static void RemoveSong()
        {
        Start: Console.WriteLine("Enter the number of songs you want to remove");
            if (int.TryParse(Console.ReadLine(), out int songId))
            {
                var findAndMatchSongById = Songs.FirstOrDefault(song => song.SongId == songId);
                Console.WriteLine($"Are you sure you want to delete {findAndMatchSongById.SongName} by {findAndMatchSongById.Artist}");
                string userAnswer = Console.ReadLine() ?? string.Empty;
                if (userAnswer.ToUpper() == "YES")
                {
                    Songs.Remove(findAndMatchSongById);
                    Console.WriteLine($"Your have successfully removed {findAndMatchSongById}");
                }
                else if (userAnswer.ToUpper() == "NO")
                {
                    Console.Clear();
                    Console.WriteLine($"{findAndMatchSongById.SongName} was not deleted");
                    Program.Main();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You have cancled this Operation");
                    Program.Main();
                }
            }
            else
            {
                Console.Clear();
                ErrorMessage();
                goto Start; ;
            }
        }

        /* ==================PlaySong===========================*/
        public static void PlaySong()
        {
        Start: ViewListOfSongs();
            Console.WriteLine("Enter song number you want to play");
            if (int.TryParse(Console.ReadLine(), out int songToPlay))
            {
                var song = Songs.FirstOrDefault(song => song.SongId == songToPlay);
                if (song == null)
                {
                    Console.Clear();
                    Console.WriteLine("The number your entered where not in the list");
                    goto Start;
                }
                Console.Clear();
                Console.WriteLine($"Playing {song.SongName} by {song.Artist}");
                Console.Write($"Song Duration => {song.SongDuration} Minutes\n ");
             for (int i = 0; i < song.SongDuration * Minutes; i++)
                {
                    Console.Write("|.|");
                    Thread.Sleep(LoopSleepDuration);
                    Console.Beep(SongFrequency, SongDuration);
                }
            playAnotherSong: Console.WriteLine("\nDo you wish to play another song [YES/NO]\n OR \n Enter [PREV/NEXT] to play the Previous/Next song");
                string answer = Console.ReadLine() ?? string.Empty;
                switch (answer.ToUpper())
                {
                    case "YES":
                        Console.Clear();
                        goto Start;
                    case "PREV": PlayPrevSong(songToPlay);
                        break;
                    case "NEXT": PlayNextSong(songToPlay);
                        break;
                    case "NO":
                        Console.Clear();
                        Program.Main();
                        break;
                    default:
                        Console.Clear();
                        ErrorMessage();
                        goto playAnotherSong;
                }
            }
            else
            {
                Console.Clear();
                ErrorMessage();
                goto Start;
            }
        }
    }
}



