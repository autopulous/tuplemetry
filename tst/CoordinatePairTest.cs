using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tuplemetry;

namespace TuplemetryTester
{
    [TestClass]
    public class CoordinatePairTest
    {
        private Random Aleatory = null;

        [TestMethod]
        public void Instantiation_Tests()
        {
            CoordinatePair AB = new CoordinatePair(1f, 2f, 3f, 4f);

            Assert.AreEqual(1f, AB.A.X, "A X coordinate is corrupted");
            Assert.AreEqual(2f, AB.A.Y, "A Y coordinate is corrupted");
            Assert.AreEqual(3f, AB.B.X, "B X coordinate is corrupted");
            Assert.AreEqual(4f, AB.B.Y, "B Y coordinate is corrupted");
            
            Coordinate C = new Coordinate(5f, 6f);
            
            CoordinatePair CD = new CoordinatePair(C, 7f, 8f);

            Assert.AreEqual(5f, CD.A.X, "C X coordinate is corrupted");
            Assert.AreEqual(6f, CD.A.Y, "C Y coordinate is corrupted");
            Assert.AreEqual(7f, CD.B.X, "D X coordinate is corrupted");
            Assert.AreEqual(8f, CD.B.Y, "D Y coordinate is corrupted");

            Coordinate E = new Coordinate(9f, 10f);
            Coordinate F = new Coordinate(11f, 12f);

            CoordinatePair EF = new CoordinatePair(E, F);

            Assert.AreEqual(9f, EF.A.X, "E X coordinate is corrupted");
            Assert.AreEqual(10f, EF.A.Y, "E Y coordinate is corrupted");
            Assert.AreEqual(11f, EF.B.X, "F X coordinate is corrupted");
            Assert.AreEqual(12f, EF.B.Y, "F Y coordinate is corrupted");

            CoordinatePair GH = new CoordinatePair(EF);

            Assert.AreEqual(9f, GH.A.X, "G X coordinate is corrupted");
            Assert.AreEqual(10f, GH.A.Y, "G Y coordinate is corrupted");
            Assert.AreEqual(11f, GH.B.X, "H X coordinate is corrupted");
            Assert.AreEqual(12f, GH.B.Y, "H Y coordinate is corrupted");
        }

        [TestMethod]
        public void Member_Tests()
        {
            CoordinatePair AB = new CoordinatePair(0f, 0f, 0f, 0f);

            AB.A.X = 11f;
            AB.A.Y = -32f;

            AB.B.X = 37f;
            AB.B.Y = 401f;

            Assert.AreEqual(11f, AB.A.X, "A X coordinate is corrupted");
            Assert.AreEqual(-32f, AB.A.Y, "A Y coordinate is corrupted");
            Assert.AreEqual(37f, AB.B.X, "B X coordinate is corrupted");
            Assert.AreEqual(401f, AB.B.Y, "B Y coordinate is corrupted");
        }

