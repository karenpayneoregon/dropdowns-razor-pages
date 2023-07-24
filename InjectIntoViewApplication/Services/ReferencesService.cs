using InjectIntoViewApplication.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InjectIntoViewApplication.Services;

#pragma warning disable CS8603, CS8618
public class ReferencesService : IReferencesService
{
    public IDataService DataService { get; }
    public List<SelectListItem> Genders { get; set; }
    public List<SelectListItem> States { get; set; }

    public ReferencesService(IDataService dataService)
    {
        DataService = dataService;

        Genders = DataService.GetGenders().Select(g =>
            new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = g.Type
            }).ToList();

        States = DataService.GetStates().Select(sl =>
            new SelectListItem
            {
                Value = sl.Id.ToString(),
                Text = sl.StateName
            }).ToList();
    }
}