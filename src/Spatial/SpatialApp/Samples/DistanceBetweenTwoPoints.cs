namespace SpatialApp.Samples
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Logging;

    using Model;

    /// <summary>Calculte Distance Between Two Points in meter</summary>
    public class DistanceBetweenTwoPoints : SampleBase
    {
        private readonly ILogger logger;

        /// <summary>Initializes a new instance of the <see cref="DistanceBetweenTwoPoints"/> class.</summary>
        /// <param name="logger">The logger.</param>
        public DistanceBetweenTwoPoints(ILogger<DistanceBetweenTwoPoints> logger)
        {
            this.logger = logger;
        }

        public override Task ExecuteAsyc()
        {
            var pointA = new GeoCoordinate(48.818508, 2.319620);
            var pointB = new GeoCoordinate(48.862360, 2.351950);

            var distance = pointA.Distance(pointB);

            this.logger.LogInformation($"Distance in meter between {pointA} and {pointB} : {distance}");

            return Task.CompletedTask;
        }

    }

    /// <summary>Sample extension methods</summary>
    public static class DistanceBetweenTwoPointsExtensions
    {
        /// <summary>Distances the specified point.</summary>
        /// <param name="source">The source.</param>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public static double Distance(this GeoCoordinate source, GeoCoordinate point)
        {
            double R = 6371; // km
            Func<double, double> radians = (x) => x * Math.PI / 180;

            double sLat1 = Math.Sin(radians(point.Latitude));
            double sLat2 = Math.Sin(radians(source.Latitude));
            double cLat1 = Math.Cos(radians(point.Latitude));
            double cLat2 = Math.Cos(radians(source.Latitude));
            double cLon = Math.Cos(radians(point.Longitude) - radians(source.Longitude));

            double cosD = sLat1 * sLat2 + cLat1 * cLat2 * cLon;

            double d = Math.Acos(cosD);

            double dist = R * d * 1000;

            return dist;
        }
    }
}
