using System.Collections.Generic;


namespace AAI_assignment.behaviour
{
    class CohesionBehaviour : SteeringBehaviour
    {
        public List<MovingEntity> Entities;
        public bool Flocking;
        public CohesionBehaviour(MovingEntity me, List<MovingEntity> entities, bool flocking = false) : base(me)
        {
            this.Entities = entities;
            Flocking = flocking;
        }

        public override Vector2D Calculate()
        {
            Vector2D centerOfMass = new Vector2D();
            Vector2D steeringForce = new Vector2D();
            int neighbourCount = 0;
            float radius;
            float force;
            if (Flocking)
            {
                radius = WorldParameters.FlockingCohRadius;
                force = WorldParameters.FlockingCohForce;
            }
            else
            {
                radius = WorldParameters.CohesionRadius;
                force = WorldParameters.CohesionForce;
            }

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
            float radius = WorldParameters.FlockingCohRadius;
            float force = WorldParameters.FlockingCohForce;

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
