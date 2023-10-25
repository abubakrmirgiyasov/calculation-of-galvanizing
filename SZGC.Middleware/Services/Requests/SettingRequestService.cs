using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SZGC.Domain.BindingModels;
using SZGC.Domain.ViewModels;
using SZGC.Middleware.Constants.Routes;
using SZGC.Middleware.Services.Interfaces;

namespace SZGC.Middleware.Services.Requests
{
    public class SettingRequestService : ISettingRequestService
    {
        public async Task<List<SettingViewModel>> GetSettingsAsync()
        {
            var baseRequestService = new RequestService<List<SettingViewModel>>(true);
            return await baseRequestService.GetRequestAsync(SettingRoute.SETTING_ALL);
        }
        public async Task<SettingBindingModel> EditSettingAsync(SettingBindingModel setting)
        {
            var baseRequestService = new RequestService<SettingBindingModel>(true);
            var content = new JsonContent<SettingBindingModel>().GetContent(setting);
            return await baseRequestService.PostRequestAsync(content, SettingRoute.SETTING_EDIT);
        }
    }
}
