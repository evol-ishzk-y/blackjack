using blackjack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    internal class Deck
    {
        const int Total_Cards = 52;

        private List<Card> cards = new List<Card>();
        private Random rand = new Random();

        public Deck()
        {
            string[] markTypes = { "heart", "diamond", "spade", "clover" };

            foreach (string m in markTypes)
            {
                for (int i = 1; i <= 13; i++)
                {
                    Card c = new Card();
                    c.mark = m;
                    c.num = i;
                    cards.Add(c); // リストに追加
                }
            }
        }

        public void Shuffle()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                int j = rand.Next(cards.Count);
                Card tmp = cards[i];
                cards[i] = cards[j];
                cards[j] = tmp;
            }
        }

        public Card PassCard()
        {
            Card pickedCard = cards[0]; // 一番上のカードを確保
            cards.RemoveAt(0);          // 山札から削除
            return pickedCard;          // 確保したカードを外に渡す
        }
    }
}
