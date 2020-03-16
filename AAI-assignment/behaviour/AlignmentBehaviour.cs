﻿using AAI_assignment.entity;
using System.Collections.Generic;


namespace AAI_assignment.behaviour
{
    class AlignmentBehaviour : SteeringBehaviour
    {
        public List<MovingEntity> Entities;
        public AlignmentBehaviour(MovingEntity me, List<MovingEntity> entities) : base(me)
        {
            this.Entities = entities;
        }

        public override Vector2D Calculate()
        {
            Vector2D averageHeading = new Vector2D();
            int neighbourCount = 0;
            float radius = WorldParameters.AlignmentRadius;
            float force = WorldParameters.AlignmentForce;

            for (int i = 0; i < Entities.Count; i++)
            {
                double dist = Vector2D.DistanceSquared(ME.Pos, Entities[i].Pos);
                if (dist < WorldParameters.AlignmentRadius * WorldParameters.AlignmentRadius && dist > 0)
                {
                    Vector2D h = Entities[i].Velocity.Clone().Normalize();
                    averageHeading += h;
                    neighbourCount++;
                }
            }
            if (neighbourCount > 0)
            {
                averageHeading /= neighbourCount;
            }
            return averageHeading.Normalize() * WorldParameters.AlignmentForce;
        }

        public Vector2D CalculateFlocking()
        {
            Vector2D averageHeading = new Vector2D();
            int neighbourCount = 0;
            float radius = WorldParameters.FlockingAlignmentRadius;
            float force = WorldParameters.FlockingAlignmentForce;

            for (int i = 0; i < Entities.Count; i++)
            {
                double dist = Vector2D.DistanceSquared(ME.Pos, Entities[i].Pos);
                if (dist < WorldParameters.AlignmentRadius * WorldParameters.AlignmentRadius && dist > 0)
                {
                    Vector2D h = Entities[i].Velocity.Clone().Normalize();
                    averageHeading += h;
                    neighbourCount++;
                }
            }
            if (neighbourCount > 0)
            {
                averageHeading /= neighbourCount;
            }
            return averageHeading.Normalize() * WorldParameters.AlignmentForce;
        }
    }
}
