namespace DilcomEducationCenter.Domain.Entities;

public sealed class Room
{
    public Guid Id { get; set; }
    public short Number { get; set; }
    public DateTime CreatedOn { get; set; }
    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}