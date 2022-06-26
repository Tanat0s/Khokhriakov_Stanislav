using System;

namespace M4_2_Min_Element
{
    //Условие задачи.
    /*Найдите наименьший элемент в последовательности, которую вводит пользователь. Последовательность нужно сохранить в массив. Детальный алгоритм программы:
        1.Пользователь вводит длину последовательности. 
        2.Затем пользователь последовательно вводит целые числа (как положительные, так и отрицательные). Числа разделяются клавишей Enter.
        3.Каждое введённое число помещается в соответствующий элемент массива.
        4.После окончания ввода данных отдельный цикл проходит по последовательности и находит минимальное число. Для этого он сравнивает каждое число в итерации с предыдущим найденным минимальным числом. */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину последовательности:");
            var sequenceLength = int.Parse(Console.ReadLine());
            var sequence = new int[sequenceLength];
            var minElement = int.MaxValue;

            Console.WriteLine("Введите элементы последовательности, каждый с новой строки:");

            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < sequence.Length; i++)
            {
                if (minElement > sequence[i])
                    minElement = sequence[i];
            }

            Console.WriteLine($"Минимальный элемент последовательности: {minElement}");
            Console.ReadKey();
        }
    }
}
