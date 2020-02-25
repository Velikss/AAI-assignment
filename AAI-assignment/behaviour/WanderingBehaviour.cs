using AAI_assignment.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI_assignment.behaviour
{
    class WanderingBehaviour : SteeringBehaviour
    {
        double WanderJitter, WanderRadius, WanderDistance;
        
        // to do
        public WanderingBehaviour(MovingEntity me) : base(me)
        {
            this.WanderJitter = 5;
            this.WanderRadius = 3;
            this.WanderDistance = 8;
        }

        public override Vector2D Calculate()
        {
            Random rand = new Random();
            Vector2D WanderTarget = new Vector2D(rand.Next(0, 1) * WanderJitter, rand.Next(0, 1) * WanderJitter);
            WanderTarget.Normalize();

            // Increase the length of the vector to the wander circle
            WanderTarget.Multiply(WanderRadius);

            Vector2D targetLocal = WanderTarget.Add(new Vector2D(WanderDistance, 0));

            Vector2D desiredVelocity = targetLocal.Sub(ME.Pos).Normalize().Multiply(ME.MaxSpeed);
            return desiredVelocity.Sub(ME.Velocity);
        }
    }
}
