using System;
using System.IO;
using System.Xml.Linq;

namespace M8_4_Notebook
{
    /*
     Программа спрашивает у пользователя данные о контакте:
        - ФИО
        - Улица
        - Номер дома
        - Номер квартиры
        - Мобильный телефон
        - Домашний телефон
     С помощью XElement создайте xml файл, в котором есть введенная информация. 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ФИО пользователя:");
            var fullName = Console.ReadLine();

            var xmlPerson = new XElement("Person", new XAttribute("name", fullName));

            Console.WriteLine($"Введите название улицы, по которой проживает {fullName}:");
            var streetName = Console.ReadLine();

            var xmlAddress = new XElement("Address", new XElement("Street", streetName));

            Console.WriteLine($"Введите номер дома, по которому проживает {fullName}:");
            var houseNumber = Console.ReadLine();

            xmlAddress.Add(new XElement("HouseNumber", houseNumber));

            Console.WriteLine($"Введите номер квартиры, по которой проживает {fullName}:");
            var flatNumber = Console.ReadLine();

            xmlAddress.Add(new XElement("FlatNumber", flatNumber));
            xmlPerson.Add(xmlAddress);

            Console.WriteLine($"Введите номер мобильного телофона пользователя {fullName}:");
            var mobilePhoneNumber = Console.ReadLine();

            var xmlPhones = new XElement("Phones", new XElement("MobilePhone", mobilePhoneNumber));

            Console.WriteLine($"Введите номер домашнего телофона пользователя {fullName}:");
            var flatPhoneNumber = Console.ReadLine();

            xmlPhones.Add(new XElement("FlatPhone", flatPhoneNumber));
            xmlPerson.Add(xmlPhones);

            File.WriteAllText(@"notebook.xml", xmlPerson.ToString());

            Console.ReadKey();
        }
    }
}
