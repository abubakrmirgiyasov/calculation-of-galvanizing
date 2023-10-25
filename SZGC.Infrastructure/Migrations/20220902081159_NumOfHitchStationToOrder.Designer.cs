﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SZGC.Infrastructure.Data;

namespace SZGC.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220902081159_NumOfHitchStationToOrder")]
    partial class NumOfHitchStationToOrder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SZGC.Domain.Models.Nomenclature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxCountTraverse")
                        .HasColumnType("int");

                    b.Property<double>("MaxWeightTraverse")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Nomenclatures");
                });

            modelBuilder.Entity("SZGC.Domain.Models.NomenclatureStage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NomenclatureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NomenclatureId");

                    b.HasIndex("StageId");

                    b.ToTable("NomenclatureStages");
                });

            modelBuilder.Entity("SZGC.Domain.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumOfHitchStation")
                        .HasColumnType("int");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SZGC.Domain.Models.OrderNomenclature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AllWeight")
                        .HasColumnType("float");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<Guid>("NomenclatureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("NomenclatureId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderNomenclatures");
                });

            modelBuilder.Entity("SZGC.Domain.Models.OrderNomenclatureStage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderNomenclatureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderNomenclatureId");

                    b.HasIndex("StageId");

                    b.ToTable("OrderNomenclatureStages");
                });

            modelBuilder.Entity("SZGC.Domain.Models.RefreshSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClientName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeExpired")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshSessions");
                });

            modelBuilder.Entity("SZGC.Domain.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8367295d-1631-4af2-87b9-aa8cfec78952"),
                            DateCreate = new DateTime(2022, 9, 2, 15, 11, 58, 458, DateTimeKind.Local).AddTicks(5645),
                            Name = "Root"
                        },
                        new
                        {
                            Id = new Guid("9cc58431-a936-45ab-8ebe-7a8dfc889284"),
                            DateCreate = new DateTime(2022, 9, 2, 15, 11, 58, 460, DateTimeKind.Local).AddTicks(5666),
                            Name = "User"
                        });
                });

            modelBuilder.Entity("SZGC.Domain.Models.Stage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSumming")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SortedBy")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Stages");
                });

            modelBuilder.Entity("SZGC.Domain.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CountFailEnter")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("UpdatePassword")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7decbc7b-9aa4-469f-8fbf-b5a3ac71c8e1"),
                            Active = true,
                            CountFailEnter = 0,
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Login = "Root",
                            MiddleName = "Root",
                            Name = "Root",
                            Password = "Wq12dALMwiXj4L0FKHKa7gVvfASdgeXmhs8Q5sHMtOs=",
                            Salt = new byte[] { 148, 243, 107, 245, 199, 12, 220, 145, 107, 22, 141, 247, 127, 93, 241, 77 },
                            SurName = "Root",
                            UpdatePassword = false
                        },
                        new
                        {
                            Id = new Guid("9171bad6-2945-49f6-bdaa-4347e61f8c0c"),
                            Active = true,
                            CountFailEnter = 0,
                            CreateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Login = "duser",
                            MiddleName = "",
                            Name = "User",
                            Password = "7nlwVzIRPMfbCrXE2oK7fPMJV4MEzRakMdqudxCwXMQ=",
                            Salt = new byte[] { 148, 243, 107, 245, 199, 12, 220, 145, 107, 22, 141, 247, 127, 93, 241, 77 },
                            SurName = "Default",
                            UpdatePassword = false
                        });
                });

            modelBuilder.Entity("SZGC.Domain.Models.UserChange", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("SurName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("UpdatePassword")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.ToTable("UserChanges");
                });

            modelBuilder.Entity("SZGC.Domain.Models.UserChangeType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserChangeType");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b17314d8-887c-44c0-bbc9-1b04bc7f36a6"),
                            DateCreate = new DateTime(2022, 9, 2, 15, 11, 58, 462, DateTimeKind.Local).AddTicks(5659),
                            Name = "Добавление пользователя"
                        },
                        new
                        {
                            Id = new Guid("e96cd380-d609-4211-b812-ee8abe678f13"),
                            DateCreate = new DateTime(2022, 9, 2, 15, 11, 58, 462, DateTimeKind.Local).AddTicks(5659),
                            Name = "Изменение пользователя"
                        },
                        new
                        {
                            Id = new Guid("2a1ecb93-fe36-47c1-9808-86c2feee02cd"),
                            DateCreate = new DateTime(2022, 9, 2, 15, 11, 58, 462, DateTimeKind.Local).AddTicks(5659),
                            Name = "Удаление пользователя"
                        });
                });

            modelBuilder.Entity("SZGC.Domain.Models.UserRole", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("8367295d-1631-4af2-87b9-aa8cfec78952"),
                            UserId = new Guid("7decbc7b-9aa4-469f-8fbf-b5a3ac71c8e1")
                        },
                        new
                        {
                            RoleId = new Guid("9cc58431-a936-45ab-8ebe-7a8dfc889284"),
                            UserId = new Guid("9171bad6-2945-49f6-bdaa-4347e61f8c0c")
                        });
                });

            modelBuilder.Entity("SZGC.Domain.Models.Nomenclature", b =>
                {
                    b.HasOne("SZGC.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SZGC.Domain.Models.NomenclatureStage", b =>
                {
                    b.HasOne("SZGC.Domain.Models.Nomenclature", "Nomenclature")
                        .WithMany("NomenclatureStages")
                        .HasForeignKey("NomenclatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SZGC.Domain.Models.Stage", "Stage")
                        .WithMany("NomenclatureStages")
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("SZGC.Domain.Models.Order", b =>
                {
                    b.HasOne("SZGC.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SZGC.Domain.Models.OrderNomenclature", b =>
                {
                    b.HasOne("SZGC.Domain.Models.Nomenclature", "Nomenclature")
                        .WithMany("OrderNomenclatures")
                        .HasForeignKey("NomenclatureId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SZGC.Domain.Models.Order", "Order")
                        .WithMany("OrderNomenclatures")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SZGC.Domain.Models.OrderNomenclatureStage", b =>
                {
                    b.HasOne("SZGC.Domain.Models.OrderNomenclature", "OrderNomenclature")
                        .WithMany("OrderNomenclatureStages")
                        .HasForeignKey("OrderNomenclatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SZGC.Domain.Models.Stage", "Stage")
                        .WithMany("OrderNomenclatureStages")
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("SZGC.Domain.Models.RefreshSession", b =>
                {
                    b.HasOne("SZGC.Domain.Models.User", "User")
                        .WithMany("RefreshSessions")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SZGC.Domain.Models.Stage", b =>
                {
                    b.HasOne("SZGC.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SZGC.Domain.Models.UserChange", b =>
                {
                    b.HasOne("SZGC.Domain.Models.User", "Owner")
                        .WithMany("OwnerChanges")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("SZGC.Domain.Models.UserChangeType", "Type")
                        .WithMany("UserChanges")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SZGC.Domain.Models.User", "User")
                        .WithMany("UserChanges")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("SZGC.Domain.Models.UserRole", b =>
                {
                    b.HasOne("SZGC.Domain.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SZGC.Domain.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
