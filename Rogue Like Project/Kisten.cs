using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rogue_Like_Project
{
    public class Kisten
    {


        public Vector2 Position = new Vector2();
        public string Box = "B";
        public Boolean BoxMove = false;


        public void BoxRoutine(int PlayerX, int PlayerY)
        {
            
            MoveKiste(PlayerX, PlayerY);
            SetBox();
            PrintBox();
        }

        public void SetBox()
        {
            Program.SetStrng(Position.X, Position.Y, Box);
        }

        public void PrintBox()
        {
            Program.SetStringToPosi(Position.X, Position.Y, Box);
        }




        //Setzt den Spieler auf das Feld des Objektes wenn er sich draufbewegen möchte
        public bool MoveKiste(int PlayerX, int PlayerY)
        {

            if (PlayerX - 1 == Position.X && PlayerY == Position.Y && Program.KeyCode == "a" && Program.Sarray[Position.X - 1, Position.Y] == " ")
            {
                
                Program.SetStrng(Position.X, Position.Y, " ");
                Program.SetStringToPosi(Position.X, Position.Y, " ");
                Position.X = Position.X - 1;
                return true;
            }
            else if (PlayerX + 1 == Position.X && PlayerY == Position.Y && Program.KeyCode == "d" && Program.Sarray[Position.X + 1, Position.Y] == " ")
            {
               
                Program.SetStrng(Position.X, Position.Y, " ");
                Program.SetStringToPosi(Position.X, Position.Y, " ");
                Position.X = Position.X + 1;
                return true;
            }
            else if (PlayerY - 1 == Position.Y && PlayerX == Position.X && Program.KeyCode == "w" && Program.Sarray[Position.X, Position.Y-1] == " ")
            {
             
                Program.SetStrng(Position.X, Position.Y, " ");
                Program.SetStringToPosi(Position.X, Position.Y, " ");
                Position.Y = Position.Y - 1;
                return true;
            }
            else if (PlayerY + 1 == Position.Y && PlayerX == Position.X && Program.KeyCode == "s" && Program.Sarray[Position.X, Position.Y+1] == " ")
            {
           
                Program.SetStrng(Position.X, Position.Y, " ");
                Program.SetStringToPosi(Position.X, Position.Y, " ");
                Position.Y = Position.Y + 1;
                return true;
            }
            else
            {
                return false;

            }
        }
    }




    }

