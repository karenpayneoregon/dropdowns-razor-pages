using InjectIntoViewApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InjectIntoViewApplication.Interfaces;

#pragma warning disable CS8618
public interface ICountryService
{
    public List<SelectListItem> Countries { get; set; }
    public string Name { get; set; }
    public string Iso { get; set; }
    public Countries GetCountryByIso(string iso);
}