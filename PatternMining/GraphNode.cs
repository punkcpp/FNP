using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternMining
{
    class GraphNode
    {
        int id;
        string label;
        int deg
        {
            get { return deg; }
            set { deg = value; }
        }

        List<GraphNode> neighbors;

        public GraphNode() { }
        public GraphNode(int i) { id = i; }
        public GraphNode(int i, string l) { id = i; label = l; neighbors = new List<GraphNode>();}
        
        public List<GraphNode> getNeighbors()
        {
            return neighbors;
        }
        public int getID()
        {
            return id;
        }
        public string getLabel()
        {
            return label;
        }
        public void addDeg()
        {
            deg++;
        }

        internal void addNeighbor(GraphNode graphNode_author)
        {
            throw new NotImplementedException();
        }
    }
}
