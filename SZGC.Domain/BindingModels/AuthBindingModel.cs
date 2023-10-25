using System.ComponentModel.DataAnnotations;

namespace SZGC.Domain.BindingModels
{
    public class LoginBindingModel
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }
        
        public string ClientName { get; set; }
    }

    public class UpdatePasswordBindingModel
    {
        public string Login { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }

    public class SessionBindingModel
    {
        public string RefreshToken { get; set; }

        public string ClientName { set; get; }
    }

    public class InfoSessionBindingModel
    {
        public string Login { set; get; }

        public string Password { set; get; }

        public string ClientName { get; set; }

        public string Ip { get; set; }

        public string RefreshToken { get; set; }
    }
}
