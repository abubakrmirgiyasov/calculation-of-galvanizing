using System;
using System.Configuration;

namespace SZGC.Api.Services
{
    public static class ConfigurationService
    {
        private static readonly string _maxCountSessions = ConfigurationManager.AppSettings.Get("MaxCountSessions");

        public static int MaxCountSessions
        {
            get
            {
                try
                {
                    return Convert.ToInt32(_maxCountSessions);
                }
                catch
                {
                    return 10;
                }
            }
        }
    }
}