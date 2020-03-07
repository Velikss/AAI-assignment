using System;
using System.Collections.Generic;
using AAI_assignment.entity;


namespace AAI_assignment.behaviour
{
    class AlignmentBehaviour : SteeringBehaviour
    {
        public float Radius;
        public List<MovingEntity> Entities;
        public float AllignmentForce;
        public AlignmentBehaviour(MovingEntity me, float radius, List<MovingEntity> entities, float allignmentForce) : base(me)
        {
            this.Radius = radius;
            this.Entities = entities;
            this.AllignmentForce = allignmentForce;
        }

        public override Vector2D Calculate()
        {
            Vector2D averageHeading = new Vector2D();
            int neighbourCount = 0;

            for (int i = 0; i < Entities.Count; i++)
            {
                double dist = Vector2D.DistanceSquared(ME.Pos, Entities[i].Pos);
                if (dist < Radius * Radius && dist > 0)
                {
                    Vector2D h = Entities[i].Velocity.Clone().Normalize();
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
