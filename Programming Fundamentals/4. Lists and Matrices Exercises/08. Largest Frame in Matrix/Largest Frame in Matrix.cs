using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Largest_Frame_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int[][] matrix = new int[rows][];
            int maxRectangleSize = 1;

            for (int i=0; i<rows; i++)
            {
                matrix[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }

            List<string> frames = new List<string>();
            for(int i=0; i<rows; i++)
            {
                for(int j=0; j<cols; j++)
                {
                    int firstElementRow = i;
                    int firstElementCol = j;
                    int element = matrix[i][j];

                    for(int k=i; k<rows; k++)
                    {
                        for(int l=j; l<cols; l++)
                        {
                            int lastElementRow = k;
                            int lastElementCol = l;

                            bool isRectangle = true;
                            
                            for(int n=firstElementCol; n<=lastElementCol; n++)
                            {
                                if (matrix[firstElementRow][n] != element)
                                {
                                    isRectangle = false;
                                }
                            }

                            for (int n = firstElementCol; n <= lastElementCol; n++)
                            {
                                if (matrix[lastElementRow][n] != element)
                                {
                                    isRectangle = false;
                                }
                            }

                            for(int n=firstElementRow; n<= lastElementRow; n++)
                            {
                                if(matrix[n][firstElementCol] != element)
                                {
                                    isRectangle = false;
                                }
                            }

                            for (int n = firstElementRow; n <= lastElementRow; n++)
                            {
                                if (matrix[n][lastElementCol] != element)
                                {
                                    isRectangle = false;
                                }
                            }

                            if(isRectangle)
                            {
                                int rectangleSize = (lastElementRow - firstElementRow + 1) * (lastElementCol - firstElementCol + 1);

                                if(rectangleSize > maxRectangleSize)
                                {
                                    maxRectangleSize = rectangleSize;
                                }

                                frames.Add(string.Format("{0}x{1}", lastElementRow - firstElementRow + 1, lastElementCol - firstElementCol + 1));
                            }
                        }
                    }
                }
            }

            frames.Sort();
            List<string> maxFrames = new List<string>();
            foreach(string frame in frames)
            {
                int[] frameSize = frame.Split('x').Select(int.Parse).ToArray();
                if(frameSize[0]* frameSize[1] == maxRectangleSize)
                {
                    maxFrames.Add(frame);
                }
            }

            Console.WriteLine(string.Join(", ", maxFrames));
        }
    }
}
