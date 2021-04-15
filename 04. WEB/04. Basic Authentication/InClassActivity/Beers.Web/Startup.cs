using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Beers.Data;
using Microsoft.EntityFrameworkCore;
using Beers.Services.Contracts;
using Beers.Services;
using Beers.Web.Helpers;

namespace Beers.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddControllers()
				.AddNewtonsoftJson(options =>
					options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
				);

			services.AddDbContext<BeerDbContext>(options =>
			{
				options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=BeerOverflow;Integrated Security=True;");
			});

			services.AddScoped<IBeerService, BeerService>();
			services.AddScoped<IBreweryService, BreweryService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IAuthHelper, AuthHelper>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
