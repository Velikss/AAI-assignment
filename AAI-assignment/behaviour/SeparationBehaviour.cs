using System;
using AAI_assignment.entity;


namespace AAI_assignment.behaviour
{
    class SeparationBehaviour : SteeringBehaviour
    {
        public SeparationBehaviour(MovingEntity me) : base(me)
        {
        }

        public override Vector2D Calculate()
        {
            ME.TagNeighbors(ME.MyWorld.entities, 10);
            Vector2D steeringForce = new Vector2D();
            foreach (MovingEntity neighbour in ME.Neighbours)
            {
                if (neighbour != ME && neighbour.Tagged)
                {
                    Vector2D ToAgent = ME.Pos.Clone().Sub(neighbour.Pos);
                    steeringForce = steeringForce.Add(ToAgent.Normalize().Divide(ToAgent.Length()));
                }
            }
            return steeringForce.Multiply(10);
        }
    }
}