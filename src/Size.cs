using System;

namespace Tuplemetry
{
    public class Size : Tuple
    {
        #region Constructor

        /// <summary>
        /// Construct a Tuple object to manage a collection of object magnitude values (e.g. width, height, depth, and hyperdimensions)
        /// </summary>
        /// <param name="Tuplet">a list of magnitude parameters or an array of floats</param>

        public Size(params float[] Tuplet) : base(Tuplet)
        {
            int Index = Tuplet.Length; 

            while (0 < Index)
            {
                Index--;

                if (0 >= Tuplet[Index]) throw new ArgumentOutOfRangeException("All members must be greater than zero");
            }
        }

        /// <summary>
        /// Clone a Size object
        /// </summary>
        /// <param name="Tuple">a Size object</param>

        public Size(Tuple Tuple) : base(Tuple) { }

        #endregion

        #region Dimension Family

        /// <summary>
        /// 1-space X domain magnitude
        /// </summary>

        public float Width
        {
            get
            {
                if (1 > Tuplet.Length) throw new MemberAccessException(Tuplet.Length.ToString() + " dimensional objects have no width");

                return Tuplet[0];
            }
            set
            {
                if (1 > Tuplet.Length) throw new MemberAccessException(Tuplet.Length.ToString() + " dimensional objects have no width");

                if (0f >= value) throw new ArgumentOutOfRangeException("Width must be greater than zero");

                Tuplet[0] = value;
            }
        }

        /// <summary>
        /// 2-space Y domain magnitude
        /// </summary>

        public float Height
        {
            get
            {
                if (2 > Tuplet.Length) throw new MemberAccessException(Tuplet.Length.ToString() + " dimensional objects have no height");

                return Tuplet[1];
            }
            set
            {
                if (2 > Tuplet.Length) throw new MemberAccessException(Tuplet.Length.ToString() + " dimensional objects have no height");

                if (0f >= value) throw new ArgumentOutOfRangeException("Height must be greater than zero");

                Tuplet[1] = value;
            }
        }

        /// <summary>
        /// 3-space Z domain magnitude
        /// </summary>

        public float Depth
        {
            get
            {
                if (3 > Tuplet.Length) throw new MemberAccessException(Tuplet.Length.ToString() + " dimensional objects have no depth");

                return Tuplet[2];
            }
            set
            {
                if (3 > Tuplet.Length) throw new MemberAccessException(Tuplet.Length.ToString() + " dimensional objects have no depth");

                if (0f >= value) throw new ArgumentOutOfRangeException("Depth must be greater than zero");

                Tuplet[2] = value;
            }
        }

        /// <summary>
        /// Spatial domain magnitude
        /// </summary>
        /// <param name="Index">1D is width, 2D is height, 3D is depth, 4D+ hyperdimension</param>
        /// <returns>the dimension magnitude</returns>

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

                if (0 >= value) throw new ArgumentOutOfRangeException("Dimension members must be greater than zero");

                Tuplet[Dimension - 1] = value;
            }
        }

        #endregion

        #region Capacity Family

        /// <summary>
        /// Calculate the 1-space capacity
        /// </summary>

        public float Length
        {
            get
            {
                if (1 != Tuplet.Length) throw new MemberAccessException(Tuplet.Length.ToString() + " dimensional objects have no length");

                return Tuplet[0];
            }
        }

        /// <summary>
        /// Calculate the 2-space capacity
        /// </summary>

        public float Area
        {
            get
            {
                if (2 != Tuplet.Length) throw new MemberAccessException(Tuplet.Length.ToString() + " dimensional objects have no area");

                return Tuplet[0] * Tuplet[1];
            }
        }

        /// <summary>
        /// Calculate the 3-space capacity
        /// </summary>

        public float Volume
        {
            get
            {
                if (3 != Tuplet.Length) throw new MemberAccessException(Tuplet.Length.ToString() + " dimensional objects have no volume");

                return Tuplet[0] * Tuplet[1] * Tuplet[2];
            }
        }

        /// <summary>
        /// Calculate the InBounds-space capacity
        /// </summary>
        /// <returns>1D is length, 2D is area, 3D is volume, 4D+ is hypervolume</returns>

        public float Capacity
        {
            get
            {
                int Index = Tuplet.Length;

                if (0 == Index) return 0f; // Zero dimensional size

                float Capacity = 1f;

                while (0 < Index)
                {
                    --Index;

                    Capacity *= Tuplet[Index];
                }

                return Capacity;
            }
        }

        #endregion
    }
}
