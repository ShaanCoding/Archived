using System;
using System.Collections.Generic;
using System.Text;

namespace A_Star_Pathfinding
{
    class Node
    {
        int sizeOfGrid = 10;//Remove later

        public int x;
        public int y;

        public Node parentNode;
        public double fCost;
        public List<Node> neighbours;

        public double gScore;
        public double hScore;

        public bool isPathNode;
        public bool isBarrier;

        public Node(int x, int y)
        {
            this.x = x;
            this.y = y;
            isPathNode = false;
            isBarrier = false;

            neighbours = new List<Node>();
        }
    }
}
