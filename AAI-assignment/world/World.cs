using AAI_assignment.behaviour;
using AAI_assignment.entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AAI_assignment.util;
using AAI_assignment.world;

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
        public static float ObstacleSeperationRadius = 25;
        public static float ObstacleSeperationForce = 1000;

        // Entity
        public static int EntityCount = 100;
        public static int EntityScale = 4;
        public static int EntityMaxSpeed = 50;

        // Obstacle
        public static bool ObstacleAvoidance = true;
        public static int ObstacleCount = 80;
        public static int ObstacleScale = 30;

        // Navigation Grid
        public static bool GridOn = true;

    }

    public class World
    {
        public List<MovingEntity> Entities = new List<MovingEntity>();
        public List<BaseGameEntity> Obstacles = new List<BaseGameEntity>();
        public Vehicle Target { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public World(int w, int h)
        {
            Width = w;
            Height = h;
            Populate();
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
            for(int i = 0; i < Entities.Count; i++)
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

        public void Update(float timeElapsed)
        {
            for (int i = 0; i < Entities.Count; i++)
            {
                Entities[i].Update(timeElapsed);
            }
        }

        public void DrawGrid(Graphics g)
        {
            NavigationGrid nG = new NavigationGrid(this);
            nG.Create(g);
        }

        public void Render(Graphics g)
        {
            if(WorldParameters.GridOn)
                DrawGrid(g);
            Entities.ForEach(e => e.Render(g));
            Target.Render(g);
            Obstacles.ForEach(e => e.Render(g));
        }

        internal void UpdateObstacleScale()
        {
            for (int i = 0; i < Obstacles.Count; i++)
            {
                Obstacles[i].Scale = WorldParameters.ObstacleScale;
            }
        }
    }
}
