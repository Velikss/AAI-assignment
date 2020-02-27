using AAI_assignment.entity;


namespace AAI_assignment.behaviour
{
    class SeekBehaviour : SteeringBehaviour
    {
        public bool Stop = false;
        public int StopRange = 10;
        public SeekBehaviour(MovingEntity me) : base(me)
        {
        }

        public override Vector2D Calculate()
        {
            Vector2D target = ME.MyWorld.Target.Pos;
            if (Stop)
            {
                if (!(ME.Pos.X >= target.X - StopRange && ME.Pos.X <= target.X + StopRange && ME.Pos.Y >= target.Y - StopRange && ME.Pos.Y <= target.Y + StopRange))
                {
                    Vector2D Tpos = ME.MyWorld.Target.Pos.Clone();
                    Vector2D desiredVelocity = Tpos.Sub(ME.Pos).Normalize().Multiply(ME.MaxSpeed);
                    return desiredVelocity.Sub(ME.Velocity);
                }
            }
            else
            {
                Vector2D Tpos = ME.MyWorld.Target.Pos.Clone();
                Vector2D desiredVelocity = Tpos.Sub(ME.Pos).Normalize().Multiply(ME.MaxSpeed);
                return desiredVelocity.Sub(ME.Velocity);
            }
            return new Vector2D();
        }
    }
}
