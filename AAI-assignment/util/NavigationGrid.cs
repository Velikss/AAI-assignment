using Huiswerk6;
using System.Drawing;

namespace AAI_assignment.util
{
    public class NavigationGrid
    {
        public World World;
        public float PointScale = 6;
        public float NumOfCells;
        public float CellSize;
        public SolidBrush myBrush = new SolidBrush(Color.DeepSkyBlue);
        public Node[,] mat;

        const int DEC = 1; // Default Edge Cost

        public NavigationGrid(World world, float numOfCells)
        {
            this.World = world;
            NumOfCells = numOfCells;
            CellSize = World.Width / NumOfCells;
            mat = new Node[(int)(NumOfCells + 1), (int)(NumOfCells + 1)];
            FloodFill();
            CreateEdges();
        }

        //public void Create(G)
        //{
        //    FloodFill(g);
        //    CreateEdges(g);
        //    Console.WriteLine(mat);
        //}

        public void FloodFill()
        {
            for (int x = 0; x <= NumOfCells; x++)
            {
                for (int y = 0; y <= NumOfCells; y++)
                {
                    bool obstacle = false;
                    Vector2D v = new Vector2D(x * CellSize, y * CellSize);
                    if (!InsideObstacle(v))
                    {
                        mat[x, y] = new Node($"{x},{y}", v);
                        //double leftCorner = x * CellSize - PointScale / 2;
                        //double rightCorner = y * CellSize - PointScale / 2;

                        //Rectangle entity = new Rectangle((int)leftCorner, (int)rightCorner, (int)PointScale, (int)PointScale);
                        //g.FillEllipse(myBrush, entity);
                    }
                    else
                        mat[x, y] = null;
                }
            }
        }

        public void CreateEdges()
        {
            for (int x = 0; x < NumOfCells; x++)
            {
                for (int y = 0; y <= NumOfCells; y++)
                {
                    if (mat[x, y] != null)
                    {
                        // straight sides
                        if (x > 0)
                            if (mat[x - 1, y] != null)
                            {
                                mat[x, y].adj.Add(new Edge(mat[x - 1, y], DEC));
                                //DrawEdge(g, mat[x, y], mat[x - 1, y]);
                            }
                        if (x < NumOfCells)
                            if (mat[x + 1, y] != null)
                            {
                                mat[x, y].adj.Add(new Edge(mat[x + 1, y], DEC));
                                //DrawEdge(g, mat[x, y], mat[x + 1, y]);
                            }
                        if (y > 0)
                            if (mat[x, y - 1] != null)
                            {
                                mat[x, y].adj.Add(new Edge(mat[x, y - 1], DEC));
                                //DrawEdge(g, mat[x, y], mat[x, y - 1]);
                            }
                        if (y < NumOfCells)
                            if (mat[x, y + 1] != null)
                            {
                                mat[x, y].adj.Add(new Edge(mat[x, y + 1], DEC));
                                //DrawEdge(g, mat[x, y], mat[x, y + 1]);
                            }
                        // diagonal sides
                        if (x > 0 && y > 0)
                            if (mat[x - 1, y - 1] != null)
                            {
                                mat[x, y].adj.Add(new Edge(mat[x - 1, y - 1], DEC));
                                //DrawEdge(g, mat[x, y], mat[x - 1, y - 1]);
                            }
                        if (x < NumOfCells && y > 0)
                            if (mat[x + 1, y - 1] != null)
                            {
                                mat[x, y].adj.Add(new Edge(mat[x + 1, y - 1], DEC));
                                //DrawEdge(g, mat[x, y], mat[x + 1, y - 1]);
                            }
                        if (x > 0 && y < NumOfCells)
                            if (mat[x - 1, y + 1] != null)
                            {
                                mat[x, y].adj.Add(new Edge(mat[x - 1, y + 1], DEC));
                                //DrawEdge(g, mat[x, y], mat[x - 1, y + 1]);
                            }
                        if (x < NumOfCells && y < NumOfCells)
                            if (mat[x + 1, y + 1] != null)
                            {
                                mat[x, y].adj.Add(new Edge(mat[x + 1, y + 1], DEC));
                                //DrawEdge(g, mat[x, y], mat[x + 1, y + 1]);
                            }
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
                    if (mat[x, y] != null)
                    {
                        // straight sides
                        if (x > 0)
                            if (mat[x - 1, y] != null)
                            {
                                DrawEdge(g, mat[x, y], mat[x - 1, y]);
                            }
                        //if (x < NumOfCells)
                        //    if (mat[x + 1, y] != null)
                        //    {
                        //        DrawEdge(g, mat[x, y], mat[x + 1, y]);
                        //    }
                        //if (y > 0)
                        //    if (mat[x, y - 1] != null)
                        //    {
                        //        DrawEdge(g, mat[x, y], mat[x, y - 1]);
                        //    }
                        if (y < NumOfCells)
                            if (mat[x, y + 1] != null)
                            {
                                DrawEdge(g, mat[x, y], mat[x, y + 1]);
                            }
                        // diagonal sides
                        if (x > 0 && y > 0)
                            if (mat[x - 1, y - 1] != null)
                            {
                                DrawEdge(g, mat[x, y], mat[x - 1, y - 1]);
                            }
                        if (x < NumOfCells && y > 0)
                            if (mat[x + 1, y - 1] != null)
                            {
                                DrawEdge(g, mat[x, y], mat[x + 1, y - 1]);
                            }
                        //if (x > 0 && y < NumOfCells)
                        //    if (mat[x - 1, y + 1] != null)
                        //    {
                        //        DrawEdge(g, mat[x, y], mat[x - 1, y + 1]);
                        //    }
                        //if (x < NumOfCells && y < NumOfCells)
                        //    if (mat[x + 1, y + 1] != null)
                        //    {
                        //        DrawEdge(g, mat[x, y], mat[x + 1, y + 1]);
                        //    }
                        double leftCorner = x * CellSize - PointScale / 2;
                        double rightCorner = y * CellSize - PointScale / 2;

                        Rectangle entity = new Rectangle((int)leftCorner, (int)rightCorner, (int)PointScale, (int)PointScale);
                        g.FillEllipse(myBrush, entity);
                    }
                }
            }
        }

        public void DrawEdge(Graphics g, Node n1, Node n2)
        {
            Pen p = new Pen(Color.LightGray, 1);
            g.DrawLine(p, (float)n1.Pos.X, (float)n1.Pos.Y, (float)n2.Pos.X, (float)n2.Pos.Y);
        }

        public bool InsideObstacle(Vector2D v)
        {
            for (int i = 0; i < World.Obstacles.Count; i++)
            {
                //double dist = Vector2D.DistanceSquared(v, World.Obstacles[i].Pos);
                //if (dist < (WorldParameters.ObstacleSeperationRadius + WorldParameters.ObstacleScale) * (WorldParameters.ObstacleSeperationRadius + WorldParameters.ObstacleScale) && dist > 0)
                //    return true;
                double dist = Vector2D.DistanceSquared(v, World.Obstacles[i].Pos);
                double maxDist = Vector2D.DistanceSquared(new Vector2D(World.Obstacles[i].Pos.X - WorldParameters.ObstacleScale, World.Obstacles[i].Pos.Y - WorldParameters.ObstacleScale), World.Obstacles[i].Pos);
                if (dist < maxDist)
                    return true;
            }

            return false;
        }


    }
}
