﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SZGC.Infrastructure.Migrations
{
    public partial class IsSummingToStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserChangeType",
                keyColumn: "Id",
                keyValue: new Guid("528c3373-8b1e-4ab8-99c0-1413ea91b299"));

            migrationBuilder.DeleteData(
                table: "UserChangeType",
                keyColumn: "Id",
                keyValue: new Guid("5d5e5f0b-3af1-4767-b268-452cff940404"));

            migrationBuilder.DeleteData(
                table: "UserChangeType",
                keyColumn: "Id",
                keyValue: new Guid("9e8dc80d-7b4f-417f-9993-775bba0c0fb0"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("bd7533ab-39b4-4832-899c-220bb196fa00"), new Guid("8d79f660-70cf-4895-bd5c-51ed5981812c") });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c3765b7d-3126-41f7-bbc4-f82b85aa6687"), new Guid("cd19b431-a9c5-4883-b436-227e817f5d7b") });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bd7533ab-39b4-4832-899c-220bb196fa00"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c3765b7d-3126-41f7-bbc4-f82b85aa6687"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8d79f660-70cf-4895-bd5c-51ed5981812c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cd19b431-a9c5-4883-b436-227e817f5d7b"));

            migrationBuilder.AddColumn<bool>(
                name: "IsSumming",
                table: "Stages",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsSumming",
                table: "Stages");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "DateCreate", "Name" },
                values: new object[,]
                {
                    { new Guid("c3765b7d-3126-41f7-bbc4-f82b85aa6687"), new DateTime(2022, 8, 24, 15, 20, 55, 121, DateTimeKind.Local).AddTicks(2434), "Root" },
                    { new Guid("bd7533ab-39b4-4832-899c-220bb196fa00"), new DateTime(2022, 8, 24, 15, 20, 55, 121, DateTimeKind.Local).AddTicks(2434), "User" }
                });

            migrationBuilder.InsertData(
                table: "UserChangeType",
                columns: new[] { "Id", "DateCreate", "Name" },
                values: new object[,]
                {
                    { new Guid("9e8dc80d-7b4f-417f-9993-775bba0c0fb0"), new DateTime(2022, 8, 24, 15, 20, 55, 122, DateTimeKind.Local).AddTicks(2467), "Добавление пользователя" },
                    { new Guid("528c3373-8b1e-4ab8-99c0-1413ea91b299"), new DateTime(2022, 8, 24, 15, 20, 55, 122, DateTimeKind.Local).AddTicks(2467), "Изменение пользователя" },
                    { new Guid("5d5e5f0b-3af1-4767-b268-452cff940404"), new DateTime(2022, 8, 24, 15, 20, 55, 122, DateTimeKind.Local).AddTicks(2467), "Удаление пользователя" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "CountFailEnter", "CreateDate", "Login", "MiddleName", "Name", "Password", "Salt", "SurName", "UpdatePassword" },
                values: new object[,]
                {
                    { new Guid("cd19b431-a9c5-4883-b436-227e817f5d7b"), true, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Root", "Root", "Root", "G1GrIyE+HaeVNwCvwhONvpUrdkaVGcNyLQqBuYvS6cs=", new byte[] { 41, 160, 18, 37, 236, 175, 123, 173, 186, 170, 70, 29, 11, 117, 20, 95 }, "Root", false },
                    { new Guid("8d79f660-70cf-4895-bd5c-51ed5981812c"), true, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "duser", "", "User", "CiTnTw+aw0NuNr9ynK5c4i2ge7iTYc07OfQPtperlbI=", new byte[] { 41, 160, 18, 37, 236, 175, 123, 173, 186, 170, 70, 29, 11, 117, 20, 95 }, "Default", false }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("c3765b7d-3126-41f7-bbc4-f82b85aa6687"), new Guid("cd19b431-a9c5-4883-b436-227e817f5d7b") });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("bd7533ab-39b4-4832-899c-220bb196fa00"), new Guid("8d79f660-70cf-4895-bd5c-51ed5981812c") });
        }
    }
}
