using InjectIntoViewApplication.Data;
using InjectIntoViewApplication.Interfaces;
using InjectIntoViewApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InjectIntoViewApplication.Services;

#pragma warning disable CS8603, CS8618
public class ReferencesService : IReferencesService
{
    public IConfiguration Configuration { get; }
    public List<SelectListItem> Genders { get; set; }
    public List<SelectListItem> States { get; set; }

    public ReferencesService(IConfiguration configuration)
    {
        Configuration = configuration;

        Genders = GetGenders().Select(g =>
            new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Type
            }).ToList();

        States = GetStates().Select(sl =>
            new SelectListItem
            {
                Value = sl.Id.ToString(),
                Text = sl.StateName
            }).ToList();
    }

    public List<StateLookup> GetStates()
    {
        var connectionString = Configuration.GetConnectionString("ReferencesConnection");
        using var context = new Context(connectionString);
        return context.StateLookup.ToList();
    }

    public List<Gender> GetGenders()
    {
        var connectionString = Configuration.GetConnectionString("ReferencesConnection");
        using var context = new Context(connectionString);

        return context.Gender.ToList();
    }

}