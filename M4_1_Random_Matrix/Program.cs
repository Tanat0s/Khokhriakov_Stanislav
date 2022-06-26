using System;

namespace M4_1_Random_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для создания матрицы введи необходимое число строк:");
            var rowsNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Введи необходимое число столбцов:");
            var columnsNumber = int.Parse(Console.ReadLine());

            int[,] array2d = new int[rowsNumber, columnsNumber];
            var random = new Random();
            var result = 0;

            for(var i = 0; i < array2d.GetLength(0); i++)
                for (int j = 0; j < array2d.GetLength(1); j++)
                {
                    array2d[i, j] = random.Next(0, 100);
                }

            for (var i = 0; i < array2d.GetLength(0); i++)
            {
                for (int j = 0; j < array2d.GetLength(1); j++)
                {
                    Console.Write($"{array2d[i, j], 3} ");
                    result += array2d[i, j];
                }
                Console.WriteLine();
            }

            Console.WriteLine($"Сумма всех элементов матрицы: {result}");
            Console.ReadKey();
        }
    }
}
