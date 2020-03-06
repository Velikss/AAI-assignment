using System;
using System.Collections.Generic;
using AAI_assignment.entity;


namespace AAI_assignment.behaviour
{
    class AlignmentBehaviour : SteeringBehaviour
    {
        public int Radius;
        public List<MovingEntity> Entities;
        public float AllignmentForce;
        public AlignmentBehaviour(MovingEntity me, int radius, List<MovingEntity> entities, float allignmentForce) : base(me)
        {
            this.Radius = radius;
            this.Entities = entities;
            this.AllignmentForce = allignmentForce;
        }

        public override Vector2D Calculate()
        {
            Vector2D averageHeading = new Vector2D();
            int neighbourCount = 0;
            foreach (MovingEntity entity in Entities)
            {
                double dist = Vector2D.DistanceSquared(ME.Pos, entity.Pos);
                if (dist < Radius * Radius && dist > 0)
                {
                    Vector2D h = entity.Velocity.Clone().Normalize();
                    averageHeading += h;
                    neighbourCount++;
                }
            }
            if (neighbourCount > 0)
            {
                averageHeading /= neighbourCount;
            }
            return averageHeading.Normalize() * AllignmentForce;
        }
    }
}
