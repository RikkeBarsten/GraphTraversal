using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public static class GraphTraversal
    {
        // DFS and BFS methods strongly inspired by: http://www.codeproject.com/Articles/32212/Introduction-to-Graph-with-Breadth-First-Search-BF

        internal static Stack<Node<String>> DFS(MyGraph<string> graph, string root, string goal)
        {
            //Find the nodes
            Node<string> rootNode = graph.NodeSet.Find(n => n.Data == root);
            Node<string> goalNode = graph.NodeSet.Find(n => n.Data == goal);

            if (rootNode == null || goalNode == null)
            {
                throw new ArgumentException("The start or goal element is not part of the graph.");
            }

            // Create a stack to keep track of search
            Stack<Node<string>> route = new Stack<Node<string>>();
            //Add rootNode to the bottom of the stack and mark it as visited
            route.Push(rootNode);
            rootNode.Visited = true;

            // Keep getting new nodes until stack is empty - or a route is found
            while (!(route.Count == 0))
            {
                Node<string> n = route.Peek();
                Node<string> child = getUnvisitedChildNode(n);
                if (child != null)
                {
                    route.Push(child);
                    child.Visited = true;
                    if (child == goalNode)
                    {
                        clearNodes(graph);
                        return route;
                    }

                }
                else
                    route.Pop();

            }
            return null;

        }

        internal static List<Node<String>> BFS(MyGraph<string> graph, string root, string goal)
        {
            //Find the nodes
            Node<string> rootNode = graph.NodeSet.Find(n => n.Data == root);
            Node<string> goalNode = graph.NodeSet.Find(n => n.Data == goal);

            if (rootNode == null || goalNode == null)
            {
                throw new ArgumentException("The start or goal element is not part of the graph.");
            }

            //List to keep track of path
            List<Node<string>> route = new List<Node<string>>();
            
            Node<string> temp = goalNode;

            //Loop through route by getting each nodes parent, until rootnode is reached
            while (temp != rootNode)
            {
                route.Add(temp);
                temp = BFSGetGoalParent(graph, rootNode, temp);
            }

            route.Add(rootNode);
            return route;
        }

        private static Node<string> BFSGetGoalParent(MyGraph<string> graph, Node<string> rootNode, Node<string> goalNode)
        {
            // Create a queue to keep track of search
            Queue<Node<String>> q = new Queue<Node<string>>();
            q.Enqueue(rootNode);
            rootNode.Visited = true;

            //Visiting children each level at a time
            while (!(q.Count == 0))
            {
                Node<string> n = q.Dequeue();
                Node<string> child = null;

                //Check each child before moving on to the next level
                while ((child = getUnvisitedChildNode(n)) != null)
                {
                    q.Enqueue(child);
                    child.Visited = true;
                    if (child == goalNode)
                    {
                        clearNodes(graph);
                        return n;
                    }
                }
            }
            return null;
        }
    



        private static Node<string> getUnvisitedChildNode(Node<string> parent)
        {
            foreach (var edge in parent.MyEdges)
            {
                if (edge.To.Visited == false)
                    return edge.To;                
            }
            return null;
        }

        private static void clearNodes(MyGraph<string> graph)
        {
            foreach (var node in graph.NodeSet)
            {
                node.Visited = false;
            }
        }
    }
}
