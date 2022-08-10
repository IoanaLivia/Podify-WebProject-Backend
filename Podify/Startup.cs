using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Podify.Entities;
using Podify.Auth;
using Podify.Managers;
using Podify.Repositories;
using Podify.Models;
using Microsoft.AspNetCore.Identity;

namespace Podify
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Podify", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme // configurare folosita pentru a putea face teste pe endpoint-uri folosindu-ne de tocken
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            //This Connection String will not work on your PCs
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=localhost\\SQLEXPRESS;Initial Catalog=PODIFY;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<AppDbContext>(); // Specificam ca folosim Identity ca serviciu in aplicatie

            services
              .AddAuthentication(options =>
              {

                  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              })


              .AddJwtBearer("AuthScheme", options =>
              {
                  options.SaveToken = true;
                  var secret = Configuration.GetSection("Jwt").GetSection("SecretKey").Get<String>();
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      ValidateLifetime = true,
                      RequireExpirationTime = true,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                      ValidateIssuer = false,
                      ValidateAudience = false,
                      ClockSkew = TimeSpan.Zero
                  };
              });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("BasicUser", policy => policy.RequireRole("BasicUser", "Admin").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());
                opt.AddPolicy("Admin", policy => policy.RequireRole("Admin").RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());

            });

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddTransient<IAuthenticationManager, AuthenticationManager>();
            services.AddTransient<ITokenManager, TokenManager>();
            services.AddTransient<IGuestsManager, GuestsManager>();
            services.AddTransient<IEpisodesManager, EpisodesManager>();
            services.AddTransient<IPodcastsManager, PodcastsManager>();
            services.AddTransient<IPodcastHostsManager, PodcastHostsManager>();


            services.AddTransient<IGuestsRepository, GuestsRepository>();
            services.AddTransient<IEpisodesRepository, EpisodesRepository>();
            services.AddTransient<IPodcastsRepository, PodcastsRepository>();
            services.AddTransient<IPodcastHostsRepository, PodcastHostsRepository>();

            services.AddScoped<InitialSeed>();


            var sp = services.BuildServiceProvider();
            var seed = sp.GetService<InitialSeed>();

            try
            {
                seed.SeedRoles().Wait();
                seed.SeedUsers().Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //, InitialSeed initialSeed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Podify v1"));
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
