using AAI_assignment.entity;
using System.Collections.Generic;

namespace AAI_assignment.behaviour
{
    class ObstacleSeparationBehaviour : SteeringBehaviour
    {
        public List<BaseGameEntity> Obstacles;
        public ObstacleSeparationBehaviour(MovingEntity me, List<BaseGameEntity> obstacles) : base(me)
        {
            this.Obstacles = obstacles;
        }

        public override Vector2D Calculate()
        {
            Vector2D steeringForce = new Vector2D();
            int obstacleScale = WorldParameters.ObstacleScale;
            float radius = WorldParameters.ObstacleSepRadius;
            float force = WorldParameters.ObstacleSepForce;

            for (int i = 0; i < Obstacles.Count; i++)
            {
                double dist = Vector2D.DistanceSquared(ME.Pos, Obstacles[i].Pos);
                if (dist < (radius + obstacleScale) * (radius + obstacleScale) && dist > 0)
                {
                    Vector2D separationForce = ME.Pos - Obstacles[i].Pos;
                    steeringForce += separationForce / dist;
                }
            }
            return steeringForce.Normalize() * force;
        }
    }
}
