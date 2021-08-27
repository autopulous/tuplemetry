using System;

namespace Tuplemetry
{
    public class Coordinate : Tuple
    {

        #region Constructor

        /// <summary>
        /// Construct a Coordinate object to manage a collection of object positional values (e.g. X, Y, Z, and hyperdimensions)
        /// </summary>
        /// <param name="Tuplet">a list of position parameters or an array of floats</param>

        public Coordinate(params float[] Tuplet) : base(Tuplet) { }

        /// <summary>
        /// Clone a Coordinate object
        /// </summary>

        public Coordinate(Tuple Tuple) : base(Tuple) { }

        #endregion

        #region ToString

        /// <summary>
        /// Format a set of coordinates for display
        /// </summary>
        /// <returns>Parenthesized and comma separated list of ordinals</returns>

        public override string ToString()
        {
            int Length = Tuplet.Length;

            if (0 == Length) return "";
            
            string String = "(";

            for (int Index = 0; Index < Length;)
            {
                String += Tuplet[Index++];

                String += Index < Length ? ", " : ")";
            }

            return String;
        }

        #endregion

        #region Dimensions

        /// <summary>
        /// 1-space width domain value
        /// </summary>

        public float X
        {
            get
            {
                if (1 > Tuplet.Length) throw new MemberAccessException(Tuplet.Length.ToString() + " dimensional objects have no X");

                return Tuplet[0];
            }
            set
            {
                if (1 > Tuplet.Length) throw new MemberAccessException(Tuplet.Length.ToString() + " dimensional objects have no X");

                Tuplet[0] = value;
            }
        }

        /// <summary>
        /// 2-space height domain value
        /// </summary>

        public float Y
        {
            get
            {
                if (2 > Tuplet.Length) throw new MemberAccessException(Tuplet.Length.ToString() + " dimensional objects have no Y");

                return Tuplet[1];
            }
            set
            {
                if (2 > Tuplet.Length) throw new MemberAccessException(Tuplet.Length.ToString() + " dimensional objects have no Y");

                Tuplet[1] = value;
            }
        }

        /// <summary>
        /// 3-space depth domain value
        /// </summary>

        public float Z
        {
            get
            {
                if (3 > Tuplet.Length) throw new MemberAccessException(Tuplet.Length.ToString() + " dimensional objects have no Z");

                return Tuplet[2];
            }
            set
            {
                if (3 > Tuplet.Length) throw new MemberAccessException(Tuplet.Length.ToString() + " dimensional objects have no Z");

                Tuplet[2] = value;
            }
        }

        /// <summary>
        /// Spatial domain position
        /// </summary>
        /// <param name="Index">1D is X, 2D is Y, 3D is Z, 4D+ hyperdimension</param>
        /// <returns></returns>

        public float this[int Dimension]
        {
            get
            {
                if (0 >= Dimension) throw new IndexOutOfRangeException("Cannot access negative dimensions (" + (Dimension).ToString() + ")");

                if (Tuplet.Length < Dimension) throw new IndexOutOfRangeException("Cannot access dimension:" + (Dimension).ToString() + " of a " + Tuplet.Length.ToString() + " dimensional object");

                return Tuplet[Dimension - 1];
            }
            set
            {
                if (0 >= Dimension) throw new IndexOutOfRangeException("Cannot access negative dimensions (" + (Dimension).ToString() + ")");

                if (Tuplet.Length < Dimension) throw new IndexOutOfRangeException("Cannot access dimension:" + (Dimension).ToString() + " of a " + Tuplet.Length.ToString() + " dimensional object");

                Tuplet[Dimension - 1] = value;
            }
        }

        #endregion

        #region Length

        /// <summary>
        /// Calculate the vector magnitude to the origin (Pythagorean theorem)
        /// </summary>

        public float Length
        {
            get
            {
                float SumOfSquares = 0f;

                int Index = Tuplet.Length; 

                while (0 < Index)
                {
                    Index--;

                    SumOfSquares += Tuplet[Index] * Tuplet[Index];
                }

                return (float) Math.Sqrt(SumOfSquares);
            }
        }

        #endregion

        #region Distance

        /// <summary>
        /// Calculate the vector magnitude to coordinate B (Pythagorean theorem)
        /// </summary>
        /// <param name="B">a vector</param>
        /// <returns>the distance between the coordinates</returns>

        public float Distance(Coordinate B)
        {
            return Distance(this, B);
        }

        public static float Distance(Coordinate A, Coordinate B)
        {
            return Math.Abs((A - B).Length);
        }

