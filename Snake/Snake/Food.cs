
using System;
using System.Security.Cryptography.X509Certificates;

public class Food
{
    private Random random = new Random();
    public Position Position { get; private set; }

    private int screenWidth;
    private int screenHeight;

    public Food(int screenWidth, int screenHeight, Snake snake)
    {
        this.screenWidth = screenWidth;
        this.screenHeight = screenHeight;
        GenerateNewPosition(snake);
    }

    public void GenerateNewPosition(Snake snake)
    {
        int x, y;
        do
        {
            x = random.Next(1, screenWidth- 1);
            y = random.Next(1, screenHeight- 1);
        } 
        while (snake.GetHeadPosition().X == x && snake.GetHeadPosition().Y == y );
        
            Position = new Position(x, y);
    }

    public void Draw()
    {
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.Write("X");
    }
}