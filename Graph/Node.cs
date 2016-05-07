using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Node<T>
    {   
        /// <summary>
        /// Region that contains all variables
        /// </summary>
        #region Variables

        private bool visited; //Indicates if the node has been visited

        private Node<T> parent; //Holds the node's parent

        private T data; //Hold the node's data eg. "Entrance"

        private List<Edge<T>> myEdges = new List<Edge<T>>(); //Holds all the nodes edges

        #endregion

        /// <summary>
        /// Region that contains peoperties
        /// </summary>
        #region Properties

        public bool Visited
        {
            get { return visited; }
            set { visited = value; }
        }

        public Node<T> Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public List<Edge<T>> MyEdges
        {
            get { return myEdges; }
            set { myEdges = value; }
        }

        #endregion

        /// <summary>
        /// The Node's constructor
        /// </summary>
        /// <param name="Data">The data to be stored in the node</param>
        public Node(T Data)
        {
            this.data = Data;
        }

        /// <summary>
        /// Adds an edge to the node
        /// </summary>
        /// <param name="Other">The node at the edge's endpoint</param>
        public void AddEdge(Node<T> Other)
        { 
            myEdges.Add(new Edge<T>(this,Other));
        }

        /// <summary>
        /// Converts value to string
        /// </summary>
        /// <returns>Returns the value as a string</returns>
        public override string ToString()
        {
            return data.ToString();
        }

    }
}
