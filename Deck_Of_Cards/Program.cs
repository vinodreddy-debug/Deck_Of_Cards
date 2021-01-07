using Deck_Of_Cards.Classes;
using Deck_Of_Cards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deck_Of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {

            Play();
            Console.WriteLine("Hurray! Game Completed");
            Console.ReadLine();
        }


        /// <summary>
        /// Play the game based on choice selected
        /// </summary>
        public static void Play()
        {
            Stack<Card> cards = Deck.CreateCards();

            while (cards.Count > 0)
            {

                //Get User/Player choice for each card
                int choice = AskSelection();

                //Logic Here
                switch (choice)
                {
                    case 1:
                        //Play Card
                        Console.WriteLine("Played card is " + Player.PlayCard(cards).DisplayName);
                        Console.WriteLine(" ");
                        break;
                    case 2:
                        //Shuffle only remaining cards
                        cards = Deck.Shuffle(cards);
                        Console.WriteLine("Cards shuffled successfully. Total shuffled cards is " + cards.Count);
                        Console.WriteLine(" ");
                        break;
                    case 3:
                        //restart - Fresh deck
                        cards = Deck.CreateCards();
                        Console.WriteLine("Game restarted");
                        Console.WriteLine(" ");
                        break;
                    default:
                        Console.WriteLine("Wrong choice");
                        Console.WriteLine(" ");
                        break;
                }
            }
        }


        /// <summary>
        /// Select Player input
        /// </summary>
        /// <returns>Return choice of player</returns>
        private static int AskSelection()
        {
            Console.WriteLine("Enter Choice");
            Console.WriteLine("1. Play Card");
            Console.WriteLine("2. Shuffle Cards");
            Console.WriteLine("3. Restart Game");

            int choice = 0;
            Int32.TryParse(Console.ReadLine(), out choice);
            if (choice <= 0 || choice > 3)
            {
                Console.WriteLine("Selection is wrong. Please enter valid choice");
                Console.WriteLine(" ");
                choice = AskSelection();
            }
            return choice;
        }



    }
}
