using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Egabinet.Migrations
{
    public partial class updateUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04d94d89-fe74-43ba-b052-90d5f3dea95f",
                column: "ConcurrencyStamp",
                value: "3c88adda-eafc-493e-81f8-e8bc2d28e9e3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72f2ff00-761f-4727-b07c-5381992b5e0a",
                column: "ConcurrencyStamp",
                value: "2cca840f-c78d-4a3e-aa4c-6abc005df715");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1eeb9bd-5412-495a-8abf-a4157f1b546d",
                column: "ConcurrencyStamp",
                value: "4fec1402-6201-4288-a8e7-b28eca3f1919");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00221f79-bc71-4186-9e5d-bfd57a80a43f",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "55aab979-249f-4db6-9bc6-e379499bb811", "USER5@OP.PL", "USER5@OP.PL", "AQAAAAEAACcQAAAAEPyrmbMX9kh0D/c7IQp7G3mLD0Y1lryIhFw+YYLiSkt+COjelBPRTu4YgO4p0wd0TQ==", "d664e3b4-1ecc-463d-80d7-e69e86d9b51f", "user5@op.pl" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26dfb75e-5f31-4a54-9844-f019998a61d1",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "208c068b-d768-41fb-b1ed-0cee2faf6f52", "USER2@OP.PL", "USER2@OP.PL", "AQAAAAEAACcQAAAAENJ622jmZtOBJaxO4bSJxRdFlLiD7Ica8IOpl6Z1E4o3jd25lWcLz3yfozb2axwPxg==", "ce219bfa-ebbc-4065-9bd1-512dddc7dbc6", "user2@op.pl" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32923230-6c8c-4510-b73e-d9bcf2484879",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "6837326e-f7ad-4438-8ef8-09d3b70e5f78", "USER6@OP.PL", "USER6@OP.PL", "AQAAAAEAACcQAAAAEJtlo32QBhbr9tGYySbaXqxO0zitROGvWHKqttRe5QP1R36Pmk7pn1GV9Kzs1fgzjg==", "9fdc2253-1fe0-46ff-a877-0347ec4dba9b", "user6@op.pl" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "452db704-3650-457a-a7da-ca545a521776",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "f242fb9d-a536-48a4-a5d2-8bb43ca3593c", "USER11@OP.PL", "USER11@OP.PL", "AQAAAAEAACcQAAAAEF7nzUjTDJaKW5A3PihwKmg7xooX8LWr5192ro72lkpnjN0BkqZxdOfmukSnB9+sJA==", "d3b18b85-240d-4832-8482-fd0620601e62", "user11@op.pl" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64791af4-436d-4419-b3e1-14641bdb2493",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "5b7b220b-3f43-449e-a78b-38ca3d4feb16", "USER3@OP.PL", "USER3@OP.PL", "AQAAAAEAACcQAAAAEDdZ4lGk94f47iUXld0k6SNYCvOWtDqqmTejvoF9+3uedsQlbXIto1zsAEM9kJJLMA==", "037ab5e1-a623-4c88-bdb0-1631fa9d08ab", "user3@op.pl" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66126f74-f32b-435d-9e24-b3ed8b3d6011",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "e0b2e686-fd85-4a96-ad6f-3771475b2566", "USER1@OP.PL", "USER1@OP.PL", "AQAAAAEAACcQAAAAEA9TwQ8M8PzAODqSuQweHFLYx4votn0WkD/dWoV4SvWopATa+Dfo+9SWAMeqxvsMpg==", "41ffeb77-be57-4a5b-a9c4-08aa2bd4ed61", "user1@op.pl" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "785a5776-fbba-4021-a263-4b9daade6ac8",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "f69058e3-0020-4c43-8504-23ba71b412ee", "USER10@OP.PL", "USER10@OP.PL", "AQAAAAEAACcQAAAAEGCWqjzFOpHFIFR9RqOjOhHi/VapenKtVtKhH12r1ocQpa/67USgYS17Ixc0RmACnw==", "672fd736-5b99-4c96-95c5-c557f2d2e187", "user10@op.pl" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7fe50ba2-def6-4ac0-8b3e-87d3b4ce693f",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "357642ec-830a-46ba-b6df-45887bc9fe94", "USER12@OP.PL", "USER12@OP.PL", "AQAAAAEAACcQAAAAEDcHxtorwYcFQL3LF6HL+3nZWIL8OF59XrZ+Cz2N+qz2ryj7XNzpIOAZVl19CGWgzg==", "9544d9f5-5038-4005-9388-cb3997f335e6", "user12@op.pl" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2ebef8b-eee6-4328-ba4d-f01a04fe4f83",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "786a447a-3204-4499-a6e0-bf29aab32578", "USER8@OP.PL", "USER8@OP.PL", "AQAAAAEAACcQAAAAEGTXl4OapV8BLNogPvLt1dZd61WouBVMM56vmFufjpqavZtveI5eu7puDFOgzC87Og==", "fbc6ddf9-5250-4566-8b23-9e7874a219a5", "user8@op.pl" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cef7f7aa-d198-4373-b441-926d8e52dbb1",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "142e8082-e319-490d-9228-5bde073f663e", "USER4@OP.PL", "USER4@OP.PL", "AQAAAAEAACcQAAAAENktTmyWK8gpLvzqfZqvZ5RIBCERa2M+nsEDCjfmUU527SPKVU07AKcWKT7jPJJ/bg==", "225c7e78-54c9-4633-937d-9a72b9a041e6", "user4@op.pl" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed216c2a-3e1c-486f-b8ca-5f13bd8baee8",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "a4c55fc8-977d-4c19-9be3-c19cd587c48c", "USER7@OP.PL", "USER7@OP.PL", "AQAAAAEAACcQAAAAEIzrVbFNUHNfJyX/RP13v/IIsdNWk3oV30zdWkXg5OeyRj0twfNYTHEG5IPdp/d4Gg==", "894f20e4-1ad3-4c90-99cb-9d2a49955c29", "user7@op.pl" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef9632fc-d406-412f-9b7a-09b902db6dfa",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "d6296024-281f-4602-9611-d5c35babed14", "USER9@OP.PL", "USER9@OP.PL", "AQAAAAEAACcQAAAAEHCS+rcLUHdlej/FSS2wFYcHKT/1DUPOme1wb7EEXkoXfiW/SXWMD/sMaarTLZ9tTQ==", "3b8443b5-4681-4b1c-a9e4-637b4f540835", "user9@op.pl" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04d94d89-fe74-43ba-b052-90d5f3dea95f",
                column: "ConcurrencyStamp",
                value: "794f7ff4-9b79-47ad-b879-b9a30435e127");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72f2ff00-761f-4727-b07c-5381992b5e0a",
                column: "ConcurrencyStamp",
                value: "b479b42a-5304-4bf7-a123-08b99d194e29");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1eeb9bd-5412-495a-8abf-a4157f1b546d",
                column: "ConcurrencyStamp",
                value: "13d1a570-332c-4627-8481-e6206136e433");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00221f79-bc71-4186-9e5d-bfd57a80a43f",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "6fa4dc17-904e-4fde-bc44-82d1896ec6b5", null, "USER5", "AQAAAAEAACcQAAAAEAYeqdwwh/0+GG3azmmk9J0mG6NAoWW1fk6oy4XAp6G9lHCio5+LLuAeRXtQMSI/uQ==", "fe519440-ebfc-411f-88f5-e59bf2e2c257", "User5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26dfb75e-5f31-4a54-9844-f019998a61d1",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "06ac39af-1856-418f-984c-b12cf0c69c80", null, "USER2", "AQAAAAEAACcQAAAAEPZTk6xQVU5drCexCdRkNrKS/GMISUCnqqfYiU26R1ORQGFHMuJsZLebXIyTikIgSQ==", "e511cded-756a-4c03-9916-5fec1ea12cea", "User2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32923230-6c8c-4510-b73e-d9bcf2484879",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "9f2b14a9-f9c6-4921-9ee0-4713a20794a2", null, "USER6", "AQAAAAEAACcQAAAAEPL02HilF4F2CGV/aCJpNt7ojWec+cMe8Iga8oFmPirYhT+5gzePK2iDXNQgMIV/Vg==", "cd4c48f9-dece-4be3-afac-1800a085975a", "User6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "452db704-3650-457a-a7da-ca545a521776",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ab29ad60-04d9-43e5-8561-d2a70293a7ca", null, "USER11", "AQAAAAEAACcQAAAAENa/LYDqyqwIeijhFqMTAQKh5BDY4BZDFTiXzRiKYnx2N34VcHRGNf7Ebn1jjbiCmw==", "93a58db6-63ba-4c84-93be-777640e58b05", "User11" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "64791af4-436d-4419-b3e1-14641bdb2493",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ed1bc190-39d4-40a2-8626-2f70467b433d", null, "USER3", "AQAAAAEAACcQAAAAEJUSmV/6bHPr7sqJtVx7qnL8MVafg3Nb2vQBqaQYJ4J49qjZM9V05IEg4j72fN7JBg==", "2a1989c0-f07f-4b1b-8d75-583ef74f48fe", "User3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "66126f74-f32b-435d-9e24-b3ed8b3d6011",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "35153629-4e9e-4a81-8af1-2b879e51a8d4", null, "USER1", "AQAAAAEAACcQAAAAEMk8U8Li73wBzqt/vmDj9utTr/+eikrHCiAuZqn8JMhMGNNzs6OvmuzRL29SuxPNsw==", "ff5c7218-1791-46e2-abdf-9230938028c8", "User1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "785a5776-fbba-4021-a263-4b9daade6ac8",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "6827552e-6611-4427-8b8f-ffca04416963", null, "USER10", "AQAAAAEAACcQAAAAEFdy594TEj0WQnVFPV4K+GoScELkd65cMGxHgWsXlnYxI7dTuAqlSTyMOfgWqxwO6g==", "a6200945-664a-4878-b930-7eedcc385384", "User10" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7fe50ba2-def6-4ac0-8b3e-87d3b4ce693f",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "538381ff-ed0b-4b53-b9b9-36832468af7c", null, "USER12", "AQAAAAEAACcQAAAAELN6Y9t3W3osRBnNlFtGBs1IOGJCR353/06VpdzPW0/bLAU8xK7BfhXxc/44uQ9DTA==", "e3c1d08e-d6c5-4b80-b3d6-815aef2faea5", "User12" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2ebef8b-eee6-4328-ba4d-f01a04fe4f83",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "97f0f878-b855-440f-9e12-dc63cb99a5c1", null, "USER8", "AQAAAAEAACcQAAAAEH5x3jP38zsjCy18NrLUc6/JcCTX+0JcLCCf14uN2sES0mtbkOBLbxIMor3iaS8JmQ==", "09bc0104-7449-4b80-a3a8-ce34bd06f1a1", "User8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cef7f7aa-d198-4373-b441-926d8e52dbb1",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "4fa26f17-a5d1-4cb3-87ff-4a668e2dff1c", null, "USER4", "AQAAAAEAACcQAAAAECkHBIjoD+B1pIjjnknsauhDeLSdVDgiDX7U2+s+Qrj1pp1vxXPlhiGD9QECSns/jg==", "21df36b2-774c-4b37-8557-61b4223e66c9", "User4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed216c2a-3e1c-486f-b8ca-5f13bd8baee8",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "1b133658-d77b-4261-acbf-07e0fcf0b463", null, "USER7", "AQAAAAEAACcQAAAAEJLBHsxLKT9qtIgeuGYYG00r5xpN+km1KZoZfoxuN7fUDs6np75sFdCEDhrrsq22HQ==", "3cde2e3d-e9d5-4a1b-ba27-4d170774b1f3", "User7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ef9632fc-d406-412f-9b7a-09b902db6dfa",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "cb63eb6f-0709-4adb-993d-022c3c475b70", null, "USER9", "AQAAAAEAACcQAAAAEJAn4INCliIXm6Ocrb4yogNpg9R+JixY+GuBKlzvZ7IZeRIRpwRv9Iai0Wq6jYGW9g==", "8c495753-2bc0-4528-9cd3-98bc249644e2", "User9" });
        }
    }
}
