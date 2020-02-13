using System;
using System.Collections.Generic;

namespace Blackjack
{
  public class Program
  {
    public static int Total(List<Card> playerHand)
    {
      var total = 0;
      for (var i = 0; i < playerHand.Count; i++)
      {
        total = playerHand[0].GetValue() + playerHand[1].GetValue() + playerHand[i].GetValue();
      }
    }
    public static int Total2(List<Card> dealerHand)
    {
      var total = 0;
      for (var i = 0; i < dealerHand.Count; i++)
      {
        total = dealerHand[0].GetValue() + dealerHand[1].GetValue() + dealerHand[i].GetValue();
      }
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

      //deal first 4 cards
      dealerHand.Add(gameDeck.DealCard());
      dealerHand.Add(gameDeck.DealCard());
      playerHand.Add(gameDeck.DealCard());
      playerHand.Add(gameDeck.DealCard());

      // create var to hold truth val
      var hit = true;
      //while loop to run as long as hit == true
      while (hit == true)
      {
        for (var i = 0; i <= 48; i++)
        {
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
            Console.WriteLine($"Player total is now {playerHand.Total}.");
          }
        }

      }
    }
  }
}
