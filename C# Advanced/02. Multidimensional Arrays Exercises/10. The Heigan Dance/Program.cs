using System;

namespace _10._The_Heigan_Dance
{
    class Program
    {
        static void Main(string[] args)
        {
            int cloudDamage = 3500;
            int eruptionDamage = 6000;
            int playerHealth = 18500;
            double heiganHealth = 3000000;
            bool cloudActive = false;

            double playerDamage = double.Parse(Console.ReadLine());

            char[,] matrix = new char[15, 15];
            int currentRow = 7;
            int currentCol = 7;
            string currentSpell = "";

            while (true)
            {
                ClearMatrix(ref matrix);

                string[] spellParameters = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                heiganHealth -= playerDamage;

                if (cloudActive)
                {
                    playerHealth -= cloudDamage;
                    if (playerHealth <= 0)
                    {
                        Finish(heiganHealth, playerHealth, currentRow, currentCol, currentSpell);
                    }

                    cloudActive = false;
                }

                if (heiganHealth <= 0)
                {
                    Finish(heiganHealth, playerHealth, currentRow, currentCol, currentSpell);
                }

                currentSpell = spellParameters[0];
                int spellRow = int.Parse(spellParameters[1]);
                int spellCol = int.Parse(spellParameters[2]);

                CastSpell(currentSpell, spellRow, spellCol, ref matrix);

                if(matrix[currentRow, currentCol] != ' ')
                {
                    if (MoveUp(matrix, currentRow, currentCol))
                    {
                        currentRow--;
                    }
                    else if (MoveRight(matrix, currentRow, currentCol))
                    {
                        currentCol++;
                    }
                    else if(MoveDown(matrix, currentRow, currentCol))
                    {
                        currentRow++;
                    }
                    else if(MoveLeft(matrix, currentRow, currentCol))
                    {
                        currentCol--;
                    }
                    else
                    {
                        if(currentSpell[0] == 'C')
                        {
                            cloudActive = true;
                            playerHealth -= cloudDamage;
                        }
                        else if(currentSpell[0] == 'E')
                        {
                            playerHealth -= eruptionDamage;
                        }

                        if(playerHealth <= 0)
                        {
                            Finish(heiganHealth, playerHealth, currentRow, currentCol, currentSpell);
                        }
                    }
                }
            }
        }

        private static bool MoveLeft(char[,] matrix, int currentRow, int currentCol)
        {
            if (currentCol != 0 && matrix[currentRow, currentCol - 1] == ' ')
            {
                return true;
            }

            return false;
        }

        private static bool MoveDown(char[,] matrix, int currentRow, int currentCol)
        {
            if (currentRow != matrix.GetLength(0) - 1 && matrix[currentRow + 1, currentCol] == ' ')
            {
                return true;
            }

            return false;
        }

        private static bool MoveRight(char[,] matrix, int currentRow, int currentCol)
        {
            if (currentCol != matrix.GetLength(1) - 1 && matrix[currentRow, currentCol+1] == ' ')
            {
                return true;
            }

            return false;
        }

        private static bool MoveUp(char[,] matrix, int currentRow, int currentCol)
        {
            if(currentRow != 0 && matrix[currentRow-1, currentCol] == ' ')
            {
                return true;
            }

            return false;
        }

        private static void CastSpell(string currentSpell, int spellRow, int spellCol, ref char[,] matrix)
        {
            for(int i=spellRow-1; i<=spellRow+1; i++)
            {
                for(int j=spellCol-1; j<=spellCol + 1; j++)
                {
                    if(i>= 0 && matrix.GetLength(0)> i && j >=0 && matrix.GetLength(1) > j)
                    {
                        matrix[i, j] = currentSpell[0];
                    }
                }
            }
        }

        private static void ClearMatrix(ref char[,] matrix)
        {
            for(int i = 0; i<matrix.GetLength(0); i++)
            {
                for(int j=0; j<matrix.GetLength(1); j++)
                {
                    matrix[i, j] = ' ';
                }
            }
        }

        private static void Finish(double heiganHealth, int playerHealth, int currentRow, int currentCol, string currentSpell)
        {
            if(heiganHealth <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganHealth:F2}");
            }

            if(playerHealth <= 0)
            {
                string lastSpell = currentSpell == "Eruption" ? "Eruption" : "Plague Cloud";
                Console.WriteLine($"Player: Killed by {lastSpell}");
            }
            else
            {
                Console.WriteLine($"Player: {playerHealth}");
            }

            Console.WriteLine($"Final position: {currentRow}, {currentCol}");

            Environment.Exit(0);
        }

        private static void Print(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
