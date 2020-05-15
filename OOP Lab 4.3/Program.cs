using System;
using System.IO;

namespace OOP_Lab_4._3
{
    class Program
    {
        public static MusicCollection[] music = new MusicCollection[1000000];
        public static bool[] delete = new bool[1000000];


        static void Main(string[] args)
        {

            Input.Key();



        }

    }

    class MusicCollection
    {
        private string song;
        private string singer;
        private string album;
        private int year;
        private string time;

        public string Song
        {
            get { return song; }
            set { song = value; }

        }
        public string Singer
        {
            get { return singer; }
            set { singer = value; }
        }
        public string Album
        {
            get { return album; }
            set { album = value; }
        }
        public int Year
        {
            get { return year; }
            set
            {
                if (value > 0) year = value;
                else throw new FormatException();
            }
        }
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
       

       
        public MusicCollection(string song, string singer, string album, int year, string time)
        {
            this.song = song;
            this.singer = singer;
            this.album = album;
            this.year = year;
            this.time = time;
        }
    }
    class Output
    {
        public static void Write(MusicCollection[] m)
        {
            Console.WriteLine("{0,-30} {1, -20} {2, -30} {3, -15} {4, -15}", "Назва пісні", "Виконавець", "Альбом", "Рік випуску", "Тривалість");

            for (int i = 0; i < m.Length; ++i)
            {
                if (m[i] != null)
                {
                    Console.WriteLine("{0,-30} {1, -20} {2, -30} {3, -15} {4,-15}", Program.music[i].Song, Program.music[i].Singer, Program.music[i].Album, Program.music[i].Year, Program.music[i].Time);
                }
            }
        }

        public static void Write1(MusicCollection[] m, bool[] write)
        {
            Console.WriteLine("{0,-30} {1, -20} {2, -30} {3, -15} {4, -15}", "Назва пісні", "Виконавець", "Альбом", "Рік випуску", "Тривалість");

            for (int i = 0; i < m.Length; ++i)
            {
                if ((write[i]) && (!Program.delete[i]))
                {
                    Console.WriteLine("{0,-30} {1, -20} {2, -30} {3, -15} {4, -15}", Program.music[i].Song, Program.music[i].Singer, Program.music[i].Album, Program.music[i].Year, Program.music[i].Time);
                }
            }
        }
    }

    class Input
    {
     

        public static void Key()
        {
            Work.Parse(Read(), false);

            Console.WriteLine("Додавання записiв: +");
            Console.WriteLine("Редагування записiв: E");
            Console.WriteLine("Знищення записiв: -");
            Console.WriteLine("Виведення записiв: Enter");
            Console.WriteLine("Пошук записiв: F");
            Console.WriteLine("Сортуванн записiв: S");
            Console.WriteLine("Вихiд: Esc");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.OemPlus:
                    Console.WriteLine();
                    Work.Add();
                    break;

                case ConsoleKey.E:
                    Console.WriteLine();
                    Work.Edit();
                    break;

                case ConsoleKey.OemMinus:
                    Console.WriteLine();
                    Work.Remove();
                    break;

                case ConsoleKey.Enter:
                    Console.WriteLine();
                    Output.Write(Program.music);
                    Key();
                    break;

                case ConsoleKey.F:
                    Console.WriteLine();
                    Work.Find();
                    break;

                case ConsoleKey.S:
                    Console.WriteLine();
                    Work.Sort();
                    break;

                case ConsoleKey.Escape:
                    return;
            }
        }
        public static string[] Read()
        {
            StreamReader fromFile = new StreamReader("text.txt");

            return fromFile.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        }
    }
    class Work
    {
        public static void Add()
        {
            Console.WriteLine("Введiть данi");

            string str = Console.ReadLine();

            string[] elements = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Parse(elements, true);

            Input.Key();
        }

        public static void Remove()
        {
            Console.Write("Виконавець: ");

            string singer = Console.ReadLine();

            bool[] write = new bool[Program.music.Length];

            for (int i = 0; i < Program.music.Length; ++i)
            {
                if (Program.music[i] != null)
                {
                    if (Program.music[i].Singer == singer)
                    {
                        Console.WriteLine("{0,-30} {1, -30} {2, -30} {3, -15} {4, -15}", Program.music[i].Song, Program.music[i].Singer, Program.music[i].Album, Program.music[i].Year, Program.music[i].Time);

                        Console.WriteLine("Видалити? (Y/N)");

                        var key = Console.ReadKey().Key;

                        if (key == ConsoleKey.Y)
                        {
                            Program.delete[i] = true;
                        }
                        else
                        {
                            Program.delete[i] = false;
                        }
                    }
                }
            }
        }

        public static void Edit()
        {
            Console.Write("Виконавець: ");

            string singer = Console.ReadLine();

            bool[] write = new bool[Program.music.Length];

            for (int i = 0; i < Program.music.Length; ++i)
            {
                if (Program.music[i] != null)
                {
                    if (Program.music[i].Singer == singer)
                    {
                        Console.WriteLine("{0,-30} {1, -20} {2, -30} {3, -15} {4, -15}", Program.music[i].Song, Program.music[i].Singer, Program.music[i].Album, Program.music[i].Year, Program.music[i].Time);

                        Console.WriteLine("Введiть нову iнформацiю");

                        string str = Console.ReadLine();

                        string[] elements = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                        Program.music[i] = new MusicCollection(elements[0], elements[1], elements[2], int.Parse(elements[3]), elements[4]);
                    }
                }
            }
        }

        public static void Find()
        {
            Console.Write("Виконавець: ");

            string singer = Console.ReadLine();

            bool[] write = new bool[Program.music.Length];

            for (int i = 0; i < Program.music.Length-1; ++i)
            {
                if (Program.music[i] != null)
                {
                    if (Program.music[i].Singer == singer)
                    {
                        write[i] = true;
                       
                    }
                    else
                    {
                        write[i] = false;
                       
                    }
                }

            }

            Output.Write1(Program.music, write);

            Input.Key();
        }

        public static void Sort()
        {
            int index = 0;

            while (Program.music[index + 1] != null)
            {
                for (int i = 0; i < Program.music.Length - 1; ++i)
                {
                    if (Program.music[i + 1] != null)
                    {

                        for (int j = 0; j < Program.music.Length - 1; j++)
                        {
                            if (needToReOrder(Program.music[j], Program.music[j + 1]))
                            {
                                MusicCollection s = Program.music[j];
                                Program.music[j] = Program.music[j + 1];
                                Program.music[j + 1] = s;
                            }
                        }




                        string tempStr;
                        int tempInt;
                       

                        tempStr = Program.music[i].Song;
                        Program.music[i].Song = Program.music[i + 1].Song;
                        Program.music[i + 1].Song = tempStr;

                        tempStr = Program.music[i].Singer;
                        Program.music[i].Singer = Program.music[i + 1].Singer;
                        Program.music[i + 1].Singer = tempStr;

                        tempStr = Program.music[i].Album;
                        Program.music[i].Album = Program.music[i + 1].Album;
                        Program.music[i + 1].Album = tempStr;

                        tempInt = Program.music[i].Year;
                        Program.music[i].Year = Program.music[i + 1].Year;
                        Program.music[i + 1].Year = tempInt;

                        tempStr = Program.music[i].Time;
                        Program.music[i].Time = Program.music[i + 1].Time;
                        Program.music[i + 1].Time = tempStr;


                    }
                }

                ++index;
            }

            Output.Write(Program.music);

            Input.Key();
        }

        private static bool needToReOrder(MusicCollection musicCollection1, MusicCollection musicCollection2)
        {
            throw new NotImplementedException();
        }

        private static void Save(MusicCollection m)
        {
            StreamWriter save = new StreamWriter("text.txt", true);

            save.WriteLine(m.Song);
            save.WriteLine(m.Singer);
            save.WriteLine(m.Album);
            save.WriteLine(m.Year);
            save.WriteLine(m.Time);

            save.Close();
        }

        public static void Parse(string[] elements, bool save)
        {
            int counter = 0;

            while (Program.music[counter] != null)
            {
                ++counter;
            }

            for (int i = 0; i < elements.Length; i += 5)
            {
                Program.music[counter + i / 5] = new MusicCollection(elements[i], elements[i + 1], elements[i + 2], int.Parse(elements[i + 3]), elements[i + 4]);

                if (save)
                {
                    Save(Program.music[counter + i / 5]);
                }
            }
        }
        public static string[] Read()
        {
            StreamReader fromFile = new StreamReader("text.txt");

            return fromFile.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        }

    

       
    }
}

