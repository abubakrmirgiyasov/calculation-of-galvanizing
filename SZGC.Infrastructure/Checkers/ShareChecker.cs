namespace SZGC.Infrastructure.Checkers
{
    public class ShareChecker
    {
        public bool CheckBadSymbol(string message)
        {
            var symbols = new char[] { '_', '\'', '/', '*', ':', '?', '|', '"', '>', '<', ' ' };

            foreach (var item in symbols)
            {
                if (message.IndexOf(item) != -1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
