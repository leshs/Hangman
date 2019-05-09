using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{

    //Versuche müssen wieder zurückgesetzt werden.
    class Program
    {
        private List<String> woerterListe = new List<String>();
        private List<char> buchstaben = new List<char>();
        private char[] wortArray;
        private char[] solutionArray;
        private int versuche;
        private ASCII galgen;

        static void Main(string[] args)
        {
            Program Hangman = new Program();
            Hangman.StartGame();
        }

        public void StartGame()
        {
            galgen = new ASCII();
            SetVersuche();
            galgen.SetVersuche(versuche);
            string file = SelectList();
            ReadFile(file);
            SelectWord();
        }

        //Versuche festlegen (zum zurücksetzen)
        public void SetVersuche()
        {
            versuche = 12;
        }

        //Spielauswahl / Auswahl der Liste
        public string SelectList()
        {
            Console.WriteLine("Bitte Spielliste wählen:");
            Console.WriteLine("1. Städte");
            Console.WriteLine("2. Pokemon");
            string pokemon = "Hangman_Wortliste_Pokemon.txt";
            string staedte = "Hangman_Wortliste_Städte.txt";
           
            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.D1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Das Spiel beginnt!");
                    Console.WriteLine("Welche Stadt wird gesucht?");
                    return staedte;
                }
                else if (cki.Key == ConsoleKey.D2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Das Spiel beginnt!");
                    Console.WriteLine("Welches Pokemon wird gesucht?");
                    return pokemon;
                }
                Console.WriteLine();
                Console.WriteLine("Bitte 1 oder 2 drücken");
            }
        }

        //Einlesen des Files und schreiben in die (Wörter-)Liste
        public void ReadFile(string file)
        {
            string line;
            StreamReader reader = new StreamReader(file);
            while ((line = reader.ReadLine()) != null)
            {
                woerterListe.Add(line);
            }
            SelectWord();
        }

        //Wort zufällig auswählen
        public void SelectWord()
        {
            int laenge = woerterListe.Count();
            Random rnd = new Random();
            string wort = woerterListe.ElementAt(rnd.Next(laenge));
            wortArray = wort.ToCharArray();

            for(int i = 0; i < wortArray.Length; i++)
            {
                wortArray[i] = Char.ToUpper(wortArray[i]);
            }
            Console.WriteLine();
            TryLetter(wortArray);
        }

        //Ausdrucken der erratenen Buchstaben
        public void PrintSolution(char[] solutionArray)
        {
            foreach (char buchstabe in solutionArray)
            {
                Console.Write(" " + buchstabe);
            }
        }

        //Hier ist das eigentliche Spiel sdf
        public void TryLetter(char[] wortArray)
        {
            int wortLength = wortArray.Length;
            int success = wortLength;
            solutionArray = new char[wortLength];
            //Füllen des "Solution-Array" mit Unterstrichen. Diese werden ggf. durch die korrekten Buchstaben ersetzt.
            for (int i = 0; i < wortLength; i++)
            {
                solutionArray[i] = '_';
            }

            //Schleife für das Spiel
            while (versuche > 0)
            {
                if (!solutionArray.Contains('_'))
                {
                    Console.WriteLine("gewonnen!!!");
                    Console.WriteLine();
                    GameOver();
                }
                Console.Write("verwendete Buchstaben: ");
                foreach(char buchstabe in buchstaben)
                {
                    Console.Write(buchstabe + " ");
                }
                Console.WriteLine();
                Console.WriteLine("verbleibende Versuche: " + versuche);
                PrintSolution(solutionArray);
                Console.WriteLine();
                Console.WriteLine("Buchstaben eingeben");
                ConsoleKeyInfo cki = Console.ReadKey();
                Console.WriteLine();
                char character = cki.KeyChar;
                Console.WriteLine();
                character = Char.ToUpper(character);
                if (!buchstaben.Contains(character))
                {
                    buchstaben.Add(character);

                    if (wortArray.Contains(character))
                    {
                        for (int j = 0; j < wortLength; j++)
                        {
                            if (wortArray.ElementAt(j).Equals(character))
                            {
                                solutionArray[j] = character;
                            }
                        }
                    }
                    else
                    {   
                        galgen.DrawGalgen();
                        versuche--;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Buchstabe bereits verwendet!");
                    continue;
                }
            }
            Console.WriteLine("verloren!");
            Console.WriteLine("Lösung: ");
            GameOver();
        }

        //Spiel zu Ende: Zurücksetzen der Variablen
        public void GameOver()
        {
            foreach (char buchstabe in wortArray)
            {
                Console.Write(buchstabe);
            }
            buchstaben.Clear();
            SetVersuche();
            woerterListe.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Enter für neues Spiel");
            Console.ReadLine();
            StartGame();
        }
    }
}
