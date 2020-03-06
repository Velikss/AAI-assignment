﻿using AAI_assignment.behaviour;
using AAI_assignment.entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI_assignment
{
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
                //me.SB.Add(new SeparationBehaviour(me, 20, entities, 10));
                //me.SB.Add(new AllignmentBehaviour(me, 10, entities, 50));
                //me.SB.Add(new CohesionBehaviour(me, 50, entities, 20));
                //me.SB.Add(new FlockingBehaviour(me, 75, 25, 50, entities,
                //                              1, 25, 1));
                //me.SB.Add(new SeekBehaviour(me));
                //me.SB.Add(new WanderingBehaviour(me));
                me.SteeringBehaviour = new FlockingBehaviour(me, 75, 25, 50, entities,
                    1.25f, 25f, 1f);
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
