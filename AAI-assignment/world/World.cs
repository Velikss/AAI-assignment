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

            for (int i = 0; i < 10; i++)
            {
                //Vehicle v = new Vehicle(new Vector2D(i * 3, i * 8), this);
                Vehicle v = new Vehicle(new Vector2D(100 + (i*10), 100 + (i*10)), this);
                v.VColor = Color.Purple;
                Vehicle v = new Vehicle(new Vector2D(i * 3, i * 8), this);
                v.VColor = Color.FromArgb(r.Next(1, 255), r.Next(1, 255), r.Next(1, 255));
                v.MaxSpeed = r.Next(25, 650);
                entities.Add(v);
            }

            Target = new Vehicle(new Vector2D(100, 60), this);
            Target.VColor = Color.DarkRed;
            Target.Pos = new Vector2D(100, 40);
        }

        public void Update(float timeElapsed)
        {
            foreach (MovingEntity me in entities)
            {
                //me.SB = new SeekBehaviour(me);
                me.SB = new WanderingBehaviour(me); // restore later
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
