using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SZGC.Domain.BindingModels;
using SZGC.Domain.Models;
using SZGC.Domain.Models.Response;
using SZGC.Domain.ViewModels;
using SZGC.Infrastructure.Cryptography;
using SZGC.Infrastructure.Services;

namespace SZGC.Api.Services
{
    public class RefreshSessionManager
    {
        public async Task<List<InfoSessionViewModel>> GetSessions(string login)
        {
            try
            {
                var user = await new UserRequests().GetByLogin(login);

                if (user != null)
                {
                    var sessions = new List<InfoSessionViewModel>();

                    foreach (RefreshSession session in user.RefreshSessions)
                    {
                        sessions.Add(new InfoSessionViewModel
                        {
                            RefreshToken = new RFC().Decrypt(session.RefreshToken, session.Salt),
                            Ip = session.Ip,
                            ClientName = session.ClientName
                        });
                    }

                    return sessions;
                }
                else
                {
                    throw new Exception("Пользователь не найден");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }

        public async Task<TokensViewModel> UpdateRefreshSession(SessionBindingModel sessionModel, string userIP)
        {
            try
            {
                var session = await new RefreshSessionRequests().GetByRefreshToken(sessionModel.RefreshToken);

                if (session.TimeExpired > DateTime.UtcNow)
                {
                    if (JwtManager.DeleteToken(sessionModel.RefreshToken))
                    {
                        TokensViewModel tokens = JwtManager.GenerateToken(session.User.Login, session.Salt);
                        session.RefreshToken = new RFC().Encrypt(tokens.RefreshToken, session.Salt);
                        session.TimeExpired = DateTime.UtcNow.AddMonths(2);
                        session.Ip = userIP;

                        await new RefreshSessionRequests().UpdateRefreshSession(session);

                        return tokens;
                    }
                    else
                    {
                        throw new Exception("Ошибка удаления токенов пользователя");
                    }
                }
                else
                {
                    JwtManager.DeleteToken(sessionModel.RefreshToken);
                    await DeleteSession(sessionModel);
                    throw new Exception("Сессия пользователя истекла");
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }
       
        public async Task<bool> AddSession(TokensViewModel tokenModel, LoginBindingModel loginModel, string userIp)
        {
            try
            {
                var user = await new UserRequests().GetByLogin(loginModel.Login);

                if (user.RefreshSessions.Count < ConfigurationService.MaxCountSessions)
                {
                    await new RefreshSessionRequests().AddSession(user, tokenModel.RefreshToken, loginModel.Salt, loginModel.ClientName, userIp);
                    return true;
                }
                else
                {
                    throw new Exception(SessionExceptions.StringOutOfRangeSession);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message, Ex);
            }
        }

        public async Task<bool> DeleteSession(SessionBindingModel sessionModel)
        {
            try
            {
                await new RefreshSessionRequests().DeleteSession(sessionModel.RefreshToken);
                JwtManager.DeleteToken(sessionModel.RefreshToken);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteUsersSession(InfoSessionBindingModel infoSessionModel)
        {
            try
            {
                await new RefreshSessionRequests().DeleteUsersSession(infoSessionModel.Login, infoSessionModel.RefreshToken);
                JwtManager.DeleteToken(infoSessionModel.RefreshToken);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}