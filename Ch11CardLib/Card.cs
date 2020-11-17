using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11CardLib
{
    public class Card : ICloneable
    {
        public readonly Rank rank;
        public readonly Suit suit;

        public static bool useTrumps = false;
        public static Suit trump = Suit.Club;
        public static bool isAceHigh = true;

        private Card()
        {

        }

        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }

        public override String ToString()
        {
            return "The " + rank + "of" + suit + "s";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public static bool operator ==(Card card1, Card card2)
        {
            return (card1? .suit == card2? .suit) && (card1? .rank == card2? .rank);
        }

        public static bool operator !=(Card card1, Card card2)
        {
            return (card1?.suit != card2?.suit) || (card1?.rank != card2?.rank);
        }

        public override bool Equals(object obj)
        {
            return (this == (Card)obj);
        }

        public override int GetHashCode()
        {
            return 13 * (int)suit + (int)rank;
        }

        public static bool operator >(Card card1, Card card2)
        {
            if (card1.suit == card2.suit)
            {
                if (isAceHigh)
                {
                    if (card1.rank == Rank.Ace)
                    {
                        if (card2.rank == Rank.Ace)
                        {
                            return false;
                        }
                        else
                            return true;
                    }
                    else
                    {
                        if (card2.rank == Rank.Ace)
                            return false;
                        else
                            return (card1.rank > card2?.rank);
                    }
                }
                else
                    return (card1.rank > card2.rank);
            }
            else
            {
                if (useTrumps && (card2.suit == Card.trump))
                    return false;
                else
                    return true;
            }
        }

        public static bool operator <(Card card1, Card card2)
        {
            return !(card1 > card2);
        }

        public static bool operator >=(Card card1, Card card2)
        {
            if (card1.suit == card2.suit)
            {
                if (isAceHigh)
                {
                    if (card1.rank == Rank.Ace)
                    {
                        return true;
                    }
                    else
                    {
                        if (card2.rank == Rank.Ace)
                            return false;
                        else
                            return (card1.rank >= card2.rank);
                    }
                }
                else
                {
                    return (card1.rank >= card2.rank);
                }
            }
            else
            {
                if (useTrumps && (card2.suit == Card.trump))
                    return false;
                else
                    return true;
            }
        }

        public static bool operator <=(Card card1, Card card2)
        {
            return !(card1 >= card2);
        }

    }
}
