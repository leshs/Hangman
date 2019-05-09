using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class ASCII
         
    {
        char[,] galgen = new char[9, 7];
        int versuche; 
        public ASCII()

            //Boden des ASCII-Bildes
        {
            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    galgen[j, i] = ' ';
                }
            }
            for(int i = 0; i < 9; i++)
            {
                galgen[i, 6] = '=';
            }            
        }

        //Aufbau des Galgenmännchens
        public void DrawGalgen()
        {
            versuche--;
            switch (versuche)
            {
                case 10:
                    for (int i = 1; i < 6; i++)
                    {
                        galgen[6, i] = '|';
                    }
                    break;
                case 9:
                    galgen[5, 5] = '/';
                    break;
                case 8:
                    galgen[7,5] = '\\';
                    break;
                case 7:
                    galgen[2, 0] = '+';
                    for(int i = 3; i < 7; i++)
                    {
                        galgen[i, 0] = '-';
                    }
                    galgen[6, 0] = '+';
                    break;
                case 6:
                    galgen[2, 1] = '|';
                    break;
                case 5:
                    galgen[2, 2] = 'O';
                    break;
                case 4:
                    galgen[2, 3] = '|';
                    break;
                case 3:
                    galgen[1, 3] = '/';
                    break;
                case 2:
                    galgen[3, 3] = '\\';
                    break;
                case 1:
                    galgen[1, 4] = '/';
                    break;
                case 0:
                    galgen[3,4] = '\\';
                    break;
            }
            PrintGalgen();
        }

        public void PrintGalgen()
        {
            for(int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    Console.Write(galgen[j, i]);
                }
                Console.WriteLine();
            }
        }

        //Methode zum Zurücksetzen der Versuche
        public void SetVersuche(int nummer) 
        {
            versuche = nummer;
        }
    }
}
