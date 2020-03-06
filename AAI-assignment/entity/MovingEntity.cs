using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AAI_assignment.entity
{

    abstract class MovingEntity : BaseGameEntity
    {
        public Vector2D Velocity { get; set; }
        public Vector2D Heading { get; set; }

        public float Mass { get; set; }
        public float MaxSpeed { get; set; }
        public BaseGameEntity Target { get; set; }
        public List<SteeringBehaviour> SB = new List<SteeringBehaviour>();
        public List<Vector2D> Feelers = new List<Vector2D>();
        public SteeringBehaviour SteeringBehaviour { get; set; }

        public MovingEntity(Vector2D pos, World w) : base(pos, w)
        {
            Mass = 30;
            MaxSpeed = 15;
            Velocity = new Vector2D();
            Heading = new Vector2D(1, 1);
        }

        public override void Update(float timeElapsed)
        {
            Vector2D steeringForce = SteeringBehaviour.Calculate();
            //Vector2D steeringForce = new Vector2D();
            //foreach (SteeringBehaviour sb in SB)
            //{
            //    steeringForce += sb.Calculate();
            //}
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
