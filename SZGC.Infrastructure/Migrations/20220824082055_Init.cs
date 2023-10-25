using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SZGC.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateCreate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserChangeType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateCreate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChangeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SurName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    Salt = table.Column<byte[]>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UpdatePassword = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CountFailEnter = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nomenclatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    MaxWeightTraverse = table.Column<double>(nullable: false),
                    MaxCountTraverse = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nomenclatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nomenclatures_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RefreshToken = table.Column<string>(nullable: true),
                    Salt = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    TimeExpired = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshSessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    SortedBy = table.Column<int>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreate = table.Column<DateTime>(nullable: false),
                    SurName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Salt = table.Column<byte[]>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UpdatePassword = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    TypeId = table.Column<Guid>(nullable: false),
                    OwnerId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserChanges_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserChanges_UserChangeType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "UserChangeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserChanges_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderNomenclatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    NomenclatureId = table.Column<Guid>(nullable: false),
                    AllWeight = table.Column<double>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNomenclatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderNomenclatures_Nomenclatures_NomenclatureId",
                        column: x => x.NomenclatureId,
                        principalTable: "Nomenclatures",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderNomenclatures_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NomenclatureStages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    NomenclatureId = table.Column<Guid>(nullable: false),
                    StageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NomenclatureStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NomenclatureStages_Nomenclatures_NomenclatureId",
                        column: x => x.NomenclatureId,
                        principalTable: "Nomenclatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NomenclatureStages_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderNomenclatureStages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    OrderNomenclatureId = table.Column<Guid>(nullable: false),
                    StageId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNomenclatureStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderNomenclatureStages_OrderNomenclatures_OrderNomenclatureId",
                        column: x => x.OrderNomenclatureId,
                        principalTable: "OrderNomenclatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderNomenclatureStages_Stages_StageId",
                        column: x => x.StageId,
                        principalTable: "Stages",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Nomenclatures_UserId",
                table: "Nomenclatures",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_NomenclatureStages_NomenclatureId",
                table: "NomenclatureStages",
                column: "NomenclatureId");

            migrationBuilder.CreateIndex(
                name: "IX_NomenclatureStages_StageId",
                table: "NomenclatureStages",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNomenclatures_NomenclatureId",
                table: "OrderNomenclatures",
                column: "NomenclatureId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNomenclatures_OrderId",
                table: "OrderNomenclatures",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNomenclatureStages_OrderNomenclatureId",
                table: "OrderNomenclatureStages",
                column: "OrderNomenclatureId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderNomenclatureStages_StageId",
                table: "OrderNomenclatureStages",
                column: "StageId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshSessions_UserId",
                table: "RefreshSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stages_UserId",
                table: "Stages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChanges_OwnerId",
                table: "UserChanges",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChanges_TypeId",
                table: "UserChanges",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserChanges_UserId",
                table: "UserChanges",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NomenclatureStages");

            migrationBuilder.DropTable(
                name: "OrderNomenclatureStages");

            migrationBuilder.DropTable(
                name: "RefreshSessions");

            migrationBuilder.DropTable(
                name: "UserChanges");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "OrderNomenclatures");

            migrationBuilder.DropTable(
                name: "Stages");

            migrationBuilder.DropTable(
                name: "UserChangeType");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Nomenclatures");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
