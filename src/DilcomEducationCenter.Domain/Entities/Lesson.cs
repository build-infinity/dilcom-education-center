namespace  DilcomEducationCenter.Domain.Entities;

public sealed class Lesson
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public int TeacherId { get; set; }
    public int RoomId { get; set; }
    public int TimeSlotId { get; set; }
    public DateOnly Date { get; set; }

    public ICollection<StudentAttendance> StudentAttendances { get; set; } = new List<StudentAttendance>();
    public Teacher Teacher { get; set; } = null!;
    public Group Group { get; set; } = null!;
    public TimeSlot TimeSlot { get; set; } = null!; 
    public Room Room { get; set; } = null!;
}