using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rogue_Like_Project
{
    public static class level
    {
        static void LvL()
        {
            int counter = 0;
            string line;

            
            System.IO.StreamReader file = new System.IO.StreamReader("D:\\lvl1.txt");
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                counter++;
            }

            file.Close();

            
            Console.ReadLine();
        }
    }
}