using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter2
{

    /// <summary>
    /// Another way to access data in a class is with an indexer,
    /// which enables instances of your class or struct to be used like arrays. 
    /// This is useful when your object contains data that resembles a collection. 
    /// 
    /// For example, imagine that you are creating a class to play a card game.
    /// You have a Deck class that contains a collection of cards.
    /// 
    /// This program shows an example implementation.
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            var deck = new Deck(
                new List<Card>() { 
                    new Card() { Value = 4 },
                    new Card() { Value = 5 }
                }
             );

            Console.WriteLine("Card value: {0}", deck[0].Value);
            Console.ReadLine();
        }
    }

    public class Card
    {
        public int Value { get; set; }
    }

    /// <summary>
    /// You can access the elements inside the list by using the [] notations. 
    /// You can also implement this on your own classes. For the Deck class, use the following:
    /// </summary>
    public class Deck
    {
        public ICollection<Card> Cards { get; private set; }

        public Deck(ICollection<Card> cards)
        {
            Cards = cards;
        }

        public Card this[int index]
        {
            get { return Cards.ElementAt(index); }
        }
    }
}
