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
}
