using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace Ch11CardLib
{
    public class Cards : CollectionBase, ICloneable  
    {
        public Cards()
        {
            
        }

        public void Add(Card newCard)
        {
            List.Add(newCard);
        }

        public void Remove(Card oldCard)
        {
            List.Remove(oldCard);
        }

        public Card this[int cardIndex]
        {
            get { return (Card)List[cardIndex]; }
            set { List[cardIndex] = value; }
        }

        public void CopyTo(Cards targetCards)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetCards[index] = this[index];
            }
        }

        public bool Contains(Card card) => InnerList.Contains(card);

        public object Clone()
        {
            Cards clonedCards = new Cards();
            foreach (Card oldCard in this)
            {
                clonedCards.Add((Card)(oldCard.Clone()));
            }

            return clonedCards;
        }
       
    }
}