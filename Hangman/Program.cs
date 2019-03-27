using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        public List<String> woerterListe = new List<String>();
        public List<String> buchstaben = new List<String>();
        static void Main(string[] args)
        {
            SelectList();
        }

        //erst auswählen, welche Liste
        public static void SelectList()
        {
            Console.WriteLine("Bitte Spielliste wählen:");
            Console.WriteLine("1. Pokemon");
            Console.WriteLine("2. Städte");

            Boolean noInput = true;

            while (noInput)
            {
                ConsoleKeyInfo cki = Console.ReadKey();


                if (cki.Key == ConsoleKey.D1)
                {
                    ReadFile("Hangman_Wortliste_Pokemon.txt");
                    noInput = false;
                }
                else if (cki.Key == ConsoleKey.D2)
                {
                    ReadFile("Hangman_Wortliste_Städte.txt");
                    noInput = false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Bitte 1 oder 2 drücken");
                }
            }
        }

        //hier die Liste lesen
        public static void ReadFile(string file)
        {
            string line;
            StreamReader reader = new StreamReader(file);
            while((line = reader.ReadLine()) != null){
                woerterListe.Add(line);
            }

            Console.ReadLine();
        }

        //Wort zufällig auswählen
        public static void SelectWord(){
            int laenge = woerterListe.Count();
            int position = random.Next(laenge);
}           string wort = woerterListe.ElementAt(position);
            char [] buchstabenArray = wort.ToCharArray();
    }
}
