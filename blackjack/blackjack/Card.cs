using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    internal class Card
    {
        public string mark = "";
        public int num;

        public int NumberCard()
        {
            if (num >= 10 && num <= 13) return 10;
            return num;
        }
    }
}
