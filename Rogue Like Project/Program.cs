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
        static public string[,] Sarray = new string[999,999];
        static public string Z = " ";
        static public string KeyCode = " ";
        static public ConsoleKey KeyInput;
        static public bool LevelEnded = false;
        public static int Stage = 0;

        public static int PrintX = 70;
        public static int PrintY = 230;


        static void Main(string[] args)
        {
            ConsoleAttributes();

            LevelManager.LoadLevel(Stage);
            KeyPress();   
        }

        private static void ConsoleAttributes()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetBufferSize(240, 80);
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
        }

        

        public static void FrameRoutine()
        {
            LevelManager.LevelRoutine(Stage);
            System.Diagnostics.Debug.WriteLine(KeyCode);
            //PrintIt();
            FinishLevel(); 
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

                        case ConsoleKey.Enter:
                            KeyCode = "!";
                            FrameRoutine();
                            break;
                        default:
                            KeyCode = " ";
                            break;
                    }
                }
            }
        }


        //Einzelne Zeichen Ändern
        public static void SetStringToPosi(int X, int Y, string Z)
        { 
        Console.SetCursorPosition(X,Y);
        Console.Write(Z);
        }


        //BildAusgabe
        public static void PrintIt()
        {
        Console.Clear();
        for (int i = 0; i <= PrintX; i++)
            {
            Y++;
            X = 0;
            Console.WriteLine();
            for (int i2 = 0; i2 <= PrintY; i2++)
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
            for (int i3 = 0; i3 <= PrintX; i3++)
            {
            X++;
            Y = 0;
            for (int i4 = 0; i4 <= PrintY; i4++)
                {
                    Y++;
                    //if (Sarray[X, Y] ==  ((char)31).ToString()|| Sarray[X, Y] ==  ((char)1).ToString() || Sarray[X, Y] ==  ((char)8).ToString() || Sarray[X, Y] ==  ((char)3).ToString())
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
                PrintIt();
                Stage++;
                LevelManager.FinishLevelLoadNew(Stage);
                LevelEnded = false;
            }
        }

    }
}
