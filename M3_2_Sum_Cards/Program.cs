using System;

namespace M3_2_Sum_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игру Blackjack! Сколько у Вас карт на руках?");
            var amountOfCards = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите пожалуйста номинал всех карт:");
            var result = 0;

            for (int i = 0; i < amountOfCards; i++)
            {
                var nominal = Console.ReadLine();

                switch (nominal)
                {
                    case "2": 
                        result += 2;
                        break;
                    case "3":
                        result += 3;
                        break;
                    case "4":
                        result += 4;
                        break;
                    case "5":
                        result += 5;
                        break;
                    case "6":
                        result += 6;
                        break;
                    case "7":
                        result += 7;
                        break;
                    case "8":
                        result += 8;
                        break;
                    case "9":
                        result += 9;
                        break;
                    case "10":
                    case "J":
                    case "Q":
                    case "K":
                    case "T":
                        result += 10;
                        break;
                    default:
                        Console.WriteLine("Карты с таким номиналом не существует. Попробуйте ещё раз.");
                        amountOfCards++;
                        break;
                }
            }

            Console.WriteLine($"Ваш общий номинал карт составлает {result}");
        }
    }
}
