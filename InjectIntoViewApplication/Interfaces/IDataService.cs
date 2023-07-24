using InjectIntoViewApplication.Models;

namespace InjectIntoViewApplication.Interfaces;

#pragma warning disable CS8603, CS8618
/// <summary>
/// Responsible for read data from backend database
/// </summary>
public interface IDataService
{
    /// <summary>
    /// Get list of states
    /// </summary>
    /// <returns></returns>
    List<StateLookup> GetStates();
    /// <summary>
    /// Get list of genders
    /// </summary>
    /// <returns></returns>
    List<Gender> GetGenders();
}