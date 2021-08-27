using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tuplemetry;

namespace TuplemetryTester
{
    [TestClass]
    public class CoordinateTest
    {
        [TestMethod]
        public void Instantiation_Tests()
        {
            Coordinate Coordinate;
            float[] Tuplet;
            
            Coordinate Coordinate0 = new Coordinate();
            Tuplet = Coordinate0.Tuplet;

            Assert.IsTrue(0 == Tuplet.Length, "0 dimensional coordinate is corrupted");

            Coordinate Coordinate1 = new Coordinate(1);
            Tuplet = Coordinate1.Tuplet;
            
            Assert.IsTrue(1 == Tuplet.Length && 1 == Tuplet[0], "1 dimensional coordinate is corrupted");

            Coordinate Coordinate4 = new Coordinate(2, 3, 4, 5);
            Tuplet = Coordinate4.Tuplet;

            Assert.IsTrue(4 == Tuplet.Length && 2 == Tuplet[0] && 3 == Tuplet[1] && 4 == Tuplet[2] && 5 == Tuplet[3], "4 dimensional coordinate is corrupted");

            Coordinate = new Coordinate(Coordinate0);
            Tuplet = Coordinate.Tuplet;
            
            Assert.IsTrue(0 == Tuplet.Length, "Coordinate object sourced 0 dimensional coordinate is corrupted");

            Coordinate = new Coordinate(Coordinate1);
            Tuplet = Coordinate.Tuplet;

            Assert.IsTrue(1 == Tuplet.Length && 1 == Tuplet[0], "Coordinate object sourced 1 dimensional coordinate is corrupted");

            Coordinate = new Coordinate(Coordinate4);
            Tuplet = Coordinate.Tuplet;

            Assert.IsTrue(4 == Tuplet.Length && 2 == Tuplet[0] && 3 == Tuplet[1] && 4 == Tuplet[2] && 5 == Tuplet[3], "Coordinate object sourced 4 dimensional coordinate is corrupted");

            float[] Tuplet0 = { };
            Coordinate = new Coordinate(Tuplet0);
            Tuplet = Coordinate.Tuplet;

            Assert.IsTrue(0 == Tuplet.Length, "float[] sourced 0 dimensional coordinate is corrupted");

            float[] Tuplet1 = { 11 };
            Coordinate = new Coordinate(Tuplet1);
            Tuplet = Coordinate.Tuplet;

            Assert.IsTrue(1 == Tuplet.Length && 11 == Tuplet[0], "float[] sourced 1 dimensional coordinate is corrupted");

            float[] Tuplet4 = { 12, 13, 14, 15 };
            Coordinate = new Coordinate(Tuplet4);
            Tuplet = Coordinate.Tuplet;

            Assert.IsTrue(4 == Tuplet.Length && 12 == Tuplet[0] && 13 == Tuplet[1] && 14 == Tuplet[2] && 15 == Tuplet[3], "float[] sourced 4 dimensional coordinate is corrupted");
        }

        [TestMethod]
        public void Member_Tests()
        {
            Coordinate Coordinate0 = new Coordinate();

            Coordinate Coordinate4 = new Coordinate(2f, 3f, 4f, 8f);

            Assert.AreEqual(2f, Coordinate4.X, "X of the 4 dimensional coordinate is incorrect");
            Assert.AreEqual(3f, Coordinate4.Y, "Y of the 4 dimensional coordinate is incorrect");
            Assert.AreEqual(4f, Coordinate4.Z, "Z of the 4 dimensional coordinate is incorrect");

            Coordinate4.X = 4f;
            Assert.AreEqual(4f, Coordinate4.X, "X reassingment of the 4 dimensional coordinate is incorrect");

            Coordinate4.Y = 9f;
            Assert.AreEqual(9f, Coordinate4.Y, "Y reassingment of the 4 dimensional coordinate is incorrect");

            Coordinate4.Z = 16f;
            Assert.AreEqual(16f, Coordinate4.Z, "Z reassingment of the 4 dimensional coordinate is incorrect");

            Assert.AreEqual(Round(20.420f), Round(Coordinate4.Length), "Length of the 4 dimensional coordinate is incorrect");
        }

