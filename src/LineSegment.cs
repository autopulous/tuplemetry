using System;

namespace Tuplemetry
{
    public class LineSegment : CoordinatePair
    {
        #region Constructor

        /// <summary>
        /// Construct a line segment from a pair of X & Y values
        /// </summary>
        /// <param name="AX"></param>
        /// <param name="AY"></param>
        /// <param name="BX"></param>
        /// <param name="BY"></param>

        public LineSegment(float AX, float AY, float BX, float BY) : base(AX, AY, BX, BY) { }

        /// <summary>
        /// Construct a line segment from a point and an X & Y value
        /// </summary>
        /// <param name="A"></param>
        /// <param name="BX"></param>
        /// <param name="BY"></param>

        public LineSegment(Coordinate A, float BX, float BY) : base(A, BX, BY) { }

        /// <summary>
        /// Construct a line segment from a pair of points
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>

        public LineSegment(Coordinate A, Coordinate B) : base(A, B) { }

        /// <summary>
        /// Construct a line segment from a line segment
        /// </summary>
        /// <param name="AB"></param>

        public LineSegment(Line AB) : base(AB) { }

        #endregion

        #region Inequality

        /// <summary>
        /// Determine line segment inequality
        /// </summary>
        /// <param name="AB"></param>
        /// <param name="CD"></param>
        /// <returns>true when the line segments are not equivalent</returns>

        public static bool operator !=(LineSegment AB, LineSegment CD)
        {
            return !(AB == CD);
        }

        /// <summary>
        /// Determine line segment inequality
        /// </summary>
        /// <param name="AB"></param>
        /// <param name="CD"></param>
        /// <returns>true when the line segments are not equivalent</returns>

        public static bool operator !=(LineSegment AB, Coordinate C)
        {
            return !(AB == C);
        }

        #endregion

        #region GetHashCode

        /// <summary>
        /// Hash the dimension member values
        /// </summary>
        /// <returns>a (cheap and stupid) hash code</returns>

        public override int GetHashCode()
        {
            return (int)(A.X + A.Y * 100f + B.X * 10000f + B.Y * 1000000f);
        }

        #endregion

        #region Equality

        /// <summary>
        /// Determine line segment equality
        /// </summary>
        /// <param name="AB"></param>
        /// <param name="CD"></param>
        /// <returns>true when the line segments are equivalent</returns>

        public static bool operator ==(LineSegment AB, LineSegment CD)
        {
            // Object typecast required to prevent recursive evaluation of the == operation on the Coordinates

            if (null == (Object)AB)
            {
                return null == (Object)CD;
            }
            else
            {
                if (null == (Object)CD) return false;
            }

            return (AB.A == CD.A && AB.B == CD.B) || (AB.A == CD.B && AB.B == CD.A);
        }

        /// <summary>
        /// Determine line segment equality
        /// </summary>
        /// <param name="AB"></param>
        /// <param name="CD"></param>
        /// <returns>true when the line segments are equivalent</returns>

        public static bool operator ==(LineSegment AB, Coordinate C)
        {
            // Object typecast required to prevent recursive evaluation of the == operation on the Coordinates

            if (null == (Object)AB)
            {
                return null == (Object)C;
            }
            else
            {
                if (null == (Object)C) return false;
            }

            return AB.A == C && AB.B == C;
        }

        /// <summary>
        /// Determine line segment equality
        /// </summary>
        /// <param name="A"></param>
        /// <param name="O">object that will be typecast as a Coordinate object</param>
        /// <returns>true when the coordinates represent the same location</returns>

        public override bool Equals(object O)
        {
            return this == (LineSegment)O;
        }

        /// <summary>
        /// Determine if the line segments are identical
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when all points within C-D are within A-B and all points within A-B are within C-D</returns>

        // Inherited from CoordinatePair - does not need to be implemented / overridden

        // public static bool Equals(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        // { }

        #endregion

        #region Congruent

        /// <summary>
        /// Determine if the line segments have the same length
        /// </summary>
        /// <param name="CD"></param>
        /// <returns>true when the length of A-B and C-D are equal</returns>

