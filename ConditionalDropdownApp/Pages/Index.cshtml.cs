using ConditionalDropdownApp.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ConditionalDropdownApp.Pages;
public class IndexModel : PageModel
{
    public void OnGet()
    {
        Priority = StaticData
            .Colors
            .OrderBy(x => Random.Shared.Next())
            .ToList()
            .FirstOrDefault();
    }

    [BindProperty]
    public string Priority { get; set; }
    [BindProperty]
    public string Message { get; set; }


    public IActionResult OnPostGetSelectedPriority()
    {
        Message = Priority is null ?
            "<span style=\"color: crimson;font-weight: 400\">Nothing selected</span>" : 
            $"You selected <strong>{Priority}</strong>";

        return Page();
    }
}
