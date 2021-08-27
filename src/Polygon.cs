using System;
using System.Drawing;
using System.Collections.Generic;

namespace Tuplemetry
{
    public class Polygon
    {
        public List <Coordinate> Vertex;

        #region Constructor

        /// <summary>
        /// Constructs an empty poloygon: use Add() to insert vertices into the ordered point list that defines the polygon
        /// </summary>

        public Polygon()
        {
        }

        /// <summary>
        /// Constructs a polygon
        /// </summary>
        /// <param name="Vertices">comma separated list of ordered points that define the polygon</param>

        public Polygon(params Coordinate[] Vertices)
        {
            foreach (Coordinate Vertex in Vertices)
            {
                Add(Vertex);
            }
        }

        /// <summary>
        /// Constructs a polygon
        /// </summary>
        /// <param name="Vertices">list of ordered points that define the polygon</param>

        public Polygon(List<Coordinate> Vertices)
        {
            foreach (Coordinate Vertex in Vertices)
            {
                Add(Vertex);
            }
        }

        #endregion

        #region Add

        /// <summary>
        /// Add a planar point to the ordered list of planar points that define the polygon
        /// </summary>
        /// <param name="Point"></param>

        public void Add(Coordinate Point)
        {
            Vertex.Add(Point);            
        }

        /// <summary>
        /// Add a point to the ordered list of points that define the polygon using planar coordinates
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// 

        public void Add(params float[] Ordinates)
        {
            switch (Ordinates.Length)
            {
            case 1:
                Vertex.Add(new Coordinate(Ordinates[0]));
                break;
            case 2:
                Vertex.Add(new Coordinate(Ordinates[0], Ordinates[1]));
                break;
            case 3:
                Vertex.Add(new Coordinate(Ordinates[0], Ordinates[1], Ordinates[2]));
                break;
            case 4:
                Vertex.Add(new Coordinate(Ordinates[0], Ordinates[1], Ordinates[2], Ordinates[3]));
                break;
            case 5:
                Vertex.Add(new Coordinate(Ordinates[0], Ordinates[1], Ordinates[2], Ordinates[3], Ordinates[4]));
                break;
            default:
                throw new IndexOutOfRangeException("Must be a 1, 2, 3, 4, or 5 dimensional Polygon coordinate");
            }
        }

        #endregion

        #region Offset

        public void Offset(params float[] Offsets)
        {
            if (Offsets.Length != Vertex[0].Dimensionality)
            {
                throw new IndexOutOfRangeException("Polygon dimensionality differs from offset dimensionality");
            }

            foreach (Coordinate Point in Vertex)
            {
                for (int i = (Offsets.Length < Point.Tiplet.Length ? Offsets.Length : Point.Tiplet.Length) - 1; i > 0; i--)
                {
                    Point.Tiplet[i] += Offsets[i];
                }
            }
        }

        #endregion

        #region Intersects

        /// <summary>
        /// Determine if any edge of a polygon intersects
        /// </summary>
        /// <param name="B"></param>
        /// <returns>true when the polygon intersects, false when the polygon does not intersect</returns>

        public bool Intersects(Polygon B)
        {
            return Intersects(this, B);
        }

        /// <summary>
        /// Determine if any edge of a polygon intersects
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns>true when the polygons intersect, false when the polygons do not intersect</returns>

        public static bool Intersects(Polygon A, Polygon B)
        {
            int A_Vertices = A.Vertex.Count;
            int B_Vertices = B.Vertex.Count;

            for (int a = A_Vertices; 0 <= a; a--)
            {
                for (int b = B_Vertices; 0 <= b; b--)
                {
                    if (LineSegment.Intersects(A.Vertex[a], A.Vertex[(a + 1) % A_Vertices], B.Vertex[b], B.Vertex[(b + 1) % B_Vertices])) return true;
                }
            }

            return false;
        }

        #endregion
    }
}
