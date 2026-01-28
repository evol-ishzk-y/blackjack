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
    player.HandCard(deck.PassCard());
    dealer.HandCard(deck.PassCard());
}

foreach(Card c in player.hand)
{
    Console.WriteLine("プレイヤーのカードは" + c.mark + "の" + c.num);
}
Console.WriteLine("プレイヤーのカードの合計値は" + player.AddTotalScore());

Console.WriteLine("もう一枚引きますか？　yes or no") ;

string command = AskYesNo();

while (command == "yes")
{
    Card drownCard = deck.PassCard();
    Console.WriteLine("プレイヤーのカードの引いたカードは" + drownCard.mark + "の" + drownCard.num);
    player.HandCard(drownCard);

    //２１以上になったらバースト
    if (player.AddTotalScore() > BurstScore)
    {
        Console.WriteLine("プレイヤーのカードの合計値は" + player.AddTotalScore());
        Console.WriteLine("バーストしました！");
        break;
    }

    Console.WriteLine("プレイヤーのカードの合計値は" + player.AddTotalScore());
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

while (dealer.AddTotalScore() < DealerStopScore)
{
    Card drownCard = deck.PassCard();
    Console.WriteLine("ディーラーのカードの引いたカードは" + drownCard.mark + "の" + drownCard.num);
    dealer.HandCard(drownCard);

    //２１になったらバースト
    if (dealer.AddTotalScore() > BurstScore)
    {
        Console.WriteLine("ディーラーのカードの合計値は" + dealer.AddTotalScore());
        Console.WriteLine("バーストしました！");
        break;
    }
}
Console.WriteLine("ディーラーのカードの合計値は" + dealer.AddTotalScore());

if (player.AddTotalScore() > BurstScore)
{
    Console.WriteLine("バーストしたのであなたの負けです");
}
else if(dealer.AddTotalScore() > BurstScore)
{
    Console.WriteLine("ディーラーがバーストしたのであなたの勝ちです");
}
else if (player.AddTotalScore() > dealer.AddTotalScore())
{
    Console.WriteLine("プレイヤーの勝ちです");
}
else if (dealer.AddTotalScore() == player.AddTotalScore())
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