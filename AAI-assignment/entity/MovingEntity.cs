using System;
using System.Collections.Generic;

namespace AAI_assignment
{

    public abstract class MovingEntity : BaseGameEntity
    {
        public Vector2D Velocity { get; set; }
        public Vector2D Heading { get; set; }

        public float Mass { get; set; }
        public float MaxSpeed { get; set; }
        public BaseGameEntity Target { get; set; }
        public List<SteeringBehaviour> SB = new List<SteeringBehaviour>();

        public MovingEntity(Vector2D pos, World w) : base(pos, w)
        {
            Mass = 30;
            MaxSpeed = 15;
            Velocity = new Vector2D();
            Heading = new Vector2D(1, 1);
        }

        public override void Update(float timeElapsed)
        {
            //Console.WriteLine(SB.Count);
            //Vector2D steeringForce = SteeringBehaviour.Calculate();
            Vector2D steeringForce = new Vector2D();
            for (int i = 0; i < SB.Count; i++)
            {
                steeringForce += SB[i].Calculate();
            }
            UpdatePosition(timeElapsed, steeringForce);
        }

        private void UpdatePosition(float timeElapsed, Vector2D steeringForce)
        {
            Vector2D acceleration = steeringForce.Divide(Mass);
            Velocity += acceleration * timeElapsed;
            Velocity.Truncate(MaxSpeed);
            //Velocity *= 2;
            //Pos.Add(Velocity.Multiply(timeElapsed));
            Pos.Add(Velocity * timeElapsed);
            Velocity *= 0.9;
            Pos.WrapAround(MyWorld.Width, MyWorld.Height);
        }

        public override string ToString()
        {
            return String.Format("{0}", Velocity);
        }
    }
}
