using InjectIntoViewApplication.Interfaces;
using InjectIntoViewApplication.Services;

namespace InjectIntoViewApplication.Classes;

public static class DIRegistrations
{
    public static IServiceCollection RegisterServicesLogic(this IServiceCollection services)
    {
        services.AddScoped<ICountry, CountriesService>();
        services.AddSingleton<IDataService, DataService>();
        services.AddSingleton<IReferencesService, ReferencesService>();
        return services;
    }
}
