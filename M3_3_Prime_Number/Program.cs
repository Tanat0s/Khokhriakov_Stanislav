using System;

namespace M3_3_Prime_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите любое целое число:");
            var number = int.Parse(Console.ReadLine());
            bool isPrime = false;
            var counter = 2;

            while (!isPrime)
            {
                if (number % counter++ == 0)
                {
                    isPrime = false;
                    break;
                }

                if (counter == number)
                    isPrime = true;
            }

            var result = isPrime ? "простое" : "не простое";

            Console.WriteLine($"Число {number} {result}");
        }
    }
}
