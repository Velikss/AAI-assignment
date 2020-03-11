using AAI_assignment.entity;
using System;

namespace AAI_assignment.behaviour
{
    public enum Deceleration
    {
        slow = 3,
        normal = 2,
        fast = 1
    }

    class ArriveBehaviour : SteeringBehaviour
    {
        Deceleration decel;
        MovingEntity me;
        public ArriveBehaviour(MovingEntity me, Deceleration d) : base(me)
        {
            this.me = me;
            this.decel = d;
        }

        public override Vector2D Calculate()
        {
            Vector2D ToTarget = me.MyWorld.Target.Pos - ME.Pos;

            double dist = ToTarget.Length();

            if (dist > 0)
            {
                const double DecelerationTweak = 0.7;

                double speed = dist / ((double)decel * DecelerationTweak);

                speed = Math.Min(speed, ME.MaxSpeed);

                Vector2D DesiredVeloctiy = ToTarget * speed / dist;

                return (DesiredVeloctiy - ME.Velocity);
            }

            return new Vector2D(0, 0);
        }
    }
}
