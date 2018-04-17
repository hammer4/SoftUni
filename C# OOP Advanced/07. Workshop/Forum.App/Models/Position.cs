namespace Forum.App.Models
{
	using System;

	public struct Position
    {
        private int left;
        private int top;

        public Position(int left, int top)
        {
            this.left = left;
            this.top = top;
        }

        public int Top
        {
            get { return top; }
            set { top = value; }
        }

        public int Left
        {
            get { return left; }
            set { left = value; }
        }

        public static Position ConsoleCenter()
        {
            int centerTop = Console.WindowHeight / 2;
            int centerLeft = Console.WindowWidth / 2;

            Position center = new Position(centerLeft, centerTop);
            return center;
        }
    }
}
