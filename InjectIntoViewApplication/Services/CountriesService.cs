using InjectIntoViewApplication.Data;
using InjectIntoViewApplication.Interfaces;
using InjectIntoViewApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
#pragma warning disable CS8603

#pragma warning disable CS8618

namespace InjectIntoViewApplication.Services;

public class CountriesService : ICountry
{
    public List<SelectListItem> Countries { get; set; }
    public string Name { get; set; }
    public string Iso { get; set; }
    public IConfiguration Configuration { get; }
    public CountriesService(IConfiguration configuration)
    {
        Configuration = configuration;

        var connectionString = Configuration.GetConnectionString("CountriesConnection");
        using var context = new Context(connectionString);

        Countries = context.Countries.Select(c =>
            new SelectListItem
            {
                Value = c.Iso,
                Text = c.Name
            }).ToList();
    }

    /// <summary>
    /// Get a country by it's ISO value
    /// </summary>
    public Countries GetCountryByIso(string iso)
    {
        var connectionString = Configuration.GetConnectionString("CountriesConnection");
        using var context = new Context(connectionString);
        return context.Countries.FirstOrDefault(x => x.Iso == iso);
    }
}