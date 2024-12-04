using System;
using System.Threading;

public class Game
{
    private int screenWidth = 50;
    private int screenHeight = 50;
    private int score = 0;
    private int gameSpeed = 100;
    private bool gameOver = false;

    private Snake snake;
    private Food food;
    private Random random = new Random();

    public void Run()
    {
        Console.CursorVisible = false;
        InitGame();

        while (!gameOver) 
        {
            if (Console.KeyAvailable) 
            {
                var key = Console.ReadKey(true).Key;
                snake.HandleInput(key); // vstup uživatele
            }

            snake.Move(); // pohyb
            CheckCollision(); // Kontrola kolize
            DrawScreen(); // Vykreslování hrací plochy
            Thread.Sleep(gameSpeed); // rychlost hry
        }

        GameOver();
    }

    private void InitGame()
    {
        snake = new Snake(screenWidth / 2, screenHeight / 2);  // Inicializace hada
        food = new Food(screenWidth, screenHeight, snake);  // Inicializace jídla
    }

    private void CheckCollision ()
    {
        Position head = snake.GetHeadPosition();
        // kolize s hracím polem
        if (head.X <= 0 || head.X >= screenWidth - 1 || head.Y <= 0 || head.Y >= screenHeight - 1)
        {
            gameOver = true;
        }
        // kolize s tělem 
        if (snake.HasCollidedWithSelf())
        {
            gameOver = true;
        }
        // kontrola zda had snědl jídlo
        if (head.X == food.Position.X && head.Y == food.Position.Y)
        {
            score++;
            snake.Grow();
            food.GenerateNewPosition(snake);
            gameSpeed = Math.Max(50, gameSpeed - 5);
        }

    }

    private void DrawScreen()
    {
        Console.Clear();
        
        // Vykreslení hranic

        for (int i = 0; i < screenWidth; i++)
        {
            Console.SetCursorPosition(i, 0);
            Console.Write("#");
            Console.SetCursorPosition(i, screenHeight - 1);
            Console.Write("#");
        }

        for (int i = 0;i < screenHeight; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("#");
            Console.SetCursorPosition(i, screenWidth - 1);
            Console.Write("#");
        }

        //Vykreslení hranic
        snake.Draw();

        //Vykreslení jídla
        food.Draw();

        //Skóre
        Console.SetCursorPosition(0, screenHeight);
        Console.Write($"Score: {score}");
    }

    private void GameOver()
    {
        Console.Clear();
        Console.SetCursorPosition(screenWidth / 2 - 5, screenHeight / 2);
        Console.WriteLine("Prohrál jsi!");
        Console.SetCursorPosition(screenWidth / 2 - 5, screenHeight / 2 + 1);
        Console.WriteLine($"Final Score: {score}");
        Console.SetCursorPosition(screenWidth / 2 - 5, screenHeight / 2 + 2);
        Console.WriteLine("Stiskni Enter pro exit.");
    }

}
