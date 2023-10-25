using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SZGC.Domain.BindingModels;
using SZGC.Domain.Models;
using SZGC.Infrastructure.Data;

namespace SZGC.Infrastructure.Services
{
    public class UserRoleRequests
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public async Task<UserRole> Get(Guid userId, Guid roleId)
        {
            try
            {
                var userRole = await _context.UserRoles
                    .FirstOrDefaultAsync(u => u.UserId == userId && u.RoleId == roleId);
                return userRole;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task AddAll(Guid userId, List<RoleBindingModel> roles)
        {
            try
            {
                for (int i = 0; i < roles.Count; i++)
                {
                    await _context.UserRoles.AddAsync(new UserRole
                    {
                        UserId = userId,
                        RoleId = roles[i].Id
                    });
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task DeleteAll(Guid userId)
        {
            try
            {
                _context.UserRoles.RemoveRange(_context.UserRoles.Where(u => u.UserId == userId));

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