        public bool Congruent(LineSegment CD)
        {
            return Congruent(this.A, this.B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine if the line segments have the same length
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when the length of A-B and C-D are equal</returns>

        public static bool Congruent(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
            return A.Distance(B) == C.Distance(D);
        }

        #endregion

        #region Collinear

        /// <summary>
        /// Determine if the line segments fall on a common line
        /// </summary>
        /// <param name="CD"></param>
        /// <returns>true when C-D is aligned with A-B</returns>

        public bool Collinear(LineSegment CD)
        {
            return Collinear(A, B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine if the line segments fall on a common line
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when C-D is aligned with A-B</returns>

        public static bool Collinear(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
            float AB_X = A.X - B.X;
            float AB_Y = A.Y - B.Y;
            float AC_X = A.X - C.X;
            float AC_Y = A.Y - C.Y;
            float AD_X = A.X - D.X;
            float AD_Y = A.Y - D.Y;

            // A-B parallel to A-C and A-B parallel to A-D

            return AB_X * AC_Y == AC_X * AB_Y && AB_X * AD_Y == AD_X * AB_Y;
        }

        #endregion

        #region Contains

        /// <summary>
        /// Determine if line segment C-D is completely within line segment A-B
        /// </summary>
        /// <param name="CD"></param>
        /// <returns>true when all points of C-D fall within A-B</returns>

        public bool Contains(LineSegment CD)
        {
            return Contains(A, B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine if line segment C-D is completely within line segment A-B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when all points of C-D fall within A-B</returns>

        public static bool Contains(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
            if (!Collinear(A, B, C, D)) return false;

            // Both endpoints of C-D must fall between A-B

            return
            (
                ((A.X <= C.X && C.X <= B.X) && (A.X <= D.X && D.X <= B.X)) || ((B.X <= C.X && C.X <= A.X) && (B.X <= D.X && D.X <= A.X))
            )
            &&
            (
                ((A.Y <= C.Y && C.Y <= B.Y) && (A.Y <= D.Y && D.Y <= B.Y)) || ((B.Y <= C.Y && C.Y <= A.Y) && (B.Y <= D.Y && D.Y <= A.Y))
            );
        }

        #endregion

        #region Overlaps

        /// <summary>
        /// Determine if the line segment C-D at least partially overlaps line segment A-B
        /// </summary>
        /// <param name="CD"></param>
        /// <returns>true when at least one point of C-D falls within A-B</returns>

        public bool Overlaps(LineSegment CD)
        {
            return Overlaps(A, B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine if the line segment C-D at least partially overlaps line segment A-B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when at least one point of C-D falls within A-B</returns>

        public static bool Overlaps(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
            if (!Collinear(A, B, C, D)) return false;

            // An endpoint of C-D must fall between A-B

            return
            (
                ((A.X <= C.X && C.X <= B.X) || (A.X >= C.X && C.X >= B.X)) && ((A.Y <= C.Y && C.Y <= B.Y) || (A.Y >= C.Y && C.Y >= B.Y))
            )
            ||
            (
                ((A.X <= D.X && D.X <= B.X) || (A.X >= D.X && D.X >= B.X)) && ((A.Y <= D.Y && D.Y <= B.Y) || (A.Y >= D.Y && D.Y >= B.Y))
            );
        }

        #endregion

        #region Intersects

        /// <summary>
        /// Determine if a point falls on a line segment
        /// </summary>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when the point falls on the line</returns>

        public bool Intersects(Coordinate C)
        {
            return Intersects(A, B, C, C);
        }

        /// <summary>
        /// Determine if the line segments intersect
        /// </summary>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when the line segments are determined to intersect</returns>

        public bool Intersects(Coordinate C, Coordinate D)
        {
            return Intersects(A, B, C, D);
        }

        /// <summary>
        /// Determine if the line segments intersect
        /// </summary>
        /// <param name="CD"></param>
        /// <returns>true when the line segments are determined to intersect</returns>

        public bool Intersects(LineSegment CD)
        {
            return Intersects(A, B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine if the line segments intersect
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when at least one point within C-D is within A-B</returns>

        public static bool Intersects(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
            // calculate dimensional magnitudes

            float AB_X = A.X - B.X;
            float AB_Y = A.Y - B.Y;
            float AC_X = A.X - C.X;
            float AC_Y = A.Y - C.Y;
            float CD_X = C.X - D.X;
            float CD_Y = C.Y - D.Y;

            // calculate intersection coefficients

            float O = AB_X * CD_Y - AB_Y * CD_X;
            float P = AC_X * CD_Y - AC_Y * CD_X;
            float Q = AC_X * AB_Y - AC_Y * AB_X;

            if (0 == O)
            {
                // when O, P and Q equal zero, the line segments (lines) are collinear

                if (0 == P && 0 == Q)
                {
                    // when the C or D falls between A and B or A or B falls between C and D the line segments overlap (and therefore intersect)




                    // 114% 48 seconds for 2,000,000 iterations of the intersects unit test (brute force)

                    //return
                    //(   // detect when A falls between C and D
                    //    ((C.X <= A.X && A.X <= D.X) || (C.X >= A.X && A.X >= D.X))
                    //    &&
                    //    ((C.Y <= A.Y && A.Y <= D.Y) || (C.Y >= A.Y && A.Y >= D.Y))
                    //)
                    //||
                    //(   // detect when B falls between C and D
                    //    ((C.X <= B.X && B.X <= D.X) || (C.X >= B.X && B.X >= D.X))
                    //    &&
                    //    ((C.Y <= B.Y && B.Y <= D.Y) || (C.Y >= B.Y && B.Y >= D.Y))
                    //)
                    //||
                    //(   // detect when C falls between A and B
                    //    ((A.X <= C.X && C.X <= B.X) || (A.X >= C.X && C.X >= B.X))
                    //    &&
                    //    ((A.Y <= C.Y && C.Y <= B.Y) || (A.Y >= C.Y && C.Y >= B.Y))
                    //)
                    //||
                    //(   // detect when D falls between A and B
                    //    ((A.X <= D.X && D.X <= B.X) || (A.X >= D.X && D.X >= B.X))
                    //    &&
                    //    ((A.Y <= D.Y && D.Y <= B.Y) || (A.Y >= D.Y && D.Y >= B.Y))
                    //);




                    // 100% 42 seconds for 2,000,000 iterations of the intersects unit test

                    // detect the longer line segment then
                    // detect if either endpoint of the shorter line segment falls between its endpoints

                    //if (AB_X * AB_X < CD_X * CD_X || AB_Y * AB_Y < DC_Y * DC_Y) // absolute relative value
                    //{
                    //    return
                    //    (   // detect when A falls between C and D
                    //        ((C.X <= A.X && A.X <= D.X) || (C.X >= A.X && A.X >= D.X))
                    //        &&
                    //        ((C.Y <= A.Y && A.Y <= D.Y) || (C.Y >= A.Y && A.Y >= D.Y))
                    //    )
                    //    ||
                    //    (   // detect when B falls between C and D
                    //        ((C.X <= B.X && B.X <= D.X) || (C.X >= B.X && B.X >= D.X))
                    //        &&
                    //        ((C.Y <= B.Y && B.Y <= D.Y) || (C.Y >= B.Y && B.Y >= D.Y))
                    //    );
                    //}
                    //else
                    //{
                    //    return
                    //    (   // detect when C falls between A and B
                    //        ((A.X <= C.X && C.X <= B.X) || (A.X >= C.X && C.X >= B.X))
                    //        &&
                    //        ((A.Y <= C.Y && C.Y <= B.Y) || (A.Y >= C.Y && C.Y >= B.Y))
                    //    )
                    //    ||
                    //    (   // detect when D falls between A and B
                    //        ((A.X <= D.X && D.X <= B.X) || (A.X >= D.X && D.X >= B.X))
                    //        &&
                    //        ((A.Y <= D.Y && D.Y <= B.Y) || (A.Y >= D.Y && D.Y >= B.Y))
                    //    );
                    //}




                    // 100% 42 seconds for 2,000,000 iterations of the intersects unit test

                    // detect the longer line segment then
                    // detect if either endpoint of the shorter line segment falls between its endpoints

                    //float AD_X = A.X_Delta(D);
                    //float AD_Y = A.Y_Delta(D);
                    //float BC_X = B.X_Delta(C);
                    //float BC_Y = B.Y_Delta(C);
                    //float BD_X = B.X_Delta(D);
                    //float BD_Y = B.Y_Delta(D);

                    //float A__B = AB_X * AB_X + AB_Y * AB_Y;
                    //float A__C = AC_X * AC_X + AC_Y * AC_Y;
                    //float A__D = AD_X * AD_X + AD_Y * AD_Y;
                    //float B__C = BC_X * BC_X + BC_Y * BC_Y;
                    //float B__D = BD_X * BD_X + BD_Y * BD_Y;
                    //float C__D = CD_X * CD_X + DC_Y * DC_Y;

                    //return
                    //(   // detect when A falls between C and D
                    //    C__D >= A__C + A__D
                    //)
                    //||
                    //(   // detect when B falls between C and D
                    //    C__D >= B__C + B__D
                    //)
                    //||
                    //(   // detect when C falls between A and B
                    //    A__B >= A__C + B__C
                    //)
                    //||
                    //(   // detect when D falls between A and B
                    //    A__B >= A__D + B__D
                    //);




                    // 93% 39 seconds for 2,000,000 iterations of the intersects unit test

                    // detect the longer line segment then
                    // detect if either endpoint of the shorter line segment falls between its endpoints

                    //float AD_X = A.X_Delta(D);
                    //float AD_Y = A.Y_Delta(D);

                    //float A__C = AC_X * AC_X + AC_Y * AC_Y;
                    //float A__D = AD_X * AD_X + AD_Y * AD_Y;
                    //float C__D = CD_X * CD_X + DC_Y * DC_Y;

                    //// detect when A falls between C and D

                    //if (C__D >= A__C + A__D) return true;

                    //float BC_X = B.X_Delta(C);
                    //float BC_Y = B.Y_Delta(C);
                    //float BD_X = B.X_Delta(D);
                    //float BD_Y = B.Y_Delta(D);

                    //float B__C = BC_X * BC_X + BC_Y * BC_Y;
                    //float B__D = BD_X * BD_X + BD_Y * BD_Y;

                    //// detect when B falls between C and D

                    //if (C__D >= B__C + B__D) return true;

                    //float A__B = AB_X * AB_X + AB_Y * AB_Y;

                    //// detect when C falls between A and B

                    //if (A__B >= A__C + B__C) return true;

                    //// detect when D falls between A and B

                    //if (A__B >= A__D + B__D) return true;

                    //return false;




                    // 86% 34 seconds for 2,000,000 iterations of the intersects unit test

                    // detect the longer line segment then
                    // detect if either endpoint of the shorter line segment falls between its endpoints

                    // calculate dimensional magnitudes

                    float AD_X = A.X - D.X;
                    float AD_Y = A.Y - D.Y;

                    // calculate pseudo-distances (square root is unnecessary to determined distance magnitude relationships)

                    float A__C = AC_X * AC_X + AC_Y * AC_Y;
                    float A__D = AD_X * AD_X + AD_Y * AD_Y;
                    float C__D = CD_X * CD_X + CD_Y * CD_Y;

                    // detect when A falls between C and D

                    if (C__D >= A__C + A__D) return true;

                    // calculate dimensional magnitudes

                    float BC_X = B.X - C.X;
                    float BC_Y = B.Y - C.Y;
                    float BD_X = B.X - D.X;
                    float BD_Y = B.Y - D.Y;

                    // calculate pseudo-distances (square root is unnecessary to determined distance magnitude relationships)

                    float B__C = BC_X * BC_X + BC_Y * BC_Y;
                    float B__D = BD_X * BD_X + BD_Y * BD_Y;

                    // detect when B falls between C and D

                    if (C__D >= B__C + B__D) return true;

                    float A__B = AB_X * AB_X + AB_Y * AB_Y;

                    // detect when C falls between A and B

                    if (A__B >= A__C + B__C) return true;

                    // detect when D falls between A and B

                    if (A__B >= A__D + B__D) return true;




                    // 107% 45 seconds for 2,000,000 iterations of the intersects unit test

                    //return
                    //(   // detect when A falls between C and D
                    //    (C.X <= A.X ? D.X >= A.X : A.X >= D.X)
                    //    &&
                    //    (C.Y <= A.Y ? D.Y >= A.Y : A.Y >= D.Y)
                    //)
                    //||
                    //(   // detect when B falls between C and D
                    //    (C.X <= B.X ? D.X >= B.X : B.X >= D.X)
                    //    &&
                    //    (C.Y <= B.Y ? D.Y >= B.Y : B.Y >= D.Y)
                    //)
                    //||
                    //(   // detect when C falls between A and B
                    //    (A.X <= C.X ? B.X >= C.X : C.X >= B.X)
                    //    &&
                    //    (A.Y <= C.Y ? B.Y >= C.Y : C.Y >= B.Y)
                    //)
                    //||
                    //(   // detect when D falls between A and B
                    //    (A.X <= D.X ? B.X >= D.X : D.X >= B.X)
                    //    &&
                    //    (A.Y <= D.Y ? B.Y >= D.Y : D.Y >= B.Y)
                    //);




                    // 107% 45 seconds for 2,000,000 iterations of the intersects unit test

                    //// detect when A falls between C and D
                    //if ((C.X <= A.X ? A.X <= D.X : A.X >= D.X) && (C.Y <= A.Y ? D.Y >= A.Y : A.Y >= D.Y)) return true;

                    //// detect when B falls between C and D
                    //if ((C.X <= B.X ? B.X <= D.X : B.X >= D.X) && (C.Y <= B.Y ? D.Y >= B.Y : B.Y >= D.Y)) return true;

                    //// detect when C falls between A and B
                    //if ((A.X <= C.X ? C.X <= B.X : C.X >= B.X) && (A.Y <= C.Y ? B.Y >= C.Y : C.Y >= B.Y)) return true;

                    //// detect when D falls between A and B
                    //if ((A.X <= D.X ? D.X <= B.X : D.X >= B.X) && (A.Y <= D.Y ? B.Y >= D.Y : D.Y >= B.Y)) return true;





                    // 105% 44 seconds for 2,000,000 iterations of the intersects unit test

                    //return
                    //(   // detect when A falls between C and D
                    //    ((0 <= C.X - A.X) != (0 < D.X - A.X))
                    //    &&
                    //    ((0 <= C.Y - A.Y) != (0 < D.Y - A.Y))
                    //)
                    //||
                    //(   // detect when B falls between C and D
                    //    ((0 <= C.X - B.X) != (0 < D.X - B.X))
                    //    &&
                    //    ((0 <= C.Y - B.Y) != (0 < D.Y - B.Y))
                    //)
                    //||
                    //(   // detect when C falls between A and B
                    //    ((0 <= A.X - C.X) != (0 < B.X - C.X))
                    //    &&
                    //    ((0 <= A.Y - C.Y) != (0 < B.Y - C.Y))
                    //)
                    //||
                    //(   // detect when D falls between A and B
                    //    ((0 <= A.X - D.X) != (0 < B.X - D.X))
                    //    &&
                    //    ((0 <= A.Y - D.Y) != (0 < B.Y - D.Y))
                    //);




                    // 105% 44 seconds for 2,000,000 iterations of the intersects unit test

                    //// detect when A falls between C and D
                    //if ((0 <= C.X - A.X) != (0 < D.X - A.X) && (0 <= C.Y - A.Y) != (0 < D.Y - A.Y)) return true;

                    //// detect when B falls between D and C
                    //if ((0 <= C.X - B.X) != (0 < D.X - B.X) && (0 <= C.Y - B.Y) != (0 < D.Y - B.Y)) return true;

                    //// detect when C falls between A and B
                    //if ((0 <= A.X - C.X) != (0 < B.X - C.X) && (0 <= A.Y - C.Y) != (0 < B.Y - C.Y)) return true;

                    //// detect when D falls between B and A
                    //if ((0 <= A.X - D.X) != (0 < B.X - D.X) && (0 <= A.Y - D.Y) != (0 < B.Y - D.Y)) return true;
                }

                // when just O equals zero, the line segments (lines) are parallel and not collinear (and therefore do not intersect)

                return false;
            }

            // determine if the line intersection is between the endpoints of both line segments

            P /= O;

            if (0 > P || P > 1) return false; 

            Q /= O;

            return (0 <= Q && Q <= 1);
        }

        #endregion

        #region Intersection

        /// <summary>
        /// Determine the intersection point of the line segments
        /// </summary>
        /// <param name="C">C-D end point</param>
        /// <param name="D">C-D end point</param>
        /// <returns>intersection point or null when the lines are parallel</returns>

        public LineSegment Intersection(Coordinate C, Coordinate D)
        {
            return Intersection(A, B, C, D);
        }

        /// <summary>
        /// Determine the intersection point of the line segments
        /// </summary>
        /// <param name="CD"></param>
        /// <returns>intersection point or null when the lines are parallel</returns>

        public LineSegment Intersection(LineSegment CD)
        {
            return Intersection(A, B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine the intersection point of the line segments
        /// </summary>
        /// <param name="AB">A-B</param>
        /// <param name="CD">C-D</param>
        /// <returns>intersection point or null when the lines are parallel</returns>

        public static LineSegment Intersection(LineSegment AB, LineSegment CD)
        {
            return Intersection(AB.A, AB.B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine the intersection of two line segments
        /// </summary>
        /// <param name="A">A-B end point</param>
        /// <param name="B">A-B end point</param>
        /// <param name="C">C-D end point</param>
        /// <param name="D">C-D end point</param>
        /// <returns> a line segment (or point) when the line segments intersect or null when the line segments are disjoint</returns>

        public static LineSegment Intersection(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
            // http://www.dcs.gla.ac.uk/~pat/52233/slides/Geometry1x1.pdf
            // http://www.geeksforgeeks.org/check-if-two-given-line-segments-intersect/
            // http://www-cs.ccny.cuny.edu/~wolberg/capstone/intersection/Intersection%20point%20of%20two%20lines.html

            float AX = A.Tuplet[0];
            float AY = A.Tuplet[1];
            float BX = B.Tuplet[0];
            float BY = B.Tuplet[1];
            float CX = C.Tuplet[0];
            float CY = C.Tuplet[1];
            float DX = D.Tuplet[0];
            float DY = D.Tuplet[1];

            float AB_X = AX - BX;
            float AB_Y = AY - BY;
            float AC_X = AX - CX;
            float AC_Y = AY - CY;
            float CD_X = CX - DX;
            float CD_Y = CY - DY;

            float O = AB_X * CD_Y - AB_Y * CD_X;

            // when O equlas zero, the line segements (lines) are parallel

            if (0 == O)
            {
                float P = AC_X * CD_Y - AC_Y * CD_X;
                float Q = AC_X * AB_Y - AC_Y * AB_X;

                // when O, P and Q equal zero, the line segments (lines) are collinear

                if (0 == P && 0 == Q)
                {
                    // logical determination of the collinear intersection (59 secs for 600,000 iterations)

                    //bool _A_C = (A.X == C.X && A.Y == C.Y);
                    //bool A_CD = (((C.X <= A.X && A.X <= D.X) || (C.X >= A.X && A.X >= D.X)) && ((C.Y < A.Y && A.Y < D.Y) || (C.Y > A.Y && A.Y > D.Y))) || (((C.X < A.X && A.X < D.X) || (C.X > A.X && A.X > D.X)) && ((C.Y <= A.Y && A.Y <= D.Y) || (C.Y >= A.Y && A.Y >= D.Y)));
                    //bool _A_D = (A.X == D.X && A.Y == D.Y);

                    //bool _B_C = (B.X == C.X && B.Y == C.Y);
                    //bool B_CD = (((C.X <= B.X && B.X <= D.X) || (C.X >= B.X && B.X >= D.X)) && ((C.Y < B.Y && B.Y < D.Y) || (C.Y > B.Y && B.Y > D.Y))) || (((C.X < B.X && B.X < D.X) || (C.X > B.X && B.X > D.X)) && ((C.Y <= B.Y && B.Y <= D.Y) || (C.Y >= B.Y && B.Y >= D.Y)));
                    //bool _B_D = (B.X == D.X && B.Y == D.Y);

                    //bool C_AB = (((A.X <= C.X && C.X <= B.X) || (A.X >= C.X && C.X >= B.X)) && ((A.Y < C.Y && C.Y < B.Y) || (A.Y > C.Y && C.Y > B.Y))) || (((A.X < C.X && C.X < B.X) || (A.X > C.X && C.X > B.X)) && ((A.Y <= C.Y && C.Y <= B.Y) || (A.Y >= C.Y && C.Y >= B.Y)));
                    //bool D_AB = (((A.X <= D.X && D.X <= B.X) || (A.X >= D.X && D.X >= B.X)) && ((A.Y < D.Y && D.Y < B.Y) || (A.Y > D.Y && D.Y > B.Y))) || (((A.X < D.X && D.X < B.X) || (A.X > D.X && D.X > B.X)) && ((A.Y <= D.Y && D.Y <= B.Y) || (A.Y >= D.Y && D.Y >= B.Y)));

                    // mathematical determination of the collinear intersection (40 secs for 600,000 iterations)

                    float AD_X = AX - DX;
                    float AD_Y = AY - DY;
                    float BC_X = BX - CX;
                    float BC_Y = BY - CY;
                    float BD_X = BX - DX;
                    float BD_Y = BY - DY;

                    // calculate pseudo-distances (square root is unnecessary to determined distance magnitude relationships)

                    float A__B = AB_X * AB_X + AB_Y * AB_Y;
                    float A__C = AC_X * AC_X + AC_Y * AC_Y;
                    float A__D = AD_X * AD_X + AD_Y * AD_Y;
                    float B__C = BC_X * BC_X + BC_Y * BC_Y;
                    float B__D = BD_X * BD_X + BD_Y * BD_Y;
                    float C__D = CD_X * CD_X + CD_Y * CD_Y;

                    // common endpoint detection

                    //bool _A_C = 0 == A__C;
                    //bool _A_D = 0 == A__D;
                    //bool _B_C = 0 == B__C;
                    //bool _B_D = 0 == B__D;

                    // inspecific shared endpoint detection (off topic example code)

                    //bool _A_CD = C__D == A__C + A__D; // A is an endpoint of C-D
                    //bool _B_CD = C__D == B__C + B__D; // B is an endpoint of C-D
                    //bool _C_AB = A__B == A__C + B__C; // C is an endpoint of A-B
                    //bool _D_AB = A__B == A__D + B__D; // D is an endpoint of A-B

                    // between detection

                    //bool A_CD = C__D > A__C + A__D; // A is between C and D
                    //bool B_CD = C__D > B__C + B__D; // B is between C and D
                    //bool C_AB = A__B > A__C + B__C; // C is between A and B
                    //bool D_AB = A__B > A__D + B__D; // D is between A and B

                    bool A_CD = C__D >= A__C + A__D; // A is between C and D or equal to C or D
                    bool B_CD = C__D >= B__C + B__D; // B is between C and D or equal to C or D
                    bool C_AB = A__B > A__C + B__C; // C is between A and B
                    bool D_AB = A__B > A__D + B__D; // D is between A and B

                    // determine the intersecting line segment

                    if (A_CD)
                    {
                        if (B_CD)
                        {
                            return new LineSegment(A, B);
                        }

                        if (C_AB)
                        {
                            return new LineSegment(A, C);
                        }

                        if (D_AB)
                        {
                            return new LineSegment(A, D);
                        }

                        return new LineSegment(A, A);
                    }

                    if (B_CD)
                    {
                        if (C_AB)
                        {
                            return new LineSegment(B, C);
                        }

                        if (D_AB)
                        {
                            return new LineSegment(B, D);
                        }

                        return new LineSegment(B, B);
                    }

                    if (C_AB && D_AB)
                    {
                        return new LineSegment(C, D);
                    }

                    // collinear outsection

                    return null;
                }

                // the line segments (lines) are parallel and not collinear (and therefore do not intersect)

                return null;
            }

            // Point intersection

            // float R = ((DC_X * AC_Y) - (DC_Y * AC_X)) / O;
            // float R = ((-CD_X * AC_Y) - (-DC_Y * AC_X)) / O;

            float M = ((CD_Y * AC_X) - (CD_X * AC_Y)) / O;

            if (0 > M || M > 1) return null; // the lines intersect but the line segments do not

            // float N = ((BA_X * AC_Y) - (BA_Y * AC_X)) / O;
            // float N = ((-AB_X * AC_Y) - (-AB_Y * AC_X)) / O;

            float N = ((AB_Y * AC_X) - (AB_X * AC_Y)) / O;

            if (0 > N || N > 1) return null; // the lines intersect but the line segments do not

            // Coordinate E = new Coordinate(A.X + (R * BA_X), A.Y + (R * BA_Y));
            // Coordinate E = new Coordinate(A.X + (R * -AB_X), A.Y + (R * -AB_Y));

            Coordinate E = new Coordinate(AX - (M * AB_X), AY - (M * AB_Y));

            return new LineSegment(E, E);
        }

        #endregion

        #region Crosses

        /// <summary>
        /// Determine if the line segments cross at a point
        /// </summary>
        /// <param name="CD"></param>
        /// <returns>true when C-D intersects A-B and C and D do not fall on A-B</returns>

        public bool Crosses(LineSegment CD)
        {
            return Crosses(A, B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine if the line segments cross at a point
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when C-D intersects A-B and C and D are not points that fall on A-B</returns>

        public static bool Crosses(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
            if (Collinear(A, B, C, D)) return false;

            if (!Intersects(A, B, C, D)) return false;

            return !Touches(A, B, C) && !Touches(A, B, D);
        }

        #endregion

        #region Perpendicular

        /// <summary>
        /// Determine if the line segments are perpendicular to each other
        /// </summary>
        /// <param name="CD"></param>
        /// <returns>true when the slope of A-B and C-D are at right angles</returns>

        public bool Perpendicular(LineSegment CD)
        {
            return Perpendicular(A, B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine if the line segments are perpendicular to each other
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when the slope of A-B and C-D are at right angles</returns>

        public static bool Perpendicular(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
            float AB_X = A.X - B.X;
            float AB_Y = A.Y - B.Y;
            float CD_X = C.X - D.X;
            float CD_Y = C.Y - D.Y;

            // Point check (points lack perpendicularity)

            if ((0 == AB_X && 0 == AB_Y) || (0 == CD_X && 0 == CD_Y)) return false;

            // Horizontal perpendicularity check

            if (0 == AB_X) return 0 == CD_Y;

            // Vertical perpendicularity check

            if (0 == AB_Y) return 0 == CD_X;

            // General perpendicularity

            return AB_X * CD_X == -AB_Y * CD_Y;
        }

        #endregion

        #region Branches

        /// <summary>
        /// Determine if the line segments fork
        /// </summary>
        /// <param name="CD"></param>
        /// <returns>true when the intersection with C-D forms four angles</returns>

        public bool Branches(LineSegment CD)
        {
            return Branches(this.A, this.B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine if the line segment branches
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when only C or D falls on a non-endpoint of A-B</returns>

        public static bool Branches(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
            if (Collinear(A, B, C, D)) return false;

            if (!Touches(A, B, C, D)) return false;

            return (A != C) && (A != D) && (B != C) && (B != D);
        }

        #endregion

        #region Touches

        /// <summary>
        /// Determine if the coordinate falls within the line segment
        /// </summary>
        /// <param name="C"></param>
        /// <returns>true when point C falls within the line segment</returns>

        public bool Touches(Coordinate C)
        {
            return Touches(A, B, C);
        }

        /// <summary>
        /// Determine if the line segment is intersected at an endpoint of C-D (extends or bends or branches)
        /// </summary>
        /// <param name="CD"></param>
        /// <returns>true when just an endpoint of C-D falls within A-B</returns>

        public bool Touches(LineSegment CD)
        {
            return Touches(A, B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine if the A-B is intersected at an endpoint of C-D (extends or bends or branches)
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when just an endpoint of C-D falls within A-B</returns>

        public static bool Touches(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
            return Touches(A, B, C) || Touches(A, B, D);
        }

        /// <summary>
        /// Determine if point C falls within the line segment
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <returns>true when C falls within the line segment</returns>

        public static bool Touches(Coordinate A, Coordinate B, Coordinate C)
        {
            if (((A.X > C.X || C.X > B.X) && (A.X < C.X || C.X < B.X)) || ((A.Y > C.Y || C.Y > B.Y) && (A.Y < C.Y || C.Y < B.Y))) return false;

            if (A.X == B.X) return A.X == C.X;
            if (A.Y == B.Y) return A.Y == C.Y;

            // Source formula
            // http://stackoverflow.com/a/25689069 (MetaMapper answer)

            // double x = pt1.X + (pt.Y - pt1.Y) * (pt2.X - pt1.X) / (pt2.Y - pt1.Y);
            // double y = pt1.Y + (pt.X - pt1.X) * (pt2.Y - pt1.Y) / (pt2.X - pt1.X);
            // return Math.Abs(pt.X - x) < epsilon || Math.Abs(pt.Y - y) < epsilon;

            // Refactor epsilon subtraction to an equality test

            //if (pt.X == pt1.X + (pt.Y - pt1.Y) * (pt2.X - pt1.X) / (pt2.Y - pt1.Y)) return true;
            //if (pt.Y == pt1.Y + (pt.X - pt1.X) * (pt2.Y - pt1.Y) / (pt2.X - pt1.X)) return true;

            // Refactor to remove division (step one: subtract from both sides)

            //if (pt.X - pt1.X == (pt.Y - pt1.Y) * (pt2.X - pt1.X) / (pt2.Y - pt1.Y)) return true;
            //if (pt.Y - pt1.Y == (pt.X - pt1.X) * (pt2.Y - pt1.Y) / (pt2.X - pt1.X)) return true;

            // Refactor to remove division (step two: multiply both sides)

            //if ((pt.X - pt1.X) * (pt2.Y - pt1.Y) == (pt.Y - pt1.Y) * (pt2.X - pt1.X)) return true;
            //if ((pt.Y - pt1.Y) * (pt2.X - pt1.X) == (pt.X - pt1.X) * (pt2.Y - pt1.Y)) return true;

            // Refactor into local variables

            //if ((C.X - A.X) * (B.Y - A.Y) == (C.Y - A.Y) * (B.X - A.X)) return true;
            //if ((C.Y - A.Y) * (B.X - A.X) == (C.X - A.X) * (B.Y - A.Y)) return true;

            // Refactor X and Y differences

            //float AB_X = A.X_Delta(B);
            //float AB_Y = A.Y_Delta(B);

            //float AC_X = A.X_Delta(C);
            //float AC_Y = A.Y_Delta(C);

            // Refactor equations

            //if (AC_X * AB_Y == AC_Y * AB_X) return true;
            //if (AC_Y * AB_X == AC_X * AB_Y) return true; // redundant

            // refactor if tests into a return (eliminating redundancy)

            // return AC_X * AB_Y == AB_X * AC_Y;

            // refactor X and Y calculation order (purely esthetic)

            // return AB_X * AC_Y == AC_X * AB_Y;

            // refactor the variable assignments

            //return A.X_Delta(B) * A.Y_Delta(C) == A.X_Delta(C) * A.Y_Delta(B);

            // refactor the function calls

            //return (A.X - B.X) * (A.Y - C.Y) == (A.X - C.X) * (A.Y - B.Y);

            // refactor the member accessors

            return (A.Tuplet[0] - B.Tuplet[0]) * (A.Tuplet[1] - C.Tuplet[1]) == (A.Tuplet[0] - C.Tuplet[0]) * (A.Tuplet[1] - B.Tuplet[1]);
        }

        #endregion

        #region Extends

        /// <summary>
        /// Determine if the line segments constitute a composite line segment
        /// </summary>
        /// <param name="CD"></param>
        /// <returns>true when C-D extends the line segment without overlapping</returns>

        public bool Extends(LineSegment CD)
        {
            return Extends(this.A, this.B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine if the line segments are parts of a longer line segment
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when C-D extends A-B without overlapping</returns>

        public static bool Extends(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
            if (C.X == D.X && C.Y == D.Y) return false; // C-D is a point

            if (!Collinear(A, B, C, D)) return false; // not straight

            if (A.X > B.X || A.Y > B.Y)
            {
                Coordinate Swap = A; A = B; B = Swap;
            }

            if (C.X > D.X || C.Y > D.Y)
            {
                Coordinate Swap = C; C = D; D = Swap;
            }

            return (A == D) || (B == C);
        }

        #endregion

        #region Bends

        /// <summary>
        /// Determine if the line segments form a corner or simple vertex
        /// </summary>
        /// <param name="CD"></param>
        /// <returns>true when the intersection with C-D forms two angles</returns>

        public bool Bends(LineSegment CD)
        {
            return Bends(A, B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine if the line segments intersect at a mutual end point forming an angle
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when an end point of A-B is an endpoint of C-D</returns>

        public static bool Bends(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
            if (C.X == D.X && C.Y == D.Y) return false; // C-D is a point

            if (Collinear(A, B, C, D)) return false; // not bent

            return (A == C) || (A == D) || (B == C) || (B == D);
        }

        #endregion

        #region Outsects

        /// <summary>
        /// Determine if the line segments are collinear but do not intersect (gapped continuation)
        /// </summary>
        /// <param name="CD"></param>
        /// <returns>true when the line segments are aligned and do not intersect</returns>

        public bool Outsects(LineSegment CD)
        {
            return Outsects(A, B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine if the line segments are collinear but do not intersect (gapped continuation)
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when the line segments are aligned and do not intersect</returns>

        public static bool Outsects(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
            return Collinear(A, B, C, D) && !Overlaps(A, B, C, D);
        }

        #endregion

        #region Parallel

        /// <summary>
        /// Determine if the line segments are parallel
        /// </summary>
        /// <param name="CD"></param>
        /// <returns>true when the slope of A-B and C-D are equal</returns>

        public bool Parallel(LineSegment CD)
        {
            return Parallel(A, B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine if the line segments are parallel
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when the slope of A-B and C-D are equal</returns>

        public static bool Parallel(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
            return (A.Tuplet[0] - B.Tuplet[0]) * (C.Tuplet[1] - D.Tuplet[1]) == (C.Tuplet[0] - D.Tuplet[0]) * (A.Tuplet[1] - B.Tuplet[1]);
        }

        #endregion

        #region Eschews

        /// <summary>
        /// Determine if the line segments are unrelated (not collinear and not intersecting)
        /// </summary>
        /// <param name="CD"></param>
        /// <returns>true when the line segments are unaligned and do not intersect</returns>

        public bool Eschews(LineSegment CD)
        {
            return Eschews(A, B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine if the line segments are unrelated (not collinear and not intersecting)
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when the line segments are unaligned and do not intersect</returns>

        public static bool Eschews(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
            if (Collinear(A, B, C, D)) return false;

            return !Intersects(A, B, C, D);
        }

        #endregion
    }
}
