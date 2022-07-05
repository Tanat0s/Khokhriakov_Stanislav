using System;
using System.IO;
using System.Text;

namespace M6_Work_With_File
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Приветствую!\nДля вывода информации о пользователях на экран нажмите 1.\nДля добавления нового пользователя введите 2.\nДля выхода из программы нажмите 'Enter'.");
            var result = Console.ReadLine();

            if (result == null)
            {
                SayGoodbye();
                return;
            }

            if(result.Equals("1"))
            {
                OutputDataFromFile();
            }
            else if(result.Equals("2"))
            {
                WriteDataToFile();
            }
            
            SayGoodbye();
        }

        public static void SayGoodbye()
        {
            Console.WriteLine("До новых встреч!");
        }

        public static void OutputDataFromFile()
        {
            using var fileStream = new FileStream(@"users.txt", FileMode.OpenOrCreate);
            using var streamReader = new StreamReader(fileStream);

            while (!streamReader.EndOfStream)
            {
                var userInfo = streamReader.ReadLine().Split('#');

                foreach (var info in userInfo)
                {
                    Console.WriteLine(info);
                }
            }
        }

        public static void WriteDataToFile()
        {
            if(!File.Exists(@"users.txt"))
            {
               using var fs = File.Create(@"users.txt");
            }

            using var streamWriter = new StreamWriter(@"users.txt", true);

            var userInfo = new StringBuilder();
            userInfo.Append($"{Guid.NewGuid()}#{DateTime.Now:dd.mm.yyyy hh:mm}#");

            Console.WriteLine("Введите Фамилию Имя Отчество:");
            userInfo.Append($"{Console.ReadLine()}#");

            Console.WriteLine("Введите возраст:");
            userInfo.Append($"{Console.ReadLine()}#");

            Console.WriteLine("Введите рост:");
            userInfo.Append($"{Console.ReadLine()}#");

            Console.WriteLine("Введите дату рождения:");
            userInfo.Append($"{Console.ReadLine()}#");

            Console.WriteLine("Введите место рождения:");
            userInfo.Append($"{Console.ReadLine()}");

            streamWriter.WriteLine(userInfo);
        }
    }
}