        [TestMethod]
        public void Calculation_Tests()
        {
            CoordinatePair AB, CD;
                
            AB = new CoordinatePair(11f, -32f, 37f, 401f);

            Assert.AreEqual(433.7799f, AB.Length, "AB distance has miscalculated");

            Assert.AreEqual(24f, AB.Between().X, "AB center X coordinate has been miscalculated");
            Assert.AreEqual(184.5f, AB.Between().Y, "AB center Y coordinate has been miscalculated");

            Assert.AreEqual(24f, CoordinatePair.Between(AB).X, "AB center X coordinate has been miscalculated");
            Assert.AreEqual(184.5f, CoordinatePair.Between(AB).Y, "AB center Y coordinate has been miscalculated");

            AB = new CoordinatePair(1f, 6f, 1f, 2f);
            CD = new CoordinatePair(8f, 2f, 4f, 1f);

            //Assert.Fail(Environment.NewLine +
            //    "_A_C.X:" + CoordinatePair.BetweenACxBD(AB, CD).A.X + " _A_C.Y:" + CoordinatePair.BetweenACxBD(AB, CD).A.Y + " BD.X:" + CoordinatePair.BetweenACxBD(AB, CD).B.X + " BD.Y:" + CoordinatePair.BetweenACxBD(AB, CD).B.Y + Environment.NewLine +
            //    "AX:" + CoordinatePair.BetweenShort(AB, CD).A.X + " AY:" + CoordinatePair.BetweenShort(AB, CD).A.Y + " BX:" + CoordinatePair.BetweenShort(AB, CD).B.X + " BY:" + CoordinatePair.BetweenShort(AB, CD).B.Y + Environment.NewLine +
            //    "AX:" + CoordinatePair.BetweenLong(AB, CD).A.X + " AY:" + CoordinatePair.BetweenLong(AB, CD).A.Y + " BX:" + CoordinatePair.BetweenLong(AB, CD).B.X + " BY:" + CoordinatePair.BetweenLong(AB, CD).B.Y);

            Assert.AreEqual(4.5f, CoordinatePair.BetweenACxBD(AB, CD).A.X, "AC center X coordinate has been miscalculated");
            Assert.AreEqual(4f, CoordinatePair.BetweenACxBD(AB, CD).A.Y, "AC center Y coordinate has been miscalculated");
            Assert.AreEqual(2.5f, CoordinatePair.BetweenACxBD(AB, CD).B.X, "BD center X coordinate has been miscalculated");
            Assert.AreEqual(1.5f, CoordinatePair.BetweenACxBD(AB, CD).B.Y, "BD center Y coordinate has been miscalculated");

            Assert.AreEqual(2.5f, CoordinatePair.BetweenShort(AB, CD).A.X, "AC vs AD center X coordinate has been miscalculated");
            Assert.AreEqual(3.5f, CoordinatePair.BetweenShort(AB, CD).A.Y, "AC vs AD center Y coordinate has been miscalculated");
            Assert.AreEqual(4.5f, CoordinatePair.BetweenShort(AB, CD).B.X, "BC vs BD center X coordinate has been miscalculated");
            Assert.AreEqual(2f, CoordinatePair.BetweenShort(AB, CD).B.Y, "BC vs BD center Y coordinate has been miscalculated");

            Assert.AreEqual(4.5f, CoordinatePair.BetweenLong(AB, CD).A.X, "AC vs AD center X coordinate has been miscalculated");
            Assert.AreEqual(4f, CoordinatePair.BetweenLong(AB, CD).A.Y, "AC vs AD center Y coordinate has been miscalculated");
            Assert.AreEqual(2.5f, CoordinatePair.BetweenLong(AB, CD).B.X, "BC vs BD center X coordinate has been miscalculated");
            Assert.AreEqual(1.5f, CoordinatePair.BetweenLong(AB, CD).B.Y, "BC vs BD center Y coordinate has been miscalculated");

            AB = new CoordinatePair(1f, 6f, 1f, 2f);
            CD = new CoordinatePair(4f, 1f, 8f, 2f);

            //Assert.Fail(Environment.NewLine +
            //    "_A_C.X:" + CoordinatePair.BetweenACxBD(AB, CD).A.X + " _A_C.Y:" + CoordinatePair.BetweenACxBD(AB, CD).A.Y + " BD.X:" + CoordinatePair.BetweenACxBD(AB, CD).B.X + " BD.Y:" + CoordinatePair.BetweenACxBD(AB, CD).B.Y + Environment.NewLine +
            //    "AX:" + CoordinatePair.BetweenShort(AB, CD).A.X + " AY:" + CoordinatePair.BetweenShort(AB, CD).A.Y + " BX:" + CoordinatePair.BetweenShort(AB, CD).B.X + " BY:" + CoordinatePair.BetweenShort(AB, CD).B.Y + Environment.NewLine +
            //    "AX:" + CoordinatePair.BetweenLong(AB, CD).A.X + " AY:" + CoordinatePair.BetweenLong(AB, CD).A.Y + " BX:" + CoordinatePair.BetweenLong(AB, CD).B.X + " BY:" + CoordinatePair.BetweenLong(AB, CD).B.Y);

            Assert.AreEqual(2.5f, CoordinatePair.BetweenACxBD(AB, CD).A.X, "AC center X coordinate has been miscalculated");
            Assert.AreEqual(3.5f, CoordinatePair.BetweenACxBD(AB, CD).A.Y, "AC center Y coordinate has been miscalculated");
            Assert.AreEqual(4.5f, CoordinatePair.BetweenACxBD(AB, CD).B.X, "BD center X coordinate has been miscalculated");
            Assert.AreEqual(2f, CoordinatePair.BetweenACxBD(AB, CD).B.Y, "BD center Y coordinate has been miscalculated");

            Assert.AreEqual(2.5f, CoordinatePair.BetweenShort(AB, CD).A.X, "AC vs AD center X coordinate has been miscalculated");
            Assert.AreEqual(3.5f, CoordinatePair.BetweenShort(AB, CD).A.Y, "AC vs AD center Y coordinate has been miscalculated");
            Assert.AreEqual(4.5f, CoordinatePair.BetweenShort(AB, CD).B.X, "BC vs BD center X coordinate has been miscalculated");
            Assert.AreEqual(2f, CoordinatePair.BetweenShort(AB, CD).B.Y, "BC vs BD center Y coordinate has been miscalculated");

            Assert.AreEqual(4.5f, CoordinatePair.BetweenLong(AB, CD).A.X, "AC vs AD center X coordinate has been miscalculated");
            Assert.AreEqual(4f, CoordinatePair.BetweenLong(AB, CD).A.Y, "AC vs AD center Y coordinate has been miscalculated");
            Assert.AreEqual(2.5f, CoordinatePair.BetweenLong(AB, CD).B.X, "BC vs BD center X coordinate has been miscalculated");
            Assert.AreEqual(1.5f, CoordinatePair.BetweenLong(AB, CD).B.Y, "BC vs BD center Y coordinate has been miscalculated");
        }

