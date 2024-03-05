namespace GeometriCS.structs
{
    /// <summary>
    /// A line through a two-dimensional vector space.
    /// </summary>
    public class Line2d
    {
        /// <summary>
        /// A point that lies on the line.
        /// </summary>
        public Vector2d PointOnLine { get; set; }

        /// <summary>
        /// Direction vector, along which all the points on the line lie.
        /// </summary>
        public Vector2d Direction { get; set; }

        /// <summary>
        /// Constructor for the line.
        /// </summary>
        /// <param name="pointOnLine">Point that lies on the line.</param>
        /// <param name="direction">Direction vector on the line.</param>
        public Line2d(Vector2d pointOnLine, Vector2d direction)
        {
            PointOnLine = pointOnLine;
            Direction = direction;
        }
    }
}
