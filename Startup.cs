using System;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using Burak.Authorization.Api.Filters;
using Burak.Authorization.Api.Configurations.Startup;
using Burak.Authorization.Data;
using Burak.Authorization.Business.Mappers;
using Burak.Authorization.Business.Validators;
using Burak.Authorization.Utilities.Middleware;
using Burak.Authorization.Utilities.ConfigModels;
using Burak.Authorization.Helper;
using Burak.Authorization.Utilities.ValidationHelper.ValidatorResolver;
using Burak.Authorization.ExternalServices.Implementation;
using Burak.Authorization.ExternalServices.Interface;
using Microsoft.EntityFrameworkCore;
using Burak.Authorization.Business.Services.Implementation;
using Burak.Authorization.Utilities.Constants;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Burak.Authorization
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

            services.AddLogging(builder => builder.AddNLog());
            services.AddOptionsConfiguration(Configuration);
            services.AddMvc(options => options.Filters.Add<GeneralExceptionFilter>());
            services.AddMvc(options => options.EnableEndpointRouting = false);
            AddSelectedDataStorage(services);
            AddMappers(services);
            AddValidations(services);
            AddBusinessServices(services);

            // JWT authentication Aayarlaması
            var key = Encoding.ASCII.GetBytes(AppConstants.JWTSecretKey);
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

            services.AddSwaggerGen(c =>
            c.SwaggerDoc(name: "v1", new OpenApiInfo { Title = "Authorization API", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(option => option.AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowAnyOrigin());

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Authorization API");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseTraceIdMiddleware();
        }

        private void AddSelectedDataStorage(IServiceCollection services)
        {
            DataStorage dataStorage = ConfigurationHelper.GetDataStorage(Configuration);

            switch (dataStorage.DataStorageType)
            {
                case DataStorageTypes.SqlServer:
                    services.AddDbContext<DataContext>(builder => builder.UseSqlServer(dataStorage.ConnectionString));
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"{dataStorage.DataStorageType} has not been pre-defined");
            }
        }

        private void AddMappers(IServiceCollection services)
        {
            //TODO: Create and add which model mapped to which
            services.AddAutoMapper(typeof(UserMappingProfiles));
        }

        private void AddValidations(IServiceCollection services)
        {
            //TODO: Add Request Validators
            services.AddSingleton<IValidatorResolver, ValidatorResolver>();
            services.AddSingleton<IValidator, UserRequestValidator>();
        }

        private void AddBusinessServices(IServiceCollection services)
        {
            //TODO: Add Services (external,internal)
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IShopExternalService, ShopExternalService>();
        }
    }
}
