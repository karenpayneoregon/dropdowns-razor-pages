using Microsoft.AspNetCore.Mvc.Rendering;

namespace InjectIntoViewApplication.Interfaces;

#pragma warning disable CS8618
public interface IReferencesService
{
    public List<SelectListItem> Genders { get; set; }
    public List<SelectListItem> States { get; set; }

}