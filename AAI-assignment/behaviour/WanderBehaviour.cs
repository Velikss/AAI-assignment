using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI_assignment.behaviour
{
    class WanderBehaviour : SteeringBehaviour
    {
        public WanderBehaviour(MovingEntity me) : base(me)
        {
        }

        public override Vector2D Calculate()
        {
            Vector2D myPosition = ME.Pos;
            Vector2D wanderTarget = Vector2D.CreateRandomVector() * WorldParameters.WanderingJitter;
            wanderTarget.Normalize();
            wanderTarget *= WorldParameters.WanderingRadius;
            Vector2D targetPosition = myPosition + ME.Velocity.Clone().SetMagnitude(WorldParameters.WanderingDistance) + wanderTarget;
            Vector2D desiredVelocity = (targetPosition - myPosition).Truncate(WorldParameters.EntityMaxSpeed);

            return desiredVelocity;
        }
    }
}
