using System;

namespace M4_3_Guess_The_Number
{
    /*Разработайте программу по следующему алгоритму:
    -Пользователь вводит максимальное целое число диапазона.
    -На основе диапазона целых чисел (от 0 до «введено пользователем») программа генерирует случайное целое число из диапазона.
    -Пользователю предлагается ввести загаданное программой случайное число. Пользователь вводит свои предположения в консоли приложения.
        *Если число меньше загаданного, программа сообщает об этом пользователю.
        *Если больше, то тоже сообщает, что число больше загаданного.
    -Программа завершается, когда пользователь угадал число.
    -Если пользователь устал играть, то вместо ввода числа он вводит пустую строку и нажимает Enter. Тогда программа завершается, предварительно показывая, какое число было загадано.*/
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Добро пожаловать в игру \"Угадай число!\"\nВведите максимальный дипазон из загадываемых чисел:");
            var maxRange = int.Parse(Console.ReadLine());
            var random = new Random();
            var secretNumber = random.Next(0, maxRange + 1);

            while(true)
            {
                Console.WriteLine("Введите загаданное число:");
                var userInput = Console.ReadLine();

                if (userInput.Equals(string.Empty))
                {
                    Console.WriteLine($"Нам Вас будет не хватать! Мы загадали число {secretNumber}. Вы были в шаге от победы!");
                    break;
                }

                var userNumber = int.Parse(userInput);

                if (userNumber == secretNumber)
                {
                    Console.WriteLine($"Поздравляем! Вы угадали число {secretNumber}!");
                    break;
                }else if(userNumber > secretNumber)
                {
                    Console.WriteLine("Вы ввели число БОЛЬШЕ загаданного!");
                }
                else
                {
                    Console.WriteLine("Вы ввели число МЕНЬШЕ загаданного!");
                }
            }
        }
    }
}
