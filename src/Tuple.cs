using System;

namespace Tuplemetry
{
    public abstract class Tuple
    {
        #region Constructor

        /// <summary>
        /// Construct a Tuple object
        /// </summary>
        /// <param name="Tuplet">a list of dimension parameters or an array of floats</param>

        public Tuple(params float[] Tuplet)
        {
            TupleFactory(Tuplet);
        }

        /// <summary>
        /// Clone a Tuple object
        /// </summary>
        /// <param name="Tuple">a Tuple object</param>
        
        public Tuple(Tuple Tuple)
        {
            TupleFactory(Tuple.Tuplet);
        }

        /// <summary>
        /// Tuple constructor helper method (applying the DRY principle)
        /// </summary>
        /// <param name="Tuplet">an array of floats</param>

        private void TupleFactory(float[] Tuplet)
        {
            int Index = Tuplet.Length;

            this.Tuplet = new float[Index];

            while (Index > 0)
            {
                Index--;

                this.Tuplet[Index] = Tuplet[Index];
            }
        }

        #endregion

        #region Accessors

        /// <summary>
        /// Tuple dimension values as an array
        /// </summary>
        
        public float[] Tuplet { get; set; }

        /// <summary>
        /// The number of tuple dimensions
        /// </summary>

        public Int32 Dimensions
        {
            get
            {
                return Tuplet.Length;
            }
        }

        #endregion

        /// <summary>
        /// (UNIMPLEMENTED)
        /// Comparison threshold at which dimension domain values will be considered equal (floating point comparison)
        /// Considering converting tuples to Int64 where reals are scaled to a fractional unit (e.g. 1000th or 10000th of a pixel is the base unit)
        /// </summary>

        public UInt64 Epsilon { get; set; }
    }
}
