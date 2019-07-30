using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace NctAPI
{
    /// <summary>
    /// Main class of the program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method of the program
        /// </summary>
        /// <param name="args">Arguments</param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// WebHost creation
        /// </summary>
        /// <param name="args">Arguments</param>
        /// <returns>WebHostBuilder</returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>();
    }
}