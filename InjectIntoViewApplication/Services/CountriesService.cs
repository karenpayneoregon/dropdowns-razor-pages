using InjectIntoViewApplication.Data;
using InjectIntoViewApplication.Interfaces;
using InjectIntoViewApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

        var connectionString = Configuration.GetConnectionString("ReferencesConnection");
        using var context = new Context(connectionString);

        Countries = context.Countries.AsNoTracking().Select(c =>
            new SelectListItem
            {
                Value = c.Iso,
                Text = c.Name
            }).ToList();

        // optional 
        Countries.Insert(0,new SelectListItem("Select","0"));
        Countries[0].Disabled = true;

    }

    /// <summary>
    /// Get a country by it's ISO value
    /// </summary>
    public Countries GetCountryByIso(string iso)
    {
        var connectionString = Configuration.GetConnectionString("ReferencesConnection");
        using var context = new Context(connectionString);
        return context.Countries.FirstOrDefault(x => x.Iso == iso);
    }
}