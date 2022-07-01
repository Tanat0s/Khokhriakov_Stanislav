using System;

namespace M5_1_Split_Strings
{
    /*Пользователь вводит в консольном приложении длинное предложение. Каждое слово в этом предложении отделено одним пробелом.
      Необходимо создать метод, который в качестве входного параметра принимает строковую переменную, а в качестве возвращаемого значения — массив слов.
      После вызова данного метода программа вызывает второй метод, который выводит каждое слово в отдельной строке.*/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Наберите любое предложение, слова в котором разделены пробелом:");
            var str = Console.ReadLine();
            var words = Split(str);
            Output(words);

            Console.ReadKey();
        }

        /// <summary>
        /// Разбивание строки на слова, в качестве разделителя выступает пробел
        /// </summary>
        /// <param name="str">Строка</param>
        /// <returns>Массив слов</returns>
        private static string[] Split(string str)
        {
            return str.Split(' ');
        }

        /// <summary>
        /// Вывод массива слов, каждое слово в отдельной строке
        /// </summary>
        /// <param name="words">Массив слов</param>
        private static void Output(string[] words)
        {
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
