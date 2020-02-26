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

        public List<MovingEntity> Neighbours = new List<MovingEntity>();

        public BaseGameEntity(Vector2D pos, World w)
        {
            Pos = pos;
            MyWorld = w;
        }

        public abstract void Update(float delta);

        public void TagNeighbors(List<MovingEntity> entities, double radius)
        {
            Neighbours.Clear();
            foreach (MovingEntity neighbour in entities)
            {
                neighbour.UnTag();
                Vector2D to = neighbour.Pos.Clone().Sub(Pos);

                double range = radius + 10;

                if ((neighbour != this) && (to.LengthSquared() < radius*100)) 
                {
                    neighbour.Tag();
                    Neighbours.Add(neighbour);
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
