using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rogue_Like_Project
{

    //In dieser Klasse wird der Schlüssel definiert. Folgendes muss sie beinhalten
    //2 Int beinhalten die die X und Y Position auf dem Bild speichern
    //1 String Wert der nur aus einem Zeichen besteht der nacher das Symbol für des Schlüssels speichert
    //Einen Bool Wert der angibt ob Schlüssel aufgenommen wurde (Start: False bzw. nicht gefunden)
    //Eine Funktion die alle Funktionen aufruft die bei jedem Frame gebraucht werden
    //Eine Funktion die an der angegeben Position den TürString setzt
    //Eine Funktion die, überpfüft ob der Schlüssel gefunden worden ist die Funktion (MoveOnMe) ausführt 
    //und wenn MoveOnMe erfolgreich ausgefüht wird, den Schlüssel ausblendet.

    public class Schlüssel
    {
    
        public Vector2 Position = new Vector2 ();
        public string Key = ((char)3).ToString();
        public Boolean KeyFound = false;


        public void KeyRoutine()
        {
            CheckPlayerKey();
            SetKey();
            PrintKey();
         
        }


        public void SetKey()
        {
            Program.SetStrng(Position.X, Position.Y, Key);
        }

        public void PrintKey()
        {
            Program.SetStringToPosi(Position.X, Position.Y, Key);
        }

        //Überpfüft ob der Spielerim Umliegenden Feld ist und füht MoveOnMe und Schlüssel ggf. aufnimmt
        public void CheckPlayerKey()
        {
            if (KeyFound == false)
            {
                Program.MoveOnMe(Position.X, Position.Y, Spieler.Position.X, Spieler.Position.Y);
                if (Spieler.Position.X == Position.X && Spieler.Position.Y == Position.Y)
                {
                    KeyFound = true;
                    Position.X = 0;
                    Position.Y = 0;
                }
            }
        }

    }
}


