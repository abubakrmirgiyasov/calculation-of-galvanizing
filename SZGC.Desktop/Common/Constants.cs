using NLog;
using SZGC.Domain.ViewModels;

namespace SZGC.Desktop.Common
{
    public class Constants
    {
        public static UserViewModel User = null;

        public static readonly Logger DesktopLogger = LogManager.GetCurrentClassLogger();
    }
}
