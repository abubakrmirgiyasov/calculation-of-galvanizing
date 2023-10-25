using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using SZGC.Domain.Models;
using SZGC.Infrastructure.Cryptography;
using SZGC.Infrastructure.Data;

namespace SZGC.Infrastructure.Services
{
    public class RefreshSessionRequests
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public async Task<RefreshSession> GetByRefreshToken(string refreshToken)
        {
            try
            {
                var session = await _context.RefreshSessions
                    .Include(p => p.User)
                    .FirstOrDefaultAsync(p => p.RefreshToken == refreshToken);

                if (session == null)
                {
                    throw new Exception("Не найдена сессия пользователя");
                }

                return session;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<RefreshSession> UpdateRefreshSession(RefreshSession refreshSession)
        {
            try
            {
                var session = await _context.RefreshSessions.FirstOrDefaultAsync(u => u.Id == refreshSession.Id);

                if (session == null)
                {
                    throw new Exception("Не найдено сессия пользователя");
                }

                session.RefreshToken = refreshSession.RefreshToken;
                session.TimeExpired = refreshSession.TimeExpired;
                session.Ip = refreshSession.Ip;
                session.ClientName = refreshSession.ClientName;
                session.Salt = refreshSession.Salt;

                await _context.SaveChangesAsync();

                return session;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> AddSession(User user, string refreshToken, string salt, string clientName, string userIp)
        {
            try
            {
                _context.Users.Attach(user);

                await _context.RefreshSessions.AddAsync(new RefreshSession
                {
                    DateCreate = DateTime.UtcNow,
                    TimeExpired = DateTime.UtcNow.AddMonths(2),
                    RefreshToken = new RFC().Encrypt(refreshToken, salt),
                    Salt = salt,
                    Ip = userIp,
                    ClientName = clientName,
                    User = user,
                });

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<bool> DeleteSession(string refreshToken)
        {
            try
            {
                var session = await _context.RefreshSessions
                    .FirstOrDefaultAsync(p => p.RefreshToken == refreshToken);

                if (session == null)
                {
                    throw new Exception("Сессия не найдена");
                }

                _context.RefreshSessions.Remove(session);

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteUsersSession(string login, string refreshToken)
        {
            try
            {
                var user = await new UserRequests().GetByLogin(login);

                var session = user.RefreshSessions
                    .FirstOrDefault(p => p.RefreshToken == new RFC().Encrypt(refreshToken, p.Salt));

                if (session == null)
                {
                    throw new Exception("Сессия не найдена");
                }

                _context.RefreshSessions.Remove(session);

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
