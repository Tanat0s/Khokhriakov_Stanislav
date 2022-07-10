using System;
using System.Threading;

namespace M7_OOP
{
    class Program
    {
        private static EmployeeRepository _employeeRepository = new EmployeeRepository();
        static void Main(string[] args)
        {
            //Добавляем новые записи, используя разные конструкторы для Employee
            _employeeRepository.Add("ФИО 1", 34, 155, new DateTime(1988, 11, 1), "Место рождения 1");
            _employeeRepository.Add("ФИО 2", 25, 188, new DateTime(1997, 5, 30));
            _employeeRepository.Add("ФИО 3", 16, 160);
            _employeeRepository.Add("ФИО 4", 45);
            _employeeRepository.Add("ФИО 5");
            _employeeRepository.Add("ФИО 6", 60, 195, new DateTime(1962, 7, 25), "Место рождения 6");

            //Просмотр всех записей
            for (int i = 0; i < _employeeRepository.Count(); i++)
            {
                _employeeRepository.Output(i);
            }

            //Ждем 1 сек, для того, чтобы была возможность изменить запись и отсортировать по дате
            Thread.Sleep(1000);

            Console.WriteLine("Обновим данные пользователя с id=5.\nДо изменения:");
            _employeeRepository.Output(4);
            _employeeRepository.Edit(new Employee(4, "ФИО 7", 50, 195, new DateTime(1972, 11, 11), "Место родения 7"));
            Console.WriteLine("После обновления данных:");
            _employeeRepository.Output(4);

            Console.WriteLine("Сортировка в порядке возростания, по дате обновления:");
            _employeeRepository.SortBy(true);
            //Просмотр всех записей
            for (int i = 0; i < _employeeRepository.Count(); i++)
            {
                _employeeRepository.Output(i);
            }

            Console.WriteLine("Сортировка в порядке убывания, по дате обновления:");
            _employeeRepository.SortBy(false);
            //Просмотр всех записей
            for (int i = 0; i < _employeeRepository.Count(); i++)
            {
                _employeeRepository.Output(i);
            }

            _employeeRepository.Delete(11);

            _employeeRepository.SaveChanges();

            Console.ReadKey();
        }

        public static void SayGoodbye()
        {
            Console.WriteLine("До новых встреч!");
        }
    }
}
