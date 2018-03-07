using System;
using System.Collections.Generic;
namespace DeckOfCards
{
    public class Player
    {
        string name; //Give the player class a name property
        public List<Card> hand; // Give the player a hand property that is a List of type Card

        public Player(string person)
        {
            name = person;
            hand = new List<Card>();
        }

        public Card draw (Deck addhand) //Give the player a draw method this needs to reference the Deck object
        {
            Card newCard = addhand.deal();
            hand.Add(newCard);
            return newCard;
        }

        public Card discard(int idx)
        {
            if (idx < 0 || idx > hand.Count) {
                System.Console.WriteLine("Discard dis");
                return null;
            } else {
                Card shuffle = hand[idx];
                hand.RemoveAt(idx);
                return shuffle;
            }
        }
    }
}    