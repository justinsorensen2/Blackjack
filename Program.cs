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
        total += Hand[i].GetValue();
      }
      return total;
    }
    public static int GetScore(List<Card> Hand)
    {
      var score = 0;
      for (var i = 2; i < Hand.Count; i++)
      {
        score = Total(Hand) + Hand[i].GetValue();
      }

      return score;
    }
    public static void Main(string[] args)
    {
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
      dealerHand.Add(gameDeck.DealCard());
      playerHand.Add(gameDeck.DealCard());
      playerHand.Add(gameDeck.DealCard());

      // create var to hold truth val and vars to hold totals
      var hit = true;
      var totalP = Total(playerHand);
      var totalD = Total(dealerHand);


      //display user cards and total
      Console.WriteLine($"Player, you have the {playerHand[0].Rank} of {playerHand[0].Suit} and {playerHand[1].Rank} of {playerHand[1].Suit}.");
      Console.WriteLine($"Your total is {totalP}.");
      //while loop to run as long as hit == true
      //allowing player to hit or stand and display totals
      var playerLoop = 1;
      while (hit == true)
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
        }
        else if (totalP > 21)
        {
          Console.WriteLine("Bust! Dealer wins.");
          Console.WriteLine("Thank you for playing!");
          hit = false;
        }
        // else if (totalP == 21)
        // {
        //   hit = false;
        // }
        else
        {
          Console.WriteLine($"Player stands. Player total is now {totalP}.");
          Console.WriteLine($"Dealer has {dealerHand[0].Rank} of {dealerHand[0].Suit} and {dealerHand[1].Rank} of {dealerHand[1].Suit}.");
          hit = false;
        }

      }
      var dealerTurn = true;
      var dealerLoop = 1;
      Console.WriteLine($"Dealer, you have been dealt the {dealerHand[dealerLoop].Rank} of {dealerHand[dealerLoop].Suit}.");
      // if (totalP == 21)
      // {
      //   Console.WriteLine("BlackJack! You win!");
      //   Console.WriteLine("Thank you for playing!");
      // }

      while (dealerTurn == true)
      {
        if (totalD <= 16)
        {
          dealerLoop++;
          Console.WriteLine($"Dealer total is {totalD}. Dealer automatically hits.");
          dealerHand.Add(gameDeck.DealCard());
          totalD = totalD + dealerHand[dealerLoop].GetValue();
          Console.WriteLine($"Dealer total is now {totalD}.");
        }
        else if (totalD < 18)
        {
          dealerLoop++;
          Console.WriteLine($"Dealer total is {totalD}. Dealer decides to hit.");
          dealerHand.Add(gameDeck.DealCard());
          totalD = totalD + dealerHand[dealerLoop].GetValue();
          Console.WriteLine($"Dealer total is now {totalD}.");

        }
        else if (totalD > 21)
        {
          Console.WriteLine("Dealer Bust! Player wins.");
          Console.WriteLine("Thank you for playing!");
          dealerTurn = false;
        }
        else if (totalD > 21)
        {
          Console.WriteLine("Dealer Bust! Player wins.");
          Console.WriteLine("Thank you for playing!");
          dealerTurn = false;
        }
        else if (totalD > 21)
        {
          Console.WriteLine("Dealer Bust! Player wins.");
          Console.WriteLine("Thank you for playing!");
          dealerTurn = false;
        }
        else if (((totalD == 21) && (totalP == 21)) || (totalD == totalP))
        {
          Console.WriteLine("Tie Game!.");
          Console.WriteLine("Thank you for playing!");
          dealerTurn = false;
        }
        // else if ((totalD == 21) && (totalP != 21))
        // {
        //   Console.WriteLine("Blackjack! Dealer wins.");
        //   Console.WriteLine("Thank you for playing!");
        //   dealerTurn = false;
        // }
        else if (((totalD == 21) && (totalP == 21)) || (totalD == totalP))
        {
          Console.WriteLine("Tie Game!.");
          Console.WriteLine("Thank you for playing!");
          dealerTurn = false;
        }
        else
        {
          var compD = 21 - totalD;
          var compP = 21 - totalP;
          if (compP < compD)
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
            Console.WriteLine($"Dealer wins!!");
          }
          Console.WriteLine("Thank you for playing!");
          dealerTurn = false;
        }
      }
    }
  }
}





