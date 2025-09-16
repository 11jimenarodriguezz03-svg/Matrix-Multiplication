using System;
using System.Text;

while (true)
{
    Console.WriteLine("Matrix Multiplication (press ESC to quit)");

    bool esc;
    string mInput = ReadLineOrEsc("Enter the value of m: ", out esc);
    if (esc) break;

    if (!int.TryParse(mInput, out int m) || m <= 0)
    {
        Console.WriteLine("Invalid value for m.");
        continue;
    }

    string nInput = ReadLineOrEsc("Enter the value of n: ", out esc);
    if (esc) break;

    if (!int.TryParse(nInput, out int n) || n <= 0)
    {
        Console.WriteLine("Invalid value for n.");
        continue;
    }

    string pInput = ReadLineOrEsc("Enter the value of p: ", out esc);
    if (esc) break;

    if (!int.TryParse(pInput, out int p) || p <= 0)
    {
        Console.WriteLine("Invalid value for p.");
        continue;
    }

    int[,] A = new int[m, n];
    int[,] B = new int[n, p];
    int[,] C = new int[m, p];

    for (int i = 0; i < m; i++)
        for (int j = 0; j < n; j++)
            A[i, j] = (i + 1) * j;

    for (int i = 0; i < n; i++)
        for (int j = 0; j < p; j++)
            B[i, j] = (j + 1) * i;

    for (int i = 0; i < m; i++)
        for (int j = 0; j < p; j++)
        {
            int sum = 0;
            for (int k = 0; k < n; k++)
                sum += A[i, k] * B[k, j];
            C[i, j] = sum;
        }

    Console.WriteLine("\nMatrix A:");
    PrintMatrix(A);

    Console.WriteLine("\nMatrix B:");
    PrintMatrix(B);

    Console.WriteLine("\nMatrix C (A x B):");
    PrintMatrix(C);

    Console.WriteLine();
}

Console.WriteLine("Program finished.");

string ReadLineOrEsc(string prompt, out bool esc)
{
    esc = false;
    Console.Write(prompt);
    var sb = new StringBuilder();

    while (true)
    {
        var key = Console.ReadKey(true);
        if (key.Key == ConsoleKey.Escape) { esc = true; Console.WriteLine(); return null; }
        if (key.Key == ConsoleKey.Enter) { Console.WriteLine(); return sb.ToString(); }
        if (key.Key == ConsoleKey.Backspace)
        {
            if (sb.Length > 0)
            {
                sb.Length--;
                Console.Write("\b \b");
            }
            continue;
        }
        if (char.IsDigit(key.KeyChar))
        {
            sb.Append(key.KeyChar);
            Console.Write(key.KeyChar);
        }
    }
}

void PrintMatrix(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
            Console.Write(matrix[i, j].ToString().PadLeft(5));
        Console.WriteLine();
    }
}
