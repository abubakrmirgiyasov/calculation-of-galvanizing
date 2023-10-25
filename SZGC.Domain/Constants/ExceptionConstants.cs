namespace SZGC.Domain.Constants
{
    public static class ExceptionConstants
    {
        public static string ErrorDeletingSession =>
            "Ошибка удаления сессии";

        public static string ErrorUpdatingUserToken =>
            "Ошибка обновления токенов пользователя";

        public static string ErrorAddingUserSession =>
            "Ошибка добавления сессии пользоваетля";

        public static string UnableToConnectServer =>
            "Невозможно соединиться с удаленным сервером";
    }
}
