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
        public float Health { get; set; }
        public Goal MyGoal { get; set; }
        public Color VColor { get; set; }


        public Agent(Vector2D pos, World w) : base(pos, w)
        {
            this.Pos = pos;
            this.Health = 100;
            this.MyWorld = w;
            this.Scale = WorldParameters.AgentScale;
        }

        public override void Update(float delta)
        {
            MyGoal.Process();
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

        public Agent FindNearest()
        {
            Agent nearest = null;

            for (int i = 0; this.MyWorld.Agents.Count < i; i++)
            {
                Agent n = this.MyWorld.Agents[i];
                double dist = Vector2D.DistanceSquared(this.Pos, n.Pos);

                if (nearest == null || dist < Vector2D.DistanceSquared(this.Pos, nearest.Pos))
                    nearest = n;
            }

            return nearest;
        }

        public virtual void Render(Graphics g)
        {
            double leftCorner = Pos.X - Scale;
            double rightCorner = Pos.Y - Scale;
            double size = Scale * 2;

            Rectangle entity = new Rectangle((int)leftCorner, (int)rightCorner, (int)size, (int)size);

            Pen p = new Pen(VColor, 2);
            SolidBrush b = new SolidBrush(VColor);

            g.FillEllipse(b, entity);
            g.DrawLine(p, (int)Pos.X, (int)Pos.Y, (int)Pos.X + (int)(Velocity.X * 2), (int)Pos.Y + (int)(Velocity.Y * 2));
        }
    }
}
