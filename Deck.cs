using System;
using System.Collections.Generic;

namespace Blackjack
{
  public class Deck
  {
    public List<Card> Cards { get; set; } = new List<Card>();

    public void Shuffle()
    {
      for (var j = 51; j > 0; j--)
      {
        //create a random number generator
        Random rand1 = new Random();
        var v = rand1.Next(j);
        //shuffle deck in place
        var temp = Cards[j];
        Cards[j] = Cards[v];
        Cards[v] = temp;
      }
    }

    public void CreateDeck()
    {
      var suit = new List<string>() { "of Clubs", "of Diamonds", "of Spades", "of Hearts" };
      var rank = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
      var value = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };

      for (var i = 0; i < suit.Count; i++)
      {
        for (var n = 0; n < rank.Count; n++)
        {
          var card = new Card();
          card.Rank = rank[n];
          card.Suit = suit[i];
          Cards.Add(card);
          if (card.Rank == "Jack" || card.Rank == "Queen" || card.Rank == "King")
          {
            card.Value = 10;
          }
          else if (card.Rank == "Ace")
          {
            card.Value = 11;
          }
          else
          {
            card.Value = int.Parse(card.Rank);
          }
        }
      }
    }
    public Card DealCard()
    {
      // get the first card
      var dealtCard = Cards[0];
      // remove the card from the deck
      Cards.RemoveAt(0);

      return dealtCard;
    }

  }

}