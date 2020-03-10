using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AAI_assignment;

namespace Unit_Tests
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void AddVector()
        {
            Vector2D v = new Vector2D(4, 5);

            v.Add(new Vector2D(4, 5));

            Assert.AreEqual(v.X, 8);
            Assert.AreEqual(v.Y, 10);
        }

        [TestMethod]
        public void MultiplyVector()
        {
            Vector2D v = new Vector2D(4, 5);

            v.Multiply(2);

            Assert.AreEqual(v.X, 8);
            Assert.AreEqual(v.Y, 10);
        }

        [TestMethod]
        public void SubstractVector()
        {
            Vector2D v = new Vector2D(4, 5);

            v.Sub(new Vector2D(2, 3));

            Assert.AreEqual(v.X, 2);
            Assert.AreEqual(v.Y, 2);
        }

        [TestMethod]
        public void AddVectorWithOperator()
        {
            Vector2D v = new Vector2D(4, 5);

            v += new Vector2D(4, 5);

            Assert.AreEqual(v.X, 8);
            Assert.AreEqual(v.Y, 10);
        }

        [TestMethod]
        public void MultiplyVectorWithOperator()
        {
            Vector2D v = new Vector2D(4, 5);

            v *= 2;

            Assert.AreEqual(v.X, 8);
            Assert.AreEqual(v.Y, 10);
        }

        [TestMethod]
        public void SubstractVectorWithOperator()
        {
            Vector2D v = new Vector2D(4, 5);

            v -= new Vector2D(2, 3);

            Assert.AreEqual(v.X, 2);
            Assert.AreEqual(v.Y, 2);
        }
    }
}
