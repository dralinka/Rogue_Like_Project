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
        public int KeyX;
        public int KeyY;
        public string Key = "K";
        public Boolean KeyFound = false;

        public void KeyRoutine(int PlayerX, int PlayerY)
        {
            CheckPlayerKey(PlayerX,PlayerY);
            SetKey();
        }

        public void SetKey()
        {
            Program.SetStrng(KeyX, KeyY, Key);
        }

        //Überpfüft ob der Spielerim Umliegenden Feld ist und füht MoveOnMe und Schlüssel ggf. aufnimmt
        public void CheckPlayerKey(int PlayerX, int PlayerY)
        {
            if (KeyFound == false)
            {
                Program.MoveOnMe(KeyX, KeyX, PlayerX, PlayerY);
                if (PlayerX == KeyX && PlayerY == KeyY)
                {
                    KeyFound = true;
                    KeyX = 0;
                    KeyY = 0;
                }
            }
        }

    }
}




/*
        int KeyX;
        int KeyY;
        string Key = "K";
        Boolean KeyFound = false;

        public void SetKeyPosition(int X, int Y)
        {
            KeyX = X;
            KeyY = Y;
        }

        //Setzt den SchlüsselString ins Array
        public void SetKey()
        {
            Program.SetStrng(KeyX, KeyY, Key);
            if (KeyFound)
            {
                KeyFound = true;
            }
        }
    }
}
 */
