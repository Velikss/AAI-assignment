using AAI_assignment.entity;
using System.Collections.Generic;


namespace AAI_assignment.behaviour
{
    class FlockingBehaviour : SteeringBehaviour
    {
        public List<MovingEntity> Entities;
        private SeparationBehaviour sB;
        private AlignmentBehaviour aB;
        private CohesionBehaviour cB;
        public FlockingBehaviour(MovingEntity me, List<MovingEntity> entities) : base(me)

        {
            this.Entities = entities;
            sB = new SeparationBehaviour(ME, Entities);
            aB = new AlignmentBehaviour(ME, Entities);
            cB = new CohesionBehaviour(ME, Entities);
        }

        public override Vector2D Calculate()
        {

            Vector2D steeringForce = sB.CalculateFlocking() + aB.CalculateFlocking() + cB.CalculateFlocking();

            return steeringForce.SetMagnitude(ME.MaxSpeed);
        }

    }
}
