using AAI_assignment.entity;


namespace AAI_assignment.behaviour
{
    public class SeekBehaviour : SteeringBehaviour
    {
        public SeekBehaviour(MovingEntity me) : base(me) { }

        public override Vector2D Calculate()
        {
            Vector2D target = ME.MyWorld.Target.Pos;
            if (WorldParameters.SeekStop)
            {
                if (!(ME.Pos.X >= target.X - WorldParameters.SeekStopRadius
                      && ME.Pos.X <= target.X + WorldParameters.SeekStopRadius
                      && ME.Pos.Y >= target.Y - WorldParameters.SeekStopRadius
                      && ME.Pos.Y <= target.Y + WorldParameters.SeekStopRadius))
                {
                    Vector2D Tpos = target.Clone();
                    Vector2D desiredVelocity = Tpos.Sub(ME.Pos).Normalize().Multiply(ME.MaxSpeed);
                    return desiredVelocity.Sub(ME.Velocity);
                }
            }
            else
            {
                Vector2D Tpos = target.Clone();
                Vector2D desiredVelocity = Tpos.Sub(ME.Pos).Normalize().Multiply(ME.MaxSpeed);
                return desiredVelocity.Sub(ME.Velocity);
            }
            return new Vector2D();
        }
    }
}
