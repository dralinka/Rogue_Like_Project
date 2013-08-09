using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rogue_Like_Project

    
{
   public static class LevelManager
   {

       public static Tür Tür1 = new Tür();
       public static Tür Tür2 = new Tür();

       public static Schlüssel Key1 = new Schlüssel();
       public static Schlüssel Key2 = new Schlüssel();

       public static Kisten Kiste1 = new Kisten();
       public static Kisten Kiste2 = new Kisten();
       public static Kisten Kiste3 = new Kisten();
       public static Kisten Kiste4 = new Kisten();
       public static Kisten Kiste5 = new Kisten();
       public static Kisten Kiste6 = new Kisten();
       public static Kisten Kiste7 = new Kisten();
       public static Kisten Kiste8 = new Kisten();







        public static void LoadLevel(int Stagelvl)
        {

            if (Stagelvl == 0)
            {

                Hauptmenu.StartMenu();
                Hauptmenu.SetCursor();
                Program.PrintIt();
            }

            if (Stagelvl == 1)
            { 
            //Alle Objekte (Schlüssel,Spieler,Kisten,Türen,Vertikale Wände, Horizontale Wände)
            // Schlüssel ist die Schlüsselklasse (PositionX, PositionY)
                // Spieler iust die SpielerKlasse (PositionX, PositionY)
                // Kisten ist die KistenKlasse (PositionX, PositionY)
                // Türen ist die TürKlasse (PositionX, PositionY)
                // Spieler ist die SpielerKlasse (PositionX, PositionY) !!! ist schon Statisch!!!!!!!!!!!!!!
                // VertikaleWände ist die Programm.VertiWall (StartPosi,EndPosi,WelcheReihe,Welches Zeichen)
                // HorizontaleWände ist die Programm.HoriWall (StartPosi,EndPosi,WelcheReihe,Welches Zeichen)

                Kiste1.Position.X = 10;
                Kiste1.Position.Y = 10;
                Tür1.Position.X = 5;
                Tür1.Position.Y = 5;
                Key1.Position.X = 20;
                Key1.Position.Y = 20;
                Spieler.Position.X = 2;
                Spieler.Position.X = 2;
                Program.VertiWall(6, 10, 3, "f");
                Program.PrintIt();
            }


        }

        public static void FinishLevelLoadNew(int Stagelvl)
        {
            Program.DelStrng();
            LoadLevel(Stagelvl);
        }

        public static void LevelRoutine(int stagelvl)
        {
            if (stagelvl == 0)
            {
                Hauptmenu.CursorRoutine();
                Hauptmenu.SetCursor();
                Program.PrintIt();

            }

            if (stagelvl == 1)
            {
                Spieler.PlayerRoutine();
                Tür1.DoorRoutine(Key1.KeyFound, Key1.KeyFound);
                Key1.KeyRoutine();
                Kiste1.BoxRoutine(Spieler.Position.X, Spieler.Position.Y);

            }
        }

    }
}
