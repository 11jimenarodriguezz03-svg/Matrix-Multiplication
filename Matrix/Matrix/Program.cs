using System;

class MatrixMultiplication
{
    static void Main()
    {
        string input;
        do
        {
            Console.WriteLine("Matrix Multiplication. Type 'exit' at any time to quit.");

            Console.Write("Enter the value of m: ");
            input = Console.ReadLine()!.ToLower();
            if (input == "exit") break;
            if (!int.TryParse(input, out int m) || m <= 0) { Console.WriteLine("Invalid value."); continue; }

            Console.Write("Enter the value of n: ");
            input = Console.ReadLine()!.ToLower();
            if (input == "exit") break;
            if (!int.TryParse(input, out int n) || n <= 0) { Console.WriteLine("Invalid value."); continue; }

            Console.Write("Enter the value of p: ");
            input = Console.ReadLine()!.ToLower();
            if (input == "exit") break;
            if (!int.TryParse(input, out int p) || p <= 0) { Console.WriteLine("Invalid value."); continue; }

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

        } while (input != "exit");

        Console.WriteLine("Program finished.");
    }

    static void PrintMatrix(int[,] matrix)
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
}
