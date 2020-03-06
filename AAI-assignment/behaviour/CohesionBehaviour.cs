using System;
using System.Collections.Generic;
using System.IO;
using AAI_assignment.entity;


namespace AAI_assignment.behaviour
{
    class CohesionBehaviour : SteeringBehaviour
    {
        public float Radius;
        public List<MovingEntity> Entities;
        public float CohesionForce;
        public CohesionBehaviour(MovingEntity me, float radius, List<MovingEntity> entities, float cohesionForce) : base(me)
        {
            this.Radius = radius;
            this.Entities = entities;
            this.CohesionForce = cohesionForce;
        }

        public override Vector2D Calculate()
        {
            Vector2D centerOfMass = new Vector2D();
            Vector2D steeringForce = new Vector2D();
            int neighbourCount = 0;

            foreach (MovingEntity entity in Entities)
            {
                Vector2D mePosition = ME.Pos.Clone();
                Vector2D otherPosition = entity.Pos.Clone();
                double dist = Vector2D.DistanceSquared(mePosition, otherPosition);
                if (dist < Radius * Radius && dist > 0)
                {
                    centerOfMass += entity.Pos;
                    neighbourCount++;
                }
            }

            if (neighbourCount > 0)
            {
                centerOfMass /= neighbourCount;
                steeringForce = Seek(centerOfMass);
            }
            return steeringForce.Normalize() * CohesionForce;
        }

        private Vector2D Seek(Vector2D target)
        {
            Vector2D desiredVelocity = (target - ME.Pos).Normalize() * ME.MaxSpeed;
            return desiredVelocity - ME.Velocity;
        }
    }
}
