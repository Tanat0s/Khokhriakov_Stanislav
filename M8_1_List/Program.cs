using System;
using System.Collections.Generic;

namespace M8_1_List
{
    /*
     - Создайте лист целых чисел. 
     - Заполните лист 100 случайными числами в диапазоне от 0 до 100. 
     - Выведите коллекцию чисел на экран. 
     - Удалите из листа числа, которые больше 25, но меньше 50. 
     - Снова выведите числа на экран.
    */
    class Program
    {
        static void Main(string[] args)
        {
            var list = CreateList(100);
            OutputList(list);
            RemoveElementsFromList(list, i => i > 25 && i < 50);
            OutputList(list);

            Console.ReadKey();
        }

        private static List<int> CreateList(int size)
        {
            var list = new List<int>();
            var random = new Random();

            for (int i = 0; i < size; i++)
            {
                list.Add(random.Next(0, 101));
            }

            return list;
        }

        private static void OutputList(List<int> list)
        {
            Console.WriteLine($"Вывод элементов списка размером {list.Count} :");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }

        private static void RemoveElementsFromList(List<int> list, Predicate<int> predicate)
        {
            Console.WriteLine($"Удалено {list.RemoveAll(predicate)} элементов.");
        }
    }
}
