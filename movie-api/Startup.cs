﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using movie_api.Data;
using Swashbuckle.AspNetCore.Swagger;

namespace movie_api
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<IMovieSource, MovieSource>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(g=>{
                g.SwaggerDoc("v2",new Info
                {
                    Title="Movie API",
                    Version="1.0",
                    Description="Movie app that user can search any movie and get latest update info about it.",
                    Contact=new Contact { Name = "Gülcan", Email = "gulcan.arik@gmail.com", Url = "http://www.github.com/gulcann"}                    
                });
 
                g.IncludeXmlComments(Path.ChangeExtension(typeof(Startup).Assembly.Location, ".xml"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("MyPolicy");
            // app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(s=>{
                s.SwaggerEndpoint("/swagger/v2/swagger.json","Movie App");
            });
        }
    }
}
