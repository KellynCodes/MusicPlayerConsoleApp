using MusicPlayerConsoleApp;

internal class Program
{
    public enum Choice
{
    choiceOne = 1,
    choiceTwo,
    choiceThree,
    choiceFour,
    choiceFive,
}

    public static void Main()
    {  //Availble song list
        UserOperations.ViewListOfSongs();

        //user operations
        EnterChoice: ChooseChoice();
        string userChoice = Console.ReadLine() ?? string.Empty;
        if(int.TryParse(userChoice, out int choice))
        {
            switch (choice)
            {
                case (int)Choice.choiceOne: UserOperations.AddSong();
                    break;
                case (int)Choice.choiceFive: UserOperations.RemoveSong();
                    break;
            }
        }
        else
        {
            UserOperations.ErrorMessage();
            goto EnterChoice;
        }

      
        //Do you want user to continue;
        /*===========================================*/
        Console.WriteLine("Do you wish to see list");
        string input = Console.ReadLine() ?? string.Empty;
        if (input.ToUpper() == "YES")
        {
            Console.Clear();
            Main();
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
    //Choice message
    public static void ChooseChoice()
    {
        Console.WriteLine("What will you like to do\n");
        Console.WriteLine("1.\t Add new song");
        Console.WriteLine("2.\t Create Playlist");
        Console.WriteLine("3.\t Play Song");
        Console.WriteLine("4.\t Edit Song");
        Console.WriteLine("5.\t Delete Song");
    }

}