        [TestMethod]
        public void Calculation_Tests()
        {
            Coordinate A = new Coordinate(16f, 1f, 8f);

            Assert.AreEqual(-16f, -A.X, "A.X negation is incorrect");
            Assert.AreEqual(-1f, -A.Y, "A.Y negation is incorrect");
            Assert.AreEqual(-8f, -A.Z, "A.Z negation is incorrect");

            Coordinate B = new Coordinate(-11f, 8f, -45f);

            Assert.AreEqual(11f, -B.X, "B.X negation is incorrect");
            Assert.AreEqual(-8f, -B.Y, "B.Y negation is incorrect");
            Assert.AreEqual(45f, -B.Z, "B.Z negation is incorrect");

            Assert.AreEqual(59.891f, Round(A.Distance(B)), "Distance between A and B is incorrect");
            Assert.AreEqual(59.891f, Round(B.Distance(A)), "Distance between B and A is incorrect");

            Coordinate C;

            C = A + B;

            Assert.AreEqual(5f, Round(C.X), "X sum is incorrect");
            Assert.AreEqual(9f, Round(C.Y), "Y sum is incorrect");
            Assert.AreEqual(-37f, Round(C.Z), "Z sum is incorrect");

            C = B + A;

            Assert.AreEqual(5f, Round(C.X), "X sum is incorrect");
            Assert.AreEqual(9f, Round(C.Y), "Y sum is incorrect");
            Assert.AreEqual(-37f, Round(C.Z), "Z sum is incorrect");

            C = A - B;

            Assert.AreEqual(27f, Round(C.X), "X difference is incorrect");
            Assert.AreEqual(-7f, Round(C.Y), "Y difference is incorrect");
            Assert.AreEqual(53f, Round(C.Z), "Z difference is incorrect");

            C = B - A;

            Assert.AreEqual(-27f, Round(C.X), "X difference is incorrect");
            Assert.AreEqual(7f, Round(C.Y), "Y difference is incorrect");
            Assert.AreEqual(-53f, Round(C.Z), "Z difference is incorrect");

            C = A % B;

            Assert.AreEqual(5f, Round(C.X), "X modulus is incorrect");
            Assert.AreEqual(1f, Round(C.Y), "Y modulus is incorrect");
            Assert.AreEqual(8f, Round(C.Z), "Z modulus is incorrect");

            C = B % A;

            Assert.AreEqual(-11f, Round(C.X), "X modulus is incorrect");
            Assert.AreEqual(0f, Round(C.Y), "Y modulus is incorrect");
            Assert.AreEqual(-5f, Round(C.Z), "Z modulus is incorrect");
            
            C = A & B;

            Assert.AreEqual(2.5f, Round(C.X), "X average is incorrect");
            Assert.AreEqual(4.5f, Round(C.Y), "Y average is incorrect");
            Assert.AreEqual(-18.5f, Round(C.Z), "Z average is incorrect");

            C = B & A;

            Assert.AreEqual(2.5f, Round(C.X), "X average is incorrect");
            Assert.AreEqual(4.5f, Round(C.Y), "Y average is incorrect");
            Assert.AreEqual(-18.5f, Round(C.Z), "Z average is incorrect");

            C = A * 10f;

            Assert.AreEqual(160f, Round(C.X), "X scale up is incorrect");
            Assert.AreEqual(10f, Round(C.Y), "Y scale up is incorrect");
            Assert.AreEqual(80f, Round(C.Z), "Z scale up is incorrect");

            C = B * -.3f;

            Assert.AreEqual(3.3f, Round(C.X), "X scale up is incorrect");
            Assert.AreEqual(-2.4f, Round(C.Y), "Y scale up is incorrect");
            Assert.AreEqual(13.5f, Round(C.Z), "Z scale up is incorrect");

            C = A / -7.15f;

            Assert.AreEqual(-2.237f, Round(C.X), "X scale down is incorrect");
            Assert.AreEqual(-0.139f, Round(C.Y), "Y scale down is incorrect");
            Assert.AreEqual(-1.118f, Round(C.Z), "Z scale down is incorrect");

            C = B / 3f;

            Assert.AreEqual(-3.666f, Round(C.X), "X scale down is incorrect");
            Assert.AreEqual(2.666f, Round(C.Y), "Y scale down is incorrect");
            Assert.AreEqual(-15f, Round(C.Z), "Z scale down is incorrect");

            C = A % 4f;

            Assert.AreEqual(0f, Round(C.X), "X modulus is incorrect");
            Assert.AreEqual(1f, Round(C.Y), "Y modulus is incorrect");
            Assert.AreEqual(0f, Round(C.Z), "Z modulus is incorrect");

            C = B % 2.1f;

            Assert.AreEqual(-0.5f, Round(C.X), "X modulus is incorrect");
            Assert.AreEqual(1.7f, Round(C.Y), "Y modulus is incorrect");
            Assert.AreEqual(-0.9f, Round(C.Z), "Z modulus is incorrect");
        }

