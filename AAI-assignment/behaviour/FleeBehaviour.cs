namespace AAI_assignment
{
    public class FleeBehaviour : SteeringBehaviour
    {
        public Vector2D Target;

        public FleeBehaviour(MovingEntity me) : base(me)
        {
            this.Target = me.MyWorld.Target.Pos;
        }

        public FleeBehaviour(MovingEntity me, Vector2D target) : base(me)
        {
            this.Target = target;
        }

        public override Vector2D Calculate()
        {

            if (WorldParameters.SeekStop)
            {
                if (!(ME.Pos.X >= Target.X - WorldParameters.SeekStopRadius
                      && ME.Pos.X <= Target.X + WorldParameters.SeekStopRadius
                      && ME.Pos.Y >= Target.Y - WorldParameters.SeekStopRadius
                      && ME.Pos.Y <= Target.Y + WorldParameters.SeekStopRadius))
                {
                    Vector2D Tpos = Target.Clone();
                    Vector2D desiredVelocity = Tpos.Sub(ME.Pos).Normalize().Multiply(ME.MaxSpeed);
                    return desiredVelocity.Sub(ME.Velocity).Invert();
                }
            }
            else
            {
                Vector2D Tpos = Target.Clone();
                Vector2D desiredVelocity = Tpos.Sub(ME.Pos).Normalize().Multiply(ME.MaxSpeed);
                return desiredVelocity.Sub(ME.Velocity).Invert();
            }
            return new Vector2D();
        }
    }
}
