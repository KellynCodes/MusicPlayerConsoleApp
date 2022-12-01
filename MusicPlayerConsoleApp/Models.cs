namespace MusicPlayerConsoleApp
{
    public class SongModel
    {
        public int SongId { get; set; }  
        public string? Artist { get; set; }
        public string? SongName { get; set; }
        public string SongDate { get; set; }
        public double ? SongDuration { get; set; }

        public SongModel(int id, string artist, string songname, double songDuration, string songdate)
        {
            SongId = id;
            Artist = artist; 
            SongName = songname;
            SongDuration = songDuration;
            SongDate = songdate;
        }

    }

    public class PlayListModel
    {
        public int PlayId { get; set; }
        public string Name { get; set; }
        public List<SongModel> SongsInPlayList { get; set; }
        public string createAt { get; set; }

        public PlayListModel(int playId, string name, List<SongModel> songmodel, string createat)
        {
            PlayId = playId;
            Name = name;
            SongsInPlayList = songmodel;
            createAt = createat;
        }
     
    }
}
