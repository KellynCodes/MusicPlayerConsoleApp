namespace MusicPlayerConsoleApp
{
    public class SongModel
    {
        public int SongId { get; set; }  
        public string? Artist { get; set; }
        public string? SongName { get; set; }
        public string SongDate { get; set; }

        public SongModel(int id, string artist, string songname, string songdate)
        {
            SongId = id;
            Artist = artist;
            SongName = songname;
            SongDate = songdate;
        }

    }
}
