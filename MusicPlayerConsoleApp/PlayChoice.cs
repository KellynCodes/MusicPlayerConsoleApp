using static MusicPlayerConsoleApp.PlayChoice;

namespace MusicPlayerConsoleApp
{
    internal class PlayChoice
    {
        public enum List : int
        {
            IdOne = 1,
            IdTwo,
            IdThree,
            IdFour,
            IdFive,
        }
        public enum Song : int
        {
            IdOne = 1,
            IdTwo,
            IdThree,
            IdFour,
            IdFive,
        }
        public static List<PlayListModel> PlayList { get; set; } = new List<PlayListModel>()
        {
            new PlayListModel((int)List.IdOne, "Flavour Songs", new List<SongInPlayList>()
            {
                new SongInPlayList((int)Song.IdOne, "Flavour", "Beautiful Woman", 0.5, UserOperations.CreatedDate),
                new SongInPlayList((int)Song.IdTwo, "Flavour", "Obi di ya", 1, UserOperations.CreatedDate),
                new SongInPlayList((int)Song.IdThree, "Flavour", "Awele", 0.1, UserOperations.CreatedDate),
                new SongInPlayList((int)Song.IdFour, "Flavour", "Nabania", 2, UserOperations.CreatedDate),
                new SongInPlayList((int)Song.IdFive, "Flavour", "Good Woman", 1.5, UserOperations.CreatedDate)
            },
        UserOperations.CreatedDate),
            new PlayListModel((int)List.IdTwo, "Phyno Songs", new List<SongInPlayList>()
            {
                new SongInPlayList((int)Song.IdOne, "Kelly Presh", "Purity", 0.5, UserOperations.CreatedDate),
                new SongInPlayList((int)Song.IdTwo, "Kizz Daniel", "Buga", 1, UserOperations.CreatedDate),
                new SongInPlayList((int)Song.IdThree, "Kizz Daniel", "Cough", 0.1, UserOperations.CreatedDate),
                new SongInPlayList((int)Song.IdFour, "Tekno", "Go", 2, UserOperations.CreatedDate),
                new SongInPlayList((int)Song.IdFive, "Jusin Bieber", "Love You Forever", 1.5, UserOperations.CreatedDate)
            }, UserOperations.CreatedDate),
            new PlayListModel((int)List.IdThree, "Timaya Songs", new List<SongInPlayList>()
            {
                new SongInPlayList((int)Song.IdOne, "Kelly Presh", "Purity", 0.5, UserOperations.CreatedDate),
                new SongInPlayList((int)Song.IdTwo, "Kizz Daniel", "Buga", 1, UserOperations.CreatedDate),
                new SongInPlayList((int)Song.IdThree, "Kizz Daniel", "Cough", 0.1, UserOperations.CreatedDate),
                new SongInPlayList((int)Song.IdFour, "Tekno", "Go", 2, UserOperations.CreatedDate),
                new SongInPlayList((int)Song.IdFive, "Jusin Bieber", "Love You Forever", 1.5, UserOperations.CreatedDate)
            }, UserOperations.CreatedDate),
            new PlayListModel((int)List.IdFour, "Kizz Daniel Songs", new List<SongInPlayList>()
            {
                new SongInPlayList((int)Song.IdOne, "Kelly Presh", "Purity", 0.5, UserOperations.CreatedDate),
                new SongInPlayList((int)Song.IdTwo, "Kizz Daniel", "Buga", 1, UserOperations.CreatedDate),
                new SongInPlayList((int)Song.IdThree, "Kizz Daniel", "Cough", 0.1, UserOperations.CreatedDate),
                new SongInPlayList((int)Song.IdFour, "Tekno", "Go", 2, UserOperations.CreatedDate),
                new SongInPlayList((int)Song.IdFive, "Jusin Bieber", "Love You Forever", 1.5, UserOperations.CreatedDate)
            }, UserOperations.CreatedDate),
            new PlayListModel((int)List.IdFive, "KellynCodes Songs", new List<SongInPlayList>()
            {
                new SongInPlayList((int)Song.IdOne, "Kelly Presh", "Purity", 0.5, UserOperations.CreatedDate),
                new SongInPlayList((int)Song.IdTwo, "Kizz Daniel", "Buga", 1, UserOperations.CreatedDate),
                new SongInPlayList((int)Song.IdThree, "Kizz Daniel", "Cough", 0.1, UserOperations.CreatedDate),
                new SongInPlayList((int)Song.IdFour, "Tekno", "Go", 2, UserOperations.CreatedDate),
                new SongInPlayList((int)Song.IdFive, "Jusin Bieber", "Love You Forever", 1.5, UserOperations.CreatedDate)
            }, UserOperations.CreatedDate),
        };

    }

