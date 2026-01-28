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

        // 1. クラスの持ち物（フィールド）を定義
        private List<Card> cards = new List<Card>();
        private Random rand = new Random();

        // 2. コンストラクタ（Deckが作られた瞬間に動く）
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

        // 3. シャッフル機能
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

        // 4. カードを1枚渡す機能（Card型を返す）
        public Card passCard()
        {
            Card pickedCard = cards[0]; // 一番上のカードを確保
            cards.RemoveAt(0);          // 山札から削除
            return pickedCard;          // 確保したカードを外に渡す
        }
    }
}
