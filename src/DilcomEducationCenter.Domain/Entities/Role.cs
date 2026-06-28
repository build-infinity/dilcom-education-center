namespace DilcomEducationCenter.Domain.Entities;

public sealed class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedOn { get; set; }

    public ICollection<User> Users { get; set; } = new List<User>();
}