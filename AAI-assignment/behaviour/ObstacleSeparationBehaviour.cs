using AAI_assignment.entity;
using System.Collections.Generic;

namespace AAI_assignment.behaviour
{
    class ObstacleSeparationBehaviour : SteeringBehaviour
    {
        public List<BaseGameEntity> Entities;
        public ObstacleSeparationBehaviour(MovingEntity me, List<BaseGameEntity> entities) : base(me)
        {
            this.Entities = entities;
        }

        public override Vector2D Calculate()
        {
            Vector2D steeringForce = new Vector2D();
            int obstacleScale = WorldParameters.ObstacleScale;
            float radius = WorldParameters.SeparationRadius;
            float force = WorldParameters.SeparationForce;

            for (int i = 0; i < Entities.Count; i++)
            {
                double dist = Vector2D.DistanceSquared(ME.Pos, Entities[i].Pos);
                if (dist < (radius + obstacleScale) * (radius + obstacleScale) && dist > 0)
                {
                    Vector2D separationForce = ME.Pos - Entities[i].Pos;
                    steeringForce += separationForce / dist;
                }
            }
            return steeringForce.Normalize() * force;
        }
    }
}
