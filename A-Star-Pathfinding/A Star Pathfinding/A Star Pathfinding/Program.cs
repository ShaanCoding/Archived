using System;
using System.Collections.Generic;
using System.Linq;

namespace A_Star_Pathfinding
{
    class Program
    {
        public static void Main(string[] args)
        {
            Node[,] nodeMap = new Node[12, 6];

            for (int y = 0; y < nodeMap.GetLength(1); y++)
            {
                for (int x = 0; x < nodeMap.GetLength(0); x++)
                {
                    nodeMap[x, y] = new Node(x, y);
                }
            }


            nodeMap[2, 1].isBarrier = true;
            nodeMap[2, 2].isBarrier = true;
            nodeMap[2, 3].isBarrier = true;
            nodeMap[2, 4].isBarrier = true;

            nodeMap[5, 0].isBarrier = true;

            nodeMap[8, 1].isBarrier = true;
            nodeMap[8, 2].isBarrier = true;
            nodeMap[8, 3].isBarrier = true;
            nodeMap[8, 4].isBarrier = true;

            //Not needed just graphic drawing of map
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
            Node startNode = new Node(0, 4);
            Node endNode = new Node(11, 1);
            bool enableDiagonals = true;

            Pathfinder pathfinder = new Pathfinder();
            pathfinder.Run(startNode, endNode, nodeMap, enableDiagonals);
        }
    }
}
