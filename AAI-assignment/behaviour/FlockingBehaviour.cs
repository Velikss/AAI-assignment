using AAI_assignment.entity;
using System.Collections.Generic;


namespace AAI_assignment.behaviour
{
    class FlockingBehaviour : SteeringBehaviour
    {
        public float RadiusC;
        public float RadiusS;
        public float RadiusA;
        public List<MovingEntity> Entities;
        public float CohesionForce;
        public float SeparationForce;
        public float AllignmentForce;
        private SeparationBehaviour sB;
        private AlignmentBehaviour aB;
        private CohesionBehaviour cB;
        public FlockingBehaviour(MovingEntity me, float radiusC, float radiusS, float radiusA, List<MovingEntity> entities,
            float cohesionForce, float separationForce, float allignmentForce) : base(me)

        {
            this.RadiusC = radiusC;
            this.RadiusS = radiusS;
            this.RadiusA = radiusA;
            this.Entities = entities;
            this.CohesionForce = cohesionForce;
            this.SeparationForce = separationForce;
            this.AllignmentForce = allignmentForce;
            sB = new SeparationBehaviour(ME, RadiusS, Entities, SeparationForce);
            aB = new AlignmentBehaviour(ME, RadiusA, Entities, AllignmentForce);
            cB = new CohesionBehaviour(ME, RadiusC, Entities, CohesionForce);
        }

        public override Vector2D Calculate()
        {

            Vector2D steeringForce = sB.Calculate() + aB.Calculate() + cB.Calculate();

            return steeringForce.SetMagnitude(ME.MaxSpeed);
        }

    }
}
