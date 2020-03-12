using AAI_assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Huiswerk6
{
    public class Node
    {
        public Vector2D Pos;
        public List<Edge> Adj;
        public Node Prev;
        public int Dist;    // G
        public int H;       // Heuristic
        public int F;       // Dist + Heuristic
        public Node(string name)
        {
            //this.name = name;
            Adj = new List<Edge>(8);
            Reset();
        }

        public Node(Vector2D v)
        {
            //this.name = name;
            Adj = new List<Edge>();
            Pos = v;
            Reset();
        }

        public void ComputeHScore(Vector2D target)
        {
            H = Math.Abs((int)target.X - (int)Pos.X) + Math.Abs((int)target.Y - (int)Pos.Y);
        }

        public void Reset()
        {
            Prev = null;
            Dist = 0;
            H = 0;
            F = 0;
        }

    }
}