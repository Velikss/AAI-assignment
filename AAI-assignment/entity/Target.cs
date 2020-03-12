using Huiswerk6;
using System.Drawing;

namespace AAI_assignment.entity
{
    public class Target : MovingEntity
    {
        public Color VColor { get; set; }
        public Node Node { get; set; }

        public Target(Node node, World w, float scale) : base(node.Pos, w)
        {
            Velocity = new Vector2D(0, 0);
            Scale = scale;
            Node = node;

            VColor = Color.Black;
        }

        public override void Render(Graphics g)
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
