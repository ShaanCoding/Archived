using System;
using System.Collections.Generic;

namespace A_Star_Pathfinding
{
    class Program
    {
        static void Main(string[] args)
        {
            Node startNode = new Node(0, 0);
            Node endNode = new Node(9, 9);

            Node[,] inputString = new Node[10,10];

            for(int x = 0; x < 10; x++)
            {
                for(int y = 0; y < 10; y++)
                {
                    inputString[x, y] = new Node(x, y);
                }
            }

            inputString[3, 0].isBarrier = true;
            inputString[3, 1].isBarrier = true;
            inputString[3, 2].isBarrier = true;
            inputString[3, 3].isBarrier = true;
            inputString[4, 5].isBarrier = true;
            inputString[4, 6].isBarrier = true;
            inputString[5, 6].isBarrier = true;
            inputString[5, 7].isBarrier = true;
            inputString[5, 8].isBarrier = true;
            inputString[5, 9].isBarrier = true;
            inputString[4, 7].isBarrier = true;
            inputString[4, 8].isBarrier = true;
            //Manually setting nodes
            /*
                "A 0 0 X 0 0 0 0 0 0",
                "0 0 0 X 0 0 0 0 0 0",
                "0 0 0 X 0 0 0 0 0 0",
                "0 0 0 X 0 0 0 0 0 0",
                "0 0 0 0 0 0 0 0 0 0",
                "0 0 0 0 X 0 0 0 0 0",
                "0 0 0 0 X X X X X 0",
                "0 0 0 0 X 0 0 0 0 0",
                "0 0 0 0 X 0 0 0 0 0",
                "0 0 0 0 0 0 0 0 0 B",
             */

            Pathfinder pathfinder = new Pathfinder(startNode, endNode, inputString);
            pathfinder.Start();
        }
    }
}
