using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rogue_Like_Project
{
    public static class Hauptmenu
    {

    public static Vector2 Position = new Vector2();
    public static string Cursor = "->";
    public static string NewGame = "NEW GAME";
    public static string LoadGame = "LOAD GAME";
    public static string QuitGame = "QUIT GAME";
    public static Vector2 Newbutton = new Vector2();
    public static Vector2 Loadbutton = new Vector2();
    public static Vector2 Quitbutton = new Vector2();
    

    public static void StartMenu()
    {

    Position.X = 15;
    Position.Y = 15;
    Newbutton.X = 17;
    Newbutton.Y = 15;
    Loadbutton.X = 17;
    Loadbutton.Y = 19;
    Quitbutton.X = 17;
    Quitbutton.Y = 23;
    }

     public static void SetCursor()
     {
        Program.SetStrng(Position.X, Position.Y, Cursor);
        SetNewbutton();
        SetLoadbutton();
        SetQuitbutton();
     }

     public static void SetLoadbutton()
     {
         Program.SetStrng(Loadbutton.X, Loadbutton.Y, LoadGame);
     }

     public static void SetQuitbutton()
     {
         Program.SetStrng(Quitbutton.X, Quitbutton.Y, QuitGame);
     }

     public static void SetNewbutton()
     {
         Program.SetStrng(Newbutton.X, Newbutton.Y, NewGame);
     }

    public static void CursorRoutine()
    {
            switch (Program.KeyCode)
            {
                case "w":
                //if (Program.Sarray[Position.X, Position.Y - 1] == " ")
                {
                    if (Position.Y == 15)
                    {
                        Program.SetStrng(Position.X, Position.Y, "");
                        Position.Y = 27;
                    }
                    else
                        Program.SetStrng(Position.X, Position.Y, "");
                        Position.Y -= 4;
                   }
                break;

                case "s":
                //if (Program.Sarray[Position.X, Position.Y + 1] == " ")
                {
                    if (Position.Y == 23)
                    {
                        Program.SetStrng(Position.X, Position.Y, "");
                        Position.Y = 11;
                    }
                    else
                        Program.SetStrng(Position.X, Position.Y, "");
                        Position.Y += 4; 
                }
                break;

                case "!":
                if (Position.Y == 15)
                    Program.LevelEnded = true;
                break; 

                default:
                break; 
            }
     }


    }
}
