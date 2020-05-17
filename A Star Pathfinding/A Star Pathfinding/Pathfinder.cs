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
        private Node startNode;
        private Node endNode;
        private Node[,] nodeMatrix;

        private List<Node> openList = new List<Node>();
        private List<Node> closedList = new List<Node>();

        public Pathfinder(Node startNode, Node endNode, Node[,] nodeMatrix)
        {
            this.startNode = startNode;
            this.endNode = endNode;
            this.nodeMatrix = nodeMatrix;
        }

        public void Start()
        {
            //Put start node on openList (leave f at zero)
            startNode.fCost = 0;
            //Not sure
            startNode.gScore = 0;
            startNode.hScore = 0;
            openList.Add(startNode);

            //Loop until find the end - while the openList is not empty
            while(openList.Count > 0)
            {
                //Get current Node - lowest f value
                Node currentNode = openList.OrderBy(x => x.fCost).First();
                //Remove from currentList and add to closedList
                openList.Remove(currentNode);
                closedList.Add(currentNode);

                //If we find goal
                if(currentNode == endNode)
                {
                    Console.WriteLine("Path found");
                    //Backtrack to get path
                    Node backTrackingNode = endNode;

                    while(backTrackingNode != startNode)
                    {
                        Console.WriteLine(string.Format("Node: {0}x {1}y", backTrackingNode.x, backTrackingNode.y));
                        backTrackingNode.isPathNode = true;
                        backTrackingNode = backTrackingNode.parentNode;
                    }
                    //Done program
                }

                //Skip walls
                if(currentNode.isBarrier)
                {
                    continue;
                }

                //Generate children - add neighbour nodes
                currentNode.neighbours = getNeighbours(currentNode, nodeMatrix);

                //Looping through all neighbours
                foreach(Node neighbour in currentNode.neighbours)
                {
                    //Child is on closed List
                    if(closedList.Contains(neighbour))
                    {
                        continue;
                    }

                    neighbour.gScore = currentNode.gScore + 1;
                    neighbour.hScore = getHeuristics(neighbour, endNode);
                    neighbour.fCost = neighbour.gScore + neighbour.hScore;

                    //TODO: REPLACE WITH LINQ
                    foreach (Node openNodes in openList)
                    {
                        if(neighbour == openNodes && neighbour.gScore > openNodes.gScore)
                        {
                            continue;
                        }
                    }

                    //Add child to the openList
                    openList.Add(neighbour);
                }
            }
        }

        private double getHeuristics(Node neighbourNode, Node endNode)
        {
            //Delta pythagoras theorem return c^2
            return ((neighbourNode.x - endNode.x) ^ 2 + (neighbourNode.y - endNode.y) ^ 2);
        }

        private List<Node> getNeighbours(Node currentNode, Node[,] nodeMatrix)
        {
            List<Node> returnList = new List<Node>();
            //We are NOT doing diagnonals so just X + 1, X - 1, Y + 1, Y - 1
            if(currentNode.x + 1 < 32)
            {
                returnList.Add(nodeMatrix[currentNode.x + 1, currentNode.y]);
            }
            else if(currentNode.x - 1 > 0)
            {
                returnList.Add(nodeMatrix[currentNode.x - 1, currentNode.y]);
            }
            else if (currentNode.y + 1 < 32)
            {
                returnList.Add(nodeMatrix[currentNode.x, currentNode.y + 1]);
            }
            else if (currentNode.y - 1 > 0)
            {
                returnList.Add(nodeMatrix[currentNode.x, currentNode.y - 1]);
            }
     
            return returnList;
        }
    }
}
