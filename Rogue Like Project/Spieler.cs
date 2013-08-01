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
    public class Spieler
    {
        public Vector2 Position = new Vector2();
        public string Player = "P";


        public void PlayerRoutine()
        {
            PlayerMove();
            SetPlayer();
        }

        public void SetPlayer()
        {
            Program.SetStrng(Position.X, Position.Y, Player);
        }

        public bool PlayerMove()
        {
            switch (Program.KeyCode)
            {
                case "a":
                    if (Program.Sarray[Position.X - 1, Position.Y] == " ")
                {
                    Position.X -= 1;
                }
                return true;

                case "w":
                if (Program.Sarray[Position.X, Position.Y - 1] == " ")
                {
                    Position.Y -= 1;
                }
                return true;

                case "d":
                if (Program.Sarray[Position.X + 1, Position.Y] == " ")
                {
                    Position.X += 1;
                }
                return true;

                case "s":
                if (Program.Sarray[Position.X, Position.Y + 1] == " ")
                {
                    Position.Y += 1;
                }
                return true;
           

                default:
                return false;     
            }
            
        }
    }
}
