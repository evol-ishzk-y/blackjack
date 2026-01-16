using blackjack;
using System;

const int Total_Cards = 52;
const int BurstScore = 21;

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
rand.Next(Total_Cards);

//配列の中身をシャッフルさせる
for (int i = 0; i < deck.Count; i++)
{
    int j = rand.Next(deck.Count);

    Card tmp = deck[i];
    deck[i] = deck[j];
    deck[j] = tmp;  
}

//playerHand作成
List<Card> playerHand = new List<Card>();

for (int i = 0;i < 2;i++)
{
    playerHand.Add(deck[0]);

    //山札から引いた分のカードを消す
    deck.RemoveAt(0);
}

//dealerHand作成
List<Card> dealerHand = new List<Card>();

for (int i = 0; i < 2; i++)
{
    dealerHand.Add(deck[0]);

    //山札から引いた分のカードを消す
    deck.RemoveAt(0);
}

//プレーヤーの手札を確認・計算
int playerScore = 0;

foreach(Card c in playerHand)
{
    Console.WriteLine("プレイヤーのカードは" + c.mark + "の" + c.num);

    if(c.num >= 10 && c.num <= 13)
    {
        playerScore += 10;
    }
    else
    {
        playerScore += c.num;
    }
}
Console.WriteLine("プレイヤーのカードの合計値は" + playerScore);

Console.WriteLine("もう一枚引きますか？　yes or no") ;

string command = Console.ReadLine()?.ToLower() ?? "";

while(command != "yes" && command != "no")
{
    Console.WriteLine("yesかnoで入力してください");
    command = Console.ReadLine()?.ToLower() ?? "";
}

while (command == "yes")
{
    Card drownCard = deck[0];
    //山札から引いた分のカードを消す
    deck.RemoveAt(0);
    Console.WriteLine("プレイヤーのカードの引いたカードは" + drownCard.mark + "の" + drownCard.num);

    if (drownCard.num >= 10 && drownCard.num <= 13)
    {
        playerScore += 10;
    }
    else
    {
        playerScore += drownCard.num;
    }

    //２１以上になったらバースト
    if(playerScore > BurstScore)
    {
        Console.WriteLine("プレイヤーのカードの合計値は" + playerScore);
        Console.WriteLine("バーストしました！");
        break;
    }

    Console.WriteLine("プレイヤーのカードの合計値は" + playerScore);
    Console.WriteLine("もう一枚引きますか？　yes or no");
    command = Console.ReadLine()?.ToLower() ?? "";
}

int dealerScore = 0;
int count = 0;

foreach (Card c in dealerHand)
{
    if(count == 1)
    {
        Console.WriteLine("ディーラーの2枚目のカードはわかりません");
    }
    else
    {
        Console.WriteLine("ディーラーのカードは" + c.mark + "の" + c.num);
    }

    if (c.num >= 10 && c.num <= 13)
    {
        dealerScore += 10;
    }
    else
    {
        dealerScore += c.num;
    }
    count++;
}

const int DealerStopScore = 17;

while (dealerScore < DealerStopScore)
{
    Card drownCard = deck[0];
    //山札から引いた分のカードを消す
    deck.RemoveAt(0);
    Console.WriteLine("ディーラーのカードの引いたカードは" + drownCard.mark + "の" + drownCard.num);

    if (drownCard.num >= 10 && drownCard.num <= 13)
    {
        dealerScore += 10;
    }
    else
    {
        dealerScore += drownCard.num;
    }

    //２１になったらバースト
    if (dealerScore > BurstScore)
    {
        Console.WriteLine("ディーラーのカードの合計値は" + dealerScore);
        Console.WriteLine("バーストしました！");
        break;
    }
}
Console.WriteLine("ディーラーのカードの合計値は" + dealerScore);

if (playerScore > BurstScore)
{
    Console.WriteLine("バーストしたのであなたの負けです");
}
else if(dealerScore > BurstScore)
{
    Console.WriteLine("ディーラーがバーストしたのであなたの勝ちです");
}
else if (playerScore > dealerScore)
{
    Console.WriteLine("プレイヤーの勝ちです");
}
else if (dealerScore == playerScore)
{
    Console.WriteLine("引き分けです");
}
else
{
    Console.WriteLine("ディーラーの勝ちです");
}
    
Console.WriteLine("Enterを押して終了"); // 何かキーが押されるまで画面を閉じない
Console.ReadLine();