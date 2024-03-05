namespace GeometriCS.structs
{
    /// <summary>
    /// A line through the R cubed space with double precision.
    /// </summary>
    public class Line3d
    {
        /// <summary>
        /// A point that lies on the line.
        /// </summary>
        public Vector3d PointOnLine { get; set; }

        /// <summary>
        /// Direction vector, along which all the points on the line lie.
        /// </summary>
        public Vector3d Direction { get; set; }

        /// <summary>
        /// Constructor for the line.
        /// </summary>
        /// <param name="pointOnLine">Point that lies on the line.</param>
        /// <param name="direction">Direction vector on the line.</param>
        public Line3d(Vector3d pointOnLine, Vector3d direction) 
        {
            PointOnLine = pointOnLine;
            Direction = direction;
        }
    }
}
