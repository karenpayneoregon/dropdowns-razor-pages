using InjectIntoViewApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;
#pragma warning disable CS8618

namespace InjectIntoViewApplication.Pages;
public class IndexModel : PageModel
{
    public readonly ICountry CountryService;
    public List<SelectListItem> CountryList { get; set; }
    [BindProperty]
    public string CountryCode1 { get; set; }
    [BindProperty]
    public string CountryCode2 { get; set; }

    public IndexModel(ICountry countryService)
    {
        CountryService = countryService;
        CountryList = countryService.Countries;
    }

    public void OnGet()
    {

    }
    
    public void OnPost()
    {
       var selectedCountry = CountryService.GetCountryByIso(CountryCode1);
       Log.Information("Code 1 {P1}", CountryCode1);
       Log.Information("    Country id: {P1}", selectedCountry.Id);
       Log.Information("    Country Name: {P1}", selectedCountry.Name);

       Log.Information("Code 2 {P1}\n", CountryCode2);
    }
}
