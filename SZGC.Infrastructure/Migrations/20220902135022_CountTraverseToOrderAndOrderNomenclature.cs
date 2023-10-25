using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SZGC.Infrastructure.Migrations
{
    public partial class CountTraverseToOrderAndOrderNomenclature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserChangeType",
                keyColumn: "Id",
                keyValue: new Guid("2a1ecb93-fe36-47c1-9808-86c2feee02cd"));

            migrationBuilder.DeleteData(
                table: "UserChangeType",
                keyColumn: "Id",
                keyValue: new Guid("b17314d8-887c-44c0-bbc9-1b04bc7f36a6"));

            migrationBuilder.DeleteData(
                table: "UserChangeType",
                keyColumn: "Id",
                keyValue: new Guid("e96cd380-d609-4211-b812-ee8abe678f13"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("8367295d-1631-4af2-87b9-aa8cfec78952"), new Guid("7decbc7b-9aa4-469f-8fbf-b5a3ac71c8e1") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9cc58431-a936-45ab-8ebe-7a8dfc889284"), new Guid("9171bad6-2945-49f6-bdaa-4347e61f8c0c") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8367295d-1631-4af2-87b9-aa8cfec78952"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9cc58431-a936-45ab-8ebe-7a8dfc889284"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7decbc7b-9aa4-469f-8fbf-b5a3ac71c8e1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9171bad6-2945-49f6-bdaa-4347e61f8c0c"));

            migrationBuilder.AddColumn<int>(
                name: "CountTraverse",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountTraverse",
                table: "OrderNomenclatures",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CountTraverse",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CountTraverse",
                table: "OrderNomenclatures");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreate", "Name" },
                values: new object[,]
                {
                    { new Guid("8367295d-1631-4af2-87b9-aa8cfec78952"), new DateTime(2022, 9, 2, 15, 11, 58, 458, DateTimeKind.Local).AddTicks(5645), "Root" },
                    { new Guid("9cc58431-a936-45ab-8ebe-7a8dfc889284"), new DateTime(2022, 9, 2, 15, 11, 58, 460, DateTimeKind.Local).AddTicks(5666), "User" }
                });

            migrationBuilder.InsertData(
                table: "UserChangeType",
                columns: new[] { "Id", "DateCreate", "Name" },
                values: new object[,]
                {
                    { new Guid("b17314d8-887c-44c0-bbc9-1b04bc7f36a6"), new DateTime(2022, 9, 2, 15, 11, 58, 462, DateTimeKind.Local).AddTicks(5659), "Добавление пользователя" },
                    { new Guid("e96cd380-d609-4211-b812-ee8abe678f13"), new DateTime(2022, 9, 2, 15, 11, 58, 462, DateTimeKind.Local).AddTicks(5659), "Изменение пользователя" },
                    { new Guid("2a1ecb93-fe36-47c1-9808-86c2feee02cd"), new DateTime(2022, 9, 2, 15, 11, 58, 462, DateTimeKind.Local).AddTicks(5659), "Удаление пользователя" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CountFailEnter", "CreateDate", "Login", "MiddleName", "Name", "Password", "Salt", "SurName", "UpdatePassword" },
                values: new object[,]
                {
                    { new Guid("7decbc7b-9aa4-469f-8fbf-b5a3ac71c8e1"), true, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Root", "Root", "Root", "Wq12dALMwiXj4L0FKHKa7gVvfASdgeXmhs8Q5sHMtOs=", new byte[] { 148, 243, 107, 245, 199, 12, 220, 145, 107, 22, 141, 247, 127, 93, 241, 77 }, "Root", false },
                    { new Guid("9171bad6-2945-49f6-bdaa-4347e61f8c0c"), true, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "duser", "", "User", "7nlwVzIRPMfbCrXE2oK7fPMJV4MEzRakMdqudxCwXMQ=", new byte[] { 148, 243, 107, 245, 199, 12, 220, 145, 107, 22, 141, 247, 127, 93, 241, 77 }, "Default", false }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("8367295d-1631-4af2-87b9-aa8cfec78952"), new Guid("7decbc7b-9aa4-469f-8fbf-b5a3ac71c8e1") });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("9cc58431-a936-45ab-8ebe-7a8dfc889284"), new Guid("9171bad6-2945-49f6-bdaa-4347e61f8c0c") });
        }
    }
}
