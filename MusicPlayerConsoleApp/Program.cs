using MusicPlayerConsoleApp;
using System.Text;

internal class Program
{
    public static StringBuilder ChooseOption = new();
    public enum Choice
{
    choiceOne = 1,
    choiceTwo,
    choiceThree,
    choiceFour,
    choiceFive,
    choiceSix,
}

    public static void Main()
    {  //Availble song list
        Console.Title = "Welcome back KellynCodes";
        UserOperations.ViewListOfSongs();

        //user operations
       /* ChooseOption.AppendLine("What will you like to do\n 1.\t Add new song\n 2.\t Delete Song\n 3.\t Edit Song\n 4.\t Create Playlist\n 5.\t Play Song\n 6.\t Add Song to playlist");*/
        Console.WriteLine("What will you like to do\n 1.\t Add new song\n 2.\t Delete Song\n 3.\t Edit Song\n 4.\t Create Playlist\n 5.\t Play Song\n 6.\t Add Song to playlist");
    EnterChoice: Console.WriteLine(ChooseOption.ToString());
        string userChoice = Console.ReadLine() ?? string.Empty;
        if(int.TryParse(userChoice, out int choice))
        {
            switch (choice)
            {
                case (int)Choice.choiceOne: UserOperations.AddSong();
                    break;
                case (int)Choice.choiceTwo: UserOperations.RemoveSong();
                    break; 
                case (int)Choice.choiceThree: UserOperations.EditSong();
                    break;
                case (int)Choice.choiceFour: UserOperations.CreatePlayList();
                    break;
                case (int)Choice.choiceFive: UserOperations.SongPlayController();
                    break;
                case (int)Choice.choiceSix: UserOperations.AddSongToPlayList();
                    break;
                    default: Console.WriteLine("Invalid input. Enter only number in the Options");
                    Console.Clear();
                    goto EnterChoice;
            }
        }
        else
        {
            Console.Clear();
            UserOperations.ErrorMessage();
            goto EnterChoice;
        }


        //Do you want user to continue;
        /*===========================================*/
        question: Console.WriteLine("\nDo you want to quit");
        string input = Console.ReadLine() ?? string.Empty;
        if (input.ToUpper() == "YES")
        {
            Console.WriteLine("You have canceled the application");
        }
        else if (input.ToUpper() == "NO")
        {
            Console.Clear();
            Main();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Please choose NO/YES for us to be certain you wanted to close the application");
            goto question;
        }
    }
    //Choice message

}
