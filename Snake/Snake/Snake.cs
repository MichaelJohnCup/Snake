using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


public class Snake
{
    private List<Position> body = new List<Position>();
    private Direction currentDirection = Direction.Right;


    public Snake(int startX, int startY)
    {
        body.Add(new Position(startX, startY));
        body.Add(new Position(startX - 1, startY));
        body.Add(new Position(startX - 2, startY));
    }

    public void Move ()
    {
        var head = body.First();
        Position newHead = head;

        switch (currentDirection)
        {
            case Direction.Up:
                newHead = new Position(head.X, head.Y - 1);
                break;
            case Direction.Down:
                newHead = new Position(head.X, head.Y + 1);
                break;
            case Direction.Left:
                newHead = new Position(head.X - 1, head.Y);
                break;
            case Direction.Right:
                newHead = new Position(head.X + 1, head.Y);
                break;
        }

        body.Insert(0, newHead);
        body.RemoveAt(body.Count - 1); // Odstraní ocas pokud nesnědl jídlo
    }

    public void Grow()
    {
        body.Add(body.Last()); // Přidá ocas
    }

    public void HandleInput(ConsoleKey key)
    {
        switch (key) 
        {
            case ConsoleKey.W:
            case ConsoleKey.UpArrow:
                if (currentDirection != Direction.Down)
                    currentDirection = Direction.Up; 
                break;

            case ConsoleKey.S:
            case ConsoleKey.DownArrow:
                if (currentDirection != Direction.Up)
                    currentDirection = Direction.Down;
                break;

            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                if (currentDirection != Direction.Right)
                    currentDirection = Direction.Left; 
                break;

            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                if (currentDirection != Direction.Left)
                    currentDirection = Direction.Right; 
                break;
        }
    }
    
    public Position GetHeadPosition()
    {
        return body.First();
    }

    public bool HasCollidedWithSelf()
    {
        var head = GetHeadPosition();
        return body.Skip(1).Any(part => part.X == head.X && part.Y == head.Y);
    }

    public void Draw()
    {
        foreach (var part in body)
        {
            Console.SetCursorPosition(part.X, part.Y);
            Console.Write("0");
        }
    }
}