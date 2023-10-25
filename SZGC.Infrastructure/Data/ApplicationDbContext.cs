using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using SZGC.Domain.Constants;
using SZGC.Domain.Models;
using SZGC.Infrastructure.Cryptography;

namespace SZGC.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<RefreshSession> RefreshSessions { get; set; }

        public DbSet<UserChange> UserChanges { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Nomenclature> Nomenclatures { get; set; }

        public DbSet<Stage> Stages { get; set; }

        public DbSet<NomenclatureStage> NomenclatureStages { get; set; }

        public DbSet<OrderNomenclature> OrderNomenclatures { get; set; }

        public DbSet<OrderNomenclatureStage> OrderNomenclatureStages { get; set; }

        public ApplicationDbContext() { Database.EnsureCreated(); }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserRole>().HasKey(u => new { u.RoleId, u.UserId });

            builder.Entity<UserRole>()
                .HasOne(u => u.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserRole>()
                .HasOne(u => u.Role)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserChange>()
                .HasOne(u => u.User)
                .WithMany(u => u.UserChanges)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserChange>()
                .HasOne(u => u.Owner)
                .WithMany(u => u.OwnerChanges)
                .HasForeignKey(u => u.OwnerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<NomenclatureStage>()
                .HasOne(u => u.Nomenclature)
                .WithMany(u => u.NomenclatureStages)
                .HasForeignKey(u => u.NomenclatureId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<NomenclatureStage>()
                .HasOne(u => u.Stage)
                .WithMany(u => u.NomenclatureStages)
                .HasForeignKey(u => u.StageId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<OrderNomenclatureStage>()
                .HasOne(u => u.Stage)
                .WithMany(u => u.OrderNomenclatureStages)
                .HasForeignKey(u => u.StageId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<OrderNomenclatureStage>()
                .HasOne(u => u.OrderNomenclature)
                .WithMany(u => u.OrderNomenclatureStages)
                .HasForeignKey(u => u.OrderNomenclatureId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<OrderNomenclature>()
                .HasOne(u => u.Nomenclature)
                .WithMany(u => u.OrderNomenclatures)
                .HasForeignKey(u => u.NomenclatureId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<OrderNomenclature>()
                .HasOne(u => u.Order)
                .WithMany(u => u.OrderNomenclatures)
                .HasForeignKey(u => u.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            byte[] salt = new Hasher().GetSalt();

            User[] users =
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    SurName = "Root",
                    Name = "Root",
                    MiddleName = "Root",
                    Login = "Root",
                    Salt = salt,
                    Password = new Hasher().GetHash("root", salt),
                    UpdatePassword = false,
                    Active = true,
                    CountFailEnter = 0
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    SurName = "Default",
                    Name = "User",
                    MiddleName = "",
                    Login = "duser",
                    Salt = salt,
                    Password = new Hasher().GetHash("user!1234", salt),
                    UpdatePassword = false,
                    Active = true,
                    CountFailEnter = 0
                }
            };

            RolesConstants rolesConstants = new RolesConstants();

            UserRole[] roles =
            {
                new UserRole { UserId = users[0].Id, RoleId = rolesConstants.roles[0].Id },
                new UserRole { UserId = users[1].Id, RoleId = rolesConstants.roles[1].Id },
            };

            UserChangeTypeConstants userChangeTypeConstants = new UserChangeTypeConstants();

            builder.Entity<User>().HasData(users);
            builder.Entity<Role>().HasData(rolesConstants.roles);
            builder.Entity<UserRole>().HasData(roles);
            builder.Entity<UserChangeType>().HasData(userChangeTypeConstants.userChangeTypes);

            Setting[] settings =
            {
                new Setting { Id = Guid.NewGuid(), Name = "WorkingShift", Value = "11" }
            };

            builder.Entity<Setting>().HasData(settings);
        }
    }
}
