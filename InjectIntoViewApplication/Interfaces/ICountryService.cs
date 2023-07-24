using InjectIntoViewApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InjectIntoViewApplication.Interfaces;

#pragma warning disable CS8618
public interface ICountry
{
    public List<SelectListItem> Countries { get; set; }
    public string Name { get; set; }
    public string Iso { get; set; }
    public Countries GetCountryByIso(string iso);
}

public interface IReferencesService
{
    public List<SelectListItem> Genders { get; set; }
    public List<SelectListItem> States { get; set; }
    public List<StateLookup> GetStates();
    public List<Gender> GetGenders();
}