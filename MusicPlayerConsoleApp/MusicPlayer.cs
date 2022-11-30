namespace MusicPlayerConsoleApp
{
    internal class MusicPlayer
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public MusicPlayer(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }

        public static void GetSongs()
        {
            UserOperations userOperations = new();
            var songs = userOperations._playList;
            foreach(var song in songs)
            {
                Console.WriteLine(song);
            }
        }
    }
}
