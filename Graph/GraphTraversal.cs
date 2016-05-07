using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    public static class GraphTraversal
    {
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
