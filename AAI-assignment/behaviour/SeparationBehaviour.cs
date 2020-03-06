using System.Collections.Generic;
using AAI_assignment.entity;


namespace AAI_assignment.behaviour
{
    class SeparationBehaviour : SteeringBehaviour
    {
        public int Radius;
        public List<MovingEntity> Entities;
        public float SeperationForce;
        public SeparationBehaviour(MovingEntity me, int radius, List<MovingEntity> entities, float seperationForce) : base(me)
        {
            this.Radius = radius;
            this.Entities = entities;
            this.SeperationForce = seperationForce;
        }

        public override Vector2D Calculate()
        {
            //ME.TagNeighbors(ME.MyWorld.entities, Radius);
            //Vector2D steeringForce = new Vector2D();
            //foreach (MovingEntity neighbour in Entities)
            //{
            //    if (neighbour != ME && neighbour.Tagged)
            //    {
            //        Vector2D ToAgent = ME.Pos - neighbour.Pos;
            //        steeringForce += ToAgent.Normalize() / ToAgent.Length();
            //    }
            //}
            //return steeringForce.Multiply(SeperationForce);
            Vector2D steeringForce = new Vector2D();
            foreach (MovingEntity other in Entities)
            {
                double dist = Vector2D.DistanceSquared(ME.Pos, other.Pos);
                if (dist < Radius * Radius && dist > 0)
                {
                    Vector2D separationForce = ME.Pos - other.Pos;
                    steeringForce += separationForce / dist;
                }
            }
            return steeringForce.Normalize() * SeperationForce;
        }
    }
}