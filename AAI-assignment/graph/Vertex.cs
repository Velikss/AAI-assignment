using System;
using System.Collections.Generic;
using System.Text;
using AAI_assignment;

namespace Huiswerk6
{
    public class Vertex : IVertex
    {
        public String name;
        public List<Edge> adj;
        public double dist;
        public Vertex prev;
        public bool visited;
        public Vector2D pos;
        public Vertex(string name)
        {
            this.name = name;
            adj = new List<Edge>();
            Reset();
        }

        public void Reset()
        {
            prev = null;
            dist = Graph.INFINITY;
            visited = false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(name);
            if (dist != Graph.INFINITY)
                sb.Append($"({dist}) ");
            if (adj.Count > 0)
            {
                sb.Append(" [ ");
                foreach (Edge edge in adj)
                {
                    sb.Append($"{edge.dest.name}");
                    sb.Append($"({edge.cost}) ");
                }

                sb.Append("]");
            }

            return sb.ToString();
        }
    }
}