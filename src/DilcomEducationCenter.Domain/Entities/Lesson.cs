namespace  DilcomEducationCenter.Domain.Entities;

public sealed class Lesson
{
    public Guid Id { get; set; }
    public Guid GroupId { get; set; }
    public Guid TeacherId { get; set; }
    public Guid RoomId { get; set; }
    public Guid TimeSlotId { get; set; }
    public DateOnly Date { get; set; }

    public ICollection<StudentAttendance> StudentAttendances { get; set; } = new List<StudentAttendance>();
    public Teacher Teacher { get; set; } = null!;
    public Group Group { get; set; } = null!;
    public TimeSlot TimeSlot { get; set; } = null!; 
    public Room Room { get; set; } = null!;
}