using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternMining
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"C:\scratch\github\data\dblp.txt";
            Graph graph = new Graph();
            graph.buildGraph(input);
            graph.printGraph();
        }
    }
}
