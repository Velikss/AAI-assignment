namespace Huiswerk6
{
    public class Graph
    {
        public static readonly double INFINITY = System.Double.MaxValue;

        private Node[,] NGraph; // Navigational Graph

        public Graph(Node[,] nG)
        {
            NGraph = nG;
        }

        public void ClearAll()
        {
            foreach (Node v in NGraph)
                v.Reset();
        }

    }
}