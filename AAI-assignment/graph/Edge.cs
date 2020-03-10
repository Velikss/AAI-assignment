using System;

namespace Huiswerk6
{
    public class Edge : IComparable<Edge>
    {
        public Node dest;
        public double cost;

        public Edge(Node d, double c)
        {
            dest = d;
            cost = c;
        }

        public int CompareTo(Edge obj)
        {
            if (obj == null) return 0;

            return cost.CompareTo(obj.cost);
        }
    }
}