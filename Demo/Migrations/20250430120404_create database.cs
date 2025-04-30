using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class createdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Attendees",
                columns: table => new
                {
                    AttendeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttendingEventIds = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendees", x => x.AttendeeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillDays",
                columns: table => new
                {
                    SkillDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsibleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillDays", x => x.SkillDayId);
                    table.ForeignKey(
                        name: "FK_SkillDays_Attendees_ResponsibleId",
                        column: x => x.ResponsibleId,
                        principalTable: "Attendees",
                        principalColumn: "AttendeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenSpots = table.Column<int>(type: "int", nullable: false),
                    FoodAlternatives = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkillDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Attendees_AttendeeId",
                        column: x => x.AttendeeId,
                        principalTable: "Attendees",
                        principalColumn: "AttendeeId");
                    table.ForeignKey(
                        name: "FK_Events_SkillDays_SkillDayId",
                        column: x => x.SkillDayId,
                        principalTable: "SkillDays",
                        principalColumn: "SkillDayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Attendees",
                columns: new[] { "AttendeeId", "AttendingEventIds", "Department", "Email", "Name", "Title" },
                values: new object[,]
                {
                    { new Guid("56a1bbb0-a096-4fba-ad1b-245d63daac37"), "[]", "JAVA", "leah.eide@origin.no", "Leah Eide", "EXECUTIVE" },
                    { new Guid("5b984b52-821b-486d-9fdc-0000710225b7"), "[]", "JAVA", "marte.smedsrud@origin.no", "Marte Smedsrud", "EXECUTIVE" },
                    { new Guid("6684a409-71be-4415-b221-ebee0667b6e0"), "[]", "MICROSOFT", "camilla.fjeld@origin.no", "Camilla Fjeld", "SENIOR" },
                    { new Guid("6735a525-7ed5-4ed1-829b-5e33c3124ce1"), "[]", "JAVA", "frida.vedvik@origin.no", "Frida Vedvik", "LEAD" },
                    { new Guid("780e20f8-3393-4e7e-94c7-4ff714dada37"), "[]", "JAVA", "sunniva.pedersen@origin.no", "Sunniva Pedersen", "LEAD" },
                    { new Guid("7e8024a5-4b73-4b77-a27e-c66b9b041277"), "[]", "JAVA", "oliver.bakken@origin.no", "Oliver Bakken", "LEAD" },
                    { new Guid("8b354640-6247-442c-84e5-d4779f89f322"), "[]", "JAVA", "jonas.edvardsen@origin.no", "Jonas Edvardsen", "JUNIOR" },
                    { new Guid("cb88041e-a34e-4c0f-b375-66e60287261b"), "[]", "UX", "marte.kristensen@origin.no", "Marte Kristensen", "LEAD" },
                    { new Guid("eb913095-b15e-405e-b638-3b5f78f2e980"), "[]", "JAVA", "sindre.nygaard@origin.no", "Sindre Nygård", "JUNIOR" },
                    { new Guid("f58825e5-6765-47f7-beb7-d8183313945a"), "[]", "MICROSOFT", "noah.kvarme@origin.no", "Noah Kvarme", "JUNIOR" }
                });

            migrationBuilder.InsertData(
                table: "SkillDays",
                columns: new[] { "SkillDayId", "Department", "Name", "ResponsibleId" },
                values: new object[,]
                {
                    { new Guid("08745bf6-1a56-44ac-9886-5e4d2641e92f"), "JAVA", "SkillDay: BMX racing", new Guid("eb913095-b15e-405e-b638-3b5f78f2e980") },
                    { new Guid("425213fe-8d55-4fc6-9aa8-3df7a2f78f49"), "JAVA", "SkillDay: Rytter", new Guid("6735a525-7ed5-4ed1-829b-5e33c3124ce1") },
                    { new Guid("4504080d-6532-4888-a08d-5f0b0f68112a"), "JAVA", "SkillDay: Sportsklatring", new Guid("8b354640-6247-442c-84e5-d4779f89f322") },
                    { new Guid("5b42228f-3a54-4651-b417-c4287dba47ca"), "MICROSOFT", "SkillDay: Rugby", new Guid("f58825e5-6765-47f7-beb7-d8183313945a") },
                    { new Guid("addc06d6-0b37-4a88-b861-0582d9e62d00"), "JAVA", "SkillDay: Taekwondo", new Guid("56a1bbb0-a096-4fba-ad1b-245d63daac37") },
                    { new Guid("b7b5fc68-8267-40de-a007-d883dc112a03"), "JAVA", "SkillDay: Bordtennis", new Guid("7e8024a5-4b73-4b77-a27e-c66b9b041277") },
                    { new Guid("c4541f82-d18f-44cd-9c4b-8fcaa274785a"), "UX", "SkillDay: Fekting", new Guid("cb88041e-a34e-4c0f-b375-66e60287261b") },
                    { new Guid("c63904d9-5129-4418-a07b-ae3d59fc3705"), "JAVA", "SkillDay: Terrengsykling", new Guid("780e20f8-3393-4e7e-94c7-4ff714dada37") },
                    { new Guid("d7b259a9-a713-4d3e-ab99-5a7962d8655f"), "MICROSOFT", "SkillDay: Maratonsvømming", new Guid("6684a409-71be-4415-b221-ebee0667b6e0") },
                    { new Guid("fa175f37-a78e-450e-8173-75c7f9203999"), "JAVA", "SkillDay: Softball", new Guid("5b984b52-821b-486d-9fdc-0000710225b7") }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Address", "AttendeeId", "Date", "Description", "FoodAlternatives", "ImageUrl", "OpenSpots", "SkillDayId" },
                values: new object[,]
                {
                    { new Guid("056d1854-79dd-4c58-8bb3-61fb69a3af3f"), "Vestre Vassstien 32, Tjelta", null, new DateTime(2023, 11, 24, 17, 30, 0, 0, DateTimeKind.Unspecified), "Experience the rush of SkillDay Taekwondo", "Frozen Yogurt;Chicken Wings", "https://source.unsplash.com/featured/?SkillDay%20Taekwondo", 1, new Guid("addc06d6-0b37-4a88-b861-0582d9e62d00") },
                    { new Guid("07840b21-8b2e-49b2-99f1-4e1bc65b58ad"), "Kirkebråten 7, Stavanger", null, new DateTime(2024, 2, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), "Join in on a session of SkillDay Terrengsykling", "Sundae;Pasta with Tomato and Basil", "https://source.unsplash.com/featured/?SkillDay%20Terrengsykling", 1, new Guid("c63904d9-5129-4418-a07b-ae3d59fc3705") },
                    { new Guid("37659ba4-0f4a-4fb5-a76d-588bfdee1986"), "Gamle Damvollen 6, Stavanger", null, new DateTime(2024, 2, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), "Discover the joy of SkillDay Terrengsykling", "Cobbler;Ricotta Stuffed Ravioli", "https://source.unsplash.com/featured/?SkillDay%20Terrengsykling", 1, new Guid("c63904d9-5129-4418-a07b-ae3d59fc3705") },
                    { new Guid("59b81267-907e-45d0-9ed1-637637b54cab"), "Gamle Korsgjerdet 0, Sola", null, new DateTime(2023, 12, 23, 20, 0, 0, 0, DateTimeKind.Unspecified), "Get better at SkillDay Rytter", "Pie;Poke", "https://source.unsplash.com/featured/?SkillDay%20Rytter", 3, new Guid("425213fe-8d55-4fc6-9aa8-3df7a2f78f49") },
                    { new Guid("6d62483b-aa5c-461f-bf1a-2d5e5e3c489d"), "Kuvika 49, Stavanger", null, new DateTime(2024, 2, 24, 20, 30, 0, 0, DateTimeKind.Unspecified), "Experience the rush of SkillDay Rytter", "Cheesecake;Chicken Fajitas", "https://source.unsplash.com/featured/?SkillDay%20Rytter", 0, new Guid("425213fe-8d55-4fc6-9aa8-3df7a2f78f49") },
                    { new Guid("73469058-13b5-480a-afc5-1bd657bb1ff5"), "Oskars Gate 74, Stavanger", null, new DateTime(2023, 11, 28, 19, 30, 0, 0, DateTimeKind.Unspecified), "Learn how to master SkillDay Rytter", "Upside Down Pineapple Cake;Caesar Salad", "https://source.unsplash.com/featured/?SkillDay%20Rytter", 9, new Guid("425213fe-8d55-4fc6-9aa8-3df7a2f78f49") },
                    { new Guid("d18a568e-4529-49e9-8333-6a1dcdb493ee"), "Kuhagen 9, Sola", null, new DateTime(2023, 11, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), "Get better at SkillDay Rytter", "Upside Down Pineapple Cake;Pork Sausage Roll", "https://source.unsplash.com/featured/?SkillDay%20Rytter", 5, new Guid("425213fe-8d55-4fc6-9aa8-3df7a2f78f49") },
                    { new Guid("d6943a80-5c39-4583-92b5-16627957fef3"), "Vestre Elvegjerdet 8, Sola", null, new DateTime(2024, 1, 24, 18, 30, 0, 0, DateTimeKind.Unspecified), "Let's try SkillDay Maratonsvømming", "Cupcake;Poutine", "https://source.unsplash.com/featured/?SkillDay%20Maratonsvømming", 6, new Guid("d7b259a9-a713-4d3e-ab99-5a7962d8655f") },
                    { new Guid("ed574cd0-8607-41c2-9f06-eadda5ab6e48"), "Camillasgate 1, Tjelta", null, new DateTime(2023, 12, 3, 20, 30, 0, 0, DateTimeKind.Unspecified), "Explore ways to enjoy SkillDay Taekwondo", "Ice Cream;California Maki", "https://source.unsplash.com/featured/?SkillDay%20Taekwondo", 6, new Guid("addc06d6-0b37-4a88-b861-0582d9e62d00") },
                    { new Guid("f3a3314e-a4fc-4fcc-97e9-b7c35330f04c"), "Øvre Geiteryggløkka 8, Stavanger", null, new DateTime(2023, 11, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), "Challenge yourself to learn SkillDay Rytter", "Frozen Yogurt;Pierogi", "https://source.unsplash.com/featured/?SkillDay%20Rytter", 7, new Guid("425213fe-8d55-4fc6-9aa8-3df7a2f78f49") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Events_AttendeeId",
                table: "Events",
                column: "AttendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_SkillDayId",
                table: "Events",
                column: "SkillDayId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillDays_ResponsibleId",
                table: "SkillDays",
                column: "ResponsibleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SkillDays");

            migrationBuilder.DropTable(
                name: "Attendees");
        }
    }
}
