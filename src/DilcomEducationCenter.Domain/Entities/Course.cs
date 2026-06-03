
namespace DilcomEducationCenter.Domain.Entities;

public sealed class Course
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int DurationWeeks { get; set; }
    public string Description { get; set; } = null!;
    public DateTime UpdatedOn { get; set; }
    public DateTime CreatedOn { get; set; }

    public ICollection<Group> Groups { get; set; } = new List<Group>();
}