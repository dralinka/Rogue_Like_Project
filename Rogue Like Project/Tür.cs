using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rogue_Like_Project
{

    //In dieser Klasse wird die Tür definiert. Folgendes muss sie beinhalten
    //2 Int beinhalten die die X und Y Position auf dem Bild speichern
    //1 String Wert der nur aus einem Zeichen besteht der nacher das Symbol für die Tür speichert
    //Einen Bool Wert der angibt ob die Tür geöffnet oder geschlossen ist (Start False bzw geschlossen)
    //Eine Funktion die alle Funktionen aufruft die bei jedem Frame gebraucht werden
    //Eine Funktion die an der angegeben Position den TürString setzt
    //Eine Funktion die wenn in der "Schlüssel"klasse der SchüsselBoolean true ist, die Tür öffnet
    //Eine Funktion die, wenn die Tür geöffnet ist und die Funktion (MoveOnMe) ausführt und bei Erfolg
    //die Tür ausblendet

    public class Tür
    {
        public Vector2 Position = new Vector2();
        public string Door = "D";
        public Boolean DoorOpen = false;

        public bool DoorRoutine(Boolean CheckKey,int PlayerX, int PlayerY)
        {
            DoorCheck(Program.BlaKey.KeyFound);
            SetDoor();
            return CheckPlayerDoor(Program.BlaPlayer.Position.X, Program.BlaPlayer.Position.Y);

        }

        //Setzt den TürString ins Array
        public void SetDoor()
        {
            Program.SetStrng(Position.X, Position.Y, Door);
        }

        //Öffnet die Tür wenn der Schlüssel gefunden worden ist
        public void DoorCheck(Boolean CheckKey)
        {
            DoorOpen = CheckKey;
        }


        //Überpfüft ob der Spieler den Schlüssel besitzt und im Umliegenden Feld ist und füht MoveOnMe aus
        public bool CheckPlayerDoor(int PlayerX, int PlayerY)
        {
            if (DoorOpen)
            {
                if (Program.MoveOnMe(Position.X, Position.Y, PlayerX, PlayerY))
                {
                    Position.X = 0;
                    Position.Y = 0;
                    return true;
                }
                else return false;
            }
            else return false;
        }

    }
}


