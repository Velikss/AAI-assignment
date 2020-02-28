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

        public MovingEntity(Vector2D pos, World w) : base(pos, w)
        {
            Mass = 30;
            MaxSpeed = 15;
            Velocity = new Vector2D();
            Heading = new Vector2D(1, 1);
        }

        public override void Update(float timeElapsed)
        {
            Vector2D temp = new Vector2D();
            foreach (SteeringBehaviour sb in SB)
            {
                Vector2D steeringForce = sb.Calculate();
                //Acceleration = Force/Mass
                Vector2D acceleration = steeringForce.Divide(Mass);
                //update velocity
                Velocity.Add(acceleration.Multiply(timeElapsed));
                // Make sure the velocity does not exceed maximum velocity
                Velocity.Truncate(MaxSpeed);

                temp.Add(Velocity.Multiply(timeElapsed));
                //Pos.Add(Velocity.Multiply(timeElapsed));
            }
            //update the position
            Pos.Add(temp);
            Heading = Pos.Clone().Normalize();
            ////Console.WriteLine(ToString());
            ////Console.WriteLine("Red: " + Pos);
            ////Console.WriteLine("Blue: " + MyWorld.Target.Pos);
        }

        public override string ToString()
        {
            return String.Format("{0}", Velocity);
        }
    }
}