    public partial class UserOperations
    {

        private static  List<SongInPlayList> _songs;
        private static int _songInPlayListToPlay;
        private static PlayListModel _unicPlayList;
        private static SongInPlayList _Song;
        private static PlayListModel _selectedPlayList;
        private static SongInPlayList _songI;


        /*=========================PLAYLIST CODES=========================*/
        public static void ShowPlayList()
        {
            Console.WriteLine("Availble Playlist are:");
            foreach (var list in PlayList)
            {
                Console.WriteLine($"{list.PlayId}\t {list.Name}\t {list.CreateAt}");
            }
        }

        public static void ShowPlayListById()
        {
            ShowPlayList();
        EnterPlayList: Console.WriteLine("Enter Playlist Id in the list");
            string ListID = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(ListID, out int PlayListID))
            {
                var unicPlayList = PlayList.FirstOrDefault(playList => playList.PlayId == PlayListID);
                _unicPlayList = unicPlayList;
                if (unicPlayList == null)
                {
                    ErrorMessage();
                    Program.Main();
                }
                Console.Clear();
                Console.WriteLine($"Welcome to {unicPlayList.Name} PlayList");
                Console.WriteLine($"These are songs by {unicPlayList.Name}");
                foreach (var songList in unicPlayList.PlayListSongs)
                {
                    _songI = songList;
                    if (songList == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Error occured please try again");
                        goto EnterPlayList;
                    }
                    Console.WriteLine($"{songList.SongInPlayListId} {songList.SongName} by {songList.Artist}. Duration: {songList.SongDuration} Minutes");
                }
                    PlaySongInPlayList(_songI);
            }
            else
            {
                ErrorMessage();
                goto EnterPlayList;
            }
        }

        public static void PlaySongInPlayList(SongInPlayList Song)
        {
        Start: Console.WriteLine("Enter song number you want to play");
            if (int.TryParse(Console.ReadLine(), out int songToPlay))
            {
                _songInPlayListToPlay = songToPlay;
                _Song = Song;
                if (Song == null)
                {
                    Console.Clear();
                    Console.WriteLine("The number your entered where not in the list");
                    goto Start;
                }
                Console.Clear();
                Console.WriteLine($"Playing {Song.SongName} by {Song.Artist}");
                Console.Write($"Song Duration => {Song.SongDuration} Minutes\n ");
                for (int i = 0; i < Song.SongDuration * OneMinute; i++)
                {
                    Console.Write("|.|");
                    Thread.Sleep(LoopSleepDuration);
                    Console.Beep(SongFrequency, SongDuration);
                }
                PlayNextOrPrevSongInPlayList();
            }
            else
            {
                Console.Clear();
                ErrorMessage();
                goto Start;
            }
        }

