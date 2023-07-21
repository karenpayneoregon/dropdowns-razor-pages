using InjectIntoViewApplication.Data;
using InjectIntoViewApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

#pragma warning disable CS8618

namespace InjectIntoViewApplication.Classes;

public interface ICountryService
{
    public List<SelectListItem> Countries { get; set; }
    public string Name { get; set; }
    public string Iso { get; set; }
    public Countries GetCountryByIso(string iso);
}
public class CountriesModel : ICountryService
{
    public List<SelectListItem> Countries { get; set; }
    public string Name { get; set; }
    public string Iso { get; set; }
    public IConfiguration Configuration { get; }
    public CountriesModel(IConfiguration configuration)
    {
        Configuration = configuration;

        var connectionString = Configuration.GetConnectionString("CountriesConnection");
        using var context = new Context(connectionString);

        Countries = context.Countries.Select(a =>
            new SelectListItem
            {
                Value = a.Iso,
                Text = a.Name
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
