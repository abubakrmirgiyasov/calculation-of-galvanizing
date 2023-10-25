using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SZGC.Infrastructure.Migrations
{
    public partial class NumOfHitchStationToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserChangeType",
                keyColumn: "Id",
                keyValue: new Guid("1e7f1be7-37f4-424d-a92b-486e803726d3"));

            migrationBuilder.DeleteData(
                table: "UserChangeType",
                keyColumn: "Id",
                keyValue: new Guid("76635b99-9bb7-47d9-877c-0104183e3f6b"));

            migrationBuilder.DeleteData(
                table: "UserChangeType",
                keyColumn: "Id",
                keyValue: new Guid("e01d843f-ce2e-4cb5-9282-201276bf1a12"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2c111180-e224-46b2-bf01-69da4f2527bd"), new Guid("38011575-d506-427d-87f6-d573967ef6d9") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b58162b8-99d4-4d4b-8c02-93bb68298e87"), new Guid("4e848a7d-38a2-4c86-8521-d49e02d33492") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2c111180-e224-46b2-bf01-69da4f2527bd"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b58162b8-99d4-4d4b-8c02-93bb68298e87"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38011575-d506-427d-87f6-d573967ef6d9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4e848a7d-38a2-4c86-8521-d49e02d33492"));

            migrationBuilder.AddColumn<int>(
                name: "NumOfHitchStation",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "NumOfHitchStation",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreate", "Name" },
                values: new object[,]
                {
                    { new Guid("2c111180-e224-46b2-bf01-69da4f2527bd"), new DateTime(2022, 9, 1, 14, 19, 35, 492, DateTimeKind.Local).AddTicks(8288), "Root" },
                    { new Guid("b58162b8-99d4-4d4b-8c02-93bb68298e87"), new DateTime(2022, 9, 1, 14, 19, 35, 492, DateTimeKind.Local).AddTicks(8288), "User" }
                });

            migrationBuilder.InsertData(
                table: "UserChangeType",
                columns: new[] { "Id", "DateCreate", "Name" },
                values: new object[,]
                {
                    { new Guid("76635b99-9bb7-47d9-877c-0104183e3f6b"), new DateTime(2022, 9, 1, 14, 19, 35, 493, DateTimeKind.Local).AddTicks(8273), "Добавление пользователя" },
                    { new Guid("1e7f1be7-37f4-424d-a92b-486e803726d3"), new DateTime(2022, 9, 1, 14, 19, 35, 493, DateTimeKind.Local).AddTicks(8273), "Изменение пользователя" },
                    { new Guid("e01d843f-ce2e-4cb5-9282-201276bf1a12"), new DateTime(2022, 9, 1, 14, 19, 35, 493, DateTimeKind.Local).AddTicks(8273), "Удаление пользователя" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CountFailEnter", "CreateDate", "Login", "MiddleName", "Name", "Password", "Salt", "SurName", "UpdatePassword" },
                values: new object[,]
                {
                    { new Guid("38011575-d506-427d-87f6-d573967ef6d9"), true, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Root", "Root", "Root", "Uo0sQgIOw0G6kVgBbKO3tGuEsjMwnnr4/SQiUglecec=", new byte[] { 149, 64, 188, 8, 171, 206, 23, 201, 179, 214, 119, 240, 210, 17, 159, 95 }, "Root", false },
                    { new Guid("4e848a7d-38a2-4c86-8521-d49e02d33492"), true, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "duser", "", "User", "BAkbQmpnTi0OcLOnc8KzTzexIFCDWuJ85sgZ7hKku1A=", new byte[] { 149, 64, 188, 8, 171, 206, 23, 201, 179, 214, 119, 240, 210, 17, 159, 95 }, "Default", false }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("2c111180-e224-46b2-bf01-69da4f2527bd"), new Guid("38011575-d506-427d-87f6-d573967ef6d9") });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("b58162b8-99d4-4d4b-8c02-93bb68298e87"), new Guid("4e848a7d-38a2-4c86-8521-d49e02d33492") });
        }
    }
}
