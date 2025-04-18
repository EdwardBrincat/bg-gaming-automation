using Bg_PageObjects.Login;
using Bg_PageObjects.Sidebar;
using Microsoft.Extensions.DependencyInjection;

namespace Sc_Casino_PageObjects;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddCasinoPageObjects(this IServiceCollection services)
	{
        services.AddScoped<LoginPage>();
        services.AddScoped<SideBarPage>();
	
		return services;
	}
}