namespace _0_Framework.Infrastructure
{
    public static class Roles
    {
        public const string Administrator = "1";
        public const string ContentUploader = "2";
        public const string SystemUser = "3";
        public const string ColleagueUser = "4";
        public static string GetRoleBy(long id)
        {
            switch (id)
            {
                case 1:
                    return "مدیرسیستم";
                case 2:
                    return "محتواگذار";
                case 3:
                    return "کاربر وبسایت";
                case 4:
                    return "همکار";
                default:
                    return "";
            }
        }
    }
}
