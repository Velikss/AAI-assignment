using System;
using System.Collections.Generic;
using System.IO;
using AAI_assignment.entity;


namespace AAI_assignment.behaviour
{
    class CohesionBehaviour : SteeringBehaviour
    {
        public int Radius;
        public List<MovingEntity> Entities;
        public int CohesionForce;
        public CohesionBehaviour(MovingEntity me, int radius, List<MovingEntity> entities, int cohesionForce) : base(me)
        {
            this.Radius = radius;
            this.Entities = entities;
            this.CohesionForce = cohesionForce;
        }

        public override Vector2D Calculate()
        {
            ME.TagNeighbors(ME.MyWorld.entities, Radius);

            Vector2D centerOfMass = new Vector2D();
            Vector2D steeringForce = new Vector2D();

            int neighbourCount = 0;

            foreach (MovingEntity neighbour in Entities)
            {
                if (neighbour != ME && neighbour.Tagged)
                {
                    centerOfMass += neighbour.Pos;
                    neighbourCount++;
                }
            }

            if (neighbourCount > 0)
            {
                centerOfMass /= neighbourCount;
                steeringForce = Seek(centerOfMass);
            }

            return steeringForce.Multiply(CohesionForce);
        }

        private Vector2D Seek(Vector2D target)
        {
            Vector2D Tpos = target.Clone();
            Vector2D desiredVelocity = Tpos.Sub(ME.Pos).Normalize().Multiply(ME.MaxSpeed);
            return desiredVelocity.Sub(ME.Velocity);
        }
    }
}
