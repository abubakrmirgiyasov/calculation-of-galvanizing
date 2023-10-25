using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SZGC.Domain.Models;
using SZGC.Domain.Models.Response;
using SZGC.Infrastructure.Data;

namespace SZGC.Infrastructure.Services
{
    public class RoleRequests
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public async Task<List<Role>> GetRoles(string login)
        {
            try
            {
                var roles = new List<Role>();

                var user = await new UserRequests().GetByLogin(login);

                foreach (var userRole in user.UserRoles)
                {
                    var role = await _context.Roles
                        .FirstOrDefaultAsync(u => u.Id == userRole.RoleId);

                    if (role != null)
                    {
                        roles.Add(role);
                    }
                    else
                    {
                        throw new Exception(RoleExceptions.StringNotFoundRole);
                    }
                }

                return roles;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<Role> GetAll()
        {
            try
            {
                var roles = _context.Roles.ToList();
                return roles;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
