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
        public static List<String> woerterListe = new List<String>();
        public static List<char> buchstaben = new List<char>();
        static void Main(string[] args)
        {
            SelectList();
        }

        //erst auswählen, welche Liste
        public static void SelectList()
        {
            Console.WriteLine("Bitte Spielliste wählen:");
            Console.WriteLine("1. Städte");
            Console.WriteLine("2. Pokemon");

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
           // buchstabenListeFuellen();
            SelectWord();

        }

        //Buchstabenliste füllen
        public static void BuchstabenListeFuellen(){
            char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        foreach(char buchstabe in alphabet)
                {
                buchstaben.Add(buchstabe);
                }
        }


        //Wort zufällig auswählen
        public static void SelectWord(){
            BuchstabenListeFuellen();
            int laenge = woerterListe.Count();
            Random rnd = new Random();
            string wort = woerterListe.ElementAt(rnd.Next(laenge));
            char [] wortArray = wort.ToCharArray();
            BuchstabenListeFuellen();
            Console.WriteLine();
            Console.WriteLine(wort);
            Console.ReadLine();
            SelectList();
            }

        public static void TryLetter(char[] wortArray){
            int wortLength = wortArray.Length();

            for(int i = 0; i < 12; i++){
                if(wortLength=0){
}                   Console.WriteLine("gewonnen");
                    SelectList();
                }
                Console.WriteLine("Buchstaben eingeben");
                ConsoleKeyInfo cki = Console.ReadKey();
                if(wortArray.Contains(cki.Key)){

}

            }   
        }
    }
}
