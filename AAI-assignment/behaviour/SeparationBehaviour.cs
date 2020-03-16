using AAI_assignment.entity;
using System.Collections.Generic;


namespace AAI_assignment.behaviour
{
    class SeparationBehaviour : SteeringBehaviour
    {
        public List<MovingEntity> Entities;
        public SeparationBehaviour(MovingEntity me, List<MovingEntity> entities) : base(me)
        {
            this.Entities = entities;
        }

        public override Vector2D Calculate()
        {
            Vector2D steeringForce = new Vector2D();
            float radius = WorldParameters.SeparationRadius;
            float force = WorldParameters.SeparationForce;

            for (int i = 0; i < Entities.Count; i++)
            {
                double dist = Vector2D.DistanceSquared(ME.Pos, Entities[i].Pos);
                if (dist < radius * radius && dist > 0)
                {
                    Vector2D separationForce = ME.Pos - Entities[i].Pos;
                    steeringForce += separationForce / dist;
                }
            }
            return steeringForce.Normalize() * force;
        }

        public Vector2D CalculateFlocking()
        {
            Vector2D steeringForce = new Vector2D();
            float radius = WorldParameters.FlockingSeparationRadius;
            float force = WorldParameters.FlockingSeparationForce;

            for (int i = 0; i < Entities.Count; i++)
            {
                double dist = Vector2D.DistanceSquared(ME.Pos, Entities[i].Pos);
                if (dist < radius * radius && dist > 0)
                {
                    Vector2D separationForce = ME.Pos - Entities[i].Pos;
                    steeringForce += separationForce / dist;
                }
            }
            return steeringForce.Normalize() * force;
        }
    }
}