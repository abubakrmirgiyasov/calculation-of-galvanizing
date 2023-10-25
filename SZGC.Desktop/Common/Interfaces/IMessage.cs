namespace SZGC.Desktop.Common.Interfaces
{
    public interface IMessage
    {
        void Info(string message);

        void Warning(string message);

        void Error(string message);
    }
}
