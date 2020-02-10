using AAI_assignment.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI_assignment.behaviour
{
    class SeekBehaviour : SteeringBehaviour
    {
        // to do
        public SeekBehaviour(MovingEntity me) : base(me)
        {
        }

        public override Vector2D Calculate()
        {
            Vector2D Cpos = ME.MyWorld.Target.Pos.Clone();
            Vector2D desiredVelocity = Cpos.Sub(ME.Pos).Normalize().Multiply(ME.MaxSpeed);
            return desiredVelocity.Sub(ME.Velocity);
        }
    }
}
