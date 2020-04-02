using System.Collections.Generic;


namespace AAI_assignment
{
    class AlignmentBehaviour : SteeringBehaviour
    {
        public List<MovingEntity> Entities;
        public bool Flocking;
        public AlignmentBehaviour(MovingEntity me, List<MovingEntity> entities, bool flocking = false) : base(me)
        {
            this.Entities = entities;
            Flocking = flocking;
        }

        public override Vector2D Calculate()
        {
            Vector2D averageHeading = new Vector2D();
            int neighbourCount = 0;
            float radius;
            float force;
            if (Flocking)
            {
                radius = WorldParameters.FlockingAliRadius;
                force = WorldParameters.FlockingAliForce;
            }
            else
            {
                radius = WorldParameters.AlignmentRadius;
                force = WorldParameters.AlignmentForce;
            }

            for (int i = 0; i < Entities.Count; i++)
            {
                double dist = Vector2D.DistanceSquared(ME.Pos, Entities[i].Pos);
                if (dist < radius * radius && dist > 0)
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
            return averageHeading.Normalize() * force;
        }
    }
}
