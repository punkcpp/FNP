using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PatternMining
{
    class Graph
    {
        public Graph() 
        { 
            n = 0; 
            m = 0;
            adj = new List<List<int>>();
            labels = new List<string>();
            deg = new List<int>();     
        }

        public void buildGraph(string file)
        {
            string[] lines = File.ReadAllLines(file);
            int idCnt = 0;
            int edgeCnt = 0;
            Dictionary<string, int> idMap = new Dictionary<string, int>();
            Console.WriteLine("start building graph");
            foreach (string line in lines)
            {
                edgeCnt++;
                string[] tokens = line.Split();
                // ID, Label, ID, Label
                int id1, id2;
                bool hasShow1 = false;
                bool hasShow2 = false;
                if (idMap.ContainsKey(tokens[0]))
                {
                    id1 = idMap[tokens[0]];
                    hasShow1 = true;
                }
                else
                {
                    id1 = idCnt++;
                    labels.Add(tokens[1]);
                    idMap.Add(tokens[0], id1);
                }
               
                if (idMap.ContainsKey(tokens[2]))
                {
                    id2 = idMap[tokens[2]];
                    hasShow2 = true;
                }
                else
                {
                    id2 = idCnt++;
                    idMap.Add(tokens[2], id2);
                    try
                    {
                        labels.Add(tokens[3]);
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        Console.WriteLine(line);
                        Console.WriteLine(e.StackTrace);
                        
                    }
                }
                if (hasShow1)
                {
                    adj[id1].Add(id2);
                    deg[id1]++;
                }
                else
                {
                    List<int> tmp = new List<int>();
                    tmp.Add(id2);
                    adj.Add(tmp);
                    deg.Add(1);
                }
                if (hasShow2)
                {
                    adj[id2].Add(id1);
                    deg[id2]++;
                }
                else
                {
                    List<int> tmp = new List<int>();
                    tmp.Add(id1);
                    adj.Add(tmp);
                    deg.Add(1);
                }
            }
            
            n = idCnt;
            m = edgeCnt;
        }
        public void pritGraph()
        {
            //string test = Console.ReadLine();
            int cnt = adj.Count;
           // Console.WriteLine("count: " + cnt + " nodes: " + n + " edges: " + m);
            for(int i = 0; i < adj.Count; i++)
            {
                //Console.ReadLine();
                string outline = i + " ";
                foreach(int node in adj[i])
                {
                    outline += (node + " ");
                }
                Console.WriteLine(outline);
            }
        }


        private List<List<int>> adj;
        private List<string> labels;
        private List<int> deg;

        public int getDeg(int nodeID)
        {
            return deg[nodeID];
        }
        public int n { set; get;}
        public int m { set; get; }
    }
}
