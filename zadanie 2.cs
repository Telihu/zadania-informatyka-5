using System;

class Program
{
    static void Main()
    {
        int[,] tablica = new int[10, 10];
        int liczba = 1;
        int k = 0, l = 0;
        int n = 10, m = 10;

        while (k < n && l < m)
        {
            // Wypełnianie górnego wiersza
            for (int i = l; i < m; i++)
            {
                tablica[k, i] = liczba++;
            }
            k++;

            // Wypełnianie prawej kolumny
            for (int i = k; i < n; i++)
            {
                tablica[i, m - 1] = liczba++;
            }
            m--;

            // Wypełnianie dolnego wiersza
            if (k < n)
            {
                for (int i = m - 1; i >= l; i--)
                {
                    tablica[n - 1, i] = liczba++;
                }
                n--;
            }

            // Wypełnianie lewej kolumny
            if (l < m)
            {
                for (int i = n - 1; i >= k; i--)
                {
                    tablica[i, l] = liczba++;
                }
                l++;
            }
        }

        // Wyświetlanie tablicy
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.Write(tablica[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}


