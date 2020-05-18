using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace A_Star_Pathfinding
{
    class Pathfinder
    {
        /*
        * Credits to https://medium.com/@nicholas.w.swift/easy-a-star-pathfinding-7e6689c7f7b2
        * For showing pseudocode
        */

        int SLEEP_TIME = 10;

        public void Run(Node startNode, Node endNode, Node[,] nodeMap)
        {

            for (int y = 0; y < nodeMap.GetLength(1); y++)
            {
                for (int x = 0; x < nodeMap.GetLength(0); x++)
                {
                    if (nodeMap[x, y].isBarrier == false)
                    {
                        if (startNode.x == x && startNode.y == y)
                        {
                            Console.Write("A");
                        }
                        else if (endNode.x == x && endNode.y == y)
                        {
                            Console.Write("B");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine();
            }

            //Put start on node on openList (set f at zero)
            startNode.fCost = 0;
            startNode.gScore = 0;
            startNode.hScore = 0;

            //Initalisation
            Node currentNode = null;
            var openList = new List<Node>();
            var closedList = new List<Node>();
            int gScore = 0;

            // start by adding the original position to the open list  
            openList.Add(startNode);

            while (openList.Count > 0)
            {
                // get the square with the lowest F score  
                currentNode = openList.OrderBy(l => l.fCost).FirstOrDefault();

                //Remove from currentList and add to closedList
                openList.Remove(currentNode);
                closedList.Add(currentNode);

                //show current square on the map  
                Console.SetCursorPosition(currentNode.x, currentNode.y);
                Console.Write('.');
                Console.SetCursorPosition(currentNode.x, currentNode.y);
                System.Threading.Thread.Sleep(SLEEP_TIME);

                //If we find goal
                if (closedList.FirstOrDefault(l => l.x == endNode.x && l.y == endNode.y) != null)
                    break;

                //Generate child - add neighbour nodes
                currentNode.neighbours = GetNeighbours(currentNode.x, currentNode.y, nodeMap, openList);
                gScore = currentNode.gScore + 1;

                //Looping through all neighbours
                foreach (Node neighbours in currentNode.neighbours)
                {
                    //If child is in closed list
                    if (closedList.FirstOrDefault(l => l.x == neighbours.x
                        && l.y == neighbours.y) != null)
                        continue;

                    //If not in openList initalize it
                    if (openList.FirstOrDefault(l => l.x == neighbours.x
                        && l.y == neighbours.y) == null)
                    {
                        // compute its score, set the parent  
                        neighbours.gScore = gScore;
                        neighbours.hScore = ComputeHScore(neighbours, endNode);
                        neighbours.fCost = neighbours.gScore + neighbours.hScore;
                        neighbours.parentNode = currentNode;

                        // and add it to the open list  
                        openList.Add(neighbours);
                    }
                    else
                    {
                        //If new fScore better than current fScore replace with better path
                        if (gScore + neighbours.hScore < neighbours.fCost)
                        {
                            neighbours.gScore = gScore;
                            neighbours.fCost = neighbours.gScore + neighbours.hScore;
                            neighbours.parentNode = currentNode;
                        }
                    }
                }
            }

            Node end = currentNode;

            //If it goes here path is found - lets print it
            while (currentNode != null)
            {
                Console.SetCursorPosition(currentNode.x, currentNode.y);
                Console.Write('_');
                Console.SetCursorPosition(currentNode.x, currentNode.y);
                currentNode = currentNode.parentNode;
                System.Threading.Thread.Sleep(SLEEP_TIME);
            }

            //How many steps was required
            if (end != null)
            {
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("Path : {0}", end.gScore);
            }

            Console.ReadLine();
        }

        static List<Node> GetNeighbours(int x, int y, Node[,] nodeMap, List<Node> openList)
        {
            List<Node> returnList = new List<Node>();

            if(y - 1 >= 0)
            {
                if (nodeMap[x, y - 1].isBarrier == false)
                {
                    Node node = openList.Find(l => l.x == x && l.y == y - 1);
                    if (node == null) returnList.Add(new Node(x, y - 1));
                }
            }

            if(y + 1 < nodeMap.GetLength(1))
            {
                if (nodeMap[x, y + 1].isBarrier == false)
                {
                    Node node = openList.Find(l => l.x == x && l.y == y + 1);
                    if (node == null) returnList.Add(new Node(x, y + 1));
                }
            }

            if(x - 1 >= 0)
            {
                if (nodeMap[x - 1, y].isBarrier == false)
                {
                    Node node = openList.Find(l => l.x == x - 1 && l.y == y);
                    if (node == null) returnList.Add(new Node(x - 1, y));
                }
            }

            if(x + 1 < nodeMap.GetLength(0))
            {
                if (nodeMap[x + 1, y].isBarrier == false)
                {
                    Node node = openList.Find(l => l.x == x + 1 && l.y == y);
                    if (node == null) returnList.Add(new Node(x + 1, y));
                }
            }

            return returnList;
        }

        static int ComputeHScore(Node neighbourNode, Node endNode)
        {
            return ((neighbourNode.x - endNode.x) ^ 2 + (neighbourNode.y - endNode.y) ^ 2);
        }
    }
}
