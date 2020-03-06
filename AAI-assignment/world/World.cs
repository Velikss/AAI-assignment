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
    class World
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
            for (int i = 0; i < 200; i += 20)
            {
                for (int j = 0; j < 200; j += 20)
                {
                    //Vehicle v = new Vehicle(new Vector2D(i * 3, i * 8), this);
                    Random rand = new Random();
                    Vehicle v = new Vehicle(new Vector2D(100 + i , 100 + j), this, 4);
                    //v.VColor = Color.Purple;
                    //Vehicle v = new Vehicle(new Vector2D(i * 3, i * 8), this);
                    v.VColor = Color.FromArgb(r.Next(1, 255), r.Next(1, 255), r.Next(1, 255));
                    v.MaxSpeed = 80;
                    entities.Add(v);
                }
            }
            //for (int i = 0; i < 200; i++)
            //{
            //    //Vehicle v = new Vehicle(new Vector2D(i * 3, i * 8), this);
            //    Random rand = new Random();
            //    Vehicle v = new Vehicle(new Vector2D(100 + i + i, 100 + i + i), this, 4);
            //    //v.VColor = Color.Purple;
            //    //Vehicle v = new Vehicle(new Vector2D(i * 3, i * 8), this);
            //    v.VColor = Color.FromArgb(r.Next(1, 255), r.Next(1, 255), r.Next(1, 255));
            //    v.MaxSpeed = r.Next(100, 100);
            //    entities.Add(v);
            //}

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
                //me.SB = new SeekBehaviour(me);
                //me.SB = new WanderingBehaviour(me); // restore later
                //me.SB = new SeparationBehaviour(me);
                //me.Update(timeElapsed);
                me.SB.Clear();
                //me.SB.Add(new SeparationBehaviour(me, 20, entities, 10));
                //me.SB.Add(new AllignmentBehaviour(me, 10, entities, 50));
                //me.SB.Add(new CohesionBehaviour(me, 50, entities, 20));
                me.SB.Add(new FlockingBehaviour(me, 10, 30, 20, entities,
                                              1, 1, 1));
                //me.SB.Add(new SeekBehaviour(me));
                //me.SB.Add(new WanderingBehaviour(me));
                me.Update(timeElapsed);
            }  
        }

        public void Render(Graphics g)
        {
            entities.ForEach(e => e.Render(g));
            Target.Render(g);
        }
    }
}
