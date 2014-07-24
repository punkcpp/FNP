using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternMining
{
    class PathSet
    {
        List<Path> pathSet;
        public PathSet() { pathSet = new List<Path>(); }
        public void addPath(Path p)
        {
            pathSet.Add(p); //add a list
        }
        public List<Path> getPathSet()
        {
            return pathSet;
        }
    }
}
