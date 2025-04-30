using Microsoft.Extensions.Logging;

namespace Demo.Models
{
    public class SkillDay
    {
        public Guid SkillDayId { get; set; }
        public string Name { get; set; }
        public Guid ResponsibleId { get; set; }
        public Attendee Responsible { get; set; } // navigation Property
        public string Department { get; set; }

        // Optional navigation property
        public List<Event> Events { get; set; }

    }
}
