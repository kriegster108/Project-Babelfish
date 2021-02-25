using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TranslationStation.DataModel;
using TranslationStation.DataModel.Config;
using Elastic.Apm.NetCoreAll;
using Prometheus;

namespace TranslationStation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // DbContext:
            services.AddDbContext<DataModel.Models.EF.TranslationContext>(options =>
                options
                    .UseNpgsql(Configuration.GetConnectionString("TranslationsDatabase"))
                    .UseSnakeCaseNamingConvention());

            // AutoMapper:
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());

            // TranslationOps
            services.AddScoped<ITranslationOps, TranslationOps>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TranslationStation", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TranslationStation v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAllElasticApm(Configuration);

            app.UseHttpMetrics();

            app.UseMetricServer();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
