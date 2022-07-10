using System;
using System.Diagnostics.CodeAnalysis;

namespace M7_OOP
{
    public struct Employee
    {
        public int Id;
        public DateTime LastChanges;
        public string FullName;
        public int Age;
        public int Height;
        public DateTime Birthday;
        public string Birthplace;

        #region Ctors
        public Employee(int id, string fullName, int age, int height, DateTime birthday, string birthplace)
        {
            Id = id;
            LastChanges = DateTime.Now;
            FullName = fullName;
            Age = age;
            Height = height;
            Birthday = birthday;
            Birthplace = birthplace;
        }

        public Employee(int id, string fullName, int age, int height, DateTime birthday) : this(id, fullName, age, height, birthday, string.Empty)
        { }

        public Employee(int id, string fullName, int age, int height) : this(id, fullName, age, height, new DateTime() ,string.Empty)
        { }

        public Employee(int id, string fullName, int age) : this(id, fullName, age, 0, new DateTime(), string.Empty)
        { }

        public Employee(int id, string fullName) : this(id, fullName, 0, 0, new DateTime(), string.Empty)
        { }
        #endregion

        public override string ToString()
        {
            return $"{Id}\n{LastChanges}\n{FullName}\n{Age}\n{Height}\n{Birthday.ToShortDateString()}\n{Birthplace}\n";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Employee)) return false;
            Employee other = (Employee)obj;
            return Id == other.Id;
        }

        public bool Equals(Employee other)
        {
            return Id == other.Id;
        }

        public static bool operator ==(Employee a, Employee b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Employee a, Employee b)
        {
            return !(a == b);
        }
    }
}
