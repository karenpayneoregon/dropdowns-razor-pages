using ConditionalDropdownApp.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace ConditionalDropdownApp.Pages;
public class IndexModel : PageModel
{
    public void OnGet()
    {
        Colors = StaticData.Colors;
        Colors.Shuffle();
        Priority = Colors.FirstOrDefault();
    }

    [BindProperty]
    public string Priority { get; set; }
    [BindProperty]
    public string Message { get; set; }
    [BindProperty]
    public List<string> Colors { get; set; }

    public IActionResult OnPostGetSelectedPriority(IFormCollection data)
    {
        Message = Priority is null ?
            "<span style=\"color: crimson;font-weight: 400\">Nothing selected</span>" : 
            $"You selected <strong>{Priority}</strong>";

        return Page();
    }
}
