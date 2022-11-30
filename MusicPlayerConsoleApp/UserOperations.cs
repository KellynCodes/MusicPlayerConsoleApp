namespace MusicPlayerConsoleApp
{
    internal class UserOperations
    {
        public List<string> _playList;
        public  void AddSongs()
        {
            Dictionary<string, string> songs = new();
            string _song;
            string _userId;
            Guid guid = Guid.NewGuid();
        //get users input
        Start: Console.WriteLine("Enter song name");
            string? usersInput = Console.ReadLine();
            //validate input
            if (string.IsNullOrWhiteSpace(usersInput))
            {
                Console.WriteLine("Input was empty or not valid");
                goto Start;
            }
            string? guidInString = guid.ToString();
            _song = usersInput;
            _userId = guidInString;
            //add the new song to dicitonary;
            songs.Add(Guid.NewGuid().ToString(), "KellynCodes");
            songs.Add(_userId, _song);
            foreach (var song in songs)
            {
                Console.WriteLine(song.Value);
            }
        }

        public void AddPlayList()
        {
            UserOperations userOperations = new();
        Start: Console.WriteLine("Enter playlist name");
            string? newUserPlayList = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newUserPlayList))
            {
                Console.WriteLine("Input was empty or not valid");
                goto Start;
            }
           userOperations._playList.Add(newUserPlayList);
            foreach(var musicPlayList in _playList)
            {
                Console.WriteLine(musicPlayList);
            }

        }
    }
}


           
