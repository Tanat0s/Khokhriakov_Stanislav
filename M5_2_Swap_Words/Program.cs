using System;

namespace M5_2_Swap_Words
{
    /*Пользователь вводит в программе длинное предложение. Каждое слово раздельно одним пробелом. После ввода пользователь нажимает клавишу Enter. Необходимо создать два метода:
        -первый метод разделяет слова в предложении;
        -второй метод меняет эти слова местами (в обратной последовательности). 
      При этом важно учесть, что один метод вызывается внутри другого метода, то есть в методе main вызывается метод cо следующей сигнатурой — ReversWords (string inputPhrase).
      Внутри этого метода вызывается метод по разделению входной фразы на слова.*/
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Наберите любое предложение, слова в котором разделены пробелом:");
            var str = Console.ReadLine();
            var reversedWords = ReverseWords(str);
            Output(reversedWords);

            Console.ReadKey();
        }

        /// <summary>
        /// Замена порядка слов в предложении на обратный
        /// </summary>
        /// <param name="str">Строка</param>
        /// <returns>Массив слов в обратном порядке</returns>
        private static string[] ReverseWords(string str)
        {
            var result = Split(str);
            Array.Reverse(result);
            return result;
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