        [TestMethod]
        public void Comparison_Tests()
        {
            Aleatory = new Random((int)DateTime.Now.Ticks);

            CoordinatePair AB, CD;
            
            for (UInt32 i = 0; i < 10000; i++)
            {
                AB = RandomPair();

                switch (Aleatory.Next(24))
                {
                    case 0:
                        CD = RandomPair(); // Unequal
                        break;

                    case 1:
                        CD = new CoordinatePair(AB.A.X, AB.A.Y, AB.B.X, AB.B.Y); // Equal
                        break;

                    case 2:
                        CD = new CoordinatePair(RandomAxisMagnitude(), AB.A.Y, AB.B.X, AB.B.Y); // Unequal
                        break;

                    case 3:
                        CD = new CoordinatePair(AB.A.X, RandomAxisMagnitude(), AB.B.X, AB.B.Y); // Unequal
                        break;

                    case 4:
                        CD = new CoordinatePair(RandomAxisMagnitude(), RandomAxisMagnitude(), AB.B.X, AB.B.Y); // Unequal
                        break;

                    case 5:
                        CD = new CoordinatePair(AB.A.X, AB.A.Y, RandomAxisMagnitude(), AB.B.Y); // Unequal
                        break;

                    case 6:
                        CD = new CoordinatePair(RandomAxisMagnitude(), AB.A.Y, RandomAxisMagnitude(), AB.B.Y); // Unequal
                        break;

                    case 7:
                        CD = new CoordinatePair(AB.A.X, RandomAxisMagnitude(), RandomAxisMagnitude(), AB.B.Y); // Unequal
                        break;

                    case 8:
                        CD = new CoordinatePair(RandomAxisMagnitude(), RandomAxisMagnitude(), RandomAxisMagnitude(), AB.B.Y); // Unequal
                        break;

                    case 9:
                        CD = new CoordinatePair(AB.A.X, AB.A.Y, AB.B.X, RandomAxisMagnitude()); // Unequal
                        break;

                    case 10:
                        CD = new CoordinatePair(RandomAxisMagnitude(), AB.A.Y, AB.B.X, RandomAxisMagnitude()); // Unequal
                        break;

                    case 11:
                        CD = new CoordinatePair(AB.A.X, RandomAxisMagnitude(), AB.B.X, RandomAxisMagnitude()); // Unequal
                        break;

                    case 12:
                        CD = new CoordinatePair(RandomAxisMagnitude(), RandomAxisMagnitude(), AB.B.X, RandomAxisMagnitude()); // Unequal
                        break;

                    case 13:
                        CD = new CoordinatePair(AB.A.X, AB.A.Y, RandomAxisMagnitude(), RandomAxisMagnitude()); // Unequal
                        break;

                    case 14:
                        CD = new CoordinatePair(RandomAxisMagnitude(), AB.A.Y, RandomAxisMagnitude(), RandomAxisMagnitude()); // Unequal
                        break;

                    case 15:
                        CD = new CoordinatePair(AB.A.X, RandomAxisMagnitude(), RandomAxisMagnitude(), RandomAxisMagnitude()); // Unequal
                        break;

                    case 16:
                        CD = new CoordinatePair(RandomAxisMagnitude(), RandomAxisMagnitude(), RandomAxisMagnitude(), RandomAxisMagnitude()); // Unequal
                        break;

                    default:
                        CD = new CoordinatePair(AB); // Equal
                        break;
                }

                CompareCoordinatePairs(AB, CD);
            }

            AB = RandomPair();
            CD = RandomPair();

            Assert.IsFalse(AB.Equals(CD.A, CD.B), "Method Equals incorrectly believes that AB(" + AB.A.X + ", " + AB.A.Y + ", " + AB.B.X + ", " + AB.B.Y + ") is not equal to CD(" + CD.A.X + ", " + CD.A.Y + ", " + CD.B.X + ", " + CD.B.Y + ")");
            Assert.IsFalse(AB.Equals(CD.A.X, CD.A.Y, CD.B.X, CD.B.Y), "Method Equals incorrectly believes that AB(" + AB.A.X + ", " + AB.A.Y + ", " + AB.B.X + ", " + AB.B.Y + ") is not equal to CD(" + CD.A.X + ", " + CD.A.Y + ", " + CD.B.X + ", " + CD.B.Y + ")");

            Assert.IsFalse(CoordinatePair.Equals(AB, CD), "Method Equals incorrectly believes that AB(" + AB.A.X + ", " + AB.A.Y + ", " + AB.B.X + ", " + AB.B.Y + ") is not equal to CD(" + CD.A.X + ", " + CD.A.Y + ", " + CD.B.X + ", " + CD.B.Y + ")");
            Assert.IsFalse(CoordinatePair.Equals(AB, CD.A, CD.B), "Method Equals incorrectly believes that AB(" + AB.A.X + ", " + AB.A.Y + ", " + AB.B.X + ", " + AB.B.Y + ") is not equal to CD(" + CD.A.X + ", " + CD.A.Y + ", " + CD.B.X + ", " + CD.B.Y + ")");
            Assert.IsFalse(CoordinatePair.Equals(AB.A, AB.B, CD.A, CD.B), "Method Equals incorrectly believes that AB(" + AB.A.X + ", " + AB.A.Y + ", " + AB.B.X + ", " + AB.B.Y + ") is not equal to CD(" + CD.A.X + ", " + CD.A.Y + ", " + CD.B.X + ", " + CD.B.Y + ")");
            Assert.IsFalse(CoordinatePair.Equals(AB.A, AB.B, CD.A.X, CD.A.Y, CD.B.X, CD.B.Y), "Method Equals incorrectly believes that AB(" + AB.A.X + ", " + AB.A.Y + ", " + AB.B.X + ", " + AB.B.Y + ") is not equal to CD(" + CD.A.X + ", " + CD.A.Y + ", " + CD.B.X + ", " + CD.B.Y + ")");
            Assert.IsFalse(CoordinatePair.Equals(AB.A.X, AB.A.Y, AB.B.X, AB.B.Y, CD.A.X, CD.A.Y, CD.B.X, CD.B.Y), "Method Equals incorrectly believes that AB(" + AB.A.X + ", " + AB.A.Y + ", " + AB.B.X + ", " + AB.B.Y + ") is not equal to CD(" + CD.A.X + ", " + CD.A.Y + ", " + CD.B.X + ", " + CD.B.Y + ")");

            AB = RandomPair();
            CD = new CoordinatePair(AB);

            Assert.IsTrue(AB.Equals(CD.A, CD.B), "Method Equals incorrectly believes that AB(" + AB.A.X + ", " + AB.A.Y + ", " + AB.B.X + ", " + AB.B.Y + ") is not equal to CD(" + CD.A.X + ", " + CD.A.Y + ", " + CD.B.X + ", " + CD.B.Y + ")");
            Assert.IsTrue(AB.Equals(CD.A.X, CD.A.Y, CD.B.X, CD.B.Y), "Method Equals incorrectly believes that AB(" + AB.A.X + ", " + AB.A.Y + ", " + AB.B.X + ", " + AB.B.Y + ") is not equal to CD(" + CD.A.X + ", " + CD.A.Y + ", " + CD.B.X + ", " + CD.B.Y + ")");

            Assert.IsTrue(CoordinatePair.Equals(AB, CD), "Method Equals incorrectly believes that AB(" + AB.A.X + ", " + AB.A.Y + ", " + AB.B.X + ", " + AB.B.Y + ") is not equal to CD(" + CD.A.X + ", " + CD.A.Y + ", " + CD.B.X + ", " + CD.B.Y + ")");
            Assert.IsTrue(CoordinatePair.Equals(AB, CD.A, CD.B), "Method Equals incorrectly believes that AB(" + AB.A.X + ", " + AB.A.Y + ", " + AB.B.X + ", " + AB.B.Y + ") is not equal to CD(" + CD.A.X + ", " + CD.A.Y + ", " + CD.B.X + ", " + CD.B.Y + ")");
            Assert.IsTrue(CoordinatePair.Equals(AB.A, AB.B, CD.A, CD.B), "Method Equals incorrectly believes that AB(" + AB.A.X + ", " + AB.A.Y + ", " + AB.B.X + ", " + AB.B.Y + ") is not equal to CD(" + CD.A.X + ", " + CD.A.Y + ", " + CD.B.X + ", " + CD.B.Y + ")");
            Assert.IsTrue(CoordinatePair.Equals(AB.A, AB.B, CD.A.X, CD.A.Y, CD.B.X, CD.B.Y), "Method Equals incorrectly believes that AB(" + AB.A.X + ", " + AB.A.Y + ", " + AB.B.X + ", " + AB.B.Y + ") is not equal to CD(" + CD.A.X + ", " + CD.A.Y + ", " + CD.B.X + ", " + CD.B.Y + ")");
            Assert.IsTrue(CoordinatePair.Equals(AB.A.X, AB.A.Y, AB.B.X, AB.B.Y, CD.A.X, CD.A.Y, CD.B.X, CD.B.Y), "Method Equals incorrectly believes that AB(" + AB.A.X + ", " + AB.A.Y + ", " + AB.B.X + ", " + AB.B.Y + ") is not equal to CD(" + CD.A.X + ", " + CD.A.Y + ", " + CD.B.X + ", " + CD.B.Y + ")");
        }

