using System.Collections.Generic;


namespace AAI_assignment.behaviour
{
    class SeparationBehaviour : SteeringBehaviour
    {
        public List<MovingEntity> Entities;
        public bool Flocking;

        public SeparationBehaviour(MovingEntity me, List<MovingEntity> entities, bool flocking = false) : base(me)
        {
            this.Entities = entities;
            Flocking = flocking;
        }

        public override Vector2D Calculate()
        {
            Vector2D steeringForce = new Vector2D();
            float radius;
            float force;
            if (Flocking)
            {
                radius = WorldParameters.FlockingSepRadius;
                force = WorldParameters.FlockingSepForce;
            }
            else
            {
                radius = WorldParameters.SeparationRadius;
                force = WorldParameters.SeparationForce;
            }

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