using Deck_Of_Cards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deck_Of_Cards.Classes
{
    public static class Deck
    {

        /// <summary>
        /// Create fresh deck of shuffled cards
        /// </summary>
        /// <returns>shuffled deck of cards in stack</returns>
        public static Stack<Card> CreateCards()
        {
            Stack<Card> cards = new Stack<Card>();
            for (int i = 2; i <= 14; i++)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    cards.Push(new Card()
                    {
                        Suit = suit,
                        Value = i,
                        DisplayName = GetShortName(i, suit)
                    });
                }
            }
            return Shuffle(cards);
        }


        /// <summary>
        /// Shuffle the given stack of cards
        /// </summary>
        /// <param name="cards">Cards to be shuffled</param>
        /// <returns>Stack of shuffled cards</returns>
        public static Stack<Card> Shuffle(Stack<Card> cards)
        {
            //Shuffle the existing cards
            List<Card> transformedCards = cards.ToList();
            Random r = new Random(DateTime.Now.Millisecond);
            for (int n = transformedCards.Count - 1; n > 0; --n)
            {
                //Step 2: Randomly pick a card which has not been shuffled
                int k = r.Next(n + 1);

                //Step 3: Swap the selected item with the last "unselected" card in the collection
                Card temp = transformedCards[n];
                transformedCards[n] = transformedCards[k];
                transformedCards[k] = temp;
            }

            Stack<Card> shuffledCards = new Stack<Card>();
            foreach (var card in transformedCards)
            {
                shuffledCards.Push(card);
            }

            return shuffledCards;
        }


        /// <summary>
        /// Used to Generate friedly name for a given value and suit(Card)
        /// </summary>
        /// <param name="value">Value of a card</param>
        /// <param name="suit">Card suit/symbol</param>
        /// <returns>Returns a friendly name of the card</returns>
        private static string GetShortName(int value, Suit suit)
        {
            string valueDisplay = "";
            if (value >= 2 && value <= 10)
            {
                valueDisplay = value.ToString();
            }
            else if (value == 11)
            {
                valueDisplay = "Jockey";
            }
            else if (value == 12)
            {
                valueDisplay = "Queen";
            }
            else if (value == 13)
            {
                valueDisplay = "King";
            }
            else if (value == 14)
            {
                valueDisplay = "Ace";
            }

            return valueDisplay +" "+ Enum.GetName(typeof(Suit), suit);
        }
    }
}
