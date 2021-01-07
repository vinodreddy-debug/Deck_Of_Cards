using Deck_Of_Cards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deck_Of_Cards.Classes
{
    public static class Player
    {
        /// <summary>
        /// Play a card from the exisitng cards
        /// </summary>
        /// <param name="cards">Stack of available cards</param>
        /// <returns>returns the cards whohc has been played</returns>
        public static Card PlayCard(Stack<Card> cards)
        {
            return cards.Pop();

        }
    }
}
