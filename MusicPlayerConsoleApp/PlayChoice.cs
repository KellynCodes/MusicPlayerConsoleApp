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
            foreach(var playList in list)
            {
                Console.WriteLine($"{playList.PlayId}\t {playList.Name}\t {playList.createAt}");
                foreach(var subList in playList.SongsInPlayList)
                {
                    Console.WriteLine($"{subList.SongName} by {subList.Artist}");
                }
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
