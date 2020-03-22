using AAI_assignment.entity;
using System.Collections.Generic;


namespace AAI_assignment.behaviour
{
    class CohesionBehaviour : SteeringBehaviour
    {
        public List<MovingEntity> Entities;
        public CohesionBehaviour(MovingEntity me, List<MovingEntity> entities) : base(me)
        {
            this.Entities = entities;
        }

        public override Vector2D Calculate()
        {
            Vector2D centerOfMass = new Vector2D();
            Vector2D steeringForce = new Vector2D();
            int neighbourCount = 0;
            float radius = WorldParameters.CohesionRadius;
            float force = WorldParameters.CohesionForce;

            for (int i = 0; i < Entities.Count; i++)
            {
                Vector2D mePosition = ME.Pos.Clone();
                Vector2D otherPosition = Entities[i].Pos.Clone();
                double dist = Vector2D.DistanceSquared(mePosition, otherPosition);
                if (dist < radius * radius && dist > 0)
                {
                    centerOfMass += Entities[i].Pos;
                    neighbourCount++;
                }
            }

            if (neighbourCount > 0)
            {
                centerOfMass /= neighbourCount;
                steeringForce = Seek(centerOfMass);
            }
            return steeringForce.Normalize() * force;
        }

        public Vector2D CalculateFlocking()
        {
            Vector2D centerOfMass = new Vector2D();
            Vector2D steeringForce = new Vector2D();
            int neighbourCount = 0;
            float radius = WorldParameters.FlockingCohesionRadius;
            float force = WorldParameters.FlockingCohesionForce;

            for (int i = 0; i < Entities.Count; i++)
            {
                Vector2D mePosition = ME.Pos.Clone();
                Vector2D otherPosition = Entities[i].Pos.Clone();
                double dist = Vector2D.DistanceSquared(mePosition, otherPosition);
                if (dist < radius * radius && dist > 0)
                {
                    centerOfMass += Entities[i].Pos;
                    neighbourCount++;
                }
            }

            if (neighbourCount > 0)
            {
                centerOfMass /= neighbourCount;
                steeringForce = Seek(centerOfMass);
            }
            return steeringForce.Normalize() * force;
        }

        private Vector2D Seek(Vector2D target)
        {
            Vector2D desiredVelocity = (target - ME.Pos).Normalize() * WorldParameters.EntityMaxSpeed;
            return desiredVelocity - ME.Velocity;
        }
    }
}
