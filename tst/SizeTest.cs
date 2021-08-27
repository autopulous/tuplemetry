using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tuplemetry;

namespace TuplemetryTester
{
    [TestClass]
    public class SizeTest
    {
        [TestMethod]
        public void Instantiation_Tests()
        {
            Size Size;
            float[] Tuplet;

            Size Size0 = new Size( );
            Tuplet = Size0.Tuplet;

            Assert.IsTrue(0 == Tuplet.Length, "0 dimensional tuple is corrupted");

            Size Size1 = new Size(1);
            Tuplet = Size1.Tuplet;

            Assert.IsTrue(1 == Tuplet.Length && 1 == Tuplet[0], "1 dimensional tuple is corrupted");

            Size Size4 = new Size(2, 3, 4, 5);
            Tuplet = Size4.Tuplet;

            Assert.IsTrue(4 == Tuplet.Length && 2 == Tuplet[0] && 3 == Tuplet[1] && 4 == Tuplet[2] && 5 == Tuplet[3], "4 dimensional tuple is corrupted");

            Size = new Size(Size0);
            Tuplet = Size.Tuplet;

            Assert.IsTrue(0 == Tuplet.Length, "Size object sourced 0 dimensional tuple is corrupted");

            Size = new Size(Size1);
            Tuplet = Size.Tuplet;

            Assert.IsTrue(1 == Tuplet.Length && 1 == Tuplet[0], "Size object sourced 1 dimensional tuple is corrupted");

            Size = new Size(Size4);
            Tuplet = Size.Tuplet;

            Assert.IsTrue(4 == Tuplet.Length && 2 == Tuplet[0] && 3 == Tuplet[1] && 4 == Tuplet[2] && 5 == Tuplet[3], "Size object sourced 4 dimensional tuple is corrupted");

            float[] Tuplet0 = { };
            Size = new Size(Tuplet0);
            Tuplet = Size.Tuplet;

            Assert.IsTrue(0 == Tuplet.Length, "float[] sourced 0 dimensional tuple is corrupted");

            float[] Tuplet1 = { 11 };
            Size = new Size(Tuplet1);
            Tuplet = Size.Tuplet;

            Assert.IsTrue(1 == Tuplet.Length && 11 == Tuplet[0], "float[] sourced 1 dimensional tuple is corrupted");

            float[] Tuplet4 = { 12, 13, 14, 15 };
            Size = new Size(Tuplet4);
            Tuplet = Size.Tuplet;

            Assert.IsTrue(4 == Tuplet.Length && 12 == Tuplet[0] && 13 == Tuplet[1] && 14 == Tuplet[2] && 15 == Tuplet[3], "float[] sourced 4 dimensional tuple is corrupted");
        }

        [TestMethod]
        public void Member_Tests()
        {
            Size Size0 = new Size();

            Assert.AreEqual(0, Size0.Capacity, "Capacity of a 0 dimensioal tupel incorrect");

            Size Size4 = new Size(2f, 3f, 4f, 5f);

            Assert.AreEqual(120f, Size4.Capacity, "Capacity of th 4 dimensioal tupel is incorrect");

            Assert.AreEqual(2f, Size4.Width, "Width of the 4 dimensional tupel is incorrect");
            Assert.AreEqual(3f, Size4.Height, "Height of the 4 dimensional tupel is incorrect");
            Assert.AreEqual(4f, Size4.Depth, "Depth of the 4 dimensional tupel is incorrect");

            Assert.AreEqual(2f, Size4[1], "The first of the 4 dimensional tupel is incorrect");
            Assert.AreEqual(3f, Size4[2], "The second of the 4 dimensional tupel is incorrect");
            Assert.AreEqual(4f, Size4[3], "The third of the 4 dimensional tupel is incorrect");
            Assert.AreEqual(5f, Size4[4], "The forth of the 4 dimensional tupel is incorrect");

            Size4.Width = 6f;
            Assert.AreEqual(6f, Size4.Width, "Width reassingment of the 4 dimensional tupel is incorrect");

            Size4.Height = 7f;
            Assert.AreEqual(7f, Size4.Height, "Height reassingment of the 4 dimensional tupel is incorrect");

            Size4.Depth = 8f;
            Assert.AreEqual(8f, Size4.Depth, "Depth reassingment of the 4 dimensional tupel is incorrect");

            Size4[1] = 9f;
            Assert.AreEqual(9f, Size4[1], "The first of the 4 dimensional tupel is incorrect");
            Size4[2] = 10f;
            Assert.AreEqual(10f, Size4[2], "The second of the 4 dimensional tupel is incorrect");
            Size4[3] = 11f;
            Assert.AreEqual(11f, Size4[3], "The third of the 4 dimensional tupel is incorrect");
            Size4[4] = 12f;
            Assert.AreEqual(12f, Size4[4], "The forth of the 4 dimensional tupel is incorrect");
        }

        [TestMethod]
        public void Exception_Tests()
        {
            try
            {
                Size A = new Size(-1);

                Assert.Fail("Size instantiation should have thrown ArgumentOutOfRangeException");
            }
            catch (ArgumentOutOfRangeException) {}

            try
            {
                Size A = new Size(0);

                Assert.Fail("Size instantiation should have thrown ArgumentOutOfRangeException");
            }
            catch (ArgumentOutOfRangeException) {}

            try
            {
                Size A = new Size(1, 1, 1, -1);

                Assert.Fail("Size instantiation should have thrown ArgumentOutOfRangeException");
            }
            catch (ArgumentOutOfRangeException) { }

            try
            {
                Size A = new Size(1, 1, 1, 0);

                Assert.Fail("Size instantiation should have thrown ArgumentOutOfRangeException");
            }
            catch (ArgumentOutOfRangeException) { }

            try
            {
                float[] Tuplet = { 1, 1, 1, -1 };

                Size A = new Size(Tuplet);

                Assert.Fail("Size instantiation should have thrown ArgumentOutOfRangeException");
            }
            catch (ArgumentOutOfRangeException) { }

            try
            {
                float[] Tuplet = { 1, 1, 1, 0 };

                Size A = new Size(Tuplet);

                Assert.Fail("Size instantiation should have thrown ArgumentOutOfRangeException");
            }
            catch (ArgumentOutOfRangeException) { }

            try
            {
                Size A = new Size();

                try
                {
                    A.Width = 1;

                    Assert.Fail("Width access should have thrown MemberAccessException");
                }
                catch (MemberAccessException) { }

                try
                {
                    A.Height = 2;

                    Assert.Fail("Height access should have thrown MemberAccessException");
                }
                catch (MemberAccessException) { }

                try
                {
                    A.Depth = 3;

                    Assert.Fail("Depth access should have thrown MemberAccessException");
                }
                catch (MemberAccessException) { }

                try
                {
                    A[0] = 4;

                    Assert.Fail("Area access should have thrown IndexOutOfRangeException");
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    A[1] = 5;

                    Assert.Fail("Area access should have thrown IndexOutOfRangeException");
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    A.Tuplet[0] = 4;

                    Assert.Fail("Depth access should have thrown IndexOutOfRangeException");
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    A.Tuplet[1] = 5;

                    Assert.Fail("Depth access should have thrown IndexOutOfRangeException");
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    A.Tuplet[2] = 6;

                    Assert.Fail("Depth access should have thrown IndexOutOfRangeException");
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    float X = A.Width;

                    Assert.Fail("Width access should have thrown MemberAccessException");
                }
                catch (MemberAccessException) { }

                try
                {
                    float X = A.Height;

                    Assert.Fail("Height access should have thrown MemberAccessException");
                }
                catch (MemberAccessException) { }

                try
                {
                    float X = A.Depth;

                    Assert.Fail("Depth access should have thrown MemberAccessException");
                }
                catch (MemberAccessException) { }

                try
                {
                    float X = A.Tuplet[0];

                    Assert.Fail("Should have thrown IndexOutOfRangeException");
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    float X = A.Tuplet[1];

                    Assert.Fail("Should have thrown IndexOutOfRangeException");
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    float X = A.Tuplet[2];

                    Assert.Fail("Should have thrown IndexOutOfRangeException");
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    float X = A.Length;

                    Assert.Fail("Length access should have thrown MemberAccessException");
                }
                catch (MemberAccessException) { }

                try
                {
                    float X = A.Area;

                    Assert.Fail("Area access should have thrown MemberAccessException");
                }
                catch (MemberAccessException) { }

                try
                {
                    float X = A[0];

                    Assert.Fail("Area access should have thrown IndexOutOfRangeException");
                }
                catch (IndexOutOfRangeException) { }

                try
                {
                    float X = A[1];

                    Assert.Fail("Area access should have thrown IndexOutOfRangeException");
                }
                catch (IndexOutOfRangeException) { }
            }
            catch (Exception e)
            {
                throw e;
            }

            try
            {
                Size A = new Size(1, 1, 1);

                try
                {
                    A.Width = -1;

                    Assert.Fail("Width access should have thrown ArgumentOutOfRangeException");
                }
                catch (ArgumentOutOfRangeException) { }

                try
                {
                    A.Width = 0f;

                    Assert.Fail("Width access should have thrown ArgumentOutOfRangeException");
                }
                catch (ArgumentOutOfRangeException) { }

                try
                {
                    A.Height = -1;

                    Assert.Fail("Height access should have thrown ArgumentOutOfRangeException");
                }
                catch (ArgumentOutOfRangeException) { }

                try
                {
                    A.Height = 0;

                    Assert.Fail("Height access should have thrown ArgumentOutOfRangeException");
                }
                catch (ArgumentOutOfRangeException) { }

                try
                {
                    A.Depth = -1;

                    Assert.Fail("Depth access should have thrown ArgumentOutOfRangeException");
                }
                catch (ArgumentOutOfRangeException) { }

                try
                {
                    A.Depth = 0;

                    Assert.Fail("Depth access should have thrown ArgumentOutOfRangeException");
                }
                catch (ArgumentOutOfRangeException) { }

                try
                {
                    A[1] = -1;

                    Assert.Fail("Depth access should have thrown ArgumentOutOfRangeException");
                }
                catch (ArgumentOutOfRangeException) { }

                try
                {
                    A[1] = 0;

                    Assert.Fail("Depth access should have thrown ArgumentOutOfRangeException");
                }
                catch (ArgumentOutOfRangeException) { }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
