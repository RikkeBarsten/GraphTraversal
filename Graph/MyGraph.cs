using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class MyGraph<T>
    {   
        List<Node<T>> nodeSet = new List<Node<T>>(); //Contains all nodes in the graph
        
        public List<Node<T>> NodeSet
        {
            get { return nodeSet; }
            set { nodeSet = value; }
        }

        /// <summary>
        /// Adds a node to the graph
        /// </summary>
        /// <param name="value">The value to be stored in the node</param>
        /// <returns>Created node</returns>
        public Node<T> AddNode(T value)
        {
            Node<T> n = new Node<T>(value);
            nodeSet.Add(n);
            return n;
        }

        /// <summary>
        /// Adds a directed edge between two nodes in the graph
        /// </summary>
        /// <param name="From">Start node</param>
        /// <param name="To">End node</param>
        public void AddDirectedEdge(T From, T To)
        {
            nodeSet.Find(x => x.Data.Equals(From)).AddEdge(nodeSet.Find(x => x.Data.Equals(To))); 
        }

        /// <summary>
        /// Creates an edge between two nodes
        /// </summary>
        /// <param name="From">First node</param>
        /// <param name="To">Second node</param>
        public void AddEdge(T From, T To)
        {
            nodeSet.Find(x => x.Data.Equals(From)).AddEdge(nodeSet.Find(x => x.Data.Equals(To)));
            nodeSet.Find(x => x.Data.Equals(To)).AddEdge(nodeSet.Find(x => x.Data.Equals(From)));

        }
    }
}
