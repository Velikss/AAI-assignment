using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAI_assignment
{

    public class Vector2D
    {
        public double X { get; set; }
        public double Y { get; set; }

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

        public static Vector2D operator *(Vector2D v1, double value)
        {
            return new Vector2D(v1.X * value, v1.Y * value);
        }

        public Vector2D Divide(double value)
        {
            this.X /= value;
            this.Y /= value;
            return this;
        }

        public static Vector2D operator /(Vector2D v1, double value)
        {
            return new Vector2D(v1.X / value, v1.Y / value);
        }

        public Vector2D Normalize()
        {
            this.X /= Length();
            this.Y /= Length();
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

        public static Vector2D randomPos(int maxX, int maxY)
        {
            Random rnd = new Random();
            return new Vector2D(rnd.NextDouble() * maxX, rnd.NextDouble() * maxY);
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
