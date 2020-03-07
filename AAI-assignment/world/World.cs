using AAI_assignment.behaviour;
using AAI_assignment.entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI_assignment
{
    public struct WorldParameters
    {
        // Behaviours
        public static bool alignment, arrive, cohesion, flocking, seek, seperation, wandering;

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
        public static float SeperationRadius = 25;
        public static float SeperationForce = 25;

        // Entity
        public static int EntityCount = 50;
        public static int EntityMaxSpeed = 50;

    }

    public class World
    {
        public List<MovingEntity> entities = new List<MovingEntity>();
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
            entities.Clear();

            Random r = new Random();
            for (int i = 0; i < WorldParameters.EntityCount; i++)
            {
                Random rand = new Random();
                Vehicle v = new Vehicle(Vector2D.CreateRandomPosition(Width, Height), this, 4);
                v.VColor = Color.FromArgb(r.Next(1, 255), r.Next(1, 255), r.Next(1, 255));
                v.MaxSpeed = WorldParameters.EntityMaxSpeed;
                entities.Add(v);
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
                Random rand = new Random();
                Vehicle v = new Vehicle(Vector2D.CreateRandomPosition(Width, Height), this, 4);
                v.VColor = Color.FromArgb(r.Next(1, 255), r.Next(1, 255), r.Next(1, 255));
                v.MaxSpeed = WorldParameters.EntityMaxSpeed;
                entities.Add(v);
            }
        }

        public void RemoveEntities(int n)
        {
            for (int i = 0; i < n; i++)
            {
                entities.RemoveRange(entities.Count - n, n);
            }
        }

        public void Update(float timeElapsed)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].SB.Clear();

                if (WorldParameters.alignment)
                    entities[i].SB.Add(new AlignmentBehaviour(entities[i], WorldParameters.AlignmentRadius, entities, WorldParameters.AlignmentForce));
                if (WorldParameters.arrive)
                    entities[i].SB.Add(new ArriveBehaviour(entities[i], WorldParameters.decel));
                if (WorldParameters.cohesion)
                    entities[i].SB.Add(new CohesionBehaviour(entities[i], WorldParameters.CohesionRadius, entities, WorldParameters.CohesionForce));
                if (WorldParameters.flocking)
                    entities[i].SB.Add(new FlockingBehaviour(entities[i], WorldParameters.FlockingCohesionRadius, WorldParameters.FlockingSeperationRadius, WorldParameters.FlockingAlignmentRadius, entities, WorldParameters.FlockingCohesionForce, WorldParameters.FlockingSeperationForce, WorldParameters.FlockingAlignmentForce));
                if (WorldParameters.seek)
                    entities[i].SB.Add(new SeekBehaviour(entities[i]));
                if (WorldParameters.seperation)
                    entities[i].SB.Add(new SeparationBehaviour(entities[i], WorldParameters.SeperationRadius, entities, WorldParameters.SeperationForce));
                if (WorldParameters.wandering)
                    entities[i].SB.Add(new WanderingBehaviour(entities[i]));

                entities[i].Update(timeElapsed);
            }
        }

        public void AddBehaviour(string behaviour)
        {
            foreach (MovingEntity me in entities)
            {
                switch (behaviour)
                {
                    case "Alignment":
                        WorldParameters.alignment = true;
                        break;
                    case "Arrive":
                        WorldParameters.arrive = true;
                        break;
                    case "Cohesion":
                        WorldParameters.cohesion = true;
                        break;
                    case "Flocking":
                        WorldParameters.flocking = true;
                        break;
                    case "Seeking":
                        WorldParameters.seek = true;
                        break;
                    case "Seperation":
                        WorldParameters.seperation = true;
                        break;
                    case "Wandering":
                        WorldParameters.wandering = true;
                        break;
                    default:
                        return;
                }
            }
        }

        public void RemoveBehaviour(string behaviour)
        {
            foreach (MovingEntity me in entities)
            {
                switch (behaviour)
                {
                    case "Alignment":
                        WorldParameters.alignment = false;
                        break;
                    case "Arrive":
                        WorldParameters.arrive = false;
                        break;
                    case "Cohesion":
                        WorldParameters.cohesion = false;
                        break;
                    case "Flocking":
                        WorldParameters.flocking = false;
                        break;
                    case "Seeking":
                        WorldParameters.seek = false;
                        break;
                    case "Seperation":
                        WorldParameters.seperation = false;
                        break;
                    case "Wandering":
                        WorldParameters.wandering = false;
                        break;
                    default:
                        return;
                }
            }
        }

        public void DrawGrid(Graphics g)
        {
            float numOfCells = 50;
            float cellSize = Width / numOfCells;
            Pen p = new Pen(Color.LightGray, 2);
            for (int y = 0; y < numOfCells; ++y)
            {
                g.DrawLine(p, 0, y * cellSize, numOfCells * cellSize, y * cellSize);
            }

            for (int x = 0; x < numOfCells; ++x)
            {
                g.DrawLine(p, x * cellSize, 0, x * cellSize, numOfCells * cellSize);
            }
        }

        public void Render(Graphics g)
        {
            DrawGrid(g);
            entities.ForEach(e => e.Render(g));
            Target.Render(g);
        }
    }
}
