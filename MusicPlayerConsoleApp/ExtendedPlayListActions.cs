using static MusicPlayerConsoleApp.PlayChoice;

namespace MusicPlayerConsoleApp
{
    internal class ExtendedPlayListActions
    {
    }

    public partial class UserOperations
    {
        public static List<PlayListModel> _playListModels = PlayList;
        public static List<SongInPlayList> _SongInPlayList;
        public static void PlayNextOrPrevSongInPlayList()
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
                    PlayPrevSongInPlayList(_songInPlayListToPlay);
                    break;
                case "NEXT":
                    PlayNextSongInPlayList(_songInPlayListToPlay);
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

        public static void PlayNextSongInPlayList(int songId)
        {
            foreach (var List in _playListModels)
            {
                _SongInPlayList = List.PlayListSongs;
            }   
                  var PlayingSong = _unicPlayList.PlayListSongs.FirstOrDefault(song => song.SongInPlayListId == songId);
                if (PlayingSong == null)
                {
              
                   Console.ForegroundColor = ConsoleColor.Red;
                  Console.WriteLine($"{PlayingSong.SongName} was the last [{PlayingSong.SongInPlayListId}] song in the list");
                  Console.ResetColor();
                ShowPlayListById();
                }
           
                var PlayingNextSong = _unicPlayList.PlayListSongs.FirstOrDefault(song => song.SongInPlayListId == songId + 1);
                Console.WriteLine("Playing next song");
            Console.WriteLine($"{PlayingNextSong.SongName} by {PlayingNextSong.Artist}");
            Console.WriteLine($"Song Duration => {PlayingNextSong.SongDuration}");
            for (int i = 0; i < _Song.SongDuration * OneMinute; i++)
            {
                Console.Write("|.|OPPS");
                Thread.Sleep(LoopSleepDuration);
                Console.Beep(SongFrequency, SongDuration);
            }
            PlayNextOrPrevSongInPlayList();
        }


        public static void PlayPrevSongInPlayList(int songId)
        {
            foreach (var List in _playListModels)
            {
                _SongInPlayList = List.PlayListSongs;
            }
            var PlayingSong = _unicPlayList.PlayListSongs.FirstOrDefault(song => song.SongInPlayListId == songId);
            if (PlayingSong == null)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{PlayingSong.SongName} was the last [{PlayingSong.SongInPlayListId}] song in the list");
                Console.ResetColor();
                ShowPlayListById();
            }

            var PlayingNextSong = _unicPlayList.PlayListSongs.FirstOrDefault(song => song.SongInPlayListId == songId - 1);
            Console.WriteLine("Playing next song");
            Console.WriteLine($"{PlayingNextSong.SongName} by {PlayingNextSong.Artist}");
            Console.WriteLine($"Song Duration => {PlayingNextSong.SongDuration}");
            for (int i = 0; i < _Song.SongDuration * OneMinute; i++)
            {
                Console.Write("|.|OPPS");
                Thread.Sleep(LoopSleepDuration);
                Console.Beep(SongFrequency, SongDuration);
            }
            PlayNextOrPrevSongInPlayList();
        }
    }
}
