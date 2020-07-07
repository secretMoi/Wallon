using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestServer.Data;
using RestServer.Data.LiaisonsTachesLocataires;
using RestServer.Data.Locataires;
using RestServer.Data.Taches;

namespace RestServer
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
			// initialise le service de connexion à la bdd
			services.AddDbContext<WallonsContext>(opt => opt.UseSqlServer(
				Configuration.GetConnectionString("WallonsConnection")
			));

			services.AddControllers();

			// initialise l'auto mapper
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			// ajoute une instance d'objet par client
			// le 2è arg permet de switcher facilement d'un repo à l'autre par dépendance d'injection (grâce à l'interface)
			services.AddScoped<ILocataireRepo, LocataireRepo>();
			services.AddScoped<ITacheRepo, TacheRepo>();
			services.AddScoped<ILiaisonTacheLocataireRepo, LiaisonTacheLocataireRepo>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
