using System;

Random random = new Random();
string[] choices = ["rock", "paper", "scissors"];

int playerScore = 0;
int computerScore = 0;
int ties = 0;

Console.WriteLine("欢迎来到石头、剪刀、布！");
Console.WriteLine("你将和计算机对战。");

bool playAgain = true;

while (playAgain)
{
    Console.WriteLine();
    Console.WriteLine("请选择一个选项：rock、paper 或 scissors");
    string? playerInput = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(playerInput))
    {
        Console.WriteLine("输入无效，请输入 rock、paper 或 scissors。");
        continue;
    }

    string playerChoice = playerInput.Trim().ToLowerInvariant();

    if (playerChoice != "rock" && playerChoice != "paper" && playerChoice != "scissors")
    {
        Console.WriteLine("选项无效，请选择 rock、paper 或 scissors。");
        continue;
    }

    string computerChoice = choices[random.Next(choices.Length)];
    Console.WriteLine($"计算机选择了：{computerChoice}");

    if (playerChoice == computerChoice)
    {
        Console.WriteLine("这一轮打平！");
        ties++;
    }
    else if (
        (playerChoice == "rock" && computerChoice == "scissors") ||
        (playerChoice == "paper" && computerChoice == "rock") ||
        (playerChoice == "scissors" && computerChoice == "paper"))
    {
        Console.WriteLine("你赢了这一轮！");
        playerScore++;
    }
    else
    {
        Console.WriteLine("你输了这一轮！");
        computerScore++;
    }

    Console.WriteLine($"比分 - 你：{playerScore} | 计算机：{computerScore} | 平局：{ties}");

    while (true)
    {
        Console.Write("是否再玩一次？(y/n)：");
        string? replayInput = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(replayInput))
        {
            Console.WriteLine("请输入 y 或 n。");
            continue;
        }

        string replayChoice = replayInput.Trim().ToLowerInvariant();

        if (replayChoice == "y" || replayChoice == "yes")
        {
            playAgain = true;
            break;
        }

        if (replayChoice == "n" || replayChoice == "no")
        {
            playAgain = false;
            break;
        }

        Console.WriteLine("请输入 y 或 n。");
    }
}

Console.WriteLine();
Console.WriteLine("游戏结束！");
Console.WriteLine($"最终比分 - 你：{playerScore} | 计算机：{computerScore} | 平局：{ties}");