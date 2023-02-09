using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Egabinet.Migrations
{
    public partial class changedatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Nurse",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermissionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nurse_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pesel = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Number = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SpecializationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PermissionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctor_Specialization_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specialization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeSheet",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeSheet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeSheet_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeSheet_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeSheet_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04d94d89-fe74-43ba-b052-90d5f3dea95f", "4165f3ae-9e5b-49f0-b8e2-8740ab586556", "Writer", "WRITER" },
                    { "72f2ff00-761f-4727-b07c-5381992b5e0a", "33464bc1-d313-4d44-bb48-2c660dcd9913", "Administrator", "ADMINISTRATOR" },
                    { "c1eeb9bd-5412-495a-8abf-a4157f1b546d", "ef9bcb92-7418-4d2d-bfc4-ffc1dc1545ec", "Reader", "READER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "00221f79-bc71-4186-9e5d-bfd57a80a43f", 0, "8d5c45fd-21d2-455c-99bc-0378e80d0344", "user5@op.pl", true, false, null, null, "USER5", "AQAAAAEAACcQAAAAEBKmtVsEw7hnkF7dZEhCbLLlhQiBX7a4JcSth1swQGrmTHRWr/uPgTrtaQ6Nx+bk3w==", null, false, "77c6bfbf-c9e5-4bb1-8e00-50402034ef08", false, "User5" },
                    { "26dfb75e-5f31-4a54-9844-f019998a61d1", 0, "6396eadb-1982-446d-a098-3fed5b828ba0", "user2@op.pl", true, false, null, null, "USER2", "AQAAAAEAACcQAAAAEFtSg1mGuOdas3aqqTSl2OKOo2/n0hRJACvPs8psFJgm7LZOrlLC3JC/kw1nxOmfMQ==", null, false, "f7723fa2-46c8-48cc-877e-d77013f985a1", false, "User2" },
                    { "32923230-6c8c-4510-b73e-d9bcf2484879", 0, "48de2081-0998-465d-8bc5-3b9aed0099f8", "user6@op.pl", true, false, null, null, "USER6", "AQAAAAEAACcQAAAAENcsn63hP36ta4WwJDbXOLOiCMrGomFa3YmjXISjS+a+ud81m4EXX7Zq2hb1Gs6tIA==", null, false, "a2768867-e26d-49e4-ab29-145a28d01bfb", false, "User6" },
                    { "452db704-3650-457a-a7da-ca545a521776", 0, "15de5949-b599-45fd-aca9-602b22dac7f3", "user11@op.pl", true, false, null, null, "USER11", "AQAAAAEAACcQAAAAEBLh92Ve0hoboc3DAtcUiKOLgnKplTy3LveVsEU4jyfroRt2q2SzkiHwuePVkdld4A==", null, false, "7dfe3af0-3e2e-43e6-a060-f9e3ebb2d6ea", false, "User11" },
                    { "64791af4-436d-4419-b3e1-14641bdb2493", 0, "0827abab-1b4b-474a-88e2-865e7ca9041d", "user3@op.pl", true, false, null, null, "USER3", "AQAAAAEAACcQAAAAEH8u6OW1hukFDXLCZjtM7wj6Pe+YrxXd4VX4Tw+CCwIVN7UK7TIUC1tLQ0Dixg48QQ==", null, false, "a103057f-8cb1-4d15-959d-d8eee3e0bfa9", false, "User3" },
                    { "66126f74-f32b-435d-9e24-b3ed8b3d6011", 0, "b145fd5b-93ce-4e9e-9f42-b925d9bd01bc", "user1@op.pl", true, false, null, null, "USER1", "AQAAAAEAACcQAAAAED4ZSO/ExXnk2OSCNEDnyRhDM3lcObMS0AOZ1ft6uAUyG9f03SC15jQLkbWWZcH/1w==", null, false, "fe834d79-e090-42f2-abc6-9ce78e3b9425", false, "User1" },
                    { "785a5776-fbba-4021-a263-4b9daade6ac8", 0, "8d2abbba-4d75-4e51-8a23-33bf439c16f4", "user10@op.pl", true, false, null, null, "USER10", "AQAAAAEAACcQAAAAELX/1LWbDQFPgaLOitvyUncFWgh/RmJWo0cCbUQ44ivIGHk19JRjbkt0dgJ4/fytxQ==", null, false, "7ecd8644-4507-464a-8fe5-92b7f76ff009", false, "User10" },
                    { "7fe50ba2-def6-4ac0-8b3e-87d3b4ce693f", 0, "947c8587-b2bd-4fdd-ac74-ccb942d69751", "user12@op.pl", true, false, null, null, "USER12", "AQAAAAEAACcQAAAAEDuoRamLoNW+oi0kzneVuq75NBWGi96Ji6mFNE355vqmY0+pzFv/cFxEM+UAG3lSxw==", null, false, "e42f7cc8-31d0-4b28-80b8-1b3a9f6e0de9", false, "User12" },
                    { "c2ebef8b-eee6-4328-ba4d-f01a04fe4f83", 0, "0f0d9638-f6d8-4150-9950-0aa94f13aad0", "user8@op.pl", true, false, null, null, "USER8", "AQAAAAEAACcQAAAAEBQyijG19p6n7UAH/rR106i5cLt+hIChFvE15TQ2Yj6EJOcDh1cIXWTvVqZUO6McQw==", null, false, "6643ef68-ce02-4c45-95a6-9e71f6e63fa6", false, "User8" },
                    { "cef7f7aa-d198-4373-b441-926d8e52dbb1", 0, "1e469177-e203-4192-9a10-d60f3e0b8091", "user4@op.pl", true, false, null, null, "USER4", "AQAAAAEAACcQAAAAED91jevUHoHCAjh34oY5xAKIZVOqxlte3vr/jNTHFNKMh3tZ/8xwaVMWkqZavNKAKw==", null, false, "6913fba3-601d-4c53-884b-4cc1ea1131d7", false, "User4" },
                    { "ed216c2a-3e1c-486f-b8ca-5f13bd8baee8", 0, "cf92785f-d771-4c8b-9df3-29fda1db3337", "user7@op.pl", true, false, null, null, "USER7", "AQAAAAEAACcQAAAAEIEbp1zWVieSLkn8OVyR5cC1w342p0iUx0MEFcqio0+qhtf+xFIyRkN2MtyQqlzTeg==", null, false, "e0617137-e650-4bde-b69a-1a52773ffb47", false, "User7" },
                    { "ef9632fc-d406-412f-9b7a-09b902db6dfa", 0, "14b1ba70-01a0-47d4-bfed-3b06d942c303", "user9@op.pl", true, false, null, null, "USER9", "AQAAAAEAACcQAAAAEJBXxTGRuwzAnTly3kUwpSHf/XzenEAc3ltCl+W0PR8jYiN0YBHMXjJGcxS4LrrWLA==", null, false, "bdac6aa3-6753-42b6-81ea-34ca0ffe3ca1", false, "User9" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "Id", "Number" },
                values: new object[,]
                {
                    { "4b4e2a8f-ab04-40ab-827d-3c7789208e4c", 2L },
                    { "525e8058-b3a1-4a9f-83e5-355848d1e6c5", 4L },
                    { "c5f12060-322b-42be-bba6-689e2e0c5721", 3L },
                    { "d36af7ac-73cb-459e-847f-0abea3581814", 1L }
                });

            migrationBuilder.InsertData(
                table: "Specialization",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { "4e8effeb-0a99-4038-9420-0c543a3a28ac", "Endokrynolog" },
                    { "690e47d4-996b-43b7-a23b-d9693cf5962c", "Stomatolog" },
                    { "6a3d526e-1fb6-4de7-bde5-e0754fc58aec", "Lekarz rodzinny" },
                    { "e86959d5-6eed-45f7-b5cb-6b8f68a4d085", "Laryngolog" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "72f2ff00-761f-4727-b07c-5381992b5e0a", "00221f79-bc71-4186-9e5d-bfd57a80a43f" },
                    { "c1eeb9bd-5412-495a-8abf-a4157f1b546d", "26dfb75e-5f31-4a54-9844-f019998a61d1" },
                    { "04d94d89-fe74-43ba-b052-90d5f3dea95f", "32923230-6c8c-4510-b73e-d9bcf2484879" },
                    { "04d94d89-fe74-43ba-b052-90d5f3dea95f", "452db704-3650-457a-a7da-ca545a521776" },
                    { "c1eeb9bd-5412-495a-8abf-a4157f1b546d", "64791af4-436d-4419-b3e1-14641bdb2493" },
                    { "04d94d89-fe74-43ba-b052-90d5f3dea95f", "66126f74-f32b-435d-9e24-b3ed8b3d6011" },
                    { "04d94d89-fe74-43ba-b052-90d5f3dea95f", "785a5776-fbba-4021-a263-4b9daade6ac8" },
                    { "04d94d89-fe74-43ba-b052-90d5f3dea95f", "7fe50ba2-def6-4ac0-8b3e-87d3b4ce693f" },
                    { "04d94d89-fe74-43ba-b052-90d5f3dea95f", "c2ebef8b-eee6-4328-ba4d-f01a04fe4f83" },
                    { "c1eeb9bd-5412-495a-8abf-a4157f1b546d", "cef7f7aa-d198-4373-b441-926d8e52dbb1" },
                    { "04d94d89-fe74-43ba-b052-90d5f3dea95f", "ed216c2a-3e1c-486f-b8ca-5f13bd8baee8" },
                    { "04d94d89-fe74-43ba-b052-90d5f3dea95f", "ef9632fc-d406-412f-9b7a-09b902db6dfa" }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "Adress", "Name", "PermissionNumber", "SpecializationId", "Surname", "UserId" },
                values: new object[,]
                {
                    { "1769f6fc-fb40-44ed-bb10-70c0c13a97e3", " Zielona 5", "Zofia", " 560053", "4e8effeb-0a99-4038-9420-0c543a3a28ac", "Kowalski", "785a5776-fbba-4021-a263-4b9daade6ac8" },
                    { "3e01671b-18fc-4f8c-bfd8-fa12666a99b6", " Kolorowa 5", "Adam", " 569853", "6a3d526e-1fb6-4de7-bde5-e0754fc58aec", "Kowalski", "ef9632fc-d406-412f-9b7a-09b902db6dfa" },
                    { "519e3b1c-8357-470d-9643-9be49bd669a3", " Obozowa 8", "Grzegorz", " 560053", "690e47d4-996b-43b7-a23b-d9693cf5962c", "Lem", "7fe50ba2-def6-4ac0-8b3e-87d3b4ce693f" },
                    { "ba61c248-a31d-4c10-9e7c-9d8d32defeea", " Adama Mickiewicza 8", "Todor", " 160053", "e86959d5-6eed-45f7-b5cb-6b8f68a4d085", " Nowaki", "452db704-3650-457a-a7da-ca545a521776" }
                });

            migrationBuilder.InsertData(
                table: "Nurse",
                columns: new[] { "Id", "Address", "Name", "PermissionNumber", "Surname", "UserId" },
                values: new object[,]
                {
                    { "68041977-3f99-4e4f-ac71-0b03a3606750", " os. Kolorowe 8", "Anna ", " 169053", " Austen", "ed216c2a-3e1c-486f-b8ca-5f13bd8baee8" },
                    { "965e09d6-0ed5-4e7a-8950-e252b1ae5380", " Obozowa 14", "Glżbieta Lem", " 567053", " Lockman", "c2ebef8b-eee6-4328-ba4d-f01a04fe4f83" },
                    { "9ae453af-8db3-440c-b8d0-1c55299ce188", " Różana 5", "AZofia", " 509853", "Stanecka", "00221f79-bc71-4186-9e5d-bfd57a80a43f" },
                    { "e40f8b49-f885-48c0-bb64-21c0d0813e88", " Topografów 5", "Hanna", " 510053", " Oklejka", "32923230-6c8c-4510-b73e-d9bcf2484879" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "Address", "Name", "Pesel", "Surname", "UserId" },
                values: new object[,]
                {
                    { "23159457-b301-4839-932a-3fd939f8b6c4", " Ostoja 5", "Zofia", 78020607221L, "Stanecka", "26dfb75e-5f31-4a54-9844-f019998a61d1" },
                    { "816c62f5-2b08-4042-8008-07a46b920921", " Obozowa 15", "Grzegorz", 65011259884L, "Fus", "cef7f7aa-d198-4373-b441-926d8e52dbb1" },
                    { "9262b74c-f7b4-47ba-8fcf-087241096f34", " Magnoliowa 5", "Adam", 85011259884L, "Nowak", "66126f74-f32b-435d-9e24-b3ed8b3d6011" },
                    { "9de0d585-60a6-445c-910c-e26ccaf46274", " Żeromskiego 4", "Austen", 95011259884L, "Nowaki", "64791af4-436d-4419-b3e1-14641bdb2493" }
                });

            migrationBuilder.InsertData(
                table: "TimeSheet",
                columns: new[] { "Id", "Data", "DoctorId", "PatientId", "RoomId" },
                values: new object[,]
                {
                    { "06223eb9-588c-4b2d-a0ab-c3c5ad65ae78", new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "3e01671b-18fc-4f8c-bfd8-fa12666a99b6", "9262b74c-f7b4-47ba-8fcf-087241096f34", "d36af7ac-73cb-459e-847f-0abea3581814" },
                    { "56932a73-5813-4215-bc39-686b11a12afc", new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "1769f6fc-fb40-44ed-bb10-70c0c13a97e3", "23159457-b301-4839-932a-3fd939f8b6c4", "4b4e2a8f-ab04-40ab-827d-3c7789208e4c" },
                    { "64060098-a52b-4e91-b5b6-63d292cea083", new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ba61c248-a31d-4c10-9e7c-9d8d32defeea", "9de0d585-60a6-445c-910c-e26ccaf46274", "c5f12060-322b-42be-bba6-689e2e0c5721" },
                    { "7fd77adc-02e5-444e-9b7e-feb2113ac22f", new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "519e3b1c-8357-470d-9643-9be49bd669a3", "816c62f5-2b08-4042-8008-07a46b920921", "525e8058-b3a1-4a9f-83e5-355848d1e6c5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_SpecializationId",
                table: "Doctor",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_UserId",
                table: "Doctor",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Nurse_UserId",
                table: "Nurse",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_UserId",
                table: "Patient",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheet_DoctorId",
                table: "TimeSheet",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheet_PatientId",
                table: "TimeSheet",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSheet_RoomId",
                table: "TimeSheet",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nurse");

            migrationBuilder.DropTable(
                name: "TimeSheet");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Specialization");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "72f2ff00-761f-4727-b07c-5381992b5e0a", "00221f79-bc71-4186-9e5d-bfd57a80a43f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c1eeb9bd-5412-495a-8abf-a4157f1b546d", "26dfb75e-5f31-4a54-9844-f019998a61d1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "04d94d89-fe74-43ba-b052-90d5f3dea95f", "32923230-6c8c-4510-b73e-d9bcf2484879" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "04d94d89-fe74-43ba-b052-90d5f3dea95f", "452db704-3650-457a-a7da-ca545a521776" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c1eeb9bd-5412-495a-8abf-a4157f1b546d", "64791af4-436d-4419-b3e1-14641bdb2493" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "04d94d89-fe74-43ba-b052-90d5f3dea95f", "66126f74-f32b-435d-9e24-b3ed8b3d6011" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "04d94d89-fe74-43ba-b052-90d5f3dea95f", "785a5776-fbba-4021-a263-4b9daade6ac8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "04d94d89-fe74-43ba-b052-90d5f3dea95f", "7fe50ba2-def6-4ac0-8b3e-87d3b4ce693f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "04d94d89-fe74-43ba-b052-90d5f3dea95f", "c2ebef8b-eee6-4328-ba4d-f01a04fe4f83" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c1eeb9bd-5412-495a-8abf-a4157f1b546d", "cef7f7aa-d198-4373-b441-926d8e52dbb1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "04d94d89-fe74-43ba-b052-90d5f3dea95f", "ed216c2a-3e1c-486f-b8ca-5f13bd8baee8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "04d94d89-fe74-43ba-b052-90d5f3dea95f", "ef9632fc-d406-412f-9b7a-09b902db6dfa" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04d94d89-fe74-43ba-b052-90d5f3dea95f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72f2ff00-761f-4727-b07c-5381992b5e0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1eeb9bd-5412-495a-8abf-a4157f1b546d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00221f79-bc71-4186-9e5d-bfd57a80a43f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32923230-6c8c-4510-b73e-d9bcf2484879");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2ebef8b-eee6-4328-ba4d-f01a04fe4f83");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed216c2a-3e1c-486f-b8ca-5f13bd8baee8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26dfb75e-5f31-4a54-9844-f019998a61d1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "452db704-3650-457a-a7da-ca545a521776");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64791af4-436d-4419-b3e1-14641bdb2493");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66126f74-f32b-435d-9e24-b3ed8b3d6011");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "785a5776-fbba-4021-a263-4b9daade6ac8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7fe50ba2-def6-4ac0-8b3e-87d3b4ce693f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cef7f7aa-d198-4373-b441-926d8e52dbb1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef9632fc-d406-412f-9b7a-09b902db6dfa");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visits_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visits_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visits_DoctorId",
                table: "Visits",
                column: "DoctorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PatientId",
                table: "Visits",
                column: "PatientId",
                unique: true);
        }
    }
}
