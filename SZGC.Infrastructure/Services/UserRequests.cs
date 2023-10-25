using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SZGC.Domain.BindingModels;
using SZGC.Domain.Models;
using SZGC.Infrastructure.Cryptography;
using SZGC.Infrastructure.Data;
using SZGC.IntegrationDatabase.Checkers;

namespace SZGC.Infrastructure.Services
{
    public class UserRequests
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public async Task<User> GetByLogin(string username)
        {
            try
            {
                var user = await _context.Users
                    .Include(u => u.RefreshSessions)
                    .Include(u => u.UserRoles)
                    .FirstOrDefaultAsync(u => u.Login == username);

                if (user == null)
                {
                    throw new Exception("Пользователь не найден");
                }

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<User> GetByLoginWithoutIncludes(string login)
        {
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Login == login);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<User> GetById(Guid id)
        {
            try
            {
                var user = await _context.Users
                    .Include(u => u.RefreshSessions)
                    .Include(u => u.UserRoles)
                    .FirstOrDefaultAsync(u => u.Id == id);
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public List<User> GetAll()
        {
            try
            {
                var users = _context.Users.ToList();
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Add(UserBindingModel userBindingModel)
        {
            try
            {
                new UserChecker().CheckedBadFieldsPreAdd(userBindingModel);

                byte[] salt = new Hasher().GetSalt();

                await _context.Users.AddAsync(new User
                {
                    SurName = userBindingModel.SurName,
                    Name = userBindingModel.Name,
                    MiddleName = userBindingModel.MiddleName,
                    CreateDate = DateTime.Now,
                    Login = userBindingModel.Login,
                    Salt = salt,
                    Password = new Hasher().GetHash(userBindingModel.Password, salt),
                    UpdatePassword = userBindingModel.UpdatePassword,
                    Active = userBindingModel.Active,
                    CountFailEnter = 0
                });

                await _context.SaveChangesAsync();

                var user = await GetByLogin(userBindingModel.Login);
                await new UserRoleRequests().AddAll(user.Id, userBindingModel.Roles);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Edit(UserBindingModel userBindingModel)
        {
            try
            {
                new UserChecker().CheckedBadFieldsPreEdit(userBindingModel);

                var user = await GetById(userBindingModel.Id);

                if (!user.Active && userBindingModel.Active)
                {
                    user.CountFailEnter = 0;
                }

                if (!string.IsNullOrEmpty(userBindingModel.Password))
                {
                    user.SurName = userBindingModel.SurName;
                    user.Name = userBindingModel.Name;
                    user.MiddleName = userBindingModel.MiddleName;
                    user.Login = userBindingModel.Login;
                    user.Password = new Hasher().GetHash(userBindingModel.Password, user.Salt);
                    user.UpdatePassword = userBindingModel.UpdatePassword;
                    user.Active = userBindingModel.Active;
                }
                else
                {
                    user.SurName = userBindingModel.SurName;
                    user.Name = userBindingModel.Name;
                    user.MiddleName = userBindingModel.MiddleName;
                    user.Login = userBindingModel.Login;
                    user.UpdatePassword = userBindingModel.UpdatePassword;
                    user.Active = userBindingModel.Active;
                }

                await _context.SaveChangesAsync();
                await new UserRoleRequests().DeleteAll(user.Id);
                await new UserRoleRequests().AddAll(user.Id, userBindingModel.Roles);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task UpdatePassword(UpdatePasswordBindingModel updatePasswordBindingModel)
        {
            try
            {
                new UserChecker().CheckFieldPreUpdatePassword(updatePasswordBindingModel);

                var user = await GetByLogin(updatePasswordBindingModel.Login);

                user.Password = new Hasher().GetHash(updatePasswordBindingModel.NewPassword, user.Salt);

                user.UpdatePassword = false;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Delete(UserBindingModel userBindingModel)
        {
            try
            {
                new UserChecker().CheckedBadFieldsPreDelete(userBindingModel);

                var user = await GetById(userBindingModel.Id);

                _context.Users.Remove(user);

                await _context.SaveChangesAsync();
                await new UserRoleRequests().DeleteAll(user.Id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
