namespace MusicPlayerConsoleApp
{
    internal class PlayChoice
    {
        private enum User : int
        {
            IdOne = 1,
            IdTwo = 2,
            IdThree = 3,
            IdFour = 4,
            IdFive = 5,
        }
        public static List<SongModel> GetSongModels { get; set; }
       public static List<PlayListModel> PlayList { get; set; } = new List<PlayListModel>()
        {
            new PlayListModel((int)User.IdOne, "Flavour Songs", UserOperations.Songs, UserOperations.CreatedDate),
            new PlayListModel((int)User.IdTwo, "Phyno Songs", UserOperations.Songs, UserOperations.CreatedDate),
            new PlayListModel((int)User.IdThree, "Timaya Songs", UserOperations.Songs, UserOperations.CreatedDate),
            new PlayListModel((int)User.IdFour, "Kizz Daniel Songs", UserOperations.Songs, UserOperations.CreatedDate),
            new PlayListModel((int)User.IdFive, "KellynCodes Songs", UserOperations.Songs, UserOperations.CreatedDate),
        };
    }
    public partial class UserOperations
    {
        /*=========================PLAYLIST CODES=========================*/
        public static void ShowPlayList()
        {
            var list = PlayChoice.PlayList;
            foreach (var playList in list)
            {
                Console.WriteLine($"{playList.PlayId}\t {playList.Name}\t {playList.CreateAt}");
               
            }
        }

        public static void ShowPlayListById()
        {
            ShowPlayList();
            Console.WriteLine("Enter Playlist Id in the list");
            string ListID = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(ListID, out int PlayListID))
            {
                var List = PlayChoice.PlayList;
            var unicPlayList = List.FirstOrDefault(matchedList => matchedList.PlayId == PlayListID);
            foreach (var playList in List)
            {
                if(unicPlayList == null)
                {
                    ErrorMessage();
                    Program.Main();
                }
                if(unicPlayList.PlayId == PlayListID)
                {
                Console.WriteLine($"{unicPlayList.PlayId}\t {unicPlayList.Name}\t {unicPlayList.CreateAt}");

                }
               /* foreach(var subList in playList.SongsInPlayList)
                {
                    Console.WriteLine($"{subList.SongName} by {subList.Artist}");
                }*/
            }
            }
            else
            {
                UserOperations.ErrorMessage();
            }
        }

        public static void CreatePlayList()
        {
            var list = PlayChoice.PlayList;

        Start: Console.WriteLine("Enter Playlist name");
            string PlayListName = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(PlayListName))
            {
                ErrorMessage();
                goto Start;
            }
            var playListId = list.Last().PlayId + 1;
            list.Add(new PlayListModel (playListId, PlayListName, Songs, CreatedDate));
            var newPlayList = list.FirstOrDefault(newSong => newSong.PlayId == playListId);
            Console.WriteLine($"{newPlayList.Name} was added to the list");
        }

        //Add song to PlayList
        private static void AddSongToPlayList()
        {
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
            Console.WriteLine($"Playing {nextSong.SongName} by {nextSong.Artist}");
            FoorLoop(nextSong);
        } 
        
        public static void PlayPrevSong(int songId)
        {
            var prevSong = Songs.FirstOrDefault(song => song.SongId == songId - 1);
           if(prevSong == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                var PlayingSong = Songs.FirstOrDefault(song => song.SongId == songId);
                Console.WriteLine($"{PlayingSong.SongName} was the first [{PlayingSong.SongId}] song in the list");
                Console.ResetColor();
                PlaySong();
            }
            Console.WriteLine("Playing previous song");
            Console.WriteLine($"Playing {prevSong.SongName} by {prevSong.Artist}");
            FoorLoop(prevSong);
        }

        public static void FoorLoop(SongModel song )
        {
            for (int i = 0; i < song.SongDuration * Minutes; i++)
            {
                Console.Write("|.|");
                Thread.Sleep(LoopSleepDuration);
                Console.Beep(SongFrequency, SongDuration);
            }
        }
    }
}
