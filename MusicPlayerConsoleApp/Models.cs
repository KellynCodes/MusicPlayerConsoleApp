namespace MusicPlayerConsoleApp
{
    public class SongModel
    {
        public int SongId { get; set; }
        public string? Artist { get; set; }
        public string? SongName { get; set; }
        public string SongDate { get; set; }
        public double SongDuration { get; set; }

        public SongModel(int id, string artist, string songname, double songDuration, string songdate)
        {
            SongId = id;
            Artist = artist;
            SongName = songname;
            SongDuration = songDuration;
            SongDate = songdate;
        }

    }

    public class SongInPlayList
    {
        public int SongInPlayListId { get; set; }
        public string SongName { get; set; }
        public string SongDate { get; set; }
        public string Artist { get; set; }
        public double SongDuration { get; set; }

        public SongInPlayList(int songInPlayListId, string artist, string songname, double songduration, string songdate)
        {
            SongInPlayListId = songInPlayListId;
            SongName = songname;
            SongDate = songdate;
            Artist = artist;
            SongDuration = songduration;
        }
    }

    public class PlayListModel
    {
        public int PlayId { get; set; }
        public string Name { get; set; }
        public string CreateAt { get; set; }
        public List<SongInPlayList> PlayListSongs { get; set; }

    public PlayListModel(int playId, string name, List<SongInPlayList> playListSongs, string createat)
        {
            PlayId = playId;
            Name = name;
            PlayListSongs = playListSongs;
            CreateAt = createat;
        }

    }
}
