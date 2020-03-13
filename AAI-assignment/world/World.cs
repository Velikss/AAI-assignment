using AAI_assignment.behaviour;
using AAI_assignment.entity;
using AAI_assignment.util;
using AAI_assignment.world;
using Huiswerk6;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AAI_assignment
{
    public struct WorldParameters
    {
        // Behaviours
        public static bool alignment, arrive, cohesion, flocking, seek, separation, wandering, obstacleSeparation;

        // Alignment
        public static int AlignmentRadius = 2;
        public static float AlignmentForce = 50;

        // Arrive
        public static Deceleration decel = Deceleration.normal;

        // Cohesion
        public static int CohesionRadius = 75;
        public static float CohesionForce = 1.25f;

        // Flocking
        public static float FlockingCohesionRadius = 75;
        public static float FlockingSeperationRadius = 25;
        public static float FlockingAlignmentRadius = 50;
        public static float FlockingCohesionForce = 1.25f;
        public static float FlockingSeperationForce = 25;
        public static float FlockingAlignmentForce = 1;

        // Seperation
        public static float SeparationRadius = 25;
        public static float SeparationForce = 50;

        // ObstacleSeperation
        public static float ObstacleSeperationRadius = 10;
        public static float ObstacleSeperationForce = 80;

        // Entity
        public static int EntityCount = 200;
        public static int EntityScale = 4;
        public static int EntityMaxSpeed = 50;

        // Obstacle
        public static bool ObstacleAvoidance = true;
        public static int ObstacleCount = 30;
        public static int ObstacleScale = 30;

        // Target
        public static int TargetMaxSpeed = 30;
        public static int TargetStopRange = 8;

        // PathFinding draw
        public static bool PathRemove = true;
        public static bool DrawVisitedNodes = false;

        // Navigation Grid
        public static bool GridOn = true;
        public static bool DrawNodes = false;
        public static bool DrawPath = true;
        public static bool GridUpdate = false;
        public static float NumOfCells = 50;
        public static float PointScale = 6;

    }

    public class World
    {
        public List<MovingEntity> Entities = new List<MovingEntity>();
        public List<BaseGameEntity> Obstacles = new List<BaseGameEntity>();
        public NavigationGrid NavGrid;
        public Stack<Node> DrawnPath;
        public Stack<Node> Path;
        public bool Pathfinding;
        public Vehicle Target { get; set; }
        public int TargetNodeX = 1;
        public int TargetNodeY = 1;
        public int Width { get; set; }
        public int Height { get; set; }

        public World(int w, int h)
        {
            Width = w;
            Height = h;
            Populate();
            NavGrid = new NavigationGrid(this, WorldParameters.NumOfCells);
            CreateTarget();
            Pathfinding = true;
        }

        private void Populate()
        {
            Entities.Clear();
            //Obstacles.Clear();

            // Entities
            AddEntities(WorldParameters.EntityCount);

            // Obstacles
            for (int i = 0; i < WorldParameters.ObstacleCount; i++)
            {
                Obstacle v = new Obstacle(Vector2D.CreateRandomPosition(Width, Height), this, WorldParameters.ObstacleScale);
                Obstacles.Add(v);
            }
        }

        private void CreateTarget()
        {
            while (NavGrid.NavGraph[TargetNodeX, TargetNodeY] == null)
            {
                TargetNodeX++;
                TargetNodeY++;
            }
            Target = new Vehicle(new Vector2D(TargetNodeX * NavGrid.CellSize, TargetNodeX * NavGrid.CellSize), this, 8);
            Target.VColor = Color.DarkRed;
            Target.MaxSpeed = WorldParameters.TargetMaxSpeed;
        }

        public void AddEntities(int n)
        {
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                Vehicle v = new Vehicle(Vector2D.CreateRandomPosition(Width, Height), this, WorldParameters.EntityScale);
                v.VColor = Color.FromArgb(r.Next(1, 255), r.Next(1, 255), r.Next(1, 255));
                v.MaxSpeed = WorldParameters.EntityMaxSpeed;
                Entities.Add(v);
            }

            RefreshBehaviours();
        }

        public void RemoveEntities(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Entities.RemoveRange(Entities.Count - n, n);
            }
        }

        public void UpdateSpeed()
        {
            for (int i = 0; i < Entities.Count; i++)
            {
                Entities[i].MaxSpeed = WorldParameters.EntityMaxSpeed;
            }
        }

        public void UpdateScale()
        {
            for (int i = 0; i < Entities.Count; i++)
            {
                Entities[i].Scale = WorldParameters.EntityScale;
            }
        }

        public void UpdateObstacleScale()
        {
            for (int i = 0; i < Obstacles.Count; i++)
            {
                Obstacles[i].Scale = WorldParameters.ObstacleScale;
            }
        }

        public void RefreshBehaviours()
        {
            for (int i = 0; Entities.Count > i; i++)
            {
                Entities[i].SB.Clear();

                if (WorldParameters.alignment)
                    Entities[i].SB.Add(new AlignmentBehaviour(Entities[i], WorldParameters.AlignmentRadius, Entities, WorldParameters.AlignmentForce));
                if (WorldParameters.arrive)
                    Entities[i].SB.Add(new ArriveBehaviour(Entities[i], WorldParameters.decel));
                if (WorldParameters.cohesion)
                    Entities[i].SB.Add(new CohesionBehaviour(Entities[i], WorldParameters.CohesionRadius, Entities, WorldParameters.CohesionForce));
                if (WorldParameters.flocking)
                    Entities[i].SB.Add(new FlockingBehaviour(Entities[i], WorldParameters.FlockingCohesionRadius, WorldParameters.FlockingSeperationRadius, WorldParameters.FlockingAlignmentRadius, Entities, WorldParameters.FlockingCohesionForce, WorldParameters.FlockingSeperationForce, WorldParameters.FlockingAlignmentForce));
                if (WorldParameters.seek)
                    Entities[i].SB.Add(new SeekBehaviour(Entities[i]));
                if (WorldParameters.separation)
                    Entities[i].SB.Add(new SeparationBehaviour(Entities[i], WorldParameters.SeparationRadius, Entities, WorldParameters.SeparationForce));
                if (WorldParameters.wandering)
                    Entities[i].SB.Add(new WanderingBehaviour(Entities[i]));
                if (WorldParameters.obstacleSeparation)
                    Entities[i].SB.Add(new ObstacleSeparationBehaviour(Entities[i], WorldParameters.ObstacleScale + WorldParameters.ObstacleSeperationRadius, Obstacles, WorldParameters.ObstacleSeperationForce));
            }
        }

        public void Update(float timeElapsed)
        {
            for (int i = 0; i < Entities.Count; i++)
            {
                Entities[i].Update(timeElapsed);
            }
            Target.Update(timeElapsed);
        }

        public void DrawGrid(Graphics g)
        {
            if(WorldParameters.GridUpdate)
                NavGrid = new NavigationGrid(this, WorldParameters.NumOfCells);
            NavGrid.DrawGrid(g);
        }

        public void DrawPath(Graphics g)
        {
            var path = DrawnPath.ToArray();
            for (int i = 0; i < path.Length; i++)
            {
                g.FillEllipse(Brushes.DarkRed, (int)(path[i].Pos.X - WorldParameters.PointScale / 2), (int)(path[i].Pos.Y - WorldParameters.PointScale / 2), WorldParameters.PointScale, WorldParameters.PointScale);
                if (i < path.Length - 1)
                    NavigationGrid.DrawEdge(g, path[i], path[i + 1], Pens.Red);
            }
            // draw visited nodes by A* algorithm
            if(WorldParameters.DrawVisitedNodes)
                for (int i = 0; i < NavGrid.VisitedNodes.Count; i++)
                {
                    g.FillEllipse(Brushes.DarkBlue, (int)(NavGrid.VisitedNodes[i].Pos.X - WorldParameters.PointScale / 2), (int)(NavGrid.VisitedNodes[i].Pos.Y - WorldParameters.PointScale / 2), WorldParameters.PointScale, WorldParameters.PointScale);
                }
        }

        public void PathFinding(int x, int y)
        {
            if (Pathfinding)
            {
                double gridX = Math.Round((double)x / NavGrid.CellSize);
                double gridY = Math.Round((double)y / NavGrid.CellSize);
                if (NavGrid.NavGraph[(int)gridX, (int)gridY] != null)
                {
                    DrawnPath = NavGrid.AStar(NavGrid.NavGraph[TargetNodeX, TargetNodeY], NavGrid.NavGraph[(int)gridX, (int)gridY]);
                    if (Path == null || Path.Count == 0)
                    {
                        Pathfinding = false;
                        if (WorldParameters.PathRemove)
                            Path = DrawnPath;
                        else
                            Path = new Stack<Node>(new Stack<Node>(DrawnPath));
                        Target.SB.Add(new PointToPointBehaviour(Target, ref Path));
                    }
                }
            }
        }

        public void Render(Graphics g)
        {
            if (WorldParameters.GridOn)
                DrawGrid(g);
            if (WorldParameters.DrawPath && DrawnPath != null)
                DrawPath(g);
            Entities.ForEach(e => e.Render(g));
            Target.Render(g);
            Obstacles.ForEach(e => e.Render(g));
        }

    }
}
