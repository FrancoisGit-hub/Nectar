using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NctAPI
{
    /// <summary>
    /// Startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constant connection name
        /// </summary>
        private const string ConnectionName = "Nectar";

        /// <summary>
        /// Property encapsulating connection name
        /// </summary>
        public static string NectarConnectionStringName { get; set; } = ConnectionName;

        /// <summary>
        /// Connection string
        /// </summary>
        public static string NectarConnectionString { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">Configuration</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration interface
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method is called by the runtime. Use this method to add services to the container (v2.2 compatibility)
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        /// </summary>
        /// <param name="app">Application builder inferface</param>
        /// <param name="env">Hosting environment interface</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days
                app.UseHsts();
            }

            NectarConnectionString = Configuration.GetConnectionString(NectarConnectionStringName);

            // Usage of HTTPS protocol
            app.UseHttpsRedirection();

            // Add MVC pattern to the execution pipeline
            app.UseMvc();
        }
    }
}
