using System;
using System.Collections.Generic;
using AAI_assignment.entity;


namespace AAI_assignment.behaviour
{
    class AllignmentBehaviour : SteeringBehaviour
    {
        public int Radius;
        public List<MovingEntity> Entities;
        public int AllignmentForce;
        public AllignmentBehaviour(MovingEntity me, int radius, List<MovingEntity> entities, int allignmentForce) : base(me)
        {
            this.Radius = radius;
            this.Entities = entities;
            this.AllignmentForce = allignmentForce;
        }

        public override Vector2D Calculate()
        {
            ME.TagNeighbors(ME.MyWorld.entities, Radius);

            Vector2D averageHeading = new Vector2D();

            int NeighbourCount = 0;

            foreach (MovingEntity neighbour in Entities)
            {
                if (neighbour != ME && neighbour.Tagged)
                {
                    averageHeading += neighbour.Heading;
                    NeighbourCount++;
                }
            }

            if (NeighbourCount > 0)
            {
                averageHeading /= (double)NeighbourCount;
                averageHeading -= ME.Heading;
            }

            return averageHeading.Multiply(AllignmentForce);
        }
    }
}
