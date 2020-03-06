using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace AAI_assignment.world
{
    public class Obstacle : BaseGameEntity
    {
        public Color Color { get; set; }
        public Obstacle(Vector2D pos, World w) : base(pos, w)
        {
            Scale = 20;
            Color = Color.Black;
        }
        public override void Render(Graphics g)
        {
            double leftCorner = Pos.X - Scale;
            double rightCorner = Pos.Y - Scale;
            double size = Scale * 2;

            Rectangle entity = new Rectangle((int)leftCorner, (int)rightCorner, (int)size, (int)size);

            Pen p = new Pen(Color, 2);
            g.DrawEllipse(p, entity);
        }

        public override void Update(float delta)
        {
            throw new NotImplementedException();
        }
    }
}
