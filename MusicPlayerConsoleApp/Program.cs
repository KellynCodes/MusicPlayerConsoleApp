using MusicPlayerConsoleApp;

internal class Program
{
    public static void Main()
    {
        UserOperations userOperations = new();
        userOperations.AddPlayList();
        userOperations.AddSongs();










        Console.WriteLine("Do you wish to see list");
        string input = Console.ReadLine() ?? string.Empty;
        if (input.ToUpper() == "YES")
        {
            MusicPlayer.GetSongs();
        }
        else if (input.ToUpper() == "NO")
        {
            Console.WriteLine("You have canceled the application");
        }
        else
        {
            Console.WriteLine("Please choose NO/YES for us to be certain you want to close the application");
        }
    }
}
