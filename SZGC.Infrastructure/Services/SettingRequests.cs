using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SZGC.Domain.BindingModels;
using SZGC.Domain.Models;
using SZGC.Infrastructure.Data;

namespace SZGC.Infrastructure.Services
{
    public class SettingRequests
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public async Task<List<Setting>> GetSettings()
        {
            try
            {
                var list = await _context.Settings
                    .ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Setting> GetSettingByName(string name)
        {
            try
            {
                var setting = await _context.Settings
                    .FirstOrDefaultAsync(x => x.Name == name);

                if (setting == null)
                {
                    throw new Exception("Настройки с таким ID не существует");
                }

                return setting;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task EditSetting(SettingBindingModel settingModel)
        {
            try
            {
                var setting = await GetSettingByName(settingModel.Name);

                setting.Value = settingModel.Value;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
