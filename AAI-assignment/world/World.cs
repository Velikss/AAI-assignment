using AAI_assignment.behaviour;
using AAI_assignment.entity;
using AAI_assignment.FuzzyLogic;
using AAI_assignment.FuzzyLogic.FuzzyTerms;
using AAI_assignment.util;
using AAI_assignment.world;
using Huiswerk6;
using System;
using System.Collections.Generic;
using System.Drawing;

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
        public static Deceleration ArriveDecel = Deceleration.normal;

        // Cohesion
        public static int CohesionRadius = 75;
        public static float CohesionForce = 1.25f;

        // Seek
        public static bool SeekStop = false;
        public static float SeekStopRadius = 10;

        // Flocking
        public static float FlockingCohRadius = 75;
        public static float FlockingSepRadius = 25;
        public static float FlockingAliRadius = 50;
        public static float FlockingCohForce = 1.25f;
        public static float FlockingSepForce = 25;
        public static float FlockingAliForce = 1;

        // Separation
        public static float SeparationRadius = 25;
        public static float SeparationForce = 50;

        // ObstacleSeparation
        public static float ObstacleSepRadius = 15;
        public static float ObstacleSepForce = 100;

        // Entity
        public static int EntityCount = 200;
        public static int EntityScale = 4;
        public static int EntityMaxSpeed = 10;

        // Agent
        public static int AgentCount = 5;
        public static int AgentScale = 16;
        public static bool AgentDebugging = false;
        public static bool ShowAgentGoals = true;

        // Obstacle
        public static int ObstacleCount = 30;
        public static int ObstacleScale = 30;

        // Target
        public static int TargetMaxSpeed = 30;
        public static int TargetStopRange = 8;

        // PathFinding draw
        public static bool PathRemove = false;
        public static bool DrawVisitedNodes = true;
        public static bool DrawPath = false;

        // Navigation Grid
        public static bool DrawGrid;
        public static bool DrawNodes;
        public static bool GridUpdate;
        public static float NumOfCells = 50;
        public static float PointScale = 6;

        // Pause
        public static bool Pause;

    }

    public class World
    {
        public List<MovingEntity> Entities = new List<MovingEntity>();
        public List<BaseGameEntity> Obstacles = new List<BaseGameEntity>();
        public List<Agent> Agents = new List<Agent>();
        public NavigationGrid NavGrid;
        public Stack<Node> DrawnPath;
        public Stack<Node> Path;
        public bool Pathfinding;
        public FuzzyModule SeekAndDestroyModule;
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
            WorldParameters.GridUpdate = true;
            CreateTarget();
            Pathfinding = true;
            CreateFuzzyModuleSeekAndDestroy();
        }

        private void Populate()
        {
            Entities.Clear();
            //Obstacles.Clear();
            Agents.Clear();

            // Entities
            //AddEntities(WorldParameters.EntityCount);
            AddAgents(WorldParameters.AgentCount);

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

        public void AddAgents(int n)
        {
            Random r = new Random();
            for (int i = 0; i < n; i++)
            {
                Agent a = new Agent(Vector2D.CreateRandomPosition(Width, Height), this, i);
                a.MaxSpeed = WorldParameters.EntityMaxSpeed;
                a.DefaultColor = Color.Blue;
                Agents.Add(a);
            }
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
                    Entities[i].SB.Add(new AlignmentBehaviour(Entities[i], Entities));
                if (WorldParameters.arrive)
                    Entities[i].SB.Add(new ArriveBehaviour(Entities[i]));
                if (WorldParameters.cohesion)
                    Entities[i].SB.Add(new CohesionBehaviour(Entities[i], Entities));
                if (WorldParameters.flocking)
                    Entities[i].SB.Add(new FlockingBehaviour(Entities[i], Entities));
                if (WorldParameters.seek)
                    Entities[i].SB.Add(new SeekBehaviour(Entities[i]));
                if (WorldParameters.separation)
                    Entities[i].SB.Add(new SeparationBehaviour(Entities[i], Entities));
                if (WorldParameters.wandering)
                    Entities[i].SB.Add(new WanderingBehaviour(Entities[i]));
                if (WorldParameters.obstacleSeparation)
                    Entities[i].SB.Add(new ObstacleSeparationBehaviour(Entities[i], Obstacles));
            }
        }

        public void CreateFuzzyModuleSeekAndDestroy()
        {
            // Fuzzy Module
            FuzzyModule fm = new FuzzyModule();

            // Distance to target
            FuzzyVariable DistToTarget = fm.CreateFLV("DistToTarget", 0, 10000000);

            FuzzySet Target_Close = DistToTarget.AddLeftShoulderSet("Target_Close", 0, 25000, 50000);
            FuzzySet Target_Medium = DistToTarget.AddTriangularSet("Target_Medium", 25000, 50000, 75000);
            FuzzySet Target_Far = DistToTarget.AddRightShoulderSet("Target_Far", 50000, 75000, 100000);

            // Health Status
            FuzzyVariable HealthStatus = fm.CreateFLV("HealthStatus", 0, 100);

            FuzzySet Health_Low = HealthStatus.AddLeftShoulderSet("Health_Low", 0, 25, 50);
            FuzzySet Health_Medium = HealthStatus.AddTriangularSet("Health_Medium", 25, 50, 75);
            FuzzySet Health_High = HealthStatus.AddRightShoulderSet("Health_High", 50, 75, 100);

            // Desirability
            FuzzyVariable Desirablility = fm.CreateFLV("Desirability", 0, 100);

            FuzzySet unDesirable = Desirablility.AddLeftShoulderSet("unDesirable", 0, 25, 50);
            FuzzySet desirable = Desirablility.AddTriangularSet("desirable", 25, 50, 75);
            FuzzySet veryDesirable = Desirablility.AddRightShoulderSet("veryDesirable", 50, 75, 100);

            // Rules
            fm.AddRule(new FuzzyTermAND(ref Target_Far, ref Health_High), new FuzzyTermSet(ref unDesirable, "unDesirable"));
            fm.AddRule(new FuzzyTermAND(ref Target_Far, ref Health_Medium), new FuzzyTermSet(ref unDesirable, "unDesirable"));
            fm.AddRule(new FuzzyTermAND(ref Target_Far, ref Health_Low), new FuzzyTermSet(ref desirable, "desirable"));
            fm.AddRule(new FuzzyTermAND(ref Target_Medium, ref Health_High), new FuzzyTermSet(ref unDesirable, "unDesirable"));
            fm.AddRule(new FuzzyTermAND(ref Target_Medium, ref Health_Medium), new FuzzyTermSet(ref desirable, "desirable"));
            fm.AddRule(new FuzzyTermAND(ref Target_Medium, ref Health_Low), new FuzzyTermSet(ref veryDesirable, "veryDesirable"));
            fm.AddRule(new FuzzyTermAND(ref Target_Close, ref Health_High), new FuzzyTermSet(ref desirable, "desirable"));
            fm.AddRule(new FuzzyTermAND(ref Target_Close, ref Health_Medium), new FuzzyTermSet(ref veryDesirable, "veryDesirable"));
            fm.AddRule(new FuzzyTermAND(ref Target_Close, ref Health_Low), new FuzzyTermSet(ref veryDesirable, "veryDesirable"));

            SeekAndDestroyModule = fm;
        }

        public void Update(float timeElapsed)
        {
            for (int i = 0; i < Entities.Count; i++)
            {
                Entities[i].Update(timeElapsed);
            }
            WorldParameters.EntityCount = Entities.Count;

            for (int i = 0; i < Agents.Count; i++)
            {
                Agents[i].Update(timeElapsed);
            }
            WorldParameters.AgentCount = Agents.Count;

            Target.Update(timeElapsed);
        }

        public void DrawGrid(Graphics g)
        {
            if (WorldParameters.GridUpdate)
            {
                NavGrid = new NavigationGrid(this, WorldParameters.NumOfCells);
                WorldParameters.GridUpdate = false;
            }
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
            if (WorldParameters.DrawVisitedNodes)
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
            if (WorldParameters.DrawGrid)
                DrawGrid(g);
            if (WorldParameters.DrawPath && DrawnPath != null)
                DrawPath(g);
            Entities.ForEach(e => e.Render(g));
            Target.Render(g);
            Obstacles.ForEach(e => e.Render(g));
            Agents.ForEach(e => { if (!e.Dead) e.Render(g); });
        }

    }
}