        private void CompareCoordinatePairs(CoordinatePair AB, CoordinatePair CD)
        {
            if (AB.A.X == CD.A.X && AB.A.Y == CD.A.Y && AB.B.X == CD.B.X && AB.B.Y == CD.B.Y)
            {
                Assert.IsTrue(AB.Equals(CD), "Method Equals incorrectly believes that AB(" + AB.A.X + ", " + AB.A.Y + ", " + AB.B.X + ", " + AB.B.Y + ") is not equal to CD(" + CD.A.X + ", " + CD.A.Y + ", " + CD.B.X + ", " + CD.B.Y + ")");
            }
            else
            {
                Assert.IsFalse(AB.Equals(CD), "Method Equals incorrectly believes that AB(" + AB.A.X + ", " + AB.A.Y + ", " + AB.B.X + ", " + AB.B.Y + ") is equal to CD(" + CD.A.X + ", " + CD.A.Y + ", " + CD.B.X + ", " + CD.B.Y + ")");
            }
        }

        private CoordinatePair RandomPair()
        {
            float AX = RandomAxisMagnitude();
            float AY = RandomAxisMagnitude();
            float BX = RandomAxisMagnitude();
            float BY = RandomAxisMagnitude();

            return new CoordinatePair(AX, AY, BX, BY);
        }

        private float RandomAxisMagnitude()
        {
            if (1 == Aleatory.Next(2))
            {
                return (float) Aleatory.Next(10001) - 5000f; // Integer value
            }
            else
            {
                return (float) Aleatory.Next(10001) - 5000f + ((float) Aleatory.Next(999) / 1000f); // Integer with fractional value
            }
        }

        [TestMethod]
        public void Exception_Tests()
        {
        }
    }
}
