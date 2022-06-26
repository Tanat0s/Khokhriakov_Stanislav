using System;

namespace M2_1_Create_Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            const byte firstTab = 13;
            const byte secondTab = 20;

            string fullName = "Jhon Doe";
            byte age = 30;
            string email = "jhon.doe@gmail.com";
            float programmingGrade = 4.2f;
            float mathGrade = 5.1f;
            float physicsGrade = 4.0f;

            Console.WriteLine(
                $"{"Full Name:",firstTab} {fullName,secondTab}\n" +
                $"{"Age:",firstTab} {age,secondTab}\n" +
                $"{"E-mail:",firstTab} {email,secondTab}\n" +
                $"{"Programming:",firstTab} {programmingGrade,secondTab}\n" +
                $"{"Math:",firstTab} {mathGrade,secondTab}\n" +
                $"{"Physics:",firstTab} {physicsGrade,secondTab}\n");

            Console.ReadKey();

            //Задание 2
            float sumGrade = programmingGrade + mathGrade + physicsGrade;
            float averageGrade = sumGrade / 3;

            Console.WriteLine(
                $"{"Sum grade:",firstTab} {sumGrade,secondTab:#.#}\n" +
                $"{"Avg grade:",firstTab} {averageGrade,secondTab:#.#}");

            Console.ReadKey();
        }
    }
}
