using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace OOP_Lab_4._1
{
    public class Student
    {
        private string name;
        private string LastName;
        private string Group;
        private int Year;
        private string Adress;
        private string Pasword;
        private int Age;
        private string Telephone;
        private float Rating;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string LastNAME
        {
            get
            {
                return LastName;
            }
            set
            {
                LastName = value;
            }
        }
        public string group
        {
            get
            {
                return Group;
            }
            set
            {
                Group = value;
            }
        }
        public int year
        {
            get
            {
                return Year;
            }
            set
            {
                Year = value;
            }
        }
        public string adress
        {
            get
            {
                return Adress;
            }
            set
            {
                Adress = value;
            }
        }
        public string pasword
        {
            get
            {
                return Pasword;
            }
            set
            {
                Pasword = value;
            }
        }
        public int age
        {
            get
            {
                return Age;
            }
            set
            {
                Age = value;
            }
        }
        public string telephone
        {
            get
            {
                return Telephone;
            }
            set
            {
                Telephone = value;
            }
        }
        public float rating
        {
            get
            {
                return Rating;
            }
            set
            {
                Rating = value;
            }
        }

    }

    public class Program
    {
        static public int StudentRating(float R)
        {
            int m = 0;

            string str = null;

            if (R >= 90)
            {
                m = 1;
                str = "Вітаємо відмінника";

            }
            if (R < 90 && R >= 75)
            {
                m = 2;

                str = "можна вчитися краще";

            }
            if (R < 75)
            {
                m = 3;
                str = "Варто більше уваги приділяти навчанню";

            }

            return m;
        }







        static void Main(string[] args)
        {




            Student s = new Student();
            Console.WriteLine("Перший студент");
            Console.Write("Name: ");
            s.Name = Console.ReadLine();
            Console.Write("Last Name: ");
            s.LastNAME = Console.ReadLine();
            Console.Write("Group: ");
            s.group = Console.ReadLine();
            Console.Write("Year: ");
            s.year = int.Parse(Console.ReadLine());
            Console.Write("Adress: ");
            s.adress = Console.ReadLine();
            Console.Write("Pasword: ");
            s.pasword = Console.ReadLine();
            Console.Write("Age:");
            s.age = int.Parse(Console.ReadLine());
            Console.Write("Telephone: ");
            s.telephone = Console.ReadLine();
            Console.Write("Rating: ");
            s.rating = float.Parse(Console.ReadLine());
            float R = s.rating;
            Console.WriteLine(StudentRating(R));

            Student s1 = new Student();
            Console.WriteLine("Другий студент");
            Console.Write("Name: ");
            s1.Name = Console.ReadLine();
            Console.Write("Last Name: ");
            s1.LastNAME = Console.ReadLine();
            Console.Write("Group: ");
            s1.group = Console.ReadLine();
            Console.Write("Year: ");
            s1.year = int.Parse(Console.ReadLine());
            Console.Write("Adress: ");
            s1.adress = Console.ReadLine();
            Console.Write("Pasword: ");
            s1.pasword = Console.ReadLine();
            Console.Write("Age:");
            s1.age = int.Parse(Console.ReadLine());
            Console.Write("Telephone: ");
            s1.telephone = Console.ReadLine();
            Console.Write("Rating: ");
            s1.rating = float.Parse(Console.ReadLine());
            R = s1.rating;
            Console.WriteLine(StudentRating(R));





        }
    }
}