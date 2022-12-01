namespace MusicPlayerConsoleApp
{
    internal class PlayChoice
    {

    }
    public partial class UserOperations
    {
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
