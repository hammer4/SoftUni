using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        List<Cell> board = new List<Cell>();

        for (byte i=1; i<=count; i++)
        {
            for(byte j=1; j<=count; j++)
            {
                board.Add(new Cell { Row = i, Col = j });
            }
        }
        int counter = 1;
        var currentCell = board[0];
        currentCell.IsVisited = true;
        currentCell.TurnVisited = counter++;

        while(board.Any(c => !c.IsVisited))
        {
            currentCell = SelectNextCell(currentCell, board);
            currentCell.IsVisited = true;
            currentCell.TurnVisited = counter++;
        }

        PrintBoard(count, board);
    }

    static void PrintBoard(int count, List<Cell> board)
    {
        for(int i=0; i<count; i++)
        {
            for(int j=0; j<count; j++)
            {
                Console.Write(board[i*count + j].TurnVisited.ToString().PadLeft(3) + " ");
            }
            Console.WriteLine();
        }
    }

    private static Cell SelectNextCell(Cell current, List<Cell> board)
    {
        var topLeft = board.FirstOrDefault(c => c.Row == current.Row - 2 && c.Col == current.Col - 1);
        var leftTop = board.FirstOrDefault(c => c.Row == current.Row - 1 && c.Col == current.Col - 2);
        var rightTop = board.FirstOrDefault(c => c.Row == current.Row - 1 && c.Col == current.Col + 2);
        var topRight = board.FirstOrDefault(c => c.Row == current.Row - 2 && c.Col == current.Col + 1);

        var bottomLeft = board.FirstOrDefault(c => c.Row == current.Row + 2 && c.Col == current.Col - 1);
        var leftBottom = board.FirstOrDefault(c => c.Row == current.Row + 1 && c.Col == current.Col - 2);
        var rightBottom = board.FirstOrDefault(c => c.Row == current.Row + 1 && c.Col == current.Col + 2);
        var bottomRight = board.FirstOrDefault(c => c.Row == current.Row + 2 && c.Col == current.Col + 1);

        return new List<Cell>
        {
             rightBottom,rightTop,leftBottom, leftTop, bottomRight, topRight, topLeft, bottomLeft
        }
        .Where(c => c != null && !c.IsVisited)
        .ToList()
        .OrderBy(c => CalculatePosibleMoves(c, board))
        .First();

    }

    private static int CalculatePosibleMoves(Cell current, List<Cell> board)
    {
        var topLeft = board.FirstOrDefault(c => c.Row == current.Row - 2 && c.Col == current.Col - 1);
        var leftTop = board.FirstOrDefault(c => c.Row == current.Row - 1 && c.Col == current.Col - 2);
        var rightTop = board.FirstOrDefault(c => c.Row == current.Row - 1 && c.Col == current.Col + 2);
        var topRight = board.FirstOrDefault(c => c.Row == current.Row - 2 && c.Col == current.Col + 1);

        var bottomLeft = board.FirstOrDefault(c => c.Row == current.Row + 2 && c.Col == current.Col - 1);
        var leftBottom = board.FirstOrDefault(c => c.Row == current.Row + 1 && c.Col == current.Col - 2);
        var rightBottom = board.FirstOrDefault(c => c.Row == current.Row + 1 && c.Col == current.Col + 2);
        var bottomRight = board.FirstOrDefault(c => c.Row == current.Row + 2 && c.Col == current.Col + 1);

        return new List<Cell>
        {
            topLeft, topRight, leftTop, rightTop, bottomLeft, bottomRight, leftBottom, rightBottom
        }
        .Where(c => c != null && !c.IsVisited)
        .Count();
    }
    private class Cell
    {
        public byte Row { get; set; }

        public byte Col { get; set; }

        public bool IsVisited { get; set; }

        public int TurnVisited { get; set; }
    }
}