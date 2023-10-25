using System;
using SZGC.Desktop.Common.Interfaces;

namespace SZGC.Desktop.Views.Auth.Interfaces
{
    public interface IAuthVIew : IView, IMessage
    {
        event Action Start;
        
        event Action Login;

        string UserName { get; set; }

        string Password {get; set;}
        
        bool RememberMe { get; set; }

        void SetNameLogin_B(string name);

        void BlockFields(bool flag);
    }
}
