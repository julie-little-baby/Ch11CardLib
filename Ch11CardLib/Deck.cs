using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11CardLib
{
    public class Deck : ICloneable
    {
        private Cards cards = new Cards();
        public Deck()
        {
            for(int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }
        }

        public Deck(bool isAceHigh) : this()
        {
            Card.isAceHigh = isAceHigh;
        }

        public Deck(bool useTrumps, Suit trump) : this()
        {
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }

        public Deck(bool isAceHigh, bool useTrumps, Suit trump) : this()
        {
            Card.isAceHigh = isAceHigh;
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }

        public Deck(Cards newCards)
        {
            cards = newCards;
        }

        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)
                return cards[cardNum];
            else
                throw new System.ArgumentOutOfRangeException("cardNum", cardNum, "Value must be between 0 and 51.");
        }


        public void Shuffle()
        {
            Cards newDeck = new Cards();
            bool[] assigned = new bool[52];
            Random sourceGen = new Random();
            for (int i = 0; i < 52; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(52);
                    if (assigned[sourceCard] == false)
                        foundCard = true;
                }
                assigned[sourceCard] = true;
                newDeck.Add(cards[sourceCard]);
            }
            newDeck.CopyTo(cards);

        }

        public object Clone()
        {
            Deck newDeck = new Deck((Cards)cards.Clone());

            return newDeck;
        }



        //    private Card[] cards;
        //    public Deck()
        //    {
        //        cards = new Card[52];
        //        for (int suitVal = 0; suitVal < 4; suitVal++)
        //        {
        //            for (int rankVal = 1; rankVal < 14; rankVal++)
        //            {
        //                cards[suitVal * 13 + rankVal - 1] = new Card((Suit)suitVal, (Rank)rankVal);
        //            }
        //        }
        //    }

        //    public Card getCard(int cardNum)
        //    {
        //        if (cardNum >= 0 && cardNum <= 51)
        //            return cards[cardNum];
        //        else
        //            throw (new System.ArgumentOutOfRangeException("cardNum", cardNum, "Value must be between 0 and 51."));
        //    }

        //    public void Shuffle()
        //    {
        //        Card[] newDeck = new Card[52];
        //        bool[] assigned = new bool[52];
        //        Random sourceGen = new Random();
        //        for (int i = 0; i < 52; i++)
        //        {
        //            int destCard = 0;
        //            bool foundCard = false;
        //            while (foundCard == false)
        //            {
        //                destCard = sourceGen.Next(52);
        //                if (assigned[destCard] == false)
        //                    foundCard = true;
        //            }
        //            assigned[destCard] = true;
        //            newDeck[destCard] = cards[i];
        //        }
        //        newDeck.CopyTo(cards, 0);

        //    }

    }
}
