using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SZGC.Domain.BindingModels;
using SZGC.Domain.ViewModels;

namespace SZGC.Middleware.Services.Interfaces
{
    public interface ISettingRequestService
    {
        Task<List<SettingViewModel>> GetSettingsAsync();
        Task<SettingBindingModel> EditSettingAsync(SettingBindingModel setting);
    }
}
