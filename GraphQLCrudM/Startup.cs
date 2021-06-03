using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLCrudM.Estructura;
using GraphQLCrudM.IServicio;
using GraphQLCrudM.Servicio;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQLCrudM
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGeneroServicio, GeneroServicio>();
            services.AddSingleton<IMusicaServicio, MusicaServicio>();

            services.AddGraphQL(x=> SchemaBuilder.New()
                .AddServices(x)
                .AddType<GeneroTipo>()
                .AddType<MusicaTipo>()
                .AddQueryType<Query>()
                .AddMutationType<Mutacion>()
                .Create()
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UsePlayground(new PlaygroundOptions
                {
                    QueryPath = "/api",
                    Path="/Playground"
                }) ;
            }

            app.UseGraphQL("/api");
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("GRAPHQL CRUD!");
                });
            });
        }
    }
}
