using System.Collections.Generic;
using AAI_assignment.entity;


namespace AAI_assignment.behaviour
{
    class SeparationBehaviour : SteeringBehaviour
    {
        public int Radius;
        public List<MovingEntity> Entities;
        public int SeperationForce;
        public SeparationBehaviour(MovingEntity me, int radius, List<MovingEntity> entities, int seperationForce) : base(me)
        {
            this.Radius = radius;
            this.Entities = entities;
            this.SeperationForce = seperationForce;
        }

        public override Vector2D Calculate()
        {
            ME.TagNeighbors(ME.MyWorld.entities, Radius);
            Vector2D steeringForce = new Vector2D();
            foreach (MovingEntity neighbour in Entities)
            {
                if (neighbour != ME && neighbour.Tagged)
                {
                    Vector2D ToAgent = ME.Pos - neighbour.Pos;
                    steeringForce += ToAgent.Normalize() / ToAgent.Length();
                }
            }
            return steeringForce.Multiply(SeperationForce);
        }
    }
}