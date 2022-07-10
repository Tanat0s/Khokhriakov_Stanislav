using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace M7_OOP
{
    public class EmployeeRepository
    {
        private readonly string filePath = @"users.txt";
        private Employee[] employees = new Employee[3];

        private int currentId = 1;

        public EmployeeRepository()
        {
            DownloadData();
        }

        private void DownloadData()
        {
            using var fileStream = new FileStream(filePath, FileMode.OpenOrCreate);
            using var streamReader = new StreamReader(fileStream);

            while (!streamReader.EndOfStream)
            {
                var userInfo = streamReader.ReadLine().Split('#');
                var employee = new Employee()
                {
                    Id = int.Parse(userInfo[0]),
                    LastChanges = DateTime.Parse(userInfo[1]),
                    FullName = userInfo[2],
                    Age = int.Parse(userInfo[3]),
                    Height = int.Parse(userInfo[4]),
                    Birthday = DateTime.Parse(userInfo[5]),
                    Birthplace = userInfo[6]
                };

                Add(employee);
            }

            if(employees.Length > 0)
                currentId = employees.Max(e => e.Id) + 1;
        }

        /// <summary>
        /// Output selected Employee on screen by Id
        /// </summary>
        /// <param name="Id">Employee Id</param>
        public void Output(int employeeId)
        {
            var indexToOutput = Array.IndexOf(employees, new Employee(employeeId, ""));

            if (indexToOutput <= 0)
                return;

            Console.WriteLine(employees[indexToOutput]);
        }


        /// <summary>
        /// Add new employee
        /// </summary>
        /// <param name="fullName">Employee fullname</param>
        /// <param name="age">Employee age</param>
        /// <param name="height">Employee height</param>
        /// <param name="birthday">Employee birthday</param>
        /// <param name="birthplace">Employee birthplace</param>
        public void Add(string fullName, int age = 0, int height = 0, DateTime birthday = new DateTime(), string birthplace = "")
        {
            Add(new Employee(currentId++, fullName, age, height, birthday, birthplace));
        }

        private void Add(Employee employee)
        {
            if(employee.Id >= employees.Length)
            {   
                Array.Resize(ref employees, employee.Id * 2);
            }

            employees[employee.Id] = employee;
        }

        /// <summary>
        /// Delete employee
        /// </summary>
        /// <param name="Id">Employee id</param>
        public void Delete(int employeeId)
        {
            var indexToDelete = Array.IndexOf(employees, new Employee(employeeId, ""));

            if(indexToDelete != -1)
                employees[indexToDelete] = new Employee();
            else
                Console.WriteLine($"Пользователя с Id={employeeId} не существует.");
        }

        /// <summary>
        /// Edit employee by Id
        /// </summary>
        /// <param name="Id">Employee Id</param>
        public void Edit(Employee employee)
        {
            var employeeIndex = Array.IndexOf(employees, employee);

            if (employeeIndex != -1)
                employees[employee.Id] = employee;
            else
                Console.WriteLine($"Пользователя с Id={employee.Id} не существует.");
        }

        /// <summary>
        /// Load list of employees by range of date
        /// </summary>
        /// <param name="start">Begin of range</param>
        /// <param name="end">End of range</param>
        /// <returns></returns>
        public IEnumerable<Employee> Load(DateTime start, DateTime end)
        {
            return employees.Where(employee => employee.LastChanges > start && employee.LastChanges <= end);
        }

        /// <summary>
        /// Sort list of employees
        /// </summary>
        /// <param name="ascending">True - ascending sort, False - descending</param>
        public void SortBy(bool ascending)
        {
            employees = ascending
                ? employees.OrderBy(e => e.LastChanges).ToArray()
                : employees.OrderByDescending(e => e.LastChanges).ToArray();
        }

        /// <summary>
        /// Save all changes to file
        /// </summary>
        public void SaveChanges()
        {
            if (!File.Exists(filePath))
            {
                using var fs = File.Create(filePath);
            }

            using var streamWriter = new StreamWriter(filePath, false);

            var userInfo = new StringBuilder();

            for(var i=0; i<currentId; i++)
            {
                //Удаленные и не существующие элементы не сохраняем, 0 - запись удалена/не существует
                if (employees[i].Id == 0)
                    continue;

                userInfo.Append($"{employees[i].Id}#{employees[i].LastChanges}#");
                userInfo.Append($"{employees[i].FullName}#");
                userInfo.Append($"{employees[i].Age}#");
                userInfo.Append($"{employees[i].Height}#");
                userInfo.Append($"{employees[i].Birthday}#");
                userInfo.Append($"{employees[i].Birthplace}");

                streamWriter.WriteLine(userInfo);
                userInfo.Clear();
            }
        }

        /// <summary>
        /// Return count of empoyee records
        /// </summary>
        /// <returns>Count of employees</returns>
        public int Count()
        {
            return employees.Length;
        }
    }
}
