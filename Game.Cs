using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static Gofish_Game.Card;


namespace Gofish_Game
{
    class Game
    {
        /*************************PROPERTIES***************************************************/
        public List<Player> players { get; private set; }
        private Dictionary<Values, Player> books;

        // Creates the object Deck and its called stock 
        private Deck stock = new Deck();
        private List<Card> game_Deck;
        private RichTextBox TB;
        private Random random;

        /****************************CONSTRUCTOR************************************************/
        public Game (string playerName, IEnumerable<string> opponentNames, RichTextBox tb)
        {
            //  Lets create a new random once this class gets called
            //  Create new random
            random = new Random();

            //  RichTextbox oject tb is now TB. 
            TB = tb;


            //  A game deck object called stock is shuffled and then that is now 
            //  The game deck. 
            game_Deck = stock.deck_shuffled;


            //  Start a new instance of played
            /*******************Create the main player ***************************/
            players = new List<Player>
            {
                
                //this creates your instance in the player list 
                new Player(playerName, random, TB)
            };
            /********************************************************************/

            /********************Create a new player from the list of opponent names**********/
             foreach (String player in opponentNames)
            {
                players.Add(new Player(player, random, TB));
                books = new Dictionary<Values, Player>();
            }
             /********************************************************************************/
             /********************Now we give each player 5 cards*****************************/
             
            for (int a = 0; a < players.Count; a++)
            {
                players[a].playerHand = Deal();
            }
            /*********************************************************************************/
          
            
        }
        
        /************************************METHODS*****************************************/
        // Deal cards to all the players
        private List<Card> Deal()
        {
            //Foreach player in opponent players list
            //Five 5 Cards to the players 
            List<Card> PlayerCards = new List<Card>();
            for (int a = 0; a < 5; a++)
            {
                //give the player cards 
                int indx = random.Next(game_Deck.Count);
                PlayerCards.Add(game_Deck[indx]);
                //Now remove that index in cards
                game_Deck.RemoveAt(indx);

            }
            return PlayerCards;

        }

        public IEnumerable<string> GetPlayerCardNames()
        {
            return players[0].GetCardNames();
        }

        public void StartGame()
        {
            //Display player name
            //then display the cards each player has player[1] and player[2]
            string playerName = "";
            for (int a = 1; a< players.Count; a++)
            {
                playerName += players[a].Name + " has the following cards: " + Environment.NewLine;

                foreach(Card pCard in players[a].playerHand)
                {
                    playerName += pCard.Name + Environment.NewLine;
                }
                    
            }
            TB.Text = playerName;
        }
    }
}
