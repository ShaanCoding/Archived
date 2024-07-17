﻿using System;
using System.Collections.Generic;
using System.Text;

namespace A_Star_Pathfinding
{
    class Node
    {
        public int x;
        public int y;
        public Node parentNode;
        public List<Node> neighbours;
        public double fCost;
        public double gScore;
        public double hScore;
        public bool isBarrier;

        public Node(int x, int y)
        {
            this.x = x;
            this.y = y;
            isBarrier = false;

            neighbours = new List<Node>();
        }
    }
}
