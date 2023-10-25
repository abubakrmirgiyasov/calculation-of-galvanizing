using System;

namespace SZGC.Domain.Models.Response
{
    public class UnauthorizedExceptions
    {
        public static string StringInvalidAccess =>
            "Неверный токен доступа";

        public static string StringMissingToken =>
            "Отсутствует токен доступа";

        public static string StringInvalidRefresh =>
            "Неверный токен обновления";
        
        public static string StringMissingRefresh =>
            "Отсутствует токен обновления";

        public static string StringNotEnoughAccess =>
            "Недостаточно доступа для выполнения";
    }
}
