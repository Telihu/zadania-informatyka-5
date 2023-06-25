using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Podaj rozmiar tablicy (n x n, gdzie n jest nieparzyste):");
        int size = ReadOddNumber();

        int[,] array = new int[size, size];

        InitializeArray(array);
        FillArray(array);
        DisplayArray(array);
    }

    static void InitializeArray(int[,] array)
    {
        int size = array.GetLength(0);
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                array[i, j] = 0;
            }
        }
    }

    static void FillArray(int[,] array)
    {
        int size = array.GetLength(0);
        int value = 1;

        // Fill odd numbers in blue direction
        int startRow = size - 1;
        int startCol = 0;
        while (startRow >= 0)
        {
            int row = startRow;
            int col = startCol;

            while (row < size && col < size)
            {
                array[row, col] = value;
                value += 2;
                row++;
                col++;
            }

            if (startCol < size - 1)
                startCol++;
            else
                startRow--;
        }

        // Fill even numbers in green direction
        startRow = 0;
        startCol = size - 1;
        while (startCol >= 0)
        {
            int row = startRow;
            int col = startCol;

            while (row < size && col >= 0)
            {
                if (array[row, col] == 0)
                {
                    array[row, col] = value;
                    value += 2;
                }
                row++;
                col--;
            }

            if (startRow < size - 1)
                startRow++;
            else
                startCol--;
        }
    }

    static void DisplayArray(int[,] array)
    {
        int size = array.GetLength(0);

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(array[i, j].ToString().PadLeft(2) + "\t");
            }
            Console.WriteLine();
        }
    }

    static int ReadOddNumber()
    {
        int number;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out number) && number > 0 && number % 2 != 0)
                return number;

            Console.WriteLine("Podaj poprawny rozmiar (liczba dodatnia i nieparzysta):");
        }
    }
}
