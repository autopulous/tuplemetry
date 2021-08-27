using System;
using System.Drawing;

namespace Tuplemetry
{
    public class Line : CoordinatePair
    {
        #region Constructor

        /// <summary>
        /// Construct a line from a pair of X & Y values
        /// </summary>
        /// <param name="AX"></param>
        /// <param name="AY"></param>
        /// <param name="BX"></param>
        /// <param name="BY"></param>

        public Line(float AX, float AY, float BX, float BY) : base (AX, AY, BX, BY)
        {
        }

        /// <summary>
        /// Construct a line from a point and an X & Y value
        /// </summary>
        /// <param name="A"></param>
        /// <param name="BX"></param>
        /// <param name="BY"></param>

        public Line(Coordinate A, float BX, float BY) : base (A, BX, BY)
        {
        }

        /// <summary>
        /// Construct a line from a pair of points
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>

        public Line(Coordinate A, Coordinate B) : base (A, B)
        {
        }

        /// <summary>
        /// Construct a line from a line
        /// </summary>
        /// <param name="AB"></param>

        public Line(Line AB) : base (AB)
        {
        }

        #endregion

        #region Collinear

        /// <summary>
        /// Determine if the line coordinates describe the same line (completely coincident)
        /// </summary>
        /// <param name="CD"></param>
        /// <returns>true when C-D is aligned with A-B</returns>

