using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace ConditionalDropdownApp.Pages;
public class IndexModel : PageModel
{
    public void OnGet()
    {
        Priority = "Amber";
    }

    [BindProperty]
    public string Priority { get; set; }
    [BindProperty]
    public string Message { get; set; }

    public IActionResult OnPostGetSelectedPriority(IFormCollection data)
    {
        Message = Priority is null ?
            "<span style=\"color: crimson;font-weight: 400\">Nothing selected</span>" : 
            $"You selected <strong>{Priority}</strong>";

        return Page();
    }
}
