namespace SpatialApp
{
    using System;
    using System.Threading.Tasks;

    using Samples;

    class Program
    {
        static async Task Main(string[] args)
        {
            //Change the sample to execute below with the generic type
            await SampleFactory.Execute<DistanceBetweenTwoPoints>();

            Console.WriteLine("End!");
            Console.ReadLine();
        }
    }
}
