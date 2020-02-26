using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI_assignment.entity
{
    class Vehicle : MovingEntity
    {
        public Color VColor { get; set; }

        public Vehicle(Vector2D pos, World w) : base(pos, w)
        {
            Velocity = new Vector2D(0, 0);
            Scale = 8;

            VColor = Color.Black;
        }
        
        public override void Render(Graphics g)
        {
            double leftCorner = Pos.X - Scale;
            double rightCorner = Pos.Y - Scale;
            double size = Scale * 2;

            Rectangle entity = new Rectangle((int)leftCorner, (int)rightCorner, (int)size, (int)size);

            Pen p = new Pen(VColor, 2);
            g.DrawEllipse(p, entity);
            g.DrawLine(p, (int) Pos.X, (int) Pos.Y, (int) Pos.X + (int)(Velocity.X * 2), (int)Pos.Y + (int)(Velocity.Y * 2));
        }
    }
}
