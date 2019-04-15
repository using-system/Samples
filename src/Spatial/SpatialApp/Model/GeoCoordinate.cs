namespace SpatialApp.Model
{
    /// <summary>
    /// Geo Coordinate
    /// </summary>
    public class GeoCoordinate
    {
        /// <summary>Initializes a new instance of the <see cref="GeoCoordinate"/> class.</summary>
        /// <param name="longitude">The longitude.</param>
        /// <param name="latitude">The latitude.</param>
        public GeoCoordinate(double longitude, double latitude)
        {
            this.Longitude = longitude;
            this.Latitude = latitude;
        }

        /// <summary>
        /// Gets the latitude.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets the longitude.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public double Longitude { get; set; }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            return $"lon : {this.Longitude} / lat : {this.Latitude}";
        }
    }
}
