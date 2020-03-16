using AAI_assignment.entity;
using System;

namespace AAI_assignment.behaviour
{
    class WanderingBehaviour : SteeringBehaviour
    {
        public double WanderJitter, WanderRadius, WanderDistance;
        public Vector2D WanderTarget;
        public MovingEntity me;

        // to do
        public WanderingBehaviour(MovingEntity me) : base(me)
        {
            this.WanderJitter = 5;
            this.WanderRadius = 3;
            this.WanderDistance = 8;
            this.WanderTarget = me.Pos.Clone();
            this.me = me;
        }

        public override Vector2D Calculate()
        {
            throw new NotImplementedException();
        }
    }
}
