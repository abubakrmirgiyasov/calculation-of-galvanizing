using JWT.Algorithms;
using JWT.Builder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Caching;
using SZGC.Domain.ViewModels;
using SZGC.Infrastructure.Cryptography;

namespace SZGC.Api.Services
{
    public static class JwtManager
    {
        private const string SECRET_KEY =
            "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG412V8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        private static List<TokensViewModel> sessions = new List<TokensViewModel>();

        public static TokensViewModel GenerateToken(string login, string salt, int expireSeconds = 86400)
        {
            try
            {
                var accessToken = new JwtBuilder()
                    .WithAlgorithm(new HMACSHA256Algorithm())
                    .WithSecret(SECRET_KEY)
                    .AddClaim("exp", DateTimeOffset.UtcNow.AddSeconds(expireSeconds).ToUnixTimeSeconds())
                    .AddClaim(ClaimTypes.Name, login)
                    .Encode();

                var refreshToken = Guid
                    .NewGuid()
                    .ToString("n");
                refreshToken += DateTime.UtcNow.GetHashCode();

                sessions.Add(new TokensViewModel
                {
                    AccessToken = accessToken,
                    RefreshToken = new RFC().Encrypt(refreshToken, salt),
                });

                return new TokensViewModel
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static bool DeleteToken(string refreshToken)
        {
            try
            {
                var token = sessions.FirstOrDefault(u => u.RefreshToken == refreshToken);

                if (token != null)
                {
                    sessions.Remove(token);

                    string json = null;

                    try
                    {
                        json = new JwtBuilder()
                            .WithAlgorithm(new HMACSHA256Algorithm())
                            .WithSecret(SECRET_KEY)
                            .MustVerifySignature()
                            .Decode(token.AccessToken);
                    }
                    catch
                    {
                        return true;
                    }

                    dynamic deserializeClaims = JsonConvert.DeserializeObject(json);

                    Cache badTokens = new Cache();
                    DateTimeOffset exp = new DateTimeOffset(new DateTime(1970, 1, 1)
                        .AddSeconds(deserializeClaims["exp"].Value));
                    badTokens.Insert(
                        key: token.AccessToken,
                        value: "NoValidate",
                        dependencies: null,
                        absoluteExpiration: exp.DateTime + exp.Offset,
                        slidingExpiration: Cache.NoSlidingExpiration);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                string json = null;

                try
                {
                    json = new JwtBuilder()
                        .WithAlgorithm(new HMACSHA256Algorithm())
                        .WithSecret(SECRET_KEY)
                        .MustVerifySignature()
                        .Decode(token);
                }
                catch
                {
                    return null;
                }

                Cache badToken = new Cache();

                if (badToken.Get(token) != null)
                {
                    return null;
                }

                var claims = new List<Claim>();

                dynamic deserializeClaims = JsonConvert.DeserializeObject(json);

                foreach (var claim in deserializeClaims)
                {
                    claims.Add(new Claim(claim.Name.ToString(), claim.Value.ToString()));
                }

                return new ClaimsPrincipal(new ClaimsIdentity(claims, AuthenticationTypes.Password));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}