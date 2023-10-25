namespace SZGC.Domain.Models.Response
{
    public class UserExceptions
    {
        public static string StringNeedUpdatePassword =>
            "Необходимо обновить пароль";

        public static string StringNotFoundUser =>
            "Пользователь не найден";

        public static string StringBadPassword =>
            "Не верныйe логин/пароль";

        public static string StringOutOfRangeEnter =>
            "Превышено количество неверных входов";

        public static string StringInactive =>
            "Учетная запись не активна";
    }
}
