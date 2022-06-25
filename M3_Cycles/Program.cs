using System;

namespace M3_1_Odd_Even
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите целое число:");
            var number = int.Parse(Console.ReadLine());
            var result = (number % 2 == 0) ? "чётное" : "нечётное";

            Console.WriteLine($"Число {number} {result}.");
        }
    }
}
