namespace Demo.Models
{
    public class Attendee
    {
        public Guid AttendeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }

        public List<Guid> AttendingEventIds { get; set; } = new List<Guid>();

        public List<Event> AttendingEvents { get; set; }

        public ICollection<SkillDay> Skilldays { get; set; } = new List<SkillDay>();
    }
}
