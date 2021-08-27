using System;

namespace Tuplemetry
{
    public class CoordinatePair
    {
        public Coordinate A { get; set; }
        public Coordinate B { get; set; }

        #region Constructor

        /// <summary>
        /// Construct a coordinate pair from a pair of X:Y values
        /// </summary>
        /// <param name="AX">The X value of the A coordinate</param>
        /// <param name="AY">The Y value of the A coordinate</param>
        /// <param name="BX">The X value of the B coordinate</param>
        /// <param name="BY">The Y value of the B coordinate</param>

        public CoordinatePair(float AX, float AY, float BX, float BY)
        {
            this.A = new Coordinate(AX, AY);
            this.B = new Coordinate(BX, BY);
        }

        /// <summary>
        /// Construct a coordinate pair from a coordinate and coordinate X:Y values
        /// </summary>
        /// <param name="A">The A coordinate</param>
        /// <param name="BX">The X value of the B coordinate</param>
        /// <param name="BY">The Y value of the B coordinate</param>

        public CoordinatePair(Coordinate A, float BX, float BY)
        {
            this.A = A;
            this.B = new Coordinate(BX, BY);
        }

        /// <summary>
        /// Construct a coordinate pair from a pair of coordinates
        /// </summary>
        /// <param name="A">The A coordinate</param>
        /// <param name="B">The B coordinate</param>

        public CoordinatePair(Coordinate A, Coordinate B)
        {
            this.A = A;
            this.B = B;
        }

        /// <summary>
        /// Construct a coordinate pair from a coordinate pair
        /// </summary>
        /// <param name="AB">The coordinate pair</param>

        public CoordinatePair(CoordinatePair AB)
        {
            this.A = AB.A;
            this.B = AB.B;
        }

        #endregion

        #region ToString

        /// <summary>
        /// Format the coordinate pair for display
        /// </summary>
        /// <returns>Hyphenated coordinate list</returns>

        public override string ToString()
        {
            return A.ToString() + "-" + B.ToString();
        }

        #endregion

        #region Equality

        /// <summary>
        /// Determine if the coordinates pair C-D is identical
        /// </summary>
        /// <param name="CX">The X value of the C coordinate</param>
        /// <param name="CY">The Y value of the C coordinate</param>
        /// <param name="DX">The X value of the D coordinate</param>
        /// <param name="DY">The Y value of the D coordinate</param>
        /// <returns>true when the coordinates pair is identical</returns>

        public bool Equals(float CX, float CY, float DX, float DY)
        {
            return Equals(A, B, new Coordinate(CX, CY), new Coordinate(DX, DY));
        }

        /// <summary>
        /// Determine if the coordinates pair C-D is identical
        /// </summary>
        /// <param name="C">The C coordinate</param>
        /// <param name="D">The D coordinate</param>
        /// <returns>true when the coordinates pair is identical</returns>

        public bool Equals(Coordinate C, Coordinate D)
        {
            return Equals(A, B, C, D);
        }

        /// <summary>
        /// Determine if the coordinates pair C-D is identical
        /// </summary>
        /// <param name="CD">The C-D coordinate pair</param>
        /// <returns>true when the coordinates pair is identical</returns>

