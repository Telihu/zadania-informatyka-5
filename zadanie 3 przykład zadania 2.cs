using System;

class Program
{
    static void Main()
    {
        int rozmiar;
        Console.Write("Podaj rozmiar tablicy: ");
        while (!int.TryParse(Console.ReadLine(), out rozmiar) || rozmiar <= 0)
        {
            Console.WriteLine("Niepoprawny rozmiar tablicy. Podaj liczbę dodatnią.");
            Console.Write("Podaj rozmiar tablicy: ");
        }

        int[,] tablica = new int[rozmiar, rozmiar];
        int liczba = 1;
        int k = 0, l = 0;
        int n = rozmiar, m = rozmiar;

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
        for (int i = 0; i < rozmiar; i++)
        {
            for (int j = 0; j < rozmiar; j++)
            {
                Console.Write(tablica[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}

