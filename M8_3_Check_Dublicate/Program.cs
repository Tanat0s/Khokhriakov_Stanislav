using System;
using System.Collections.Generic;

namespace M8_3_Check_Dublicate
{
    /*
      Пользователь вводит число. Число сохраняется в HashSet коллекцию. Если такое число уже присутствует в коллекции, 
      то пользователю на экран выводится сообщение, что число уже вводилось ранее. Если числа нет, то появляется сообщение о том, 
      что число успешно сохранено.
    */
    class Program
    {
        static void Main(string[] args)
        {
            var set = new HashSet<int>();

            while(true)
            {
                Console.WriteLine("Для добавлени числа в коллекцию введите число:");
                var number = Console.ReadLine();

                if(!string.IsNullOrEmpty(number))
                {
                    if(set.Add(int.Parse(number)))
                        Console.WriteLine($"Число {number} успешно добавлено в коллекцию");
                    else
                        Console.WriteLine($"Число {number} уже существует в коллекции!");
                }
                else
                {
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
