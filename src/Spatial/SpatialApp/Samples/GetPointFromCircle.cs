using System.Threading.Tasks;

namespace SpatialApp.Samples
{
    using System;
    using Microsoft.Extensions.Logging;
    using Model;

    public class GetPointFromCircle : SampleBase
    {
        private readonly ILogger logger;


        /// <summary>Initializes a new instance of the <see cref="GetPointFromCircle"/> class.</summary>
        /// <param name="logger">The logger.</param>
        public GetPointFromCircle(ILogger<DistanceBetweenTwoPoints> logger)
        {
            this.logger = logger;
        }


        /// <summary>Executes the sample async.</summary>
        /// <returns></returns>
        public override Task ExecuteAsyc()
        {
            var pointA = new GeoCoordinate(2.319620, 48.818508);
            var pointB = pointA.GetPointFromCircle(5000, Bearing.NorthBound);

            this.logger.LogInformation($"NorthBound point near by 5 km from {pointA} : {pointB}");

            return Task.CompletedTask;
        }
    }

    /// <summary>Sample extensions methods</summary>
    public static class NearByExtensions
    {
        /// <summary>Nears the by.</summary>
        /// <param name="center">The source.</param>
        /// <param name="radius">The radius.</param>
        /// <param name="bearing">The bearing.</param>
        /// <returns></returns>
        public static GeoCoordinate GetPointFromCircle(this GeoCoordinate center, double radius, Bearing bearing)
        {
            Func<double, double> radians = (x) => x * Math.PI / 180;

            var latA = radians(center.Latitude);
            var lonA = radians(center.Longitude);
            var angularDistance = radius / 1000 / 6371;
            var trueCourse = radians((double)bearing);

            var lat = Math.Asin(
                Math.Sin(latA) * Math.Cos(angularDistance) +
                Math.Cos(latA) * Math.Sin(angularDistance) * Math.Cos(trueCourse));

            var dlon = Math.Atan2(
                Math.Sin(trueCourse) * Math.Sin(angularDistance) * Math.Cos(lonA),
                Math.Cos(angularDistance) - Math.Sin(lonA) * Math.Sin(center.Latitude));

            var lon = ((lonA + dlon + Math.PI) % (Math.PI * 2)) - Math.PI;

            return new GeoCoordinate(
                lat * (180.0 / Math.PI),
                lon * (180.0 / Math.PI));
        }
    }
}