        [TestMethod]
        public void Exception_Tests()
        {
            try
            {
                Coordinate A = new Coordinate();

                try
                {
                    A.X = 1;

                    Assert.Fail("X assignment should have thrown MemberAccessException");
                }
                catch (MemberAccessException) { }

                try
                {
                    A.Y = 2;

                    Assert.Fail("Y assignment should have thrown MemberAccessException");
                }
                catch (MemberAccessException) { }

                try
                {
                    A.Z = 3;

                    Assert.Fail("Z assignment should have thrown MemberAccessException");
                }
                catch (MemberAccessException) { }

                try
                {
                    A.Tuplet[0] = 4;

                    Assert.Fail("Tuplet[0] assignment should have thrown IndexOutOfRangeException");
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    A.Tuplet[1] = 5;

                    Assert.Fail("Tuplet[1] assignment should have thrown IndexOutOfRangeException");
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    A.Tuplet[2] = 6;

                    Assert.Fail("Tuplet[2] assignment should have thrown IndexOutOfRangeException");
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    float N = A.X;

                    Assert.Fail("X access should have thrown MemberAccessException");
                }
                catch (MemberAccessException) { }

                try
                {
                    float N = A.Y;

                    Assert.Fail("Y access should have thrown MemberAccessException");
                }
                catch (MemberAccessException) { }

                try
                {
                    float N = A.Z;

                    Assert.Fail("Z access should have thrown MemberAccessException");
                }
                catch (MemberAccessException) { }

                try
                {
                    float N = A.Tuplet[0];

                    Assert.Fail("Tuplet[0] access should have thrown IndexOutOfRangeException");
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    float N = A.Tuplet[1];

                    Assert.Fail("Tuplet[1] access should have thrown IndexOutOfRangeException");
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    float N = A.Tuplet[2];

                    Assert.Fail("Tuplet[2] access should have thrown IndexOutOfRangeException");
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    A = new Coordinate(11, 13, 17);

                    A = A / 0;

                    Assert.Fail("Coordinate modulus should have thrown a DivideByZeroException");

                }
                catch (DivideByZeroException) { }

                try
                {
                    A = new Coordinate(11, 13, 17);

                    A = A % 0;

                    Assert.Fail("Coordinate modulus should have thrown a DivideByZeroException");

                }
                catch (DivideByZeroException) { }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public float Round(float X)
        {
            Int64 Epsilon = 1000;

            return (float)((Int64)(X * Epsilon)) / Epsilon;
        }
    }
}