        public bool Equals(CoordinatePair CD)
        {
            return Equals(A, B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine if the coordinates pairs A-B and C-D are identical
        /// </summary>
        /// <param name="CX">The X value of the A coordinate</param>
        /// <param name="CY">The Y value of the A coordinate</param>
        /// <param name="DX">The X value of the B coordinate</param>
        /// <param name="DY">The Y value of the B coordinate</param>
        /// <param name="CX">The X value of the C coordinate</param>
        /// <param name="CY">The Y value of the C coordinate</param>
        /// <param name="DX">The X value of the D coordinate</param>
        /// <param name="DY">The Y value of the D coordinate</param>
        /// <returns>true when the coordinates pairs are identical</returns>

        public static bool Equals(float AX, float AY, float BX, float BY, float CX, float CY, float DX, float DY)
        {
            return Equals(new Coordinate(AX, AY), new Coordinate(BX, BY), new Coordinate(CX, CY), new Coordinate(DX, DY));
        }

        /// <summary>
        /// Determine if the coordinates pairs A-B and C-D are identical
        /// </summary>
        /// <param name="A">The A coordinate</param>
        /// <param name="B">The B coordinate</param>
        /// <param name="CX">The X value of the C coordinate</param>
        /// <param name="CY">The Y value of the C coordinate</param>
        /// <param name="DX">The X value of the D coordinate</param>
        /// <param name="DY">The Y value of the D coordinate</param>
        /// <returns>true when the coordiniate pairs are identical</returns>

        public static bool Equals(Coordinate A, Coordinate B, float CX, float CY, float DX, float DY)
        {
            return Equals(A, B, new Coordinate(CX, CY), new Coordinate(DX, DY));
        }

        /// <summary>
        /// Determine if the coordinates pairs A-B and C-D are identical
        /// </summary>
        /// <param name="A">The A coordinate</param>
        /// <param name="B">The B coordinate</param>
        /// <param name="C">The C coordinate</param>
        /// <param name="D">The D coordinate</param>
        /// <returns>true when the coordinates pairs are identical</returns>

        public static bool Equals(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
            return (A == C && B == D) || (A == D && B == C);
        }

        /// <summary>
        /// Determine if the coordinates pairs A-B and C-D are identical
        /// </summary>
        /// <param name="AB"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when the coordinates pairs are identical</returns>

        public static bool Equals(CoordinatePair AB, Coordinate C, Coordinate D)
        {
            return Equals(AB.A, AB.B, C, D);
        }

        /// <summary>
        /// Determine if the coordinates pairs A-B and C-D are identical
        /// </summary>
        /// <param name="AB"></param>
        /// <param name="CD"></param>
        /// <returns>true when the coordinates pairs are identical</returns>

        public static bool Equals(CoordinatePair AB, CoordinatePair CD)
        {
            return Equals(AB.A, AB.B, CD.A, CD.B);
        }

        #endregion

        #region Length

        /// <summary>
        /// Calculate the distance between the coordinates in the pair (Pythagorean theorem)
        /// </summary>
        /// <returns>the distance between the coordinates</returns>

        public float Length
        {
            get 
            {
                return A.Distance(B);
            }
        }

        #endregion

        #region Dimensional Difference

        public float X_Length
        {
            get
            {
                return this.A.X_Delta(this.B);
            }
        }

        public float Y_Length
        {
            get
            {
                return this.A.Y_Delta(this.B);
            }
        }

        #endregion

        #region Between

        /// <summary>
        /// Calculate the position of the coordinate centered between this coordinate and coordinate B
        /// </summary>
        /// <param name="B">a coordinate position in InBounds-space</param>
        /// <returns>the coordinate position between the coordinates</returns>

        public Coordinate Between()
        {
            return this.A & this.B;
        }

        /// <summary>
        /// Calculate the position of the coordinate centered between coordinate A and coordinate B
        /// </summary>
        /// <param name="A">a coordinate position in InBounds-space</param>
        /// <param name="B">a coordinate position in InBounds-space</param>
        /// <returns>the coordinate position between the coordinates</returns>

        public static Coordinate Between(CoordinatePair AB)
        {
            return AB.A & AB.B;
        }

        /// <summary>
        /// Calculate coordinate pair built from the centers of _A_C and BD
        /// </summary>
        /// <param name="AB"></param>
        /// <param name="CD"></param>
        /// <returns>the coordinate pair between the coordinate pairs</returns>

        public static CoordinatePair BetweenACxBD(CoordinatePair AB, CoordinatePair CD)
        {
            return new CoordinatePair(AB.A & CD.A, AB.B & CD.B);
        }

        /// <summary>
        /// Calculate the closer coordinate pair centered between coordinate pair A-B and coordinate pair C-D
        /// </summary>
        /// <param name="AB"></param>
        /// <param name="CD"></param>
        /// <returns>the coordinate pair between the coordinate pairs</returns>

        public static CoordinatePair BetweenShort(CoordinatePair AB, CoordinatePair CD)
        {
            Coordinate A_C = AB.A & CD.A;
            Coordinate A_D = AB.A & CD.B;
            Coordinate B_C = AB.B & CD.A;
            Coordinate B_D = AB.B & CD.B;

            if (A_C.Distance(B_D) < A_D.Distance(B_C))
            {
                return new CoordinatePair(A_C, B_D);
            }
            else
            {
                return new CoordinatePair(A_D, B_C);
            }
        }

        /// <summary>
        /// Calculate the farther coordinate pair centered between coordinate pair A-B and coordinate pair C-D
        /// </summary>
        /// <param name="AB"></param>
        /// <param name="CD"></param>
        /// <returns>the coordinate pair between the coordinate pairs</returns>

        public static CoordinatePair BetweenLong(CoordinatePair AB, CoordinatePair CD)
        {
            Coordinate A_C = AB.A & CD.A;
            Coordinate A_D = AB.A & CD.B;
            Coordinate B_C = AB.B & CD.A;
            Coordinate B_D = AB.B & CD.B;

            if (A_C.Distance(B_D) > A_D.Distance(B_C))
            {
                return new CoordinatePair(A_C, B_D);
            }
            else
            {
                return new CoordinatePair(A_D, B_C);
            }
        }

        #endregion
    }
}
