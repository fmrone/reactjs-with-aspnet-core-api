using AutoMapper;
using FredericoRibeiro.Produto.Application.Services;
using FredericoRibeiro.Produto.Repository;
using FredericoRibeiro.Produto.Repository.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace FredericoRibeiro.Produto.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Mapper.Initialize(config =>
            {
                config.AddProfile<RepositoryMapperProfile>();
                config.AddProfile<WepApiMapperProfile>();
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1.0", new Swashbuckle.AspNetCore.Swagger.Info {
                    Title = "FredericoRibeiro.Produto.WebApi", Version = "v1.0"
                });
            });

            services.AddDbContext<ProdutoContext>(options =>
                options.UseInMemoryDatabase("InMemoryDatabase"));

            // Add dependency injection
            services.AddScoped<Domain.Services.IProdutoService, ProdutoService>();
            services.AddScoped<Domain.Repositories.IProdutoReadOnlyRepository, ProdutoRepository>();
            services.AddScoped<Domain.Repositories.IProdutoWriteOnlyRepository, ProdutoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json/",
                    "FredericoRibeiro.Produto.WebApi");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseCors("CorsPolicy");
            app.UseMvc();
        }
    }
}
