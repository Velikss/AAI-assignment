using System.Collections.Generic;


namespace AAI_assignment.behaviour
{
    class FlockingBehaviour : SteeringBehaviour
    {
        public List<MovingEntity> Entities;
        private SeparationBehaviour SB;
        private AlignmentBehaviour AB;
        private CohesionBehaviour CB;
        public FlockingBehaviour(MovingEntity me, List<MovingEntity> entities) : base(me)

        {
            this.Entities = entities;
            SB = new SeparationBehaviour(ME, Entities, true);
            AB = new AlignmentBehaviour(ME, Entities, true);
            CB = new CohesionBehaviour(ME, Entities, true);
        }

        public override Vector2D Calculate()
        {

            Vector2D steeringForce = SB.CalculateFlocking() + AB.CalculateFlocking() + CB.CalculateFlocking();

            return steeringForce.SetMagnitude(ME.MaxSpeed);
        }

    }
}
