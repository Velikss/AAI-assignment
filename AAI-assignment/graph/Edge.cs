using System;

namespace Huiswerk6
{
    public class Edge : IComparable<Edge>
    {
        public Node Dest;
        public double Cost;

        public Edge(Node dest, double cost)
        {
            Dest = dest;
            Cost = cost;
        }

        public int CompareTo(Edge obj)
        {
            if (obj == null) return 0;

            return Cost.CompareTo(obj.Cost);
        }
    }
}