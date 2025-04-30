namespace Demo.Models
{
    public class Event
    {
        public Guid EventId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
        public int OpenSpots { get; set; }

        public List<string> FoodAlternatives { get; set; } = new List<string>();

        // Relationship with SkillDay
        public Guid SkillDayId { get; set; }
        public SkillDay SkillDay { get; set; }
    }
}
