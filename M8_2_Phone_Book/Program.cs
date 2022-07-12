using System;
using System.Collections.Generic;

namespace M8_2_Phone_Book
{
    /*
     - Пользователю итеративно предлагается вводить в программу номера телефонов и ФИО их владельцев. 
     - В процессе ввода информация размещается в Dictionary, где ключом является номер телефона, а значением — ФИО владельца. Таким образом, у одного владельца может быть несколько номеров телефонов. 
       Признаком того, что пользователь закончил вводить номера телефонов, является ввод пустой строки. 
     - Далее программа предлагает найти владельца по введенному номеру телефона. Пользователь вводит номер телефона и ему выдаётся ФИО владельца. Если владельца по такому номеру телефона не зарегистрировано, 
       программа выводит на экран соответствующее сообщение.
     */
    class Program
    {
        private static Dictionary<string, string> phoneBookDictionary = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            FillDictionary();

            Console.WriteLine("Для поиска пользователя укажите его телефонный номер:");
            var key = Console.ReadLine();

            OutputUserByPhone(key);

            Console.ReadKey();
        }

        static void FillDictionary()
        {
            while (true)
            {
                Console.WriteLine("Введите номер телофона пользователя:");
                var phone = Console.ReadLine();

                if (string.IsNullOrEmpty(phone))
                    break;

                Console.WriteLine("Введите ФИО пользователя:");
                var fullName = Console.ReadLine();

                if (string.IsNullOrEmpty(fullName))
                    break;

                phoneBookDictionary[phone] = fullName;
            }
        }

        static void OutputUserByPhone(string phone)
        {
            string result;

            if (phoneBookDictionary.TryGetValue(phone, out result))
            {
                Console.WriteLine($"По данному телефонному номеру {phone} зарегестрирован пользователь {result}");
            }
            else
            {
                Console.WriteLine($"Пользователя с телефонным номером {phone} не существует!");
            }
        }
    }
}
