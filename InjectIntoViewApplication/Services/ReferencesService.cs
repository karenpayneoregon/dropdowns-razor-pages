using InjectIntoViewApplication.Data;
using InjectIntoViewApplication.Interfaces;
using InjectIntoViewApplication.Models;

namespace InjectIntoViewApplication.Services;

#pragma warning disable CS8603, CS8618
public class ReferencesService : IReferencesService
{
    public IConfiguration Configuration { get; }

    public ReferencesService(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public List<StateLookup> GetStates()
    {
        var connectionString = Configuration.GetConnectionString("CountriesConnection");
        using var context = new Context(connectionString);
        return context.StateLookup.ToList();
    }

    public List<Gender> GetGenders()
    {
        var connectionString = Configuration.GetConnectionString("CountriesConnection");
        using var context = new Context(connectionString);

        return context.Gender.ToList();
    }

}