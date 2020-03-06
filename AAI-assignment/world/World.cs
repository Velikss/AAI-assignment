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
            Random r = new Random();
            for (int i = 0; i < 200; i++)
            {
                Random rand = new Random();
                Vehicle v = new Vehicle(Vector2D.CreateRandomPosition(Width, Height), this, 4);
                v.VColor = Color.FromArgb(r.Next(1, 255), r.Next(1, 255), r.Next(1, 255));
                v.MaxSpeed = 50;
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

        public void Update(float timeElapsed)
        { 
            foreach (MovingEntity me in entities)
            {
                me.SB.Clear();

                if (WorldParameters.alignment)
                    me.SB.Add(new AlignmentBehaviour(me, WorldParameters.AlignmentRadius, entities, WorldParameters.AlignmentForce));
                if (WorldParameters.arrive)
                    me.SB.Add(new ArriveBehaviour(me, WorldParameters.decel));
                if (WorldParameters.cohesion)
                    me.SB.Add(new CohesionBehaviour(me, WorldParameters.CohesionRadius, entities, WorldParameters.CohesionForce));
                if (WorldParameters.flocking)
                    me.SB.Add(new FlockingBehaviour(me, WorldParameters.FlockingCohesionRadius, WorldParameters.FlockingSeperationRadius, WorldParameters.FlockingAlignmentRadius, entities, WorldParameters.FlockingCohesionForce, WorldParameters.FlockingSeperationForce, WorldParameters.FlockingAlignmentForce));
                if (WorldParameters.seek)
                    me.SB.Add(new SeekBehaviour(me));
                if (WorldParameters.seperation)
                    me.SB.Add(new SeparationBehaviour(me, WorldParameters.SeperationRadius, entities, WorldParameters.SeperationForce));
                if (WorldParameters.wandering)
                    me.SB.Add(new WanderingBehaviour(me));

                me.Update(timeElapsed);
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
