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
        public int DoorX = 1;
        public int DoorY = 1;
        public string Door = "D";
        public Boolean DoorOpen = false;

        public void DoorRoutine(Boolean CheckKey,int PlayerX, int PlayerY)
        {
            DoorCheck(Program.BlaKey.KeyFound);
            SetDoor();
            CheckPlayerDoor(Program.BlaPlayer.Position.X, Program.BlaPlayer.Position.Y);

        }

        //Setzt den TürString ins Array
        public void SetDoor()
        {
            Program.SetStrng(DoorX, DoorY, Door);
        }

        //Öffnet die Tür wenn der Schlüssel gefunden worden ist
        public void DoorCheck(Boolean CheckKey)
        {
            DoorOpen = CheckKey;
        }


        //Überpfüft ob der Spieler den Schlüssel besitzt und im Umliegenden Feld ist und füht MoveOnMe aus
        public void CheckPlayerDoor(int PlayerX, int PlayerY)
        {
            if(DoorOpen)
            {
                if (Program.MoveOnMe(DoorX, DoorY, PlayerX, PlayerY))
                {
                    DoorX = 0;
                    DoorY = 0;
                }
            }
        }

    }
}



    /*
        public string Door = "D";
        Boolean DoorOpen = false;
    
        public int x
        {
            get;
            set;
        }

        public int y
        {
            get;
            set;
        }

        public void SetDoorPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void GetDoorPosition(out int x, out int y)
        {
            x = this.x;
            y = this.y;
        }

        public Boolean DoorCheck(int x, int y)
        {
            if ((x + 1 == this.x || x - 1 == this.x) && (y == this.y))
            {
                if ((y + 1 == this.y || x - 1 == this.y) && (x == this.x))
                {

                    DoorOpen = true;
                    Door = " ";
                    return true;
                   
                }
            }
                return false;
        
        }
    }
}
    */