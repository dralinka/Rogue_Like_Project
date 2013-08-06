using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rogue_Like_Project
{
    public static class Program
    {
        static public int X = 0;
        static public int Y = 0;
        static public string[,] Sarray = new string[51,51];
        static public string Z = " ";
        static public string KeyCode = " ";
        static public ConsoleKey KeyInput;
        static public bool LevelEnded = false;


        public static Schlüssel BlaKey = new Schlüssel();
        public static Spieler BlaPlayer = new Spieler();
        public static Tür Blatür = new Tür();
        public static Kisten BlaKisten = new Kisten();
        public static Kisten Bla2Kisten = new Kisten();
        public static Kisten Bla3Kisten = new Kisten();
        public static Kisten Bla4Kisten = new Kisten();
        public static Kisten Bla5Kisten = new Kisten();
        public static Kisten Bla6Kisten = new Kisten();

        static void Main(string[] args)
        {

            //WändeTest
            VertiWall(8, 40, 4, "#");
            VertiWall(8, 40, 36, "#");
            HoriWall(4, 40, 8, "#");
            HoriWall(4, 40, 36, "#");

            //TürTest
            Blatür.Position.X = 25;
            Blatür.Position.Y = 36;

            //SchlüsselTest
            BlaKey.Position.X = 25;
            BlaKey.Position.Y = 25;

            //SpielerTest
            BlaPlayer.Position.X = 30;
            BlaPlayer.Position.Y = 30;
        
            //Kisten test
            BlaKisten.Position.X = 24;
            BlaKisten.Position.Y = 25;

            //Kisten test
            Bla2Kisten.Position.X = 24;
            Bla2Kisten.Position.Y = 26;

            //Kisten test
            Bla3Kisten.Position.X = 25;
            Bla3Kisten.Position.Y = 26;

            //Kisten test
            Bla4Kisten.Position.X = 26;
            Bla4Kisten.Position.Y = 26;

            //Kisten test
            Bla5Kisten.Position.X = 26;
            Bla5Kisten.Position.Y = 25;

            //Kisten test
            Bla6Kisten.Position.X = 25;
            Bla6Kisten.Position.Y = 24;

            SetRoutine();
            FrameRoutine();
            SetRoutine();

            KeyPress();
         
            
        }
        public static void SetRoutine()
        {
            //Spieler muss in der Routine als letztes abgerufen werden

            VertiWall(8, 40, 4, "#");
            VertiWall(8, 40, 36, "#");
            HoriWall(4, 40, 8, "#");
            HoriWall(4, 40, 36, "#");

            BlaKey.SetKey();

            BlaKisten.SetBox();
            Bla2Kisten.SetBox();
            Bla3Kisten.SetBox();
            Bla4Kisten.SetBox();
            Bla5Kisten.SetBox();
            Bla6Kisten.SetBox();

            Blatür.SetDoor();

            BlaPlayer.SetPlayer();

        }

        public static void FrameRoutine()
        {
            
            
            FinishLevel();

            BlaKey.SetKey();
            
            BlaKey.KeyRoutine(BlaPlayer.Position.X, BlaPlayer.Position.Y);

            BlaKisten.SetBox();
            Bla2Kisten.SetBox();
            Bla3Kisten.SetBox();
            Bla4Kisten.SetBox();
            Bla5Kisten.SetBox();
            Bla6Kisten.SetBox();

            //Kisten müssen vorher dargestellt werden

            BlaKisten.BoxRoutine(BlaPlayer.Position.X, BlaPlayer.Position.Y);
            Bla2Kisten.BoxRoutine(BlaPlayer.Position.X, BlaPlayer.Position.Y);
            Bla3Kisten.BoxRoutine(BlaPlayer.Position.X, BlaPlayer.Position.Y);
            Bla4Kisten.BoxRoutine(BlaPlayer.Position.X, BlaPlayer.Position.Y);
            Bla5Kisten.BoxRoutine(BlaPlayer.Position.X, BlaPlayer.Position.Y);
            Bla6Kisten.BoxRoutine(BlaPlayer.Position.X, BlaPlayer.Position.Y);


            LevelEnded = Blatür.DoorRoutine(BlaKey.KeyFound, BlaPlayer.Position.X, BlaPlayer.Position.Y);

            BlaPlayer.PlayerRoutine();

            BlaKey.KeyRoutine(BlaPlayer.Position.X, BlaPlayer.Position.Y);



            PrintIt();
            DelStrng();
        }

        public static void KeyPress()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.A:
                            KeyCode = "a";
                            FrameRoutine();
                            break;
                        case ConsoleKey.W:
                            KeyCode = "w";
                            FrameRoutine();
                            break;
                        case ConsoleKey.S:
                            KeyCode = "s";
                            FrameRoutine();
                            break;
                        case ConsoleKey.D:
                            KeyCode = "d";
                            FrameRoutine();
                            break;
                        default:
                            KeyCode = " ";
                            break;
                    }
                }
            }
        }


        //BildAusgabe
        public static void PrintIt()
        {
        Console.Clear();
            for (int i = 0; i <=35; i++)
            {
            Y++;
            X = 0;
            Console.WriteLine();
                for (int i2 = 0; i2<=35; i2++)
                {
                X++;
                    if (Sarray[X, Y] == null)
                    {
                        Sarray[X, Y] = Z;
                    }
                Console.Write(Sarray[X,Y]);
                }
            }
        X = 0;
        Y = 0;
        }


        //Setzt das das gewüschte Zeichen in Bildausgabe Array
        public static void SetStrng(int x, int y,string z)
        {
            Sarray[x, y] = z;
        }

        //Löscht alle Zeichen aus dem Array
        public static void DelStrng()
        {
            for (int i3 = 0; i3 <= 35; i3++)
            {
            X++;
            Y = 0;
                for (int i4 = 0; i4 <= 35; i4++)
                {
                    Y++;
                    if (Sarray[X, Y] == "P" || Sarray[X, Y] == "K" || Sarray[X, Y] == "D" || Sarray[X, Y] == "O")
                    {
                    Sarray[X, Y] = " ";
                    }
                }
            }
        X = 0;
        Y = 0;
        }


        //Setzt ein Vertikale Stringreihe ins array zwischen zwei Punkten and Reihe X mit String Symbol
        public static void VertiWall(int start1, int end1, int ReiheX, string Symbol)
        {
            int H = 0;
            start1 -= 1;
            for (int Walli = 0; Walli <= end1; Walli++)
            {
                H ++;
                if (H > start1)
                {
                   SetStrng(H, ReiheX, Symbol); 
                }  
            }
        }

        //Setzt ein Horizontale Stringreihe ins array zwischen zwei Punkten and Zeile Y mit String Symbol
        public static void HoriWall(int start2, int end2, int ReiheY, string Symbol)
        {
            int H = 0;
            start2 -= 1;
            for (int Walli = 0; Walli <= end2; Walli++)
            {
                H ++;
                if (H > start2)
                {
                   SetStrng(ReiheY, H, Symbol); 
                }  
            }
        }


        //Setzt den Spieler auf das Feld des Objektes wenn er sich draufbewegen möchte
        public static bool MoveOnMe(int ObjX, int ObjY,int PlayerX,int PlayerY)
        {
            if (PlayerX + 1 == ObjX && PlayerY == ObjY && KeyCode == "d")
            {
                Sarray[ObjX, ObjY] = " ";
                return true;
            }
            else if (PlayerX - 1 == ObjX && PlayerY == ObjY && KeyCode == "a")
            {
                Sarray[ObjX, ObjY] = " ";
                return true;
            }
            else if (PlayerY + 1 == ObjY && PlayerX == ObjX && KeyCode == "s")
            {
                Sarray[ObjX, ObjY] = " ";
                return true;
            }
            else if (PlayerY - 1 == ObjY && PlayerX == ObjX && KeyCode == "w")
            {
                Sarray[ObjX, ObjY] = " ";
                return true;
            }
            else
            {
                return false;
            }
              
        }

        public static void FinishLevel()
        {
            if (LevelEnded)
            {
                DelStrng();

                //WändeTest
                VertiWall(8, 40, 4, "#");
                VertiWall(8, 40, 36, "#");
                HoriWall(4, 40, 8, "#");
                HoriWall(4, 40, 36, "#");

                //TürTest
                Blatür.Position.X = 25;
                Blatür.Position.Y = 36;

                //SchlüsselTest
                BlaKey.Position.X = 25;
                BlaKey.Position.Y = 25;

                //SpielerTest
                BlaPlayer.Position.X = 30;
                BlaPlayer.Position.Y = 30;

                //Kisten test
                BlaKisten.Position.X = 24;
                BlaKisten.Position.Y = 25;

                //Kisten test
                Bla2Kisten.Position.X = 24;
                Bla2Kisten.Position.Y = 26;

                //Kisten test
                Bla3Kisten.Position.X = 25;
                Bla3Kisten.Position.Y = 26;

                //Kisten test
                Bla4Kisten.Position.X = 26;
                Bla4Kisten.Position.Y = 26;

                //Kisten test
                Bla5Kisten.Position.X = 26;
                Bla5Kisten.Position.Y = 25;

                //Kisten test
                Bla6Kisten.Position.X = 25;
                Bla6Kisten.Position.Y = 24;

                BlaKey.KeyFound = false;

                LevelEnded = false;
            }
        }

    }
}
