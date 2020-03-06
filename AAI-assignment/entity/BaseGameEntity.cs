using System.Collections.Generic;
using System.Drawing;
using AAI_assignment.entity;

namespace AAI_assignment
{
    abstract class BaseGameEntity
    {
        public Vector2D Pos { get; set; }
        public float Scale { get; set; }
        public World MyWorld { get; set; }

        public bool Tagged;

        public BaseGameEntity(Vector2D pos, World w)
        {
            Pos = pos;
            MyWorld = w;
        }

        public abstract void Update(float delta);

        public void TagNeighbors(List<MovingEntity> entities, double radius)
        {
            foreach (MovingEntity neighbour in entities)
            {
                neighbour.UnTag();
                Vector2D to = neighbour.Pos - Pos;

                double range = radius + neighbour.Scale;

                if ((neighbour != this) && (to.LengthSquared() < range*range) && (to.LengthSquared() > 0) )
                {
                    neighbour.Tag();
                }
            }
        }

        public void Tag()
        {
            Tagged = true;
        }

        public void UnTag()
        {
            Tagged = false;
        }
        public virtual void Render(Graphics g)
        {
            g.FillEllipse(Brushes.Blue, new Rectangle((int)Pos.X, (int)Pos.Y, 10, 10));
        }


    }  
}
