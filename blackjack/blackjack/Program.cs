using blackjack;
using System;

//Listの山札作成
List<Card> deck = new List<Card>();

//マークを格納
string[] markTypes = {"heart", "diamond", "spade", "clover"};

foreach (string m  in markTypes)
{
    for(int i = 1; i <= 13; i++ )
    {
        Card c = new Card();
        c.mark = m;
        c.num = i;
 
        //deckに５２枚のカードをいれる
        deck.Add(c);
    }
}

//Listのインデックスをシャッフル
Random rand = new Random();
rand.Next(52);

//配列の中身をシャッフルさせる
for (int i = 0; i < deck.Count; i++)
{
    int j = rand.Next(deck.Count);

    Card tmp = deck[i];
    deck[i] = deck[j];
    deck[j] = tmp;  
}