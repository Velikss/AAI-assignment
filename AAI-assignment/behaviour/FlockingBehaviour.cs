using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Permissions;
using AAI_assignment.entity;


namespace AAI_assignment.behaviour
{
    class FlockingBehaviour : SteeringBehaviour
    {
        public int RadiusC;
        public int RadiusS;
        public int RadiusA;
        public List<MovingEntity> Entities;
        public int CohesionForce;
        public int SeparationForce;
        public int AllignmentForce;
        public FlockingBehaviour(MovingEntity me, int radiusC, int radiusS, int radiusA, List<MovingEntity> entities, 
            int cohesionForce, int separationForce, int allignmentForce) : base(me)

        {
            this.RadiusC = radiusC;
            this.RadiusS = radiusS;
            this.RadiusA = radiusA;
            this.Entities = entities;
            this.CohesionForce = cohesionForce;
            this.SeparationForce = separationForce;
            this.AllignmentForce = allignmentForce;
        }

        public override Vector2D Calculate()
        {
            SeparationBehaviour sB = new SeparationBehaviour(ME, RadiusS, Entities, SeparationForce);
            AllignmentBehaviour aB = new AllignmentBehaviour(ME, RadiusA, Entities, AllignmentForce);
            CohesionBehaviour cB = new CohesionBehaviour(ME, RadiusC, Entities, CohesionForce);

            Vector2D steeringForce = new Vector2D();
            steeringForce += sB.Calculate();
            steeringForce += aB.Calculate();
            steeringForce += cB.Calculate();

            return steeringForce.Truncate(ME.MaxSpeed);
        }

    }
}
