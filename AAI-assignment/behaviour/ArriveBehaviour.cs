using AAI_assignment.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI_assignment.behaviour
{
    enum Deceleration
    {
        slow = 3,
        normal = 2, 
        fast = 1
    }

    class ArriveBehaviour : SteeringBehaviour
    {
        public Vector2D TargetPos;
        Deceleration decel;
        public ArriveBehaviour(MovingEntity me,  Deceleration d) : base(me)
        {
            this.TargetPos = me.MyWorld.Target.Pos;
            this.decel = d;
        }

        public override Vector2D Calculate()
        {
            Vector2D ToTarget = TargetPos - ME.Pos;

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
