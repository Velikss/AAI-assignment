using AAI_assignment.behaviour;
using AAI_assignment.entity;
using AAI_assignment.util;
using AAI_assignment.world;
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
        public static float SeparationForce = 25;

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

        // Navigation Grid
        public static bool GridOn = true;
        public static bool DrawNodes = true;
        public static float NumOfCells = 50;

    }

    public class World
    {
        public List<MovingEntity> Entities = new List<MovingEntity>();
        public List<BaseGameEntity> Obstacles = new List<BaseGameEntity>();
        public NavigationGrid NavGrid;
        public Vehicle Target { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public World(int w, int h)
        {
            Width = w;
            Height = h;
            Populate();
            NavGrid = new NavigationGrid(this, WorldParameters.NumOfCells);
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

            //Vehicle d = new Vehicle(new Vector2D(1000, 60), this, 4);
            //d.VColor = Color.Red;
            //d.MaxSpeed = r.Next(100, 100);
            //entities.Add(d);

            Target = new Vehicle(new Vector2D(100, 60), this, 8);
            Target.VColor = Color.DarkRed;
            Target.Pos = new Vector2D(10, 10);
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
        }

        public void DrawGrid(Graphics g)
        {
            //NavGrid = new NavigationGrid(this, WorldParameters.NumOfCells);
            NavGrid.DrawGrid(g);
        }

        public void Render(Graphics g)
        {
            Entities.ForEach(e => e.Render(g));
            Target.Render(g);
            Obstacles.ForEach(e => e.Render(g));
            if (WorldParameters.GridOn)
                DrawGrid(g);
        }

    }
}