        public static void CreatePlayList()
        {
            var list = PlayList;

        Start: Console.WriteLine("Enter Playlist name");
            string PlayListName = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(PlayListName))
            {
                ErrorMessage();
                goto Start;
            }
            var playListId = list.Last().PlayId + 1;
            list.Add(new PlayListModel(playListId, PlayListName, new List<SongInPlayList>()
            {
                new SongInPlayList((int)Song.IdOne, "Kelly Presh", "Purity", 0.5, CreatedDate) }, CreatedDate));
            ShowPlayList();
        }

        /// <summary>
        ///============================Add song to PlayList=============================
        /// </summary>
        public static void AddSongToPlayList()
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
        EnterSongDuration: Console.WriteLine("Enter song Duration");

            if (double.TryParse(Console.ReadLine(), out double SongDuation))
            {
              StartAfresh: Console.WriteLine("Do you wish to add this song to an existing playList or you want to create your own playlist for this song\n Type [ADD] to add to an existing Playlist OR \n Type [CREATE] to create your preffered playlist");
                string userAnswer = Console.ReadLine() ?? string.Empty;
                if (userAnswer?.ToUpper() == "ADD")
                {
                    Console.WriteLine("These are list of existing play list");
                    ShowPlayList();
                SelectPlayListID: Console.WriteLine("Select a playlist you want to add this new song");
                    if (int.TryParse(Console.ReadLine(), out int PlayListID))
                    {
                        var PlayList = PlayChoice.PlayList;
                        var selectedPlayList = PlayList.FirstOrDefault(list => list.PlayId == PlayListID);
                        _selectedPlayList = selectedPlayList;
                        var SongList = selectedPlayList.PlayListSongs;
                        int NewSongId = SongList.Last().SongInPlayListId + 1;
                        SongList.Add(new SongInPlayList(NewSongId, songName, ArtistName, SongDuation, CreatedDate));
                        Console.WriteLine($"You have successfully Added your new song [{songName}] to {selectedPlayList.Name}");
                        ShowPlayList();
                        Console.WriteLine("Enter song number to play");
                        ShowPlayListById();
                    }
                    else
                    {
                        Console.Clear();
                        ErrorMessage();
                        goto SelectPlayListID;
                    }
                }
                else if (userAnswer?.ToUpper() == "CREATE")
                {
                    var PlayList = PlayChoice.PlayList;
                    foreach (var item in PlayList)
                    {
                        _songs = item.PlayListSongs;
                    }
                        int NewSongId = _songs.Last().SongInPlayListId + 1;
                        int NewPlayListId = PlayList.Last().PlayId + 1;
                    EnterPlayListName: Console.WriteLine("Enter Playlist name");
                        string playListName = Console.ReadLine() ?? string.Empty;
                        if (string.IsNullOrWhiteSpace(playListName))
                        {
                            ErrorMessage();
                            goto EnterPlayListName;
                        }
                        var newPlayListSong = new List<SongInPlayList>() { new SongInPlayList(NewSongId, ArtistName, songName, SongDuation, CreatedDate) };
                        PlayList.Add(new PlayListModel(NewPlayListId, playListName, newPlayListSong, CreatedDate));
                        Console.WriteLine("Song successfully added to list");
                        ShowPlayList();
                        Console.WriteLine("Enter song number to play");
                    ShowPlayListById();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please Enter [CREATE/ADD].");
                    goto StartAfresh;
                }
            }
            else
            {
                Console.Clear();
                ErrorMessage();
                goto EnterSongDuration;
            }
        }

        /*=========================END OF PLAYLIST CODES=========================*/
        /*|*/
        /*=========================SONG CODES=========================*/
        public static void PlayNextSong(int songId)
        {
            var nextSong = Songs.FirstOrDefault(song => song.SongId == songId + 1);
            if (nextSong == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                var PlayingSong = Songs.FirstOrDefault(song => song.SongId == songId);
                Console.WriteLine($"{PlayingSong.SongName} was the last [{PlayingSong.SongId}] song in the list");
                Console.ResetColor();
                PlaySong();
            }
            Console.WriteLine("Playing next song");
            Console.WriteLine($"{nextSong.SongName} by {nextSong.Artist}");
            Console.WriteLine($"Song Duration => {nextSong.SongDuration}");
            ForLoop(nextSong);
            PlayNextOrPrevSong();
        }

        public static void PlayPrevSong(int songId)
        {
            var prevSong = Songs.FirstOrDefault(song => song.SongId == songId - 1);
            if (prevSong == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                var PlayingSong = Songs.FirstOrDefault(song => song.SongId == songId);
                Console.WriteLine($"{PlayingSong.SongName} was the first [{PlayingSong.SongId}] song in the list");
                Console.ResetColor();
                PlaySong();
            }
            Console.WriteLine("Playing previous song");
            Console.WriteLine($"{prevSong.SongName} by {prevSong.Artist}");
            Console.WriteLine($"Song Duration => {prevSong.SongDuration}");
            ForLoop(prevSong);
            PlayNextOrPrevSong();
        }

        public static void ForLoop(SongModel song)
        {
            for (int i = 0; i < song.SongDuration * OneMinute; i++)
            {
                Console.Write("|.|");
                Thread.Sleep(LoopSleepDuration);
                Console.Beep(SongFrequency, SongDuration);
            }
        }
    }
}
