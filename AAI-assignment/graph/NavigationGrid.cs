using Huiswerk6;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AAI_assignment.util
{
    public class NavigationGrid
    {
        public World World;
        public float NumOfCells;
        public float CellSize;
        public SolidBrush myBrush = new SolidBrush(Color.DeepSkyBlue);
        public Node[,] NavGraph;
        public List<Node> VisitedNodes;

        const int DSEC = 2; // Default Straight Edge Cost
        const int DDEC = 1; // Default Diagonal Edge Cost

        public NavigationGrid(World world, float numOfCells)
        {
            this.World = world;
            VisitedNodes = new List<Node>();
            NumOfCells = numOfCells;
            CellSize = World.Width / NumOfCells;
            NavGraph = new Node[(int)(NumOfCells + 1), (int)(NumOfCells + 1)];
            FloodFill();
            CreateEdges();
        }

        public void FloodFill()
        {
            for (int x = 0; x <= NumOfCells; x++)
            {
                for (int y = 0; y <= NumOfCells; y++)
                {
                    Vector2D v = new Vector2D(x * CellSize, y * CellSize);
                    if (!InsideObstacle(v))
                    {
                        NavGraph[x, y] = new Node(v);
                    }
                    else
                        NavGraph[x, y] = null;
                }
            }
        }

        public void CreateEdges()
        {
            for (int x = 0; x < NumOfCells; x++)
            {
                for (int y = 0; y <= NumOfCells; y++)
                {
                    if (NavGraph[x, y] != null)
                    {
                        // straight sides
                        if (x > 0)
                            if (NavGraph[x - 1, y] != null)
                                NavGraph[x, y].Adj.Add(new Edge(NavGraph[x - 1, y], DSEC));
                        if (x < NumOfCells)
                            if (NavGraph[x + 1, y] != null)
                                NavGraph[x, y].Adj.Add(new Edge(NavGraph[x + 1, y], DSEC));
                        if (y > 0)
                            if (NavGraph[x, y - 1] != null)
                                NavGraph[x, y].Adj.Add(new Edge(NavGraph[x, y - 1], DSEC));
                        if (y < NumOfCells)
                            if (NavGraph[x, y + 1] != null)
                                NavGraph[x, y].Adj.Add(new Edge(NavGraph[x, y + 1], DSEC));
                        // diagonal sides
                        if (x > 0 && y > 0)
                            if (NavGraph[x - 1, y - 1] != null)
                                NavGraph[x, y].Adj.Add(new Edge(NavGraph[x - 1, y - 1], DDEC));
                        if (x < NumOfCells && y > 0)
                            if (NavGraph[x + 1, y - 1] != null)
                                NavGraph[x, y].Adj.Add(new Edge(NavGraph[x + 1, y - 1], DDEC));
                        if (x > 0 && y < NumOfCells)
                            if (NavGraph[x - 1, y + 1] != null)
                                NavGraph[x, y].Adj.Add(new Edge(NavGraph[x - 1, y + 1], DDEC));
                        if (x < NumOfCells && y < NumOfCells)
                            if (NavGraph[x + 1, y + 1] != null)
                                NavGraph[x, y].Adj.Add(new Edge(NavGraph[x + 1, y + 1], DDEC));
                    }
                }
            }
        }

        public void DrawGrid(Graphics g)
        {

            for (int x = 0; x <= NumOfCells; x++)
            {
                for (int y = 0; y <= NumOfCells; y++)
                {
                    if (NavGraph[x, y] != null)
                    {
                        // straight sides
                        if (x >= 0 && x < NumOfCells)
                            if (NavGraph[x + 1, y] != null)
                                DrawEdge(g, NavGraph[x, y], NavGraph[x + 1, y]);
                        if (y < NumOfCells)
                            if (NavGraph[x, y + 1] != null)
                                DrawEdge(g, NavGraph[x, y], NavGraph[x, y + 1]);
                        // diagonal
                        if (x < NumOfCells && y > 0)
                            if (NavGraph[x + 1, y - 1] != null)
                                DrawEdge(g, NavGraph[x, y], NavGraph[x + 1, y - 1]);
                        if (y < NumOfCells && x < NumOfCells)
                            if (NavGraph[x + 1, y + 1] != null)
                                DrawEdge(g, NavGraph[x, y], NavGraph[x + 1, y + 1]);

                        // Node ellipses
                        if (WorldParameters.DrawNodes)
                        {
                            double leftCorner = x * CellSize - WorldParameters.PointScale / 2;
                            double rightCorner = y * CellSize - WorldParameters.PointScale / 2;

                            Rectangle entity = new Rectangle((int)leftCorner, (int)rightCorner, (int)WorldParameters.PointScale, (int)WorldParameters.PointScale);
                            g.FillEllipse(myBrush, entity);
                        }
                    }
                }
            }
        }

        public static void DrawEdge(Graphics g, Node n1, Node n2, Pen p = null)
        {
            if (p == null)
                p = new Pen(Color.LightGray, 1);
            g.DrawLine(p, (float)n1.Pos.X, (float)n1.Pos.Y, (float)n2.Pos.X, (float)n2.Pos.Y);
        }

        public bool InsideObstacle(Vector2D v)
        {
            for (int i = 0; i < World.Obstacles.Count; i++)
            {
                double dist = Vector2D.DistanceSquared(v, World.Obstacles[i].Pos);
                double maxDist = Vector2D.DistanceSquared(new Vector2D(World.Obstacles[i].Pos.X - WorldParameters.ObstacleScale, World.Obstacles[i].Pos.Y - WorldParameters.ObstacleScale), World.Obstacles[i].Pos);
                if (dist < maxDist)
                    return true;
            }

            return false;
        }

        public Stack<Node> AStar(Node start, Node target)
        {
            Node current = null;
            List<Node> openList = new List<Node>();
            List<Node> closedList = new List<Node>();
            int g = 0;

            // start by adding the original position to the open list  
            openList.Add(start);

            while (openList.Count > 0)
            {
                // get the square with the lowest F score
                var lowest = openList.Min(l => l.F);
                current = openList.First(l => l.F == lowest);

                // add the current square to the closed list  
                closedList.Add(current);

                // remove it from the open list  
                openList.Remove(current);

                // if we added the destination to the closed list, we've found a path  
                if (closedList.FirstOrDefault(l => l.Pos.X == target.Pos.X && l.Pos.Y == target.Pos.Y) != null)
                    break;

                g = current.Dist + 1;

                foreach (var Edge in current.Adj)
                {
                    Node node = Edge.Dest;
                    // if this adjacent square is already in the closed list, ignore it
                    if (closedList.FirstOrDefault(l => l.Pos.X == node.Pos.X
                                                       && l.Pos.Y == node.Pos.Y) != null)
                        continue;

                    // if it's not in the open list...
                    if (openList.FirstOrDefault(l => l.Pos.X == node.Pos.X
                                                     && l.Pos.Y == node.Pos.Y) == null)
                    {
                        // compute its score, set the parent
                        node.Dist = g;
                        node.ComputeHScore(target.Pos);
                        node.F = node.Dist + node.H;
                        node.Prev = current;

                        // and add it to the open list
                        openList.Insert(0, node);
                    }
                    else
                    {
                        // test if using the current G score makes the adjacent square's F score
                        // lower, if yes update the parent because it means it's a better path
                        if (g + node.H < node.F)
                        {
                            node.Dist = g;
                            node.F = node.Dist + node.H;
                            node.Prev = current;
                        }
                    }
                }
            }

            Stack<Node> nodes = new Stack<Node>(5);

            while (current != null)
            {
                nodes.Push(current);
                current = current.Prev;
            }

            VisitedNodes = openList;

            foreach (var node in closedList)
                node.Reset();

            return nodes;
        }


    }
}
