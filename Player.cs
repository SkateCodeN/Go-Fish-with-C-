using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static Gofish_Game.Card;



namespace Gofish_Game
{
    
    
    class Player
    {
        /**********CLASS REFERENCES**************/
                                    //
        //
        private RichTextBox TB;
        private Deck deck_cards;
        private Random random;
        public IEnumerable<Card> playerHand { get; set; }

        
        //
        //
        /**************************************/

        /**********PROPERTY********************/
        #region Old Name Property
        //From private string name;
        //      public string Name {get {return name;}}
        #endregion

        /// <summary>

        /// Read only meaning cant write to this Name Property
        /// This gets the name of the player
        /// </summary>
        public string Name { get; private set; }
        /***********CONSTRUCTOR***************************************/
                                    /// <summary>
        /// Player constructor 
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="rnd"></param>
        /// <param name="tb"></param>
        
        public Player (string playerName, Random rnd, RichTextBox tb)
        {
            random = rnd;
            deck_cards = new Deck();
            playerHand = new List<Card>();
            
            string welcomePlayer = " has joined the game";
            Name = playerName;
            
            tb.Text += Name + " " + welcomePlayer + Environment.NewLine;
            //instantiate the TextBox class tb and add a string 

            //TB = new RichTextBox();
            TB = tb;

            //TB.Text += Test();

            //cards = new Deck();
            //playerDeck = cards.PlayerCards;
            
        }

        /**************************************************************/

        #region test
            public string Test()
        {

            string sample = Name + " has these cards in his Hand: " + Environment.NewLine;
            foreach (Card cards in playerHand)
            {
                sample += cards.Name + Environment.NewLine;
            }

            return sample;
        }

        #endregion


        /// <summary>
        /// Player object has a reference to the Deck class and calls the SortByValue Method
        /// </summary>
        /**********METHODS********************************************/

        public void SortHand() { deck_cards.Sort(); }

        public IEnumerable<Values> PullOutBooks()
        {
            List<Values> books = new List<Values>();
            for (int i = 1; i <= 13; i++)
            {
                Values value = (Values)i;
                int howMany = 0;
                for (int card =0; card < 1; card++)
                {

                }
            }

            return books;

        }
        // This currently gets the name of all the card names in the deck, named deck cards, 
        //  Lets turn this into a method that shows a players cards. Ie the ones they currently have. 
        public IEnumerable<string> GetCardNames()
        {
            List<string> playerCards = new List<string>();
            foreach (Card cardName in playerHand)
            {
                playerCards.Add(cardName.Name);
            }
            return playerCards;
        }


        public int CardCount { get { return deck_cards.CardCount; } }



        /// <summary>
        /// A player asks for a value of a card to another player, if they have that
        /// value card then it is added to a list and then returned. 
        /// </summary>
        /// <param name="aCard"></param>
        /// <param name="aPlayer"></param>
        /// <returns></returns>
        public List<Card> askForCard (Values aCard, Player aPlayer)
        {
            List<Card> askedCards = new List<Card>();

           for(int i =0; i< aPlayer.playerHand.Count; i++)
            {
                if (aCard == aPlayer.playerHand[i].Value)
                {
                    askedCards.Add(aPlayer.playerHand[i]);
                }
                else
                    return null;
            }

            return askedCards;
        }

        /************************************************************/
    }
}
