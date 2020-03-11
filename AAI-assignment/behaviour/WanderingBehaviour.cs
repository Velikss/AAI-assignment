using AAI_assignment.entity;
using System;

namespace AAI_assignment.behaviour
{
    class WanderingBehaviour : SteeringBehaviour
    {
        public double WanderJitter, WanderRadius, WanderDistance;
        public Vector2D WanderTarget;

        // to do
        public WanderingBehaviour(MovingEntity me) : base(me)
        {
            this.WanderJitter = 5;
            this.WanderRadius = 3;
            this.WanderDistance = 8;
            this.WanderTarget = me.Pos.Clone();
        }

        public override Vector2D Calculate()
        {
            Random rand = new Random();
            //Vector2D WanderTarget = new Vector2D(rand.Next(-1, 1) * WanderJitter, rand.Next(-1, 1) * WanderJitter);
            WanderTarget.Add(new Vector2D(rand.Next(-1, 1) * WanderJitter, rand.Next(-1, 1) * WanderJitter));
            //Reproject this new vector back onto a unit circle
            WanderTarget.Normalize();

            // Increase the length of the vector to the wander circle
            WanderTarget.Multiply(WanderRadius);

            Vector2D targetLocal = WanderTarget.Add(new Vector2D(WanderDistance, 0));

            //Vector2D desiredVelocity = targetLocal.Sub(ME.Pos).Normalize().Multiply(ME.MaxSpeed);
            //return desiredVelocity.Sub(ME.Velocity);
            return targetLocal.Sub(ME.Pos);
        }
    }
}
