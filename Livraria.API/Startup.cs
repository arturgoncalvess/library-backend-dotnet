using Livraria.API.Data;
using Livraria.API.Services.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using FluentValidation.AspNetCore;
using System.IO;
using System.Reflection;
using Livraria.API.Services.Books;
using Livraria.API.Services.Publishers;
using Livraria.API.Services.Rentals;
using Livraria.API.Validator;
using Microsoft.CodeAnalysis.Options;
using System.ComponentModel;

namespace Livraria.API
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
            services.AddDbContext<LibraryContext>(
                context => context.UseMySql(Configuration.GetConnectionString("MySqlConnection"))
                );

            services.AddControllers()
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<UserValidator>())
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<BookValidator>())
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<PublisherValidator>())
                .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<RentalValidator>())
                    .AddNewtonsoftJson(
                        opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

            services.AddCors(options => {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:8080",
                "http://10.0.0.236:8080", "http://testfront1.loca.lt"));
            });


            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IRentalService, RentalService>();

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            })
                .AddApiVersioning(options =>
                {
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.ReportApiVersions = true;
                });

            var apiProviderDescription = services.BuildServiceProvider()
                .GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(options =>
            {

                foreach (var description in apiProviderDescription.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                        description.GroupName,
                        new Microsoft.OpenApi.Models.OpenApiInfo()
                        {
                            Title = "Library API",
                            Version = description.ApiVersion.ToString(),
                            Description = "Book Store REST API",
                            Contact = new Microsoft.OpenApi.Models.OpenApiContact
                            {
                                Name = "Artur Gonçalves",
                                Email = "arturgoncalves00000@gmail.com",
                                Url = new Uri("https://github.com/ArturGoncalvesDev")
                            }
                        }
                    );
                }


                var xmlCommentsFiles = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFiles);

                options.IncludeXmlComments(xmlCommentsFullPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider apiDescriptionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger()
                .UseSwaggerUI(options =>
                {
                    foreach (var description in apiDescriptionProvider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }

                    options.RoutePrefix = "";
                });

            app.UseCors(
                x => x.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader()
            );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
