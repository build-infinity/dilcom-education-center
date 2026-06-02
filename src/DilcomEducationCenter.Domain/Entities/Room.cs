namespace DilcomEducationCenter.Domain.Entities;

public sealed class Room
{
    public int Id { get; set; }
    public short Number { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}