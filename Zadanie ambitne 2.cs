using System;

class Program
{
    static void Main()
    {
        int[][] magicSquare1 = new int[][]
        {
            new int[] {2, 7, 6},
            new int[] {9, 5, 1},
            new int[] {4, 3, 8}
        };

        int[][] magicSquare2 = new int[][]
        {
            new int[] {1, 1, 1},
            new int[] {1, 1, 1},
            new int[] {1, 1, 1}
        };

        int[][] nonMagicSquare = new int[][]
        {
            new int[] {2, 7, 6},
            new int[] {9, 5, 1},
            new int[] {4, 3, 9}
        };

        Console.WriteLine("Wybierz kwadrat do sprawdzenia:");
        Console.WriteLine("1 - Kwadrat magiczny");
        Console.WriteLine("2 - Kwadrat niespełniający warunku unikatowości");
        Console.WriteLine("3 - Kwadrat niespełniający warunku sum");
        int choice = Convert.ToInt32(Console.ReadLine());

        int[][] selectedSquare;

        switch (choice)
        {
            case 1:
                selectedSquare = magicSquare1;
                break;
            case 2:
                selectedSquare = magicSquare2;
                break;
            case 3:
                selectedSquare = nonMagicSquare;
                break;
            default:
                Console.WriteLine("Nieprawidłowy wybór.");
                return;
        }

        if (IsMagicSquare(selectedSquare))
        {
            Console.WriteLine("Podany kwadrat jest kwadratem magicznym.");
        }
        else
        {
            Console.WriteLine("Podany kwadrat nie jest kwadratem magicznym.");
        }

        Console.ReadLine();
    }

    static bool IsMagicSquare(int[][] square)
    {
        int size = square.Length;
        int magicSum = size * (size * size + 1) / 2;

        // Sprawdzenie sum w wierszach i kolumnach
        for (int i = 0; i < size; i++)
        {
            int rowSum = 0;
            int colSum = 0;
            for (int j = 0; j < size; j++)
            {
                rowSum += square[i][j];
                colSum += square[j][i];
            }
            if (rowSum != magicSum || colSum != magicSum)
            {
                return false; // Jeśli suma wiersza lub kolumny nie zgadza się, to nie jest kwadratem magicznym
            }
        }

        // Sprawdzenie sum na przekątnych
        int diagSum1 = 0;
        int diagSum2 = 0;
        for (int i = 0; i < size; i++)
        {
            diagSum1 += square[i][i];
            diagSum2 += square[i][size - i - 1];
        }
        if (diagSum1 != magicSum || diagSum2 != magicSum)
        {
            return false; // Jeśli suma na przekątnych nie zgadza się, to nie jest kwadratem magicznym
        }

        // Sprawdzenie unikatowości liczb w kwadracie
        bool[] foundNumbers = new bool[size * size + 1];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                int num = square[i][j];
                if (num < 1 || num > size * size || foundNumbers[num])
                {
                    return false; // Jeśli liczba jest spoza zakresu lub już wystąpiła, to nie jest kwadratem magicznym
                }
                foundNumbers[num] = true;
            }
        }

        return true; // Jeśli przeszedł wszystkie warunki, to jest kwadratem magicznym
    }
}
