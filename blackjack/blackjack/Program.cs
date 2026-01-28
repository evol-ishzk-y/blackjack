using blackjack;
using System;

const int BurstScore = 21;

Deck deck = new Deck();
deck.Shuffle();

Player player = new Player();
Player dealer = new Player();

//最初の二枚配る
for (int i = 0; i < 2; i++)
{
    player.AddCard(deck.passCard());
    dealer.AddCard(deck.passCard());
}

foreach(Card c in player.hand)
{
    Console.WriteLine("プレイヤーのカードは" + c.mark + "の" + c.num);
}
Console.WriteLine("プレイヤーのカードの合計値は" + player.GetTotalScore());

Console.WriteLine("もう一枚引きますか？　yes or no") ;

string command = AskYesNo();

while (command == "yes")
{
    Card drownCard = deck.passCard();
    Console.WriteLine("プレイヤーのカードの引いたカードは" + drownCard.mark + "の" + drownCard.num);
    player.AddCard(drownCard);

    //２１以上になったらバースト
    if (player.GetTotalScore() > BurstScore)
    {
        Console.WriteLine("プレイヤーのカードの合計値は" + player.GetTotalScore());
        Console.WriteLine("バーストしました！");
        break;
    }

    Console.WriteLine("プレイヤーのカードの合計値は" + player.GetTotalScore());
    Console.WriteLine("もう一枚引きますか？　yes or no");
    command = AskYesNo();
}

int count = 0;

foreach (Card c in dealer.hand)
{

    if (count == 1)
    {
        Console.WriteLine("ディーラーの2枚目のカードはわかりません");
    }
    else
    {
        Console.WriteLine("ディーラーのカードは" + c.mark + "の" + c.num);
    }
    count++;
}

const int DealerStopScore = 17;

while (dealer.GetTotalScore() < DealerStopScore)
{
    Card drownCard = deck.passCard();
    Console.WriteLine("ディーラーのカードの引いたカードは" + drownCard.mark + "の" + drownCard.num);
    dealer.AddCard(drownCard);

    //２１になったらバースト
    if (dealer.GetTotalScore() > BurstScore)
    {
        Console.WriteLine("ディーラーのカードの合計値は" + dealer.GetTotalScore());
        Console.WriteLine("バーストしました！");
        break;
    }
}
Console.WriteLine("ディーラーのカードの合計値は" + dealer.GetTotalScore());

if (player.GetTotalScore() > BurstScore)
{
    Console.WriteLine("バーストしたのであなたの負けです");
}
else if(dealer.GetTotalScore() > BurstScore)
{
    Console.WriteLine("ディーラーがバーストしたのであなたの勝ちです");
}
else if (player.GetTotalScore() > dealer.GetTotalScore())
{
    Console.WriteLine("プレイヤーの勝ちです");
}
else if (dealer.GetTotalScore() == player.GetTotalScore())
{
    Console.WriteLine("引き分けです");
}
else
{
    Console.WriteLine("ディーラーの勝ちです");
}
    
Console.WriteLine("Enterを押して終了"); // 何かキーが押されるまで画面を閉じない
Console.ReadLine();

string AskYesNo()
{
    string input = Console.ReadLine()?.ToLower() ?? "";
    while (input != "yes" && input != "no")
    {
        Console.WriteLine("yesかnoで入力してください");
        input = Console.ReadLine()?.ToLower() ?? "";
    }
    return input;
}