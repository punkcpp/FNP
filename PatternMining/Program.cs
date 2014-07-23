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
            Console.WriteLine("test");
            Graph graph = new Graph();
            string input = @"C:\scratch\github\data\dblp_small.txt";
            graph.buildGraph(input);
            graph.pritGraph();
        }
    }
}
