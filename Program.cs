using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[,] matrix = {
            { 3, -1, 5 },
            { 7, -6, 2 },
            { -4, -5, -6 },
            { 1, -7, 3 }
        };

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        Console.WriteLine("Суми елементів у рядках з від’ємними числами:");
        for (int i = 0; i < rows; i++)
        {
            bool hasNegative = false;
            int rowSum = 0;

            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] < 0)
                {
                    hasNegative = true;
                }
                rowSum += matrix[i, j];
            }

            if (hasNegative)
            {
                Console.WriteLine($"Рядок {i + 1}: {rowSum}");
            }
        }

        Console.WriteLine("\nСідлові точки:");
        List<(int row, int col)> saddlePoints = new List<(int, int)>();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int element = matrix[i, j];

                bool isRowMin = true;
                for (int k = 0; k < cols; k++)
                {
                    if (matrix[i, k] < element)
                    {
                        isRowMin = false;
                        break;
                    }
                }

                bool isColMax = true;
                for (int k = 0; k < rows; k++)
                {
                    if (matrix[k, j] > element)
                    {
                        isColMax = false;
                        break;
                    }
                }

                if (isRowMin && isColMax)
                {
                    saddlePoints.Add((i + 1, j + 1)); 
                    Console.WriteLine($"Рядок {i + 1}, Стовпець {j + 1}");
                }
            }
        }

        if (saddlePoints.Count == 0)
        {
            Console.WriteLine("Сідлових точок немає.");
        }
    }
}




