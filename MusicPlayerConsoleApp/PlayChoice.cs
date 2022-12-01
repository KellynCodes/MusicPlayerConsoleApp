namespace MusicPlayerConsoleApp
{
    internal class PlayChoice
    {

    }
    public partial class UserOperations
    {
        public static void PlayNextSong(int songId)
        {
            Console.Write("Playing next song");
            var nextSong = Songs.FirstOrDefault(song => song.SongId == songId + 1);
            Console.WriteLine($"Playing {nextSong.SongName} by {nextSong.Artist}");
        } 
        
        public static void PlayPrevSong(int songId)
        {
            Console.WriteLine("Playing previous song");
            var prevSong = Songs.FirstOrDefault(song => song.SongId == songId - 1);
           if(prevSong == null)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                var PlayingSong = Songs.FirstOrDefault(song => song.SongId == songId);

                Console.WriteLine($"{PlayingSong.SongName} was the first [{PlayingSong.SongId}] song in the list");
                Console.BackgroundColor = ConsoleColor.White;

                PlaySong();
            }
            Console.WriteLine($"Playing {prevSong.SongName} by {prevSong.Artist}");
        }
    }
}
