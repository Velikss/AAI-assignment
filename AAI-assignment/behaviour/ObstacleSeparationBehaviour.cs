using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AAI_assignment.entity;

namespace AAI_assignment.behaviour
{
    class ObstacleSeparationBehaviour : SteeringBehaviour
    {
        public float Radius;
        public List<BaseGameEntity> Entities;
        public float SeperationForce;
        public ObstacleSeparationBehaviour(MovingEntity me, float radius, List<BaseGameEntity> entities, float seperationForce) : base(me)
        {
            this.Radius = radius;
            this.Entities = entities;
            this.SeperationForce = seperationForce;
        }

        public override Vector2D Calculate()
        {
            Vector2D steeringForce = new Vector2D();

            for (int i = 0; i < Entities.Count; i++)
            {
                double dist = Vector2D.DistanceSquared(ME.Pos, Entities[i].Pos);
                if (dist < Radius * Radius && dist > 0)
                {
                    Vector2D separationForce = ME.Pos - Entities[i].Pos;
                    steeringForce += separationForce / dist;
                }
            }
            return steeringForce.Normalize() * SeperationForce;
        }
    }
}
