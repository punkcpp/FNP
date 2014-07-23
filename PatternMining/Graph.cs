using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PatternMining
{
    class Graph
    {
        int n; //num of nodes
        int m; //num of edges

        List<GraphNode> nodeSet; // adjcant list of graph

        public Graph() 
        { 
            n = 0; 
            m = 0;
            nodeSet = new List<GraphNode>();
        }
        void buildGraph(string fileConf, string file1, string file2)
        {
            /*
             * file1: paper-author 
             * file2: paper-conf
             */
            // read conference file, id-confName
            Dictionary<string, string> conference = new Dictionary<string, string>();
            string[] confs = System.IO.File.ReadAllLines(fileConf);
            foreach(string conf in confs)
            {
                string[] c = conf.Split();
                conference.Add(c[0],c[1]);
            }
            //

            // add node to NodeSet
            string[] lines = System.IO.File.ReadAllLines(file1);
       
            foreach (string line in lines)
            {
                string[] tokens = line.Split();
                int paperID = Convert.ToInt32(tokens[0]);
                int authorID = Convert.ToInt32(tokens[1]);
                GraphNode graphNode_paper = new GraphNode(paperID,"paper");
                GraphNode graphNode_author = new GraphNode(authorID, "author");
                graphNode_paper.addNeighbor(graphNode_author);
                graphNode_author.addNeighbor(graphNode_paper); //Case: if there are multiple lines the same, will redundant
                graphNode_paper.addDeg();
                graphNode_author.addDeg();
            }
            
            lines = System.IO.File.ReadAllLines(file2);
            foreach (string line in lines)
            {
                string[] tokens = line.Split();
                int paperID = Convert.ToInt32(tokens[0]);
                int authorID = Convert.ToInt32(tokens[1]);
                GraphNode graphNode_paper = new GraphNode(paperID, "paper");
                GraphNode graphNode_conf = new GraphNode(authorID, conference[tokens[1]]); //check same node, maintain a node dictionary
                graphNode_paper.addNeighbor(graphNode_conf);
                graphNode_conf.addNeighbor(graphNode_paper); //Case: if there are multiple lines the same, will redundant
                graphNode_paper.addDeg();
                graphNode_conf.addDeg();

            }
        }
        public void addNode()
        {
            n++;
        }
        public void addEdge()
        {
            m++;
        }
        public int getNumOfNodes()
        {
            return n;
        }
        public int getNumOfEdges()
        {
            return m;
        }
       
    }
}
