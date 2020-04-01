namespace AAI_assignment.behaviour
{
    public class SeekBehaviour : SteeringBehaviour
    {
        Vector2D target;

        public SeekBehaviour(MovingEntity me) : base(me)
        {
            this.target = me.MyWorld.Target.Pos;
        }

        public SeekBehaviour(MovingEntity me, Vector2D target) : base(me)
        {
            this.target = target;
        }

        public override Vector2D Calculate()
        {

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
