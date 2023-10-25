using NLog;

namespace SZGC.Api.Constants
{
    public class LoggerConstant
    {
        public static readonly Logger ApiLogger = LogManager.GetCurrentClassLogger();
    }
}