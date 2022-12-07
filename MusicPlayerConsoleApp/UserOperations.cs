using System.Threading;

namespace MusicPlayerConsoleApp
{
    public static partial class UserOperations
    {
        private static int SongFrequency { get; set; } = 1000;
        private static int SongDuration { get; set; } = 200;
        private static int LoopSleepDuration { get; set; } = 500;
        private static int OneMinute { get; set; } = 60;
        private static int _timeOut = 3500;
        private static readonly Random RandomNumbers = new();

        public static string CreatedDate { get; set; } = $"{DateTime.Now.ToLongDateString()} by {DateTime.Now.ToLongTimeString()}";

        public static List<SongModel> Songs { get; set; } = new List<SongModel>()
            {
                new SongModel(1, "Kelly Presh", "Purity", 0.5, CreatedDate),
                new SongModel(2, "Kizz Daniel", "Buga", 1, CreatedDate),
                new SongModel(3, "Kizz Daniel", "Cough", 0.1, CreatedDate),
                new SongModel(4, "Tekno", "Go", 2, CreatedDate),
                new SongModel(5, "Jusin Bieber", "Love You Forever", 1.5, CreatedDate)
            };

        public static int _songToPlay;

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
                Songs.Add(new SongModel(NewSongId, ArtistName, songName, songDuration, CreatedDate));
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
                    Console.WriteLine($"Your have successfully removed {findAndMatchSongById.SongName}");
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

        public static void EditSong()
        {
            ViewListOfSongs();
        Start: Console.WriteLine("Enter the number of songs you want to Edit");
            if (int.TryParse(Console.ReadLine(), out int songId))
            {
                var findAndMatchSongById = Songs.FirstOrDefault(song => song.SongId == songId);
            AreYouSure: Console.WriteLine($"Are you sure you want to Edit {findAndMatchSongById.SongName} by {findAndMatchSongById.Artist}");
                string userAnswer = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(userAnswer))
                {
                    Console.Clear();
                    ErrorMessage();
                    goto AreYouSure;
                }
                if (userAnswer.ToUpper() == "YES")
                {
                EnterNewSongName: Console.WriteLine("Enter new song name");
                    string songName = Console.ReadLine() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(songName))
                    {
                        Console.Clear();
                        ErrorMessage();
                        goto EnterNewSongName;
                    }
                EnterNewArtistName: Console.WriteLine("Enter artist name");
                    string artistName = Console.ReadLine() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(artistName))
                    {
                        Console.Clear();
                        ErrorMessage();
                        goto EnterNewArtistName;
                    }
                EnterNewSongDuration: Console.WriteLine("Enter new song Duration");
                    if (double.TryParse(Console.ReadLine(), out double newSongDuration))
                    {
                        Songs.Remove(findAndMatchSongById);
                        Songs.Add(new SongModel(findAndMatchSongById.SongId, artistName, songName, newSongDuration, CreatedDate));
                        Console.WriteLine($"Your have successfully Edited {findAndMatchSongById.SongName}");
                        ViewListOfSongs();
                    }
                    else
                    {
                        Console.Clear();
                        ErrorMessage();
                        goto EnterNewSongDuration;
                    }
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
        public static void SongPlayController()
        {
        start: Console.WriteLine("Enter list number to choose from the list");
            Console.WriteLine("1. Play Song by PREV and NEXT");
            Console.WriteLine("2. Play song serially");
            Console.WriteLine("3. Shuffle Songs");
            Console.WriteLine("4. Play song in Play list");
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
                switch (answer)
                {
                    case (int)PlayChoice.Song.IdOne:
                        PlaySong();
                        break;
                    case (int)PlayChoice.Song.IdTwo:
                        PlaySongSerially();
                        break;
                    case (int)PlayChoice.Song.IdThree:
                        ShuffleSong();
                        break;
                    case (int)PlayChoice.Song.IdFour:
                        ShowPlayListById();
                        break;
                }
            }
            else
            {
                Console.Clear();
                ErrorMessage();
                goto start;
            }

        }
        public static void PlaySong()
        {
        Start: ViewListOfSongs();
            Console.WriteLine("Enter song number you want to play");
            if (int.TryParse(Console.ReadLine(), out int songToPlay))
            {
                _songToPlay = songToPlay;
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
                ForLoop(song);
                PlayNextOrPrevSong();
            }
            else
            {
                Console.Clear();
                ErrorMessage();
                goto Start;
            }
        }

        public static void PlaySongSerially()
        {
            ViewListOfSongs();
            Console.WriteLine("Shuffle is on");
            int Count = 0;
            ViewListOfSongs();
            Console.WriteLine("Shuffle is on");
            for (var song = 0; song < Songs.Count; song++)
            {
                try
                {
                    Console.WriteLine($"\nPlaying {Songs[Count].SongName} by {Songs[Count].Artist} \n Song Duration => {Songs[Count].SongDuration} Minutes");
                    for (int i = 0; i < Songs[Count].SongDuration * OneMinute; i++)
                    {
                        Console.Write("|.|");
                        Thread.Sleep(LoopSleepDuration);
                        Console.Beep(SongFrequency, SongDuration);
                    }
                    Thread.Sleep(_timeOut);
                    Count++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("The songs has finished");
                    PlayNextOrPrevSong();
                }

            }
        }

        public static void ShuffleSong()
        {
            const int One = 0;
            var list = Songs;
            int NumberOfItemsInList = list.Count;
            while (NumberOfItemsInList > One)
            {
                NumberOfItemsInList--;
                int NextRandomNumbers = RandomNumbers.Next(NumberOfItemsInList + One);
               var ListResult = (list[NumberOfItemsInList], list[NumberOfItemsInList]) = (list[NextRandomNumbers], list[NextRandomNumbers]);
                Console.WriteLine($"\nPlaying {ListResult.Item1.SongName} by {ListResult.Item1.Artist} \n Song Duration => {ListResult.Item1.SongDuration} Minutes");
                for (int i = 0; i < ListResult.Item1.SongDuration * OneMinute; i++)
                {
                    Console.Write("|.|");
                    Thread.Sleep(LoopSleepDuration);
                    Console.Beep(SongFrequency, SongDuration);
                }
                Thread.Sleep(_timeOut);
            }
        }


        public static void PlayNextOrPrevSong()
        {
        playAnotherSong: Console.WriteLine("\nDo you wish to play another song [YES/NO]\n OR \n Enter [PREV/NEXT] to play the Previous/Next song");
            string answer = Console.ReadLine() ?? string.Empty;
            switch (answer.ToUpper())
            {
                case "YES":
                    Console.Clear();
                    PlaySong();
                    break;
                case "PREV":
                    PlayPrevSong(_songToPlay);
                    break;
                case "NEXT":
                    PlayNextSong(_songToPlay);
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
    }
}



