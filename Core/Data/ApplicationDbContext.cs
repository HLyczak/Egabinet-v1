
using Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Egabinet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<TimeSheet> TimeSheet { get; set; }
        public DbSet<Nurse> Nurse { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Specialization> Specialization { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeSheet>().HasOne(p => p.Doctor).WithMany(s => s.TimeSheet).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TimeSheet>().HasOne(p => p.Patient).WithMany(s => s.TimeSheet).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TimeSheet>().HasOne(p => p.Room).WithMany(s => s.TimeSheet).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IdentityRole>().HasData
                (new IdentityRole { Name = "Administrator", Id = "72f2ff00-761f-4727-b07c-5381992b5e0a", NormalizedName = "ADMINISTRATOR" },
                new IdentityRole { Name = "Reader", Id = "c1eeb9bd-5412-495a-8abf-a4157f1b546d", NormalizedName = "READER" },
                new IdentityRole { Name = "Writer", Id = "04d94d89-fe74-43ba-b052-90d5f3dea95f", NormalizedName = "WRITER" }
                );

            modelBuilder.Entity<Specialization>().HasData
                (new Specialization { Id = "6a3d526e-1fb6-4de7-bde5-e0754fc58aec", Value = "Lekarz rodzinny" },
                 new Specialization { Id = "4e8effeb-0a99-4038-9420-0c543a3a28ac", Value = "Endokrynolog" },
                 new Specialization { Id = "e86959d5-6eed-45f7-b5cb-6b8f68a4d085", Value = "Laryngolog" },
                 new Specialization { Id = "690e47d4-996b-43b7-a23b-d9693cf5962c", Value = "Stomatolog" }
                );

            modelBuilder.Entity<Room>().HasData
             (new Room { Id = "d36af7ac-73cb-459e-847f-0abea3581814", Number = 1 },
              new Room { Id = "4b4e2a8f-ab04-40ab-827d-3c7789208e4c", Number = 2 },
              new Room { Id = "c5f12060-322b-42be-bba6-689e2e0c5721", Number = 3 },
              new Room { Id = "525e8058-b3a1-4a9f-83e5-355848d1e6c5", Number = 4 }
             );

            PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();

            //PasswordHash = hasher.HashPassword(null, "Admin123!")

            List<IdentityUser> users = new List<IdentityUser> {
                new IdentityUser { Id = "66126f74-f32b-435d-9e24-b3ed8b3d6011", UserName = "user1@op.pl", NormalizedUserName = "USER1@OP.PL", NormalizedEmail="USER1@OP.PL", Email = "user1@op.pl", EmailConfirmed = true },
                new IdentityUser { Id = "26dfb75e-5f31-4a54-9844-f019998a61d1", UserName = "user2@op.pl", NormalizedUserName = "USER2@OP.PL", NormalizedEmail="USER2@OP.PL", Email = "user2@op.pl", EmailConfirmed = true },
                new IdentityUser { Id = "64791af4-436d-4419-b3e1-14641bdb2493", UserName = "user3@op.pl", NormalizedUserName = "USER3@OP.PL", NormalizedEmail="USER3@OP.PL", Email = "user3@op.pl", EmailConfirmed = true },
                new IdentityUser { Id = "cef7f7aa-d198-4373-b441-926d8e52dbb1", UserName = "user4@op.pl", NormalizedUserName = "USER4@OP.PL", NormalizedEmail="USER4@OP.PL", Email = "user4@op.pl", EmailConfirmed = true },

                new IdentityUser { Id = "00221f79-bc71-4186-9e5d-bfd57a80a43f", UserName = "user5@op.pl", NormalizedUserName = "USER5@OP.PL", NormalizedEmail="USER5@OP.PL", Email = "user5@op.pl", EmailConfirmed = true },
                new IdentityUser { Id = "32923230-6c8c-4510-b73e-d9bcf2484879", UserName = "user6@op.pl", NormalizedUserName = "USER6@OP.PL", NormalizedEmail="USER6@OP.PL", Email = "user6@op.pl", EmailConfirmed = true },
                new IdentityUser { Id = "ed216c2a-3e1c-486f-b8ca-5f13bd8baee8", UserName = "user7@op.pl", NormalizedUserName = "USER7@OP.PL", NormalizedEmail="USER7@OP.PL", Email = "user7@op.pl", EmailConfirmed = true },
                new IdentityUser { Id = "c2ebef8b-eee6-4328-ba4d-f01a04fe4f83", UserName = "user8@op.pl", NormalizedUserName = "USER8@OP.PL", NormalizedEmail="USER8@OP.PL", Email = "user8@op.pl", EmailConfirmed = true },

                new IdentityUser { Id = "ef9632fc-d406-412f-9b7a-09b902db6dfa", UserName = "user9@op.pl", NormalizedUserName = "USER9@OP.PL", NormalizedEmail="USER9@OP.PL", Email = "user9@op.pl", EmailConfirmed = true },
                new IdentityUser { Id = "785a5776-fbba-4021-a263-4b9daade6ac8", UserName = "user10@op.pl", NormalizedUserName = "USER10@OP.PL", NormalizedEmail="USER10@OP.PL", Email = "user10@op.pl", EmailConfirmed = true },
                new IdentityUser { Id = "452db704-3650-457a-a7da-ca545a521776", UserName = "user11@op.pl", NormalizedUserName = "USER11@OP.PL", NormalizedEmail="USER11@OP.PL", Email = "user11@op.pl", EmailConfirmed = true },
                new IdentityUser { Id = "7fe50ba2-def6-4ac0-8b3e-87d3b4ce693f", UserName = "user12@op.pl", NormalizedUserName = "USER12@OP.PL", NormalizedEmail="USER12@OP.PL", Email = "user12@op.pl", EmailConfirmed = true }
            };
            modelBuilder.Entity<IdentityUser>().HasData(users);


            users[0].PasswordHash = hasher.HashPassword(users[0], "Admin123!");
            users[1].PasswordHash = hasher.HashPassword(users[1], "Admin123!");
            users[2].PasswordHash = hasher.HashPassword(users[2], "Admin123!");
            users[3].PasswordHash = hasher.HashPassword(users[3], "Admin123!");
            users[4].PasswordHash = hasher.HashPassword(users[4], "Admin123!");
            users[5].PasswordHash = hasher.HashPassword(users[5], "Admin123!");
            users[6].PasswordHash = hasher.HashPassword(users[6], "Admin123!");
            users[7].PasswordHash = hasher.HashPassword(users[7], "Admin123!");
            users[8].PasswordHash = hasher.HashPassword(users[8], "Admin123!");
            users[9].PasswordHash = hasher.HashPassword(users[9], "Admin123!");
            users[10].PasswordHash = hasher.HashPassword(users[10], "Admin123!");
            users[11].PasswordHash = hasher.HashPassword(users[11], "Admin123!");



            modelBuilder.Entity<Patient>().HasData
                (new Patient { Id = "9262b74c-f7b4-47ba-8fcf-087241096f34", UserId = "66126f74-f32b-435d-9e24-b3ed8b3d6011", Name = "Adam", Surname = "Nowak", Address = " Magnoliowa 5", Pesel = 85011259884 },
                new Patient { Id = "23159457-b301-4839-932a-3fd939f8b6c4", UserId = "26dfb75e-5f31-4a54-9844-f019998a61d1", Name = "Zofia", Surname = "Stanecka", Address = " Ostoja 5", Pesel = 78020607221 },
                new Patient { Id = "9de0d585-60a6-445c-910c-e26ccaf46274", UserId = "64791af4-436d-4419-b3e1-14641bdb2493", Name = "Austen", Surname = "Nowaki", Address = " Żeromskiego 4", Pesel = 95011259884 },
                new Patient { Id = "816c62f5-2b08-4042-8008-07a46b920921", UserId = "cef7f7aa-d198-4373-b441-926d8e52dbb1", Name = "Grzegorz", Surname = "Fus", Address = " Obozowa 15", Pesel = 65011259884 }
                 );
            modelBuilder.Entity<Nurse>().HasData
                (new Nurse { Id = "9ae453af-8db3-440c-b8d0-1c55299ce188", UserId = "00221f79-bc71-4186-9e5d-bfd57a80a43f", Name = "AZofia", Surname = "Stanecka", Address = " Różana 5", PermissionNumber = " 509853" },
                new Nurse { Id = "e40f8b49-f885-48c0-bb64-21c0d0813e88", UserId = "32923230-6c8c-4510-b73e-d9bcf2484879", Name = "Hanna", Surname = " Oklejka", Address = " Topografów 5", PermissionNumber = " 510053" },
                new Nurse { Id = "68041977-3f99-4e4f-ac71-0b03a3606750", UserId = "ed216c2a-3e1c-486f-b8ca-5f13bd8baee8", Name = "Anna ", Surname = " Austen", Address = " os. Kolorowe 8", PermissionNumber = " 169053" },
                new Nurse { Id = "965e09d6-0ed5-4e7a-8950-e252b1ae5380", UserId = "c2ebef8b-eee6-4328-ba4d-f01a04fe4f83", Name = "Glżbieta Lem", Surname = " Lockman", Address = " Obozowa 14", PermissionNumber = " 567053" }
                 );

            modelBuilder.Entity<Doctor>().HasData
               (new Doctor { Id = "3e01671b-18fc-4f8c-bfd8-fa12666a99b6", UserId = "ef9632fc-d406-412f-9b7a-09b902db6dfa", Name = "Adam", Surname = "Kowalski", Adress = " Kolorowa 5", PermissionNumber = " 569853", SpecializationId = "6a3d526e-1fb6-4de7-bde5-e0754fc58aec" },
               new Doctor { Id = "1769f6fc-fb40-44ed-bb10-70c0c13a97e3", UserId = "785a5776-fbba-4021-a263-4b9daade6ac8", Name = "Zofia", Surname = "Kowalski", Adress = " Zielona 5", PermissionNumber = " 560053", SpecializationId = "4e8effeb-0a99-4038-9420-0c543a3a28ac" },
               new Doctor { Id = "ba61c248-a31d-4c10-9e7c-9d8d32defeea", UserId = "452db704-3650-457a-a7da-ca545a521776", Name = "Todor", Surname = " Nowaki", Adress = " Adama Mickiewicza 8", PermissionNumber = " 160053", SpecializationId = "e86959d5-6eed-45f7-b5cb-6b8f68a4d085" },
               new Doctor { Id = "519e3b1c-8357-470d-9643-9be49bd669a3", UserId = "7fe50ba2-def6-4ac0-8b3e-87d3b4ce693f", Name = "Grzegorz", Surname = "Lem", Adress = " Obozowa 8", PermissionNumber = " 560053", SpecializationId = "690e47d4-996b-43b7-a23b-d9693cf5962c" }
                );

            modelBuilder.Entity<TimeSheet>().HasData
            (new TimeSheet { Id = "06223eb9-588c-4b2d-a0ab-c3c5ad65ae78", PatientId = "9262b74c-f7b4-47ba-8fcf-087241096f34", DoctorId = "3e01671b-18fc-4f8c-bfd8-fa12666a99b6", RoomId = "d36af7ac-73cb-459e-847f-0abea3581814", Data = new DateTime(2022, 05, 10) },
             new TimeSheet { Id = "56932a73-5813-4215-bc39-686b11a12afc", PatientId = "23159457-b301-4839-932a-3fd939f8b6c4", DoctorId = "1769f6fc-fb40-44ed-bb10-70c0c13a97e3", RoomId = "4b4e2a8f-ab04-40ab-827d-3c7789208e4c", Data = new DateTime(2022, 05, 10) },
             new TimeSheet { Id = "64060098-a52b-4e91-b5b6-63d292cea083", PatientId = "9de0d585-60a6-445c-910c-e26ccaf46274", DoctorId = "ba61c248-a31d-4c10-9e7c-9d8d32defeea", RoomId = "c5f12060-322b-42be-bba6-689e2e0c5721", Data = new DateTime(2022, 10, 10) },
             new TimeSheet { Id = "7fd77adc-02e5-444e-9b7e-feb2113ac22f", PatientId = "816c62f5-2b08-4042-8008-07a46b920921", DoctorId = "519e3b1c-8357-470d-9643-9be49bd669a3", RoomId = "525e8058-b3a1-4a9f-83e5-355848d1e6c5", Data = new DateTime(2022, 10, 10) }

            );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData
(
 new IdentityUserRole<string> { RoleId = "04d94d89-fe74-43ba-b052-90d5f3dea95f", UserId = "66126f74-f32b-435d-9e24-b3ed8b3d6011" },
 new IdentityUserRole<string> { RoleId = "c1eeb9bd-5412-495a-8abf-a4157f1b546d", UserId = "26dfb75e-5f31-4a54-9844-f019998a61d1" },
 new IdentityUserRole<string> { RoleId = "c1eeb9bd-5412-495a-8abf-a4157f1b546d", UserId = "64791af4-436d-4419-b3e1-14641bdb2493" },
 new IdentityUserRole<string> { RoleId = "c1eeb9bd-5412-495a-8abf-a4157f1b546d", UserId = "cef7f7aa-d198-4373-b441-926d8e52dbb1" },

 new IdentityUserRole<string> { RoleId = "72f2ff00-761f-4727-b07c-5381992b5e0a", UserId = "00221f79-bc71-4186-9e5d-bfd57a80a43f" },
 new IdentityUserRole<string> { RoleId = "04d94d89-fe74-43ba-b052-90d5f3dea95f", UserId = "32923230-6c8c-4510-b73e-d9bcf2484879" },
 new IdentityUserRole<string> { RoleId = "04d94d89-fe74-43ba-b052-90d5f3dea95f", UserId = "ed216c2a-3e1c-486f-b8ca-5f13bd8baee8" },
 new IdentityUserRole<string> { RoleId = "04d94d89-fe74-43ba-b052-90d5f3dea95f", UserId = "c2ebef8b-eee6-4328-ba4d-f01a04fe4f83" },

 new IdentityUserRole<string> { RoleId = "04d94d89-fe74-43ba-b052-90d5f3dea95f", UserId = "ef9632fc-d406-412f-9b7a-09b902db6dfa" },
 new IdentityUserRole<string> { RoleId = "04d94d89-fe74-43ba-b052-90d5f3dea95f", UserId = "785a5776-fbba-4021-a263-4b9daade6ac8" },
 new IdentityUserRole<string> { RoleId = "04d94d89-fe74-43ba-b052-90d5f3dea95f", UserId = "452db704-3650-457a-a7da-ca545a521776" },
 new IdentityUserRole<string> { RoleId = "04d94d89-fe74-43ba-b052-90d5f3dea95f", UserId = "7fe50ba2-def6-4ac0-8b3e-87d3b4ce693f" }

);


            base.OnModelCreating(modelBuilder);
        }

    }


}