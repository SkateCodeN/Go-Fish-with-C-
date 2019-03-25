// This is the Fice class 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gofish_Game
{
    class Card
    {
                    //      Enums part of the Data Type
        //      Think of enums as a sort of dictionary that has values, one can assign 'value' to these defenitions
        //      
        //      Lets look at our code in the following Card class. we define the types of cards there are and the values each card represents.


        //      This is how you declare an enum, almost like a property.  enum [name] { v1, v2, } 

        //      Here this enum just has definitions for the various suits the card class contains

        //      2/28/19 Edit We have to make these enums public otherwise it is not seen in the scope of the class Card
        /**************ENUMS****************************/
        public enum Suits
        {
            Spades,
            Dimonds,
            Clubs,
            Hearts,

        }

        //      By Default we have values such as Ace = 1, so the defention Ace in the Values Enum equals (int) of 1.
        public enum Values
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,

        }
        /***********************************************/

                    #region comments on Enums
        //      However we can make the default defenitions value (int) to another value data type
        //      Other value data types : Double, float, decimal, long 
        //      Edit: Strings are a  little more tricky

        // Code Example : enum Example : long {v1,v2, example = 20000000,}

        //      These properties are responsible to get to the enums
        #endregion

        /************PROPERTIES***************************/
        //  Added a little more encapsulation to these properties as the cards Suits and values can only be seen by other classes
        //  and not to be overriden.
        public Suits Suit { get; private set; }
        public Values Value { get; private set; }

        //      Name is a property that returns a string  ex "King of Spades"
        public string Name => Value.ToString() + " of " + Suit.ToString();

        /************************************************/

        /***********CONSTRUCTOR**************************/

        public Card(Suits suit, Values value)
        {
            Suit = suit;
            Value = value;
        }

        /************************************************/

        
        /*********METHODS********************************/
        
        /************************************************/

    }
}

