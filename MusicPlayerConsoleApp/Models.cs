namespace MusicPlayerConsoleApp
{
    public class SongModel
    {
        public int SongId { get; set; }
        public string? Artist { get; set; }
        public string? SongName { get; set; }
        public string SongDate { get; set; }
        public double? SongDuration { get; set; }

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
        public static int SongInPlayListId { get; set; }
        public static string SongName { get; set; }
        public static string SongDate { get; set; }
        public static string Artist { get; set; }
        public static double SongDuration { get; set; }

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
            public static List<SongInPlayList> PlayListSongs { get; set; } = new List<SongInPlayList>()
            {
                new SongInPlayList(1, "Kelly Presh", "Purity", 0.5, UserOperations.CreatedDate),
                new SongInPlayList(2, "Kizz Daniel", "Buga", 1, UserOperations.CreatedDate),
                new SongInPlayList(3, "Kizz Daniel", "Cough", 0.1, UserOperations.CreatedDate),
                new SongInPlayList(4, "Tekno", "Go", 2, UserOperations.CreatedDate),
                new SongInPlayList(5, "Jusin Bieber", "Love You Forever", 1.5, UserOperations.CreatedDate)
            };
        public string CreateAt { get; set; }

            public PlayListModel(int playId, string name, List<SongInPlayList> playListSongs, string createat)
            {
                PlayId = playId;
                Name = name;
                PlayListSongs = playListSongs;
                CreateAt = createat;
            }

        }
    }
