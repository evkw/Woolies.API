using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Woolies.Abstractions.Configuration;
using Woolies.Abstractions.Repositories;
using Woolies.Abstractions.Services;
using Woolies.api.Configuration;
using Woolies.repository;
using Woolies.Services;
using Woolies.Repositories;
using Microsoft.Extensions.Logging;

namespace Woolies.api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            // Repo DI
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddSingleton<IWooliesTestEndpointClient, WooliesTestEndpointClient>();

            // Service DI
            services.AddTransient<IExerciseOneService, ExerciseOneService>();
            services.AddTransient<IExerciseTwoService, ExerciseTwoService>();
            services.AddTransient<IExerciseThreeService, ExerciseThreeService>();

            // Config DI
            services.Configure<WooliesTestConfiguration>(this.Configuration);
            services.AddSingleton<IWooliesTestConfiguration, WooliesTestConfiguration>();

            // Logging
            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddLogging(loggingBuilder => loggingBuilder
                .AddConsole()
                .AddDebug()
                .SetMinimumLevel(LogLevel.Debug));

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }
    }
}
