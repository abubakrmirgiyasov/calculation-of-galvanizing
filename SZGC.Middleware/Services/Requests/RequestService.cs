using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SZGC.Domain.BindingModels;
using SZGC.Domain.Constants;
using SZGC.Domain.Exceptions;
using SZGC.Domain.Models.Response;
using SZGC.Middleware.Constants;
using SZGC.Middleware.Constants.Routes;

namespace SZGC.Middleware.Services.Requests
{
    public class RequestService<T>
    {
        private HttpClient _client;

        private bool _auth;

        public HttpClient Client { get => _client; set => _client = value; }

        public RequestService(bool auth)
        {
            _auth = auth;
            SetHttpClient();
        }

        private void SetHttpClient()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri(new BaseUrl().LoadBaseUrl())
            };

            Client.DefaultRequestHeaders.Accept.Clear();

            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            if (_auth)
            {
                Client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(AuthenticationConstants.TOKEN_DEFAULT_SCHEME, Params.AccessToken);
            }
        }

        public async Task<T> GetRequestAsync(string route)
        {
            try
            {
                var response = await _client.GetAsync(route);
                var apiRespoonse = await response.Content.ReadAsStringAsync();
                return new JsonResponse<T>().GetResponse(response, apiRespoonse);
            }
            catch (Exception ex)
            {
                try
                {
                    ValidationException(ex);
                    throw new Exception(ex.Message, ex);
                }
                catch (InvalidAccessTokenException)
                {
                    await new AuthRequestService().UpdateRefreshTokensAsync(new SessionBindingModel
                    {
                        RefreshToken = Params.RefreshToken,
                        ClientName = Environment.MachineName
                    });

                    try
                    {
                        SetHttpClient();
                        var response = await _client.GetAsync(route);
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        return new JsonResponse<T>().GetResponse(response, apiResponse);
                    }
                    catch (Exception all)
                    {
                        ValidationException(all);
                        throw new Exception(all.Message, all);
                    }
                }
                catch (Exception all)
                {
                    throw new Exception(all.Message, all);
                }
            }
        }

        public async Task<T> PostRequestAsync(string content, string route)
        {
            try
            {
                var response = await _client.PostAsync(route, new StringContent(content, Encoding.UTF8, "application/json"));
                var apiResponse = await response.Content.ReadAsStringAsync();
                return new JsonResponse<T>().GetResponse(response, apiResponse);
            }
            catch (Exception ex)
            {
                try
                {
                    ValidationException(ex);
                    throw new Exception(ex.Message, ex);
                }
                catch (ServerConnectionFailedException sc)
                {
                    throw new ServerConnectionFailedException(sc.Message, sc);
                }
                catch (InvalidAccessTokenException)
                {
                    await new AuthRequestService().UpdateRefreshTokensAsync(new SessionBindingModel
                    {
                        RefreshToken = Params.RefreshToken,
                        ClientName = Environment.MachineName
                    });

                    try
                    {
                        SetHttpClient();
                        var response = await _client.PostAsync(route, new StringContent(content, Encoding.UTF8, "application/json"));
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        return new JsonResponse<T>().GetResponse(response, apiResponse);
                    }
                    catch (Exception all)
                    {
                        ValidationException(all);
                        throw new Exception(all.Message, all);
                    }
                }
                catch (Exception all)
                {
                    throw new Exception(all.Message, all);
                }
            }
        }

        private void ValidationException(Exception ex)
        {
            if (ex.Message == UnauthorizedExceptions.StringInvalidAccess)
            {
                throw new InvalidAccessTokenException(ex.Message);
            }
            else if (ex.Message == SessionExceptions.StringOutOfRangeSession)
            {
                throw new OutOfRangeSessionsException(ex.Message);
            }
            else if (ex.Message == UserExceptions.StringNeedUpdatePassword)
            {
                throw new NeedUpdatePasswordException(ex.Message);
            }
            else if (ex.InnerException != null && ex.InnerException.Message == ExceptionConstants.UnableToConnectServer)
            {
                throw new ServerConnectionFailedException(ex.Message, ex);
            }
            else
            {
                throw new InvalidRefreshTokenException(ex.Message);
            }
        }
    }
}