        public bool Collinear(Line CD)
        {
            return Collinear(A, B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine if the line coordinates describe the same line (completely coincident)
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns></returns>

        public static bool Collinear(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
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

            // Points lack collinearity

            if ((AX == BX && AY == BY) || (CX == DX && CY == DY)) return false;

            // when A-C and A-D are parallel to A-B the lines are collinear

            return AB_X * (AY - CY) == (AX - CX) * AB_Y && AB_X * (AY - DY) == (AX - DX) * AB_Y;
        }

        #endregion

        #region Intersects

        /// <summary>
        /// Determine if a point intersects a line
        /// </summary>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when the lines are determined to intersect</returns>

        public bool Intersects(Coordinate C)
        {
            return Intersects(A, B, C, C);
        }

        /// <summary>
        /// Determine if a line intersects
        /// </summary>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when the lines are determined to intersect</returns>

        public bool Intersects(Coordinate C, Coordinate D)
        {
            return Intersects(A, B, C, D);
        }

        /// <summary>
        /// Determine if a line intersects
        /// </summary>
        /// <param name="CD"></param>
        /// <returns>true when the lines are determined to intersect</returns>

        public bool Intersects(Line CD)
        {
            return Intersects(A, B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine if the lines intersect
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when at least one point within C-D is within A-B</returns>

        public static bool Intersects(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
            // calculate dimensional magnitudes

            float AB_X = A.Tuplet[0] - B.Tuplet[0];
            float AB_Y = A.Tuplet[1] - B.Tuplet[1];
            float AC_X = A.Tuplet[0] - C.Tuplet[0];
            float AC_Y = A.Tuplet[1] - C.Tuplet[1];
            float CD_X = C.Tuplet[0] - D.Tuplet[0];
            float CD_Y = C.Tuplet[1] - D.Tuplet[1];

            // calculate intersection coefficients

            float O = AB_X * CD_Y - AB_Y * CD_X;
            float P = AC_X * CD_Y - AC_Y * CD_X;
            float Q = AC_X * AB_Y - AC_Y * AB_X;

            // when O does not equal zero, the lines are not parallel and not collinear (therefore intersecting)
            // when O, P and Q equal zero, the lines are parallel and collinear (therefore intersecting)

            return (0 != O) || (0 == P && 0 == Q);
        }
        #endregion

        #region Intersection

        /// <summary>
        /// Determine the intersection point of the lines
        /// </summary>
        /// <param name="C">C-D end point</param>
        /// <param name="D">C-D end point</param>
        /// <returns>intersection point or null when the lines are parallel</returns>

        public LineSegment Intersection(Coordinate C, Coordinate D)
        {
            return Intersection(A, B, C, D);
        }

        /// <summary>
        /// Determine the intersection point of the lines
        /// </summary>
        /// <param name="CD"></param>
        /// <returns>intersection point or null when the lines are parallel</returns>

        public LineSegment Intersection(Line CD)
        {
            return Intersection(A, B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine the intersection point of the lines
        /// </summary>
        /// <param name="AB">A-B</param>
        /// <param name="CD">C-D</param>
        /// <returns>intersection point or null when the lines are parallel</returns>

        public static LineSegment Intersection(Line AB, Line CD)
        {
            return Intersection(AB.A, AB.B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine the intersection point of the lines
        /// </summary>
        /// <param name="A">A-B end point</param>
        /// <param name="B">A-B end point</param>
        /// <param name="C">C-D end point</param>
        /// <param name="D">C-D end point</param>
        /// <returns>intersection point or null when the lines are parallel</returns>

        public static LineSegment Intersection(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
            Coordinate E;
            Coordinate F;

            // http://www-cs.ccny.cuny.edu/~wolberg/capstone/intersection/Intersection%20point%20of%20two%20lines.html

            float AX = A.Tuplet[0];
            float AY = A.Tuplet[1];
            float BX = B.Tuplet[0];
            float BY = B.Tuplet[1];
            float CX = C.Tuplet[0];
            float CY = C.Tuplet[1];
            float DX = D.Tuplet[0];
            float DY = D.Tuplet[1];

            // calculate dimensional magnitudes

            float AB_X = AX - BX;
            float AB_Y = AY - BY;
            float AC_X = AX - CX;
            float AC_Y = AY - CY;
            float CD_X = CX - DX;
            float CD_Y = CY - DY;

            //// calculate intersection coefficients

            //float O = ((B.X - A.X) * (D.Y - C.Y)) - ((B.Y - A.Y) * (D.X - C.X));
            //float O = (BA_X * DC_Y) - (BA_Y * DC_X);
            //float O = (-AB_X * -CD_Y) - (-AB_Y * -CD_X);

            float O = AB_X * CD_Y - AB_Y * CD_X;

            //float P = (((D.X - C.X) * (A.Y - C.Y)) - ((D.Y - C.Y) * (A.X - C.X)))
            //float P = ((-CD_X * AC_Y) - (-CD_Y * AC_X));
            //float P = ((-CD_X * AC_Y) + (CD_Y * AC_X));
            //float P = ((CD_Y * AC_X) - (CD_X * AC_Y));
            //float P = ((AC_X * CD_Y) - (AC_Y * CD_X));

            float P = AC_X * CD_Y - AC_Y * CD_X;
            float Q = AC_X * AB_Y - AC_Y * AB_X;

            // when O equals zero, the lines are parallel

            if (0 == O)
            {
                // when O is zero and P or Q do not equal zero, the lines are parallel and not collinear (therefore not intersecting)

                if (0 != P || 0 != Q)
                {
                    return null; // the lines are parallel and not collinear
                }

                // mathematical determination of the collinear intersection

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

                float E__F;

                // build the longest intersecting line segment (unrolled loop)

                E = A;

                if (A__B > A__C)
                {
                    F = B;
                    E__F = A__B;
                }
                else
                {
                    F = C;
                    E__F = A__C;
                }

                if (A__D > E__F)
                {
                    F = D;
                    E__F = A__D;
                }

                if (B__C > E__F)
                {
                    E = B;
                    F = C;
                    E__F = B__C;
                }

                if (B__D > E__F)
                {
                    E = B;
                    F = D;
                    E__F = B__D;
                }

                if (C__D > E__F)
                {
                    E = C;
                    F = D;
                    E__F = C__D;
                }

                // return the longest intersecting line segment

                return new LineSegment(E, F);
            }

            // point intersection

            P /= O;

            //Coordinate E = new Coordinate(A.X + (P * (B.X - A.X)), A.Y + (P * (B.Y - A.Y)));

            E = new Coordinate(A.X - (P * AB_X), A.Y - (P * AB_Y));

            return new LineSegment(E, E);
        }

        #endregion

        #region Perpendicular

        /// <summary>
        /// Determine if the lines are perpendicular
        /// </summary>
        /// <param name="CD"></param>
        /// <returns>true when the slope of A-B and C-D are at right angles</returns>

        public bool Perpendicular(Line CD)
        {
            return Perpendicular(A, B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine if the lines are perpendicular
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns>true when the slope of A-B and C-D are at right angles</returns>

        public static bool Perpendicular(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
            float AB_X = A.Tuplet[0] - B.Tuplet[0];
            float AB_Y = A.Tuplet[1] - B.Tuplet[1];
            float CD_X = C.Tuplet[0] - D.Tuplet[0];
            float DC_Y = D.Tuplet[1] - C.Tuplet[1]; // flipped difference to simplify the general perpendicularity test

            // Points lack perpendicularity

            if ((0 == AB_X && 0 == AB_Y) || (0 == CD_X && 0 == DC_Y)) return false;

            // Horizontal perpendicularity check (special case)

            if (0 == AB_X) return 0 == DC_Y;

            // Vertical perpendicularity check (special case)

            if (0 == AB_Y) return 0 == CD_X;

            // General perpendicularity

            return AB_X * CD_X == AB_Y * DC_Y;
        }

        #endregion

        #region Parallel

        /// <summary>
        /// Determine if the lines are parallel
        /// </summary>
        /// <param name="CD"></param>
        /// <returns>true when the slope of A-B and C-D are equal</returns>

        public bool Parallel(Line CD)
        {
            return Parallel(A, B, CD.A, CD.B);
        }

        /// <summary>
        /// Determine if the lines are parallel
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        /// <returns></returns>

        public static bool Parallel(Coordinate A, Coordinate B, Coordinate C, Coordinate D)
        {
            // return AB_X * CD_Y == AB_Y * CD_X;
            // return (A.X - B.X) * (C.Y - D.Y) == (A.Y - B.Y) * (C.X - D.X);

            return (A.Tuplet[0] - B.Tuplet[0]) * (C.Tuplet[1] - D.Tuplet[1]) == (A.Tuplet[1] - B.Tuplet[1]) * (C.Tuplet[0] - D.Tuplet[0]);
        }

        #endregion
    }
}
