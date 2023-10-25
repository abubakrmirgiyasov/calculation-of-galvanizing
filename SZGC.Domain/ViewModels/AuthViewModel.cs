namespace SZGC.Domain.ViewModels
{
    public class InfoSessionViewModel
    {
        
        public string ClientName { get; set; }

        public string Ip { get; set; }

        public string RefreshToken { get; set; }
    }

    public class TokensViewModel
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
