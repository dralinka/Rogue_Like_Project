using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rogue_Like_Project
{
    //In dieser Klasse wird der Spieler definiert. Folgendes muss sie beinhalten
    //2 Int beinhalten die die X und Y Position auf dem Bild speichern
    //1 String Wert der nur aus einem Zeichen besteht der nacher das Symbol für des Spielers speichert
    //Eine Funktion die alle Funktionen aufruft die bei jedem Frame gebraucht werden
    //Eine Funktion die an der angegeben Position den SpielerString setzt
    //Eine Funktion die, die Eingabe überprüft (WASD) und dementsprechenden überprüft ob das Feld frei ist
    //den Spieler dorthin bewegt.
    public static class Spieler
    {
        public static Vector2 Position = new Vector2(4,3);
        public static string Player = ((char)1).ToString();


        public static void PlayerRoutine()
        {
            PlayerMove();
            SetPlayer();
            PrintPlayer();
        }

        public static void SetPlayer()
        {
            Program.SetStrng(Position.X, Position.Y, Player);
        }

        public static void PrintPlayer()
        {
            Program.SetStringToPosi(Position.X, Position.Y, Player);
        }

        public static bool PlayerMove()
        {
            switch (Program.KeyCode)
            {
                case "a":
                    if (Program.Sarray[Position.X - 1, Position.Y] == " ")//| || Program.Sarray[Position.X - 1, Position.Y] == "")
                {
                    Program.SetStrng(Position.X, Position.Y, " ");
                    Program.SetStringToPosi(Position.X, Position.Y, " ");
                    Position.X -= 1;
                    SetPlayer();
                    PrintPlayer();
                }
                return true;

                case "w":
                if (Program.Sarray[Position.X, Position.Y - 1] == " " )//|| Program.Sarray[Position.X - 1, Position.Y] == "")
                {
                    Program.SetStrng(Position.X, Position.Y, " ");
                    Program.SetStringToPosi(Position.X, Position.Y, " ");
                    Position.Y -= 1;
                    SetPlayer();
                    PrintPlayer();
                }
                return true;

                case "d":
                if (Program.Sarray[Position.X + 1, Position.Y] == " ")//||| Program.Sarray[Position.X - 1, Position.Y] == "")
                {
                    Program.SetStrng(Position.X, Position.Y, " ");
                    Program.SetStringToPosi(Position.X, Position.Y, " ");
                    Position.X += 1;
                    SetPlayer();
                    PrintPlayer();
                }
                return true;

                case "s":
                if (Program.Sarray[Position.X, Position.Y + 1] == " ")//||| Program.Sarray[Position.X - 1, Position.Y] == "")
                {
                    Program.SetStrng(Position.X, Position.Y, " ");
                    Program.SetStringToPosi(Position.X, Position.Y, " ");
                    Position.Y += 1;
                    SetPlayer();
                    PrintPlayer();
                }
                return true;
           

                default:
                return false;     
            }
            
        }
    }
}
