using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    internal class Player
    {
        public List<Card> hand = new List<Card>();

        public void AddCard(Card card)
        {
            hand.Add(card);
        }

        public int GetTotalScore()
        {
            int total = 0;
            foreach (Card card in hand)
            {
                total += card.GetCard(); 
            }
            return total;
        }
    }
}
