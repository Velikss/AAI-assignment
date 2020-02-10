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
        private MovingEntity target;
        // to do
        public SeekBehaviour(MovingEntity me, MovingEntity _target) : base(me)
        {
            target = _target;
        }

        public override Vector2D Calculate()
        {
            Vector2D desiredVelocity = target.Pos.Sub(ME.Pos).Normalize().Multiply(ME.MaxSpeed);
            return desiredVelocity.Sub(ME.Velocity);
        }
    }
}
