using System;
using System.Collections.Generic;
using System.Linq;

namespace A_Star_Pathfinding
{
    class Program
    {
        public static void Main(string[] args)
        {
            // draw map  
            string[] map = new string[]
            {
                "+------------+",
                "|     x      |",
                "|  x     x  B|",
                "|  x     x   |",
                "|  x     x   |",
                "|A x     x   |",
                "|            |",
                "+------------+",
            };
            Node startNode = new Node(1, 5);
            Node endNode = new Node(12, 2);

            Pathfinder pathfinder = new Pathfinder();
            pathfinder.Run(startNode, endNode, map);
        }
    }
}
