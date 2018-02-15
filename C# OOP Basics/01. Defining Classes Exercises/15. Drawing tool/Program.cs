using System;

public class Program
{
    static void Main(string[] args)
    {
        string type = Console.ReadLine();

        switch (type)
        {
            case "Square":
                int width = int.Parse(Console.ReadLine());
                var square = new Square(width);
                var drawingTool = new DrawingTool(square);
                drawingTool.Figure.Draw();
                break;
            case "Rectangle":
                int width2 = int.Parse(Console.ReadLine());
                int height2 = int.Parse(Console.ReadLine());
                var rectangle = new Rectangle(width2, height2);
                var drawingTool2 = new DrawingTool(rectangle);
                drawingTool2.Figure.Draw();
                break;
        }
    }
}