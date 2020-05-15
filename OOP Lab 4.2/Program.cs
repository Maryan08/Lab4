using System;

namespace OOP_Lab_4._2
{
    public class Bank
    {
        public DateTime data;
        public string name;
        public string LastName;
        public string number;
        public float input;
        public float output;
        public float GetCash;
        public float OutCash;
        public float Cash;
        public Bank(DateTime data,string name,string LastName,string number,float input,float output,float GetCash,float OutCash,float Cash)
        {
            this.data = data;
            this.name = name;
            this.LastName = LastName;
            this.number = number;
            this.input = input;
            this.output = output;
            this.GetCash = GetCash;
            this.OutCash = OutCash;
            this.Cash = Cash;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            float max=0;
            Console.Write("Введіть кількість клієнтів: ");
            int n = int.Parse(Console.ReadLine());
            Bank[] b = new Bank[n];
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("Клієнт №" + (i + 1));
                Console.Write("дата проведення операції: ");
                DateTime data = new DateTime(2020,12,12);
                Console.WriteLine(data.ToString());
                Console.Write("Iм’я: ");
                string name = Console.ReadLine();
                Console.Write("прізвище: ");
                string LastName = Console.ReadLine();
                Console.Write("№ рахунку: ");
                string number = Console.ReadLine();
                Console.Write("сума безготівкового отримання: ");
                float input = float.Parse(Console.ReadLine());
                Console.Write("сума безготівкового переведення: ");
                float output = float.Parse(Console.ReadLine());
                Console.Write("отримано готівкою: ");
                float GetCash = float.Parse(Console.ReadLine());
                Console.Write("видано готівкою: ");
                float OutCash = float.Parse(Console.ReadLine());
                Console.Write("залишок вкладу: ");
                float Cash = float.Parse(Console.ReadLine());

                b[i] =new Bank(data,name,LastName,number,input,output,GetCash,OutCash,Cash);
               
            }
            int m= 0;
            Bank[] bk = new Bank[1];
            for (int i = 0; i < n; i++)
            {
                if (b[i].input >= max)
                {
                    m = i+1;
                    max = b[i].input;
                    bk[0] = b[i];
                  
                }
            }
            Console.WriteLine("\n*************************************\nКлієнт який має найбільшу суму безготівкового отримання коштів на рахунок.");
            Console.WriteLine("{0,-5} {1, -30} {2, -10} {3, -20} {4, -15} {5,-30} {6,-40}{7,-20}{8,-20}{9,-20}", "№", "Дата", "Ім'я", "прізвище", "№ рахунку", "сума безготівкового отримання", "сума безготівкового переведення", "отримано готівкою", "видано готівкою", "залишок вкладу");
            Console.WriteLine("{0,-5} {1, -30} {2, -10} {3, -20} {4, -15} {5,-40} {6,-30}{7,-30}{8,-10}{9,-15}" ,m, bk[0].data, bk[0].name, bk[0].LastName, bk[0].number, bk[0].input, bk[0].output, bk[0].GetCash, bk[0].OutCash, bk[0].Cash);

        }
    }
}
