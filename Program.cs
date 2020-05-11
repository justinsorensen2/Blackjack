using System;
using System.Collections.Generic;

namespace Blackjack
{
  public class Program
  {
    public static int Total(List<Card> Hand)
    {
      var total = 0;
      for (var i = 0; i < Hand.Count; i++)
      {
        total += Hand[i].Value;
      }
      return total;
    }
    public static void DisplayHand(List<Card> Hand)
    {
      for (int i = 0; i < Hand.Count; i++)
      {
        Console.WriteLine($"{Hand[i].DisplayCard()}");
      }
    }
    // public static int SetAceValue(List<Card> Hand)
    // {
    //   var aceValue = 0;
    //   for (var i = 0; i < Hand.Count; i++)
    //   {
    //     if (Hand[i].GetValue() == 11)
    //     {
    //       Console.WriteLine($"You have been dealt an Ace. You may set its value to one(1) or eleven(11).");
    //       Console.WriteLine($"Please enter the desired value. Valid entries are 1 or 11.");
    //       aceValue = int.Parse(Console.ReadLine());
    //       if (aceValue != 1 && aceValue != 11)
    //       {
    //         Console.WriteLine($"That is not a valid selection. Pease try again.");
    //         aceValue = int.Parse(Console.ReadLine());
    //       }
    //       else if (aceValue == 11)
    //       {
    //         return 11;
    //       }
    //       else
    //       {
    //         return 1;
    //       }
    //     }
    //     else
    //     {
    //       return Hand[i].GetValue();
    //     }
    //   }
    // }
    public static void Main()
    {
      //clear the console at the beginning of each game
      Console.Clear();
      //declare dealer and player hand lists
      var dealerHand = new List<Card>();
      var playerHand = new List<Card>();

      // declare then create deck
      var gameDeck = new Deck();

      gameDeck.CreateDeck();

      //shuffle
      gameDeck.Shuffle();

      //deal first 4 cards and add totals
      dealerHand.Add(gameDeck.DealCard());
      playerHand.Add(gameDeck.DealCard());
      dealerHand.Add(gameDeck.DealCard());
      playerHand.Add(gameDeck.DealCard());

      // create var to hold truth val and vars to hold totals
      var hit = true;
      var totalP = Total(playerHand);
      var totalD = Total(dealerHand);
      //display user cards and total
      Console.WriteLine($"Dealer's second card is the {dealerHand[1].Rank} of {dealerHand[1].Suit}.");
      Console.WriteLine($"Player, you have the:");
      DisplayHand(playerHand);
      Console.WriteLine($"Your total is {totalP}.");
      //check for blackjack and set var = true, if blackjack exists
      var pBlackjack = false;
      if (totalP == 21)
      {
        pBlackjack = true;
      }
      else
      {
        pBlackjack = false;
      }
      //while loop to run as long as hit == true
      //allowing player to hit or stand and display totals
      var playerLoop = 1;
      while (pBlackjack == false && hit == true)
      {
        playerLoop++;
        Console.WriteLine($"Player, would you like to hit(H) or stand(S)? Valid entries are H or S.");
        var hitOrStand = Console.ReadLine().ToUpper();

        if (hitOrStand != "H" && hitOrStand != "S")
        {
          Console.WriteLine($"That is not a valid entry please try again.");
          hitOrStand = Console.ReadLine().ToUpper();
        }
        else if (hitOrStand == "H")
        {
          playerHand.Add(gameDeck.DealCard());
          totalP = totalP + playerHand[playerLoop].GetValue();
          Console.WriteLine($"Player, you have been dealt the {playerHand[playerLoop].Rank} of {playerHand[playerLoop].Suit}.");
          Console.WriteLine($"Player total is now {totalP}.");
          if (totalP > 21)
          {
            Console.WriteLine($"Dealer has:");
            DisplayHand(dealerHand);
            Console.WriteLine($"Dealer total is {totalD}.");
            hit = false;
          }
          else if (totalP == 21)
          {
            Console.WriteLine($"Dealer has {dealerHand[0].Rank} of {dealerHand[0].Suit} and {dealerHand[1].Rank} of {dealerHand[1].Suit}.");
            hit = false;
          }
          else
          {
            hit = true;
          }
        }
        else
        {
          Console.WriteLine($"Player stands. Player total is now {totalP}.");
          Console.WriteLine($"Dealer has:");
          DisplayHand(dealerHand);
          hit = false;
        }
      }
      // set var to hold dealer Blackjack condition, check for Blackjack conditions with player
      var dBlackjack = true;
      if ((totalD == 21) && (pBlackjack = false))
      {
        Console.WriteLine("Blackjack! Dealer wins. You lose.");
        dBlackjack = true;
      }
      else
      {
        dBlackjack = false;
      }
      // run dealer turn until dealer has at least 17
      var dealerLoop = 1;
      while (dBlackjack == false)
      {
        if (totalD <= 16)
        {
          dealerLoop++;
          Console.WriteLine($"Dealer total is {totalD}. Dealer automatically hits.");
          dealerHand.Add(gameDeck.DealCard());
          Console.WriteLine($"Dealer, you have been dealt the {dealerHand[dealerLoop].Rank} of {dealerHand[dealerLoop].Suit}.");
          totalD = totalD + dealerHand[dealerLoop].GetValue();
          Console.WriteLine($"Dealer total is now {totalD}.");
        }
        else
        {
          dBlackjack = true;
        }
      }
      //check win conditions
      if ((pBlackjack = true) && (dBlackjack = false))
      {
        Console.WriteLine("Blackjack! You win! Congrats!");
      }
      else if ((pBlackjack = false) && (dBlackjack = true))
      {
        Console.WriteLine("Blackjack! Dealer wins. You lose.");
      }
      else if (totalD > 21 && totalP <= 21)
      {
        Console.WriteLine("Dealer Bust! Player wins.");
      }
      else if (totalD == 21 && totalP != 21)
      {
        Console.WriteLine("Dealer wins! You lose.");
      }
      else if (totalD == totalP)
      {
        Console.WriteLine("It's a push!");
      }
      else if (totalP > 21 && totalD <= 21)
      {
        Console.WriteLine("Bust! Dealer wins.");
      }
      else
      {
        if (totalD < totalP)
        {
          Console.WriteLine($"Dealer stands.");
          Console.WriteLine($"Dealer total is now {totalD}.");
          Console.WriteLine($"Player total is now {totalP}.");
          Console.WriteLine($"Player wins!!");
        }
        else
        {
          Console.WriteLine($"Dealer stands.");
          Console.WriteLine($"Dealer total is now {totalD}.");
          Console.WriteLine($"Player total is now {totalP}.");
          Console.WriteLine($"Dealer wins!! You lose.");
        }
      }
      //thank player and call method to ask if they want to play again
      Console.WriteLine("Thank you for playing!");
      Blackjack.Program2.Game();
    }
  }
}






