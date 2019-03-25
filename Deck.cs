using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gofish_Game.Card;

namespace Gofish_Game
{
    class Deck
    {
        private List <Card> cards;
        private Random random = new Random();
        public List<Card>  deck_shuffled { get; private set; }

        public int CardCount { get { return deck_shuffled.Count; }  }
        

        /**************CONSTRUCTOR***********************/

        // 
        public Deck()
        {
            // Creat the Deck of cards in list form
            cards = new List<Card> ();
            // Get all of these cards in order and place them on the cards list
            cards = GetDeck();
            //shuffle the deck!
            cards = Shuffle(cards);
            //return the list to a public list to only read
            deck_shuffled = cards;

            /*
            for (int a = 0; a < 4; a++)
            {
                //give the player cards
                int indx = random.Next(cards.Count);
                PlayerCards.Add(cards[indx]);
                //Now remove that index in cards
                cards.RemoveAt(indx);

            }
            */

        }

        /************************************************/
                        #region failed_for_loops 3/1/19
        /*

        //      further digressing this code (step in F11)
        //      reveals behaviour of deck[1] being the only location modified.

        //      so Program class does not really output anything when I call this string[] array

        public string[] deckCards()
        {
            string[] deck = new string[54];
            
            for (int a = 0; a < 4; a++)
            {
                for (int b = 1; b < 14; a++ )
                {
                    card = new Card((Suits)a, (Values)b);
                    deck[b] = card.Name;
                }
            }

            return deck;
        }
        */
        #endregion


        /******************METHODS****************************/
        /// <summary>
        /// Method that returns a deck of cards all 52 in order. according to Card Enums Values and suits.
        /// </summary>
        /// <returns></returns>
        private List<Card> GetDeck()
        {
            
            
            List<Card> Deck = new List<Card>();

            foreach (Suits suits in Enum.GetValues(typeof(Suits)))
            {
                foreach (Values values in Enum.GetValues(typeof(Values)))
                {
                    Card card = new Card(suits, values);
                    Deck.Add(card);
                }
            }

            
            

            return Deck;
        }

        /// <summary>
        /// Method of List<card> that takes a list of card items and shuffles
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private List<Card> Shuffle(List<Card> cards)
        {
            List<Card> shuffleDeck = new List<Card>();

            while (cards.Count > 0)
            {
                int cardToMove = random.Next(cards.Count);
                shuffleDeck.Add(cards[cardToMove]);
                cards.RemoveAt(cardToMove);
            }
            return shuffleDeck;
        }

        //      This is just a test
        //      public string Test => "Hello there";


        /// <summary>
        /// Calls out the Class to compare by suits
        /// </summary>
        public void Sort()
        {
            cards.Sort(new CardCompare_BySuit());
        }

        /// <summary>
        /// A robust list of strings that gets all the names of the cards in the deck. 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetCardNames()
        {
            // Old For code
            /*
            string[] cardsIhave = new string[deck_shuffled.Count];
                for(int i =0; i< deck_shuffled.Count; i++)
                {
                    cardsIhave[i] = deck_shuffled[i].Name;
                }
                */
            List<string> cardsIhave = new List<string>();

            foreach (Card testcard in deck_shuffled)
                cardsIhave.Add(testcard.Name);

            return cardsIhave;
        }

        /// <summary>
        /// Choose and index in the deck and you get to see the card at the index of the deck.
        /// </summary>
        /// <param name="Number"></param>
        /// <returns></returns>
        public Card Peek(int Number)
        {
            return deck_shuffled[Number];
        }

        /**********************************************************/
    }



    class CardCompare_BySuit: IComparer <Card>
    {
        public int Compare(Card x, Card y)
        {
            if (x.Suit > y.Suit)
                return 1;
            if (x.Suit < y.Suit)
                return -1;
            if (x.Value > y.Value)
                return 1;
            if (x.Value < y.Value)
                return -1;

            return 0;
        }
    }
}
