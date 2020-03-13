using System;
using System.Collections.Generic;
using AAI_assignment.entity;
using Huiswerk6;

namespace AAI_assignment.behaviour
{
    class PointToPointBehaviour : SteeringBehaviour
    {
        public int StopRange = WorldParameters.TargetStopRange;
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

            if (!(ME.Pos.X >= Target.Pos.X - StopRange && ME.Pos.X <= Target.Pos.X + StopRange && ME.Pos.Y >= Target.Pos.Y - StopRange && ME.Pos.Y <= Target.Pos.Y + StopRange))
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
