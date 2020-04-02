using System;

namespace AAI_assignment
{

    public class Vector2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        private static Random random = new Random();
        public Vector2D() : this(0, 0)
        {
        }

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double Length()
        {
            return Math.Sqrt(LengthSquared());
        }

        public double LengthSquared()
        {
            return (X * X) + (Y * Y);
        }

        public static double DistanceSquared(Vector2D v1, Vector2D v2)
        {
            return (v1.X - v2.X) * (v1.X - v2.X) + (v1.Y - v2.Y) * (v1.Y - v2.Y);
        }

        public Vector2D Add(Vector2D v)
        {
            this.X += v.X;
            this.Y += v.Y;
            return this;
        }

        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
        }

        public Vector2D Sub(Vector2D v)
        {
            this.X -= v.X;
            this.Y -= v.Y;
            return this;
        }

        public static Vector2D operator -(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X - v2.X, v1.Y - v2.Y);
        }

        public Vector2D Multiply(double value)
        {
            this.X *= value;
            this.Y *= value;
            return this;
        }

        public Vector2D Multiply(double xVal, double yVal)
        {
            X *= xVal;
            Y *= yVal;
            return this;
        }

        public static Vector2D operator *(Vector2D v1, double value)
        {
            return new Vector2D(v1.X * value, v1.Y * value);
        }

        public Vector2D Divide(double value)
        {
            if (value > 0)
            {
                X /= value;
                Y /= value;
            }
            return this;
        }

        public static Vector2D operator /(Vector2D v1, double value)
        {
            return new Vector2D(v1.X / value, v1.Y / value);
        }

        public Vector2D Normalize()
        {
            Divide(Length());
            return this;
        }

        public Vector2D Truncate(double maX)
        {
            if (Length() > maX)
            {
                Normalize();
                Multiply(maX);
            }
            return this;
        }

        public Vector2D SetMagnitude(double magnitude)
        {
            Normalize();
            Multiply(magnitude, magnitude);
            return this;
        }

        public Vector2D WrapAround(double xMax, double yMax)
        {
            X = (X + xMax) % xMax;
            Y = (Y + yMax) % yMax;
            return this;
        }

        public Vector2D Invert()
        {
            Vector2D n = new Vector2D(X * -1, Y * -1);

            return n;
        }

        public static Vector2D CreateRandomWorldPosition(double xMax, double yMax)
        {
            double x = random.NextDouble();
            double y = random.NextDouble();
            Vector2D newVector = new Vector2D(x, y).Multiply(xMax, yMax);
            return newVector;

        }

        public static Vector2D CreateRandomVector()
        {
            double x = random.NextDouble() - 0.5;
            double y = random.NextDouble() - 0.5;

            return new Vector2D(x, y).Normalize();
        }

        public Vector2D Clone()
        {
            return new Vector2D(this.X, this.Y);
        }

        public override string ToString()
        {
            return String.Format("({0},{1})", X, Y);
        }
    }


}
