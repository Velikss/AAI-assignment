using Huiswerk6;
using System;
using System.Collections.Generic;

namespace AAI_assignment.behaviour
{
    class PointToPointBehaviour : SteeringBehaviour
    {
        public Stack<Node> Path;
        public Node Target;
        public PointToPointBehaviour(MovingEntity me, ref Stack<Node> path) : base(me)
        {
            Path = path;
        }

        public override Vector2D Calculate()
        {
            if (Path == null || Path.Count == 0)
                return new Vector2D();
            if (Target == null)
                Target = Path.Pop();

            if (!(ME.Pos.X >= Target.Pos.X - WorldParameters.TargetStopRange
                  && ME.Pos.X <= Target.Pos.X + WorldParameters.TargetStopRange
                  && ME.Pos.Y >= Target.Pos.Y - WorldParameters.TargetStopRange
                  && ME.Pos.Y <= Target.Pos.Y + WorldParameters.TargetStopRange))
            {
                Vector2D Tpos = Target.Pos.Clone();
                Vector2D desiredVelocity = Tpos.Sub(ME.Pos).Normalize().Multiply(ME.MaxSpeed);
                return desiredVelocity.Sub(ME.Velocity);
            }
            else
            {
                Target = Path.Pop();
                if (Path == null || Path.Count == 0)
                {
                    double gridX = Math.Round((double)Target.Pos.X / ME.MyWorld.NavGrid.CellSize);
                    double gridY = Math.Round((double)Target.Pos.Y / ME.MyWorld.NavGrid.CellSize);
                    ME.MyWorld.TargetNodeX = (int)gridX;
                    ME.MyWorld.TargetNodeY = (int)gridY;
                    ME.MyWorld.Pathfinding = true;
                }
            }
            return new Vector2D();
        }
    }
}
