using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Helpers;
using WebApi.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;
using DAL.Helper;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Logging;
using DAL.Interfaces;
using BLL.Interfaces;


namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
           Configuration = configuration;
        }
        //public Startup(IWebHostEnvironment env)
        //{
        //    var builder = new ConfigurationBuilder()
        //       .SetBasePath(env.ContentRootPath)
        //       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //       .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        //       .AddEnvironmentVariables();
        //    Configuration = builder.Build();
        //}

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options => {
                options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.AddControllers();
            services.AddTransient<IDatabaseHelper, DatabaseHelper>();
            services.AddTransient<ClassOfStudentRepositoryIF, ClassOfStudentRepository>();
            services.AddTransient<ClassOfStudentBusinessIF, ClassOfStudentBusiness>();

            services.AddTransient<StudentOfSubjectRepositoryIF, StudentOfSubjectRepository>();
            services.AddTransient<StudentOfSubjectBusinessIF, StudentOfSubjectBusiness>();

            services.AddTransient<ListSubjectClassRepositoryIF, ListSubjectClassRepository>();
            services.AddTransient<ListSubjectClassBusinessIF, ListSubjectClassBusiness>();


            services.AddDbContext<RegisterSubjectDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("RegisterSubjectDBContext")));
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddSwaggerGen(gen =>
            {
                gen.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "RS API", Version = "v1.0" });
            });
            services.AddCors();

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseCors(builder =>
            //{
            //    builder.WithOrigins("http://localhost:4200");
            //    builder.AllowAnyMethod();
            //    builder.AllowAnyHeader();
            //});

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
           // app.UseCors("AllowAll");
            //app.UseApiMiddleware();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "RS API");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
      
    }
}
