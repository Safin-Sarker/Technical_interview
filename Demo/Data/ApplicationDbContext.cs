using Demo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Demo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<SkillDay> SkillDays { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var foodConverter = new ValueConverter<List<string>, string>(
                v => string.Join(";", v),
                v => v.Split(';', StringSplitOptions.None).ToList()
            );
            var foodComparer = new ValueComparer<List<string>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList()
            );

            modelBuilder.Entity<Event>()
                .Property(e => e.FoodAlternatives)
                .HasConversion(foodConverter)
                .Metadata.SetValueComparer(foodComparer);

            modelBuilder.Entity<SkillDay>()
                .HasOne(sd => sd.Responsible)
                .WithMany(a => a.Skilldays)
                .HasForeignKey(sd => sd.ResponsibleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>()
            .HasMany<Attendee>()
            .WithMany(a => a.AttendingEvents);


            modelBuilder.Entity<SkillDay>().HasKey(sd => sd.SkillDayId);
            modelBuilder.Entity<Event>().HasKey(e => e.EventId);
            modelBuilder.Entity<Attendee>().HasKey(a => a.AttendeeId);

            modelBuilder.Entity<Attendee>().HasData(
                new Attendee { AttendeeId = Guid.Parse("780e20f8-3393-4e7e-94c7-4ff714dada37"), Name = "Sunniva Pedersen", Email = "sunniva.pedersen@origin.no", Title = "LEAD", Department = "JAVA" },
                new Attendee { AttendeeId = Guid.Parse("7e8024a5-4b73-4b77-a27e-c66b9b041277"), Name = "Oliver Bakken", Email = "oliver.bakken@origin.no", Title = "LEAD", Department = "JAVA" },
                new Attendee { AttendeeId = Guid.Parse("6735a525-7ed5-4ed1-829b-5e33c3124ce1"), Name = "Frida Vedvik", Email = "frida.vedvik@origin.no", Title = "LEAD", Department = "JAVA" },
                new Attendee { AttendeeId = Guid.Parse("6684a409-71be-4415-b221-ebee0667b6e0"), Name = "Camilla Fjeld", Email = "camilla.fjeld@origin.no", Title = "SENIOR", Department = "MICROSOFT" },
                new Attendee { AttendeeId = Guid.Parse("56a1bbb0-a096-4fba-ad1b-245d63daac37"), Name = "Leah Eide", Email = "leah.eide@origin.no", Title = "EXECUTIVE", Department = "JAVA" },
                new Attendee { AttendeeId = Guid.Parse("cb88041e-a34e-4c0f-b375-66e60287261b"), Name = "Marte Kristensen", Email = "marte.kristensen@origin.no", Title = "LEAD", Department = "UX" },
                new Attendee { AttendeeId = Guid.Parse("8b354640-6247-442c-84e5-d4779f89f322"), Name = "Jonas Edvardsen", Email = "jonas.edvardsen@origin.no", Title = "JUNIOR", Department = "JAVA" },
                new Attendee { AttendeeId = Guid.Parse("f58825e5-6765-47f7-beb7-d8183313945a"), Name = "Noah Kvarme", Email = "noah.kvarme@origin.no", Title = "JUNIOR", Department = "MICROSOFT" },
                new Attendee { AttendeeId = Guid.Parse("5b984b52-821b-486d-9fdc-0000710225b7"), Name = "Marte Smedsrud", Email = "marte.smedsrud@origin.no", Title = "EXECUTIVE", Department = "JAVA" },
                new Attendee { AttendeeId = Guid.Parse("eb913095-b15e-405e-b638-3b5f78f2e980"), Name = "Sindre Nygård", Email = "sindre.nygaard@origin.no", Title = "JUNIOR", Department = "JAVA" }
            );

            modelBuilder.Entity<SkillDay>().HasData(
               new SkillDay { SkillDayId = Guid.Parse("c63904d9-5129-4418-a07b-ae3d59fc3705"), Name = "SkillDay: Terrengsykling", Department = "JAVA", ResponsibleId = Guid.Parse("780e20f8-3393-4e7e-94c7-4ff714dada37") },
               new SkillDay { SkillDayId = Guid.Parse("b7b5fc68-8267-40de-a007-d883dc112a03"), Name = "SkillDay: Bordtennis", Department = "JAVA", ResponsibleId = Guid.Parse("7e8024a5-4b73-4b77-a27e-c66b9b041277") },
               new SkillDay { SkillDayId = Guid.Parse("425213fe-8d55-4fc6-9aa8-3df7a2f78f49"), Name = "SkillDay: Rytter", Department = "JAVA", ResponsibleId = Guid.Parse("6735a525-7ed5-4ed1-829b-5e33c3124ce1") },
               new SkillDay { SkillDayId = Guid.Parse("d7b259a9-a713-4d3e-ab99-5a7962d8655f"), Name = "SkillDay: Maratonsvømming", Department = "MICROSOFT", ResponsibleId = Guid.Parse("6684a409-71be-4415-b221-ebee0667b6e0") },
               new SkillDay { SkillDayId = Guid.Parse("addc06d6-0b37-4a88-b861-0582d9e62d00"), Name = "SkillDay: Taekwondo", Department = "JAVA", ResponsibleId = Guid.Parse("56a1bbb0-a096-4fba-ad1b-245d63daac37") },
               new SkillDay { SkillDayId = Guid.Parse("c4541f82-d18f-44cd-9c4b-8fcaa274785a"), Name = "SkillDay: Fekting", Department = "UX", ResponsibleId = Guid.Parse("cb88041e-a34e-4c0f-b375-66e60287261b") },
               new SkillDay { SkillDayId = Guid.Parse("4504080d-6532-4888-a08d-5f0b0f68112a"), Name = "SkillDay: Sportsklatring", Department = "JAVA", ResponsibleId = Guid.Parse("8b354640-6247-442c-84e5-d4779f89f322") },
               new SkillDay { SkillDayId = Guid.Parse("5b42228f-3a54-4651-b417-c4287dba47ca"), Name = "SkillDay: Rugby", Department = "MICROSOFT", ResponsibleId = Guid.Parse("f58825e5-6765-47f7-beb7-d8183313945a") },
               new SkillDay { SkillDayId = Guid.Parse("fa175f37-a78e-450e-8173-75c7f9203999"), Name = "SkillDay: Softball", Department = "JAVA", ResponsibleId = Guid.Parse("5b984b52-821b-486d-9fdc-0000710225b7") },
               new SkillDay { SkillDayId = Guid.Parse("08745bf6-1a56-44ac-9886-5e4d2641e92f"), Name = "SkillDay: BMX racing", Department = "JAVA", ResponsibleId = Guid.Parse("eb913095-b15e-405e-b638-3b5f78f2e980") }
           );

            modelBuilder.Entity<Event>().HasData(
              new Event { EventId = Guid.Parse("37659ba4-0f4a-4fb5-a76d-588bfdee1986"), Description = "Discover the joy of SkillDay Terrengsykling", Address = "Gamle Damvollen 6, Stavanger", Date = DateTime.Parse("2024-02-05T19:00:00"), ImageUrl = "https://source.unsplash.com/featured/?SkillDay%20Terrengsykling", OpenSpots = 1, FoodAlternatives = new List<string> { "Cobbler", "Ricotta Stuffed Ravioli" }, SkillDayId = Guid.Parse("c63904d9-5129-4418-a07b-ae3d59fc3705") },
              new Event { EventId = Guid.Parse("07840b21-8b2e-49b2-99f1-4e1bc65b58ad"), Description = "Join in on a session of SkillDay Terrengsykling", Address = "Kirkebråten 7, Stavanger", Date = DateTime.Parse("2024-02-23T17:00:00"), ImageUrl = "https://source.unsplash.com/featured/?SkillDay%20Terrengsykling", OpenSpots = 1, FoodAlternatives = new List<string> { "Sundae", "Pasta with Tomato and Basil" }, SkillDayId = Guid.Parse("c63904d9-5129-4418-a07b-ae3d59fc3705") },
              new Event { EventId = Guid.Parse("6d62483b-aa5c-461f-bf1a-2d5e5e3c489d"), Description = "Experience the rush of SkillDay Rytter", Address = "Kuvika 49, Stavanger", Date = DateTime.Parse("2024-02-24T20:30:00"), ImageUrl = "https://source.unsplash.com/featured/?SkillDay%20Rytter", OpenSpots = 0, FoodAlternatives = new List<string> { "Cheesecake", "Chicken Fajitas" }, SkillDayId = Guid.Parse("425213fe-8d55-4fc6-9aa8-3df7a2f78f49") },
              new Event { EventId = Guid.Parse("f3a3314e-a4fc-4fcc-97e9-b7c35330f04c"), Description = "Challenge yourself to learn SkillDay Rytter", Address = "Øvre Geiteryggløkka 8, Stavanger", Date = DateTime.Parse("2023-11-19T17:00:00"), ImageUrl = "https://source.unsplash.com/featured/?SkillDay%20Rytter", OpenSpots = 7, FoodAlternatives = new List<string> { "Frozen Yogurt", "Pierogi" }, SkillDayId = Guid.Parse("425213fe-8d55-4fc6-9aa8-3df7a2f78f49") },
              new Event { EventId = Guid.Parse("73469058-13b5-480a-afc5-1bd657bb1ff5"), Description = "Learn how to master SkillDay Rytter", Address = "Oskars Gate 74, Stavanger", Date = DateTime.Parse("2023-11-28T19:30:00"), ImageUrl = "https://source.unsplash.com/featured/?SkillDay%20Rytter", OpenSpots = 9, FoodAlternatives = new List<string> { "Upside Down Pineapple Cake", "Caesar Salad" }, SkillDayId = Guid.Parse("425213fe-8d55-4fc6-9aa8-3df7a2f78f49") },
              new Event { EventId = Guid.Parse("d18a568e-4529-49e9-8333-6a1dcdb493ee"), Description = "Get better at SkillDay Rytter", Address = "Kuhagen 9, Sola", Date = DateTime.Parse("2023-11-28T16:00:00"), ImageUrl = "https://source.unsplash.com/featured/?SkillDay%20Rytter", OpenSpots = 5, FoodAlternatives = new List<string> { "Upside Down Pineapple Cake", "Pork Sausage Roll" }, SkillDayId = Guid.Parse("425213fe-8d55-4fc6-9aa8-3df7a2f78f49") },
              new Event { EventId = Guid.Parse("59b81267-907e-45d0-9ed1-637637b54cab"), Description = "Get better at SkillDay Rytter", Address = "Gamle Korsgjerdet 0, Sola", Date = DateTime.Parse("2023-12-23T20:00:00"), ImageUrl = "https://source.unsplash.com/featured/?SkillDay%20Rytter", OpenSpots = 3, FoodAlternatives = new List<string> { "Pie", "Poke" }, SkillDayId = Guid.Parse("425213fe-8d55-4fc6-9aa8-3df7a2f78f49") },
              new Event { EventId = Guid.Parse("d6943a80-5c39-4583-92b5-16627957fef3"), Description = "Let's try SkillDay Maratonsvømming", Address = "Vestre Elvegjerdet 8, Sola", Date = DateTime.Parse("2024-01-24T18:30:00"), ImageUrl = "https://source.unsplash.com/featured/?SkillDay%20Maratonsvømming", OpenSpots = 6, FoodAlternatives = new List<string> { "Cupcake", "Poutine" }, SkillDayId = Guid.Parse("d7b259a9-a713-4d3e-ab99-5a7962d8655f") },
              new Event { EventId = Guid.Parse("056d1854-79dd-4c58-8bb3-61fb69a3af3f"), Description = "Experience the rush of SkillDay Taekwondo", Address = "Vestre Vassstien 32, Tjelta", Date = DateTime.Parse("2023-11-24T17:30:00"), ImageUrl = "https://source.unsplash.com/featured/?SkillDay%20Taekwondo", OpenSpots = 1, FoodAlternatives = new List<string> { "Frozen Yogurt", "Chicken Wings" }, SkillDayId = Guid.Parse("addc06d6-0b37-4a88-b861-0582d9e62d00") },
              new Event { EventId = Guid.Parse("ed574cd0-8607-41c2-9f06-eadda5ab6e48"), Description = "Explore ways to enjoy SkillDay Taekwondo", Address = "Camillasgate 1, Tjelta", Date = DateTime.Parse("2023-12-03T20:30:00"), ImageUrl = "https://source.unsplash.com/featured/?SkillDay%20Taekwondo", OpenSpots = 6, FoodAlternatives = new List<string> { "Ice Cream", "California Maki" }, SkillDayId = Guid.Parse("addc06d6-0b37-4a88-b861-0582d9e62d00") }
          );
        }
    }
}
