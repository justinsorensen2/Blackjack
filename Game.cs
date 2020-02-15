using System;

namespace Blackjack
{
  public class Program2
  {
    public static void Game()
    {
      var replay = true;
      while (replay == true)
      {
        Console.WriteLine($"Would you like to play another hand? Valid Entries are (Y) or (N).");
        var playerInput = Console.ReadLine().ToUpper();
        if (playerInput != "Y" && playerInput != "N")
        {
          Console.WriteLine($"That is not a valid entry. Please try again.");
          playerInput = Console.ReadLine().ToUpper();
        }
        else if (playerInput == "N")
        {
          replay = false;
        }
        else
        {
          replay = false;
          Blackjack.Program.Main();
        }
      }
    }
  }
}
