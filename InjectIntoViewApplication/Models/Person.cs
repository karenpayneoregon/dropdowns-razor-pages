#pragma warning disable CS8618
namespace InjectIntoViewApplication.Models;

public class Person
{
    public int Id { get; set; } 
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public StateLookup State { get; set; }
}
