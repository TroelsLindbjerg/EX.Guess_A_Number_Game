using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace EX.Guess_A_Number_Game
{
    class Program
    {
        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Velkommen til spillet");
            Console.WriteLine("");
            Console.WriteLine("Option 1. Spil");
            Console.WriteLine("Option 2. Se Highscore");
            Console.WriteLine("Option 3. Afslut");
            Console.WriteLine("----------------------------------------------");
            Console.Write("Indtast 1 eller 2 eller 3 udfra hvad du ønsker: ");
            string myOptions;
            myOptions = Console.ReadLine();
            switch (myOptions)
            {
                case "1":
                    Game();
                    break;
                case "2":
                    Highscore();
                    break;
                case "3":
                    Exit();
                    break;
            }
            
            MainMenu();
        }
        static void Game()
        {
            Random rnd = new Random();
            int a = rnd.Next(10);

            //Skal slettes senere.
            Console.WriteLine(a);
            Console.WriteLine("Gæt et tal mellem 0 - 10");

            int b = int.Parse(Console.ReadLine());
            int count = 1;

            while (b != a)
            {
                if (b > a)
                {
                    Console.WriteLine("Dit gæt er for højt");
                }
                else
                {
                    Console.WriteLine("Dit gæt er for lavt");
                }
                Console.WriteLine("Gæt igen");
                b = int.Parse(Console.ReadLine());
                count++;

            }
            Console.WriteLine("Du har gættet rigtigt og brugt " + count + " gæt");
            Console.Write("Indtast dit navn: ");

            string navn = Console.ReadLine(); ;
            SaveHighscore(count, navn);
            Console.ReadLine();
        }
        static void Highscore()
        {
            showHighscore();
            Console.ReadLine();
        }
        static void Exit()
        {
            Console.WriteLine("Er du sikker på at du vil afslutte spillet?");
            Console.WriteLine("Tryk ENTER for at gennemføre");
            System.Environment.Exit(1);
        }

        static void showHighscore()
        {
            List<string> highscoreList = new List<string>();

            using (StreamReader read = new StreamReader(@"C:\Users\troe5906\source\repos\EX.Guess_A_Number_Game\EX.Guess_A_Number_Game\bin\Debug\Highscore.txt"))
            {
                while (!read.EndOfStream)
                {
                    highscoreList.Add(read.ReadLine());
                }
            }
            highscoreList.Sort();
            highscoreList = highscoreList.OrderBy(s => int.Parse(s.Split(':')[0])).ToList();
            foreach (var item in highscoreList)
            {
                Console.WriteLine(item);
            }
        }
        static void SaveHighscore (int tal, string forNavn)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Users\troe5906\source\repos\EX.Guess_A_Number_Game\EX.Guess_A_Number_Game\bin\Debug\Highscore.txt", true))
            {
                writer.WriteLine(tal + ": " + forNavn);
            }
        }
        static void Main(string[] args)
        {
            MainMenu();
            showHighscore();

            //KODEN TIL SPILLET
            //Random rnd = new Random();
            //int a = rnd.Next(10);

            ////Skal slettes senere.
            //Console.WriteLine(a);
            //Console.WriteLine("Gæt et tal mellem 0 - 10");

            //int b = int.Parse(Console.ReadLine());
            //int count = 1;

            //while (b != a)
            //{
            //    if (b > a)
            //    {
            //        Console.WriteLine("Dit gæt er for højt");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Dit gæt er for lavt");
            //    }
            //    Console.WriteLine("Gæt igen");
            //    b = int.Parse(Console.ReadLine());
            //    count++;

            //}
            //Console.WriteLine("Du har gættet rigtigt og brugt " + count + " gæt");
            //Console.Write("Indtast dit navn: ");

            //string navn = Console.ReadLine();

            //SaveHighscore(count, navn);
            //showHighscore();

        }
    }
}
