﻿using AAI_assignment.behaviour;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI_assignment
{
    public class Agent : MovingEntity
    {
        public int ID { get; set; }
        public float Health { get; set; }
        public List<Agent> Attackers { get; set; }
        public bool Dead { get; set; }
        public Agent Target { get; set; }
        public Goal MyGoal { get; set; }
        public Color DefaultColor { get; set; }
        public Color DebugColor { get; set; }

        private static Random random = new Random();
        public Agent(Vector2D pos, World w, int i) : base(pos, w)
        {
            this.ID = i;
            this.Pos = pos;
            this.MyWorld = w;
            this.Health = 100;
            this.Scale = WorldParameters.AgentScale;
            this.MyGoal = new SeekAndDestroy_Goal(this);
            this.Attackers = new List<Agent>();
        }

        public override void Update(float delta)
        {
            if (!Dead)
            {
                MyGoal.Process();

                if (Attackers.Count > 0)
                {
                    this.Health -= 0.4f;
                }

                if (Health <= 0)
                {
                    this.Dead = true;
                    this.Target.Attackers.Remove(this);
                    MyGoal.Terminate();
                }

                Vector2D steeringForce = new Vector2D();
                for (int i = 0; i < SB.Count; i++)
                {
                    steeringForce += SB[i].Calculate();
                }
                UpdatePosition(delta, steeringForce);
            }
        }

        private void UpdatePosition(float timeElapsed, Vector2D steeringForce)
        {
            Vector2D acceleration = steeringForce.Divide(Mass);
            Velocity += acceleration * timeElapsed;
            Velocity.Truncate(MaxSpeed);
            Pos.Add(Velocity * timeElapsed);
            Velocity *= 0.9;
            Pos.WrapAround(MyWorld.Width, MyWorld.Height);
        }
        
        public Agent FindMostDesirableTarget()
        {
            Agent mostDesirable = null;
            double highetsCrispValue = 0.0;

            for (int i = 0; this.MyWorld.Agents.Count > i; i++)
            {
                Agent n = this.MyWorld.Agents[i];

                if (n.Dead)
                    continue;

                if (this.Pos == n.Pos)
                    continue;

                double dist = Vector2D.DistanceSquared(this.Pos, n.Pos);
                double crisp = this.MyWorld.SeekAndDestroyModule.CalculateDesirability(dist, n.Health); // health TODO

                if (mostDesirable == null)
                    mostDesirable = n;
                if (crisp > highetsCrispValue && n != this)
                {
                    highetsCrispValue = crisp;
                    mostDesirable = n;
                } 
            }

            return mostDesirable;
        }

        public void RefreshBehaviours()
        {
            SB.Clear();

            SB.Add(new SeekBehaviour(this, Target.Pos));

            SB.Add(new SeparationBehaviour(this, MyWorld.Agents.Cast<MovingEntity>().ToList()));

            SB.Add(new ObstacleSeparationBehaviour(this, MyWorld.Obstacles));
        }

        public virtual void Render(Graphics g)
        {
            double leftCorner = Pos.X - Scale;
            double rightCorner = Pos.Y - Scale;
            double size = Scale * 2;

            Rectangle entity = new Rectangle((int)leftCorner, (int)rightCorner, (int)size, (int)size);
            
            // Set color to debug color if debugging is enabled
            Color c;
            if (WorldParameters.AgentDebugging)
                c = DebugColor;
            else
                c = DefaultColor;

            Pen p = new Pen(c, 2);
            SolidBrush b = new SolidBrush(c);

            g.FillEllipse(b, entity);
            g.DrawLine(p, (int)Pos.X, (int)Pos.Y, (int)Pos.X + (int)(Velocity.X * 2), (int)Pos.Y + (int)(Velocity.Y * 2));
        }
    }
}
