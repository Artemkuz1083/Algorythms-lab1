using AlgorytmsLibrary;
using System;

public class Matr : IResercheable
{
    public Matr(int size, string name) : base(size, name)
    {
    }

    public override void Run(int[] array, int value = 0)
    {
        int n = (int)Math.Sqrt(array.Length);
        int[,] matrixA = GenerateMatrix(n);
        int[,] matrixB = GenerateMatrix(n);

        int[,] matrixProduct = MatrixProduct(matrixA, matrixB);

    }

    public int[,] GenerateMatrix(int n)
    {
        int[,] matrix = new int[n, n];

        Random random = new Random();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = random.Next(0, 10000);
            }
        }

        return matrix;
    }

    public int[,] MatrixProduct(int[,] matrixA, int[,] matrixB)
    {
        int n = matrixA.GetLength(0);
        int[,] matrixProduct = new int[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k < n; k++)
                {
                    matrixProduct[i, j] += matrixA[i, k] * matrixB[k, j];
                }
            }
        }

        return matrixProduct;
    }
}