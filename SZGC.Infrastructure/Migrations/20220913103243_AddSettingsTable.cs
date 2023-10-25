using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SZGC.Infrastructure.Migrations
{
    public partial class AddSettingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserChangeType",
                keyColumn: "Id",
                keyValue: new Guid("22fda4a1-36d5-47d9-9304-16a0fd6f1413"));

            migrationBuilder.DeleteData(
                table: "UserChangeType",
                keyColumn: "Id",
                keyValue: new Guid("9b96c52c-0c60-4137-abcd-f878111b7650"));

            migrationBuilder.DeleteData(
                table: "UserChangeType",
                keyColumn: "Id",
                keyValue: new Guid("e7525854-391a-478d-8620-f784cb3e07dc"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7129dc42-9349-47b7-b0de-7702368372ce"), new Guid("dcea69dd-636a-4f0f-922a-806146db98c7") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("790f3bfe-52f4-4623-86f0-c69eeb92682d"), new Guid("05bcca38-d952-4053-bcfe-5410ee226f8e") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("7129dc42-9349-47b7-b0de-7702368372ce"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("790f3bfe-52f4-4623-86f0-c69eeb92682d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("05bcca38-d952-4053-bcfe-5410ee226f8e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dcea69dd-636a-4f0f-922a-806146db98c7"));

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreate", "Name" },
                values: new object[,]
                {
                    { new Guid("c9554729-2fd8-4cdd-9993-f49274ec800c"), new DateTime(2022, 9, 13, 17, 32, 42, 405, DateTimeKind.Local).AddTicks(3084), "Root" },
                    { new Guid("5f718117-20d9-4080-a7ad-d88f315f9f0b"), new DateTime(2022, 9, 13, 17, 32, 42, 405, DateTimeKind.Local).AddTicks(3084), "User" }
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[] { new Guid("615358b4-0672-4dc9-94d2-cb45db769ffd"), "WorkingShift", "11" });

            migrationBuilder.InsertData(
                table: "UserChangeType",
                columns: new[] { "Id", "DateCreate", "Name" },
                values: new object[,]
                {
                    { new Guid("d9fc7e44-7c6a-4713-bfb6-e258daf43c23"), new DateTime(2022, 9, 13, 17, 32, 42, 406, DateTimeKind.Local).AddTicks(3065), "Добавление пользователя" },
                    { new Guid("10705ceb-d3e8-4f73-a8cb-817c6a1d04f2"), new DateTime(2022, 9, 13, 17, 32, 42, 406, DateTimeKind.Local).AddTicks(3065), "Изменение пользователя" },
                    { new Guid("8f562b11-ce40-476d-a063-80271d2956c3"), new DateTime(2022, 9, 13, 17, 32, 42, 406, DateTimeKind.Local).AddTicks(3065), "Удаление пользователя" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CountFailEnter", "CreateDate", "Login", "MiddleName", "Name", "Password", "Salt", "SurName", "UpdatePassword" },
                values: new object[,]
                {
                    { new Guid("2075715e-86b6-4b74-852d-9a40b450f32a"), true, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Root", "Root", "Root", "NDJ5azugs+sM+kmoS0qU5d/PYRnJwHjn0lwiA/S+/Po=", new byte[] { 148, 84, 30, 28, 80, 208, 112, 142, 17, 187, 37, 115, 206, 112, 105, 224 }, "Root", false },
                    { new Guid("6c30ca41-67d3-4e92-b4ee-8a9e901e6a9a"), true, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "duser", "", "User", "azRxwNBq6nDLDX2XI3vHGCZ0saPZMI80+iNaywKIQh4=", new byte[] { 148, 84, 30, 28, 80, 208, 112, 142, 17, 187, 37, 115, 206, 112, 105, 224 }, "Default", false }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("c9554729-2fd8-4cdd-9993-f49274ec800c"), new Guid("2075715e-86b6-4b74-852d-9a40b450f32a") });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("5f718117-20d9-4080-a7ad-d88f315f9f0b"), new Guid("6c30ca41-67d3-4e92-b4ee-8a9e901e6a9a") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DeleteData(
                table: "UserChangeType",
                keyColumn: "Id",
                keyValue: new Guid("10705ceb-d3e8-4f73-a8cb-817c6a1d04f2"));

            migrationBuilder.DeleteData(
                table: "UserChangeType",
                keyColumn: "Id",
                keyValue: new Guid("8f562b11-ce40-476d-a063-80271d2956c3"));

            migrationBuilder.DeleteData(
                table: "UserChangeType",
                keyColumn: "Id",
                keyValue: new Guid("d9fc7e44-7c6a-4713-bfb6-e258daf43c23"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5f718117-20d9-4080-a7ad-d88f315f9f0b"), new Guid("6c30ca41-67d3-4e92-b4ee-8a9e901e6a9a") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c9554729-2fd8-4cdd-9993-f49274ec800c"), new Guid("2075715e-86b6-4b74-852d-9a40b450f32a") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5f718117-20d9-4080-a7ad-d88f315f9f0b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c9554729-2fd8-4cdd-9993-f49274ec800c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2075715e-86b6-4b74-852d-9a40b450f32a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6c30ca41-67d3-4e92-b4ee-8a9e901e6a9a"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreate", "Name" },
                values: new object[,]
                {
                    { new Guid("790f3bfe-52f4-4623-86f0-c69eeb92682d"), new DateTime(2022, 9, 2, 20, 50, 20, 716, DateTimeKind.Local).AddTicks(375), "Root" },
                    { new Guid("7129dc42-9349-47b7-b0de-7702368372ce"), new DateTime(2022, 9, 2, 20, 50, 20, 717, DateTimeKind.Local).AddTicks(310), "User" }
                });

            migrationBuilder.InsertData(
                table: "UserChangeType",
                columns: new[] { "Id", "DateCreate", "Name" },
                values: new object[,]
                {
                    { new Guid("e7525854-391a-478d-8620-f784cb3e07dc"), new DateTime(2022, 9, 2, 20, 50, 20, 718, DateTimeKind.Local).AddTicks(303), "Добавление пользователя" },
                    { new Guid("9b96c52c-0c60-4137-abcd-f878111b7650"), new DateTime(2022, 9, 2, 20, 50, 20, 718, DateTimeKind.Local).AddTicks(303), "Изменение пользователя" },
                    { new Guid("22fda4a1-36d5-47d9-9304-16a0fd6f1413"), new DateTime(2022, 9, 2, 20, 50, 20, 718, DateTimeKind.Local).AddTicks(303), "Удаление пользователя" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CountFailEnter", "CreateDate", "Login", "MiddleName", "Name", "Password", "Salt", "SurName", "UpdatePassword" },
                values: new object[,]
                {
                    { new Guid("05bcca38-d952-4053-bcfe-5410ee226f8e"), true, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Root", "Root", "Root", "HrilCvfdN0MkN1qKEkSGOcT9qHJ02oWWxJsHP3TfCbA=", new byte[] { 208, 10, 29, 196, 114, 139, 191, 5, 70, 18, 164, 241, 95, 164, 177, 192 }, "Root", false },
                    { new Guid("dcea69dd-636a-4f0f-922a-806146db98c7"), true, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "duser", "", "User", "eI3gYdAPQSAlvG/YN4AqsDd1coPZnpXjqDYCxhbLzd0=", new byte[] { 208, 10, 29, 196, 114, 139, 191, 5, 70, 18, 164, 241, 95, 164, 177, 192 }, "Default", false }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("790f3bfe-52f4-4623-86f0-c69eeb92682d"), new Guid("05bcca38-d952-4053-bcfe-5410ee226f8e") });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("7129dc42-9349-47b7-b0de-7702368372ce"), new Guid("dcea69dd-636a-4f0f-922a-806146db98c7") });
        }
    }
}
