namespace SpatialApp.Samples
{
    using System.Threading.Tasks;

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    /// <summary>Sample factory</summary>
    public class SampleFactory
    {
        /// <summary>Executes this instance.</summary>
        /// <typeparam name="TSample">The type of the sample.</typeparam>
        /// <returns></returns>
        public async static Task Execute<TSample>()
                where TSample : SampleBase
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<Samples.SampleBase, TSample>();
            services.AddLogging(options =>
            {
                options.SetMinimumLevel(LogLevel.Information);
                options.AddConsole();
            });

            var serviceProvider = services.BuildServiceProvider();

            await serviceProvider.GetService<SampleBase>().ExecuteAsyc();
        }
    }
}
