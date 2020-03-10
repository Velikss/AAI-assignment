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
        public Obstacle(Vector2D pos, World w, float scale) : base(pos, w)
        {
            Scale = scale;
            Color = Color.Red;
        }
        public override void Render(Graphics g)
        {
            double leftCorner = Pos.X - Scale;
            double rightCorner = Pos.Y - Scale;
            double size = Scale * 2;

            Rectangle entity = new Rectangle((int)leftCorner, (int)rightCorner, (int)size, (int)size);

            SolidBrush myBrush = new SolidBrush(Color);
            g.FillEllipse(myBrush, entity);
        }

        public override void Update(float delta)
        {
            throw new NotImplementedException();
        }
    }
}
