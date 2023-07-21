# About

A simple example for injection into a view

![Figure1](assets/figure1.png)

## Service

```csharp
public interface ICountryService
{
    public List<SelectListItem> Countries { get; set; }
    public string Name { get; set; }
    public string Iso { get; set; }
}
public class CountriesModel : ICountryService
{
    public List<SelectListItem> Countries { get; set; }
    public string Name { get; set; }
    public string Iso { get; set; }

    public CountriesModel()
    {
        using var context = new Context();

        Countries = context.Countries.Select(a =>
            new SelectListItem
            {
                Value = a.Iso,
                Text = a.Name
            }).ToList();
    }
}

```

## Program.cs

Register ICountryService service

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddScoped<ICountryService, CountriesModel>();
```

## Index Page

In the view add

```csharp
@inject ICountryService CountriesModel
```

Construct the DropDown

```html
<div class="row g-3 align-items-center mb-2 mt-1">
    <div class="col-3 text-end ms-1">
        @* ReSharper disable once Html.IdNotResolved *@
        <label for="countries">Countries:</label>
    </div>
    <div class="col me-2">
        @Html.DropDownListFor(model => 
            model.CountryCode1, 
            Model.CountryList,
            new {
                @class = "form-select",
                style = "width:18.5em;",
                id = "countries"
            })
    </div>
</div>
```

### Index code behind

In the actual front end code there are two DropDowns, for the DropDown shown above the following property CountryCode1 is the selected item while CountryCode2 is for a conventional HTML tag version of a DropDown.

```csharp
public class IndexModel : PageModel
{
    public readonly ICountryService CountryService;
    public List<SelectListItem> CountryList { get; set; }
    [BindProperty]
    public string CountryCode1 { get; set; }
    [BindProperty]
    public string CountryCode2 { get; set; }

    public IndexModel(ICountryService countryService)
    {
        CountryService = countryService;
        CountryList = countryService.Countries;
    }

    public void OnGet()
    {

    }
    
    public void OnPost()
    {
       Log.Information("Code 1 {P1}", CountryCode1);
       Log.Information("Code 2 {P1}", CountryCode2);
    }
}
```
