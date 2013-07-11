using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication4
{
    class program
    {
        static void Main(string[] args)
        {
            Tür T = new Tür();
            int x;
            int y;

            T.GetDoorPosition(out x, out y);

            Console.Read();
        }
    }
}
