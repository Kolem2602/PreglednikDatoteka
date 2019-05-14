using System;
using System.IO;

namespace DatotecniSustav01
{
    class Program
    {
        static void Main(string[] args)
        {
            string direktorij = @"C:\";
            DirectoryInfo dirInfo = new DirectoryInfo(direktorij);

            var datoteke = dirInfo.GetFiles();
            long velicina = 0;
            //varijable za laksu pretvorbu B u KB,MB,GB
            const long OneKb = 1024;
            const long OneMb = OneKb * 1024;
            const long OneGb = OneMb * 1024;
       

            Console.WriteLine("+------------------+-------------+---------+----------------------------------------------------+");
            Console.WriteLine("| Veličina       B |          KB |      MB |      GB | Nazivi datoteka                          |");
            Console.WriteLine("+------------------+-------------+---------+----------------------------------------------------+");
            foreach (FileInfo d in datoteke)
            {
                velicina += d.Length;
                Console.WriteLine("|{0, 15} B | {1, 8} KB | {2, 4} MB | {3, 4} GB |{4,40} |", 
                    d.Length, 
                    d.Length / OneKb, 
                    d.Length / OneMb,
                    d.Length / OneGb,
                    d.FullName);
            }
            Console.WriteLine("+------------------+-------------+---------+--------------------------------------------------+");
            Console.WriteLine("|{0, 15} B | {1, 8} KB | {2, 4} MB |  {3,4}GB                                          |",
                velicina,
                velicina / OneKb,
                velicina / OneMb,
                velicina/OneGb);
            Console.WriteLine("+------------------+-------------+---------+--------------------------------------------------+");

            Console.SetCursorPosition(1, 3);
            Console.Write(">");
            int brojRedova = datoteke.Length + 6;

            int cekanjeTreperenje = 500;
            Console.CursorVisible = false;
            int pokazivacY = 3;
            while (true)
            {
                System.Threading.Thread.Sleep(cekanjeTreperenje);
                Console.SetCursorPosition(1, pokazivacY);
                Console.Write(" ");
                System.Threading.Thread.Sleep(cekanjeTreperenje);
                Console.SetCursorPosition(1, pokazivacY);
                Console.Write(">");

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pritisnutaTipka = Console.ReadKey(true);
                    if (pritisnutaTipka.Key == ConsoleKey.DownArrow)
                    {
                        pokazivacY++;
                    }
                }
            }

            // Console.SetCursorPosition(0, brojRedova);
        } //Main
    }
}
