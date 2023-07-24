using InjectIntoViewApplication.Interfaces;
using InjectIntoViewApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Serilog;

#pragma warning disable CS8618

namespace InjectIntoViewApplication.Pages
{
    public class Index1Model : PageModel
    {
        public readonly IReferencesService ReferencesService;
        public List<SelectListItem> GenderList { get; set; }
        public List<SelectListItem> StatesList { get; set; }
        [BindProperty]
        public Person Person { get; set; }


        [BindProperty]
        public int GenderIdentifier { get; set; }

        [BindProperty]
        public int StateIdentifier { get; set; }

        public Index1Model(IReferencesService referencesService)
        {
            ReferencesService = referencesService;
            GenderList = ReferencesService.Genders;
            StatesList = ReferencesService.States;
            Person = new Person();
        }

        public void OnGet()
        {
        }

        public RedirectToPageResult OnPost()
        {
            
            Person.Gender = ReferencesService.GetGenders().FirstOrDefault(x => x.Id == GenderIdentifier)!;
            Person.State = ReferencesService.GetStates().FirstOrDefault(x => x.Id == StateIdentifier)!;
            Log.Information("First name '{P1}' Last name {P2} Gender {P3} State {P4}", 
                Person.FirstName, 
                Person.LastName, 
                Person.Gender!.Type,
                Person.State.StateAbbrev);

            return RedirectToPage("/Index");


        }
    }
}
