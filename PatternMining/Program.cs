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
            string input = @"C:\scratch\github\data\dblp.txt";
            graph.buildGraph(input);
            graph.pritGraph();
            int testDeg = graph.getDeg(10);
            Console.WriteLine(testDeg);
        }
    }
}