        #endregion

        #region Dimensional Difference

        public float X_Delta(Coordinate B)
        {
            return this.X - B.X;
        }

        public static float X_Delta(Coordinate A, Coordinate B)
        {
            return A.X - B.X;
        }

        public float Y_Delta(Coordinate B)
        {
            return this.Y - B.Y;
        }

        public static float Y_Delta(Coordinate A, Coordinate B)
        {
            return A.Y - B.Y;
        }

        #endregion

        #region Relations

        public float DotProduct(Coordinate B)
        {
            return DotProduct(this, B);
        }

        public static float DotProduct(Coordinate A, Coordinate B)
        {
            float Product = 0;

            int Index = B.Dimensions > A.Dimensions ? A.Dimensions : B.Dimensions;

            while (Index > 0)
            {
                Index--;

                Product += A.Tuplet[Index] * B.Tuplet[Index];
            }

            return Product;
        }

        public float CrossProduct(Coordinate B)
        {
            return CrossProduct(this, B);
        }

        public static float CrossProduct(Coordinate A, Coordinate B)
        {
            return (A.X * B.Y) - (A.Y * B.X);
        }

        #endregion

        #region Middle

        /// <summary>
        /// Average vectors
        /// </summary>
        /// <param name="B"></param>
        /// <returns>the vector average</returns>

        public Coordinate Middle(Coordinate B)
        {
            return this & B;
        }

        /// <summary>
        /// Average vectors
        /// </summary>
        /// <param name="A">a vector</param>
        /// <param name="B">a vector</param>
        /// <returns>the vector average</returns>

        public static Coordinate Middle(Coordinate A, Coordinate B)
        {
            return A & B;
        }

        #endregion

        #region Negation

        /// <summary>
        /// Negate a vector
        /// </summary>
        /// <param name="A">vector</param>
        /// <returns>the negated vector</returns>

        public static Coordinate operator -(Coordinate A)
        {
            Coordinate C = new Coordinate(A);

            int Index = C.Dimensions;

            while (Index > 0)
            {
                Index--;

                C.Tuplet[Index] = -A.Tuplet[Index];
            }

            return C;
        }

        #endregion

        #region Addition

        /// <summary>
        /// Add vectors
        /// </summary>
        /// <param name="A">vector addend</param>
        /// <param name="B">vector addend</param>
        /// <returns>the vector sum/returns>

        public static Coordinate operator +(Coordinate A, Coordinate B)
        {
            Coordinate C = new Coordinate(A);

            int Index = C.Dimensions > B.Dimensions ? B.Dimensions : C.Dimensions;

            while (Index > 0)
            {
                Index--;

                C.Tuplet[Index] += B.Tuplet[Index];
            }

            return C;
        }

        #endregion

        #region Subtraction

        /// <summary>
        /// Subtract vectors
        /// </summary>
        /// <param name="A">vector minuend</param>
        /// <param name="B">vector subtrahend</param>
        /// <returns>the vector difference</returns>

        public static Coordinate operator -(Coordinate A, Coordinate B)
        {
            Coordinate C = new Coordinate(A);

            int Index = C.Dimensions > B.Dimensions ? B.Dimensions : C.Dimensions; 

            while (Index > 0)
            {
                Index--;

                C.Tuplet[Index] -= B.Tuplet[Index];
            }

            return C;
        }

        #endregion

        #region Average

        /// <summary>
        /// Average vectors
        /// </summary>
        /// <param name="A">a vector</param>
        /// <param name="B">a vector</param>
        /// <returns>the vector average</returns>

        public static Coordinate operator &(Coordinate A, Coordinate B)
        {
            Coordinate C = new Coordinate(A);

            int Index = C.Dimensions > B.Dimensions ? B.Dimensions : C.Dimensions; 

            while (Index > 0)
            {
                Index--;

                C.Tuplet[Index] += (B.Tuplet[Index] - C.Tuplet[Index]) / 2; // midpoint
            }

            return C;
        }

        #endregion

        #region Multiplication

        /// <summary>
        /// Positively scale a vector
        /// </summary>
        /// <param name="A">mutiplicand</param>
        /// <param name="Scale">mutiplier</param>
        /// <returns>the scaled vector</returns>

        public static Coordinate operator *(Coordinate A, float Scale)
        {
            Coordinate C = new Coordinate(A);

            int Index = C.Dimensions;

            while (Index > 0)
            {
                Index--;

                C.Tuplet[Index] *= Scale;
            }

            return C;
        }

        #endregion

        #region Division

        /// <summary>
        /// Negatively scale a vector
        /// </summary>
        /// <param name="A">dividend</param>
        /// <param name="Scale">divisor</param>
        /// <returns>the scaled vector</returns>

        public static Coordinate operator /(Coordinate A, float Scale)
        {
            if (0f == Scale) throw new DivideByZeroException("Mathematics is flawed: cannot divide by zero");

            Coordinate C = new Coordinate(A);

            int Index = C.Dimensions;

            while (Index > 0)
            {
                Index--;

                C.Tuplet[Index] /= Scale;
            }

            return C;
        }

        #endregion

        #region Modulation

        /// <summary>
        /// Calculate the coordinate that is within the rectangluar limits of coordinate B (modulus the vector)
        /// computes the remainder of the vector magnitudes divided by the modulo
        /// (rectangular spatial wrap-around)
        /// </summary>
        /// <param name="A">a coordinate</param>
        /// <param name="B">a rectangluar modular limit (divisor)</param>
        /// <returns>the modulused coordinate position</returns>

        public static Coordinate operator %(Coordinate A, Coordinate B)
        {
            Coordinate C = new Coordinate(A);

            int Index = C.Dimensions > B.Dimensions ? B.Dimensions : C.Dimensions; 

            while (Index > 0)
            {
                Index--;

                if (0f == B.Tuplet[Index]) throw new DivideByZeroException("Mathematics is flawed: cannot modulus by zero");

                C.Tuplet[Index] %= B.Tuplet[Index];
            }

            return C;
        }

        /// <summary>
        /// Calculate the coordinate that is within the cubic limits of the modulo (modulus the vector)
        /// computes the remainder of the vector magnitudes divided by the modulo
        /// (cubic spatial wrap-around)
        /// </summary>
        /// <param name="A">a coordinate</param>
        /// <param name="Modulo">a cubic modular limit (divisor)</param>
        /// <returns>the modulused coordinate position</returns>

        public static Coordinate operator %(Coordinate A, float Modulo)
        {
            if (0 == Modulo) throw new DivideByZeroException("Mathematics is flawed: cannot modulus by zero");

            Coordinate C = new Coordinate(A);

            int Index = C.Dimensions;

            while (Index > 0)
            {
                Index--;

                C.Tuplet[Index] %= Modulo;
            }

            return C;
        }

        #endregion

        #region GetHashCode

        /// <summary>
        /// Hash the dimension member values
        /// </summary>
        /// <returns>a (cheap and not so great) hash code</returns>

        public override int GetHashCode()
        {
            int Hash = 0;

            int Index = this.Dimensions;

            while (Index > 0)
            {
                Index--;

                Hash += (int) (this.Tuplet[Index] * 1000 * Index * Index);
            }

            return Hash;
        }

        #endregion

        #region Equality

        /// <summary>
        /// Determine coordinate equality
        /// </summary>
        /// <param name="A"></param>
        /// <param name="O">object that will be typecast as a Coordinate object</param>
        /// <returns>true when the coordinates represent the same location</returns>

        public override bool Equals (object O)
        {
            return this == (Coordinate) O;
        }

        /// <summary>
        /// Determine coordinate equality
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns>true when the coordinates represent the same location</returns>

        public static bool operator ==(Coordinate A, Coordinate B)
        {
            // Object typecast required to prevent recursive evaluation of the == operation on the Coordinates

            if (null == (Object) A)
            {
                return null == (Object) B;
            }
            else
            {
                if (null == (Object) B) return false;
            }

            int LowerDimensions, HigherDimensions;

            Coordinate UnmatchedCoordinates;

            if (A.Dimensions > B.Dimensions)
            {
                LowerDimensions = B.Dimensions;
                HigherDimensions = A.Dimensions;

                UnmatchedCoordinates = A;
            }
            else
            {
                LowerDimensions = A.Dimensions;
                HigherDimensions = B.Dimensions;

                UnmatchedCoordinates = B;
            }

            int Index = 0;

            while (Index < LowerDimensions)
            {
                if (A.Tuplet[Index] != B.Tuplet[Index]) return false;

                Index++;
            }

            while (Index < HigherDimensions)
            {
                if (0 != UnmatchedCoordinates.Tuplet[Index]) return false;

                Index++;
            }

            return true;
        }

        #endregion

        #region Inequality

        /// <summary>
        /// Determine coordinate inequality
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns>true when the coordinates represent the same location</returns>

        public static bool operator !=(Coordinate A, Coordinate B)
        {
            return !(A == B);
        }

        #endregion
    }
}