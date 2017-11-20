namespace Core.DAL.Dictionary
{
    public static class DbDictionary
    {
        public static class SP
        {
            public static class Users
            {
                public const string GetByEmail = "usp_Users_GetByEmail";
                public const string Create = "usp_Users_Create";
                public const string Delete = "usp_Users_Delete";
                public const string Update = "usp_Users_Update";
                public const string GetByPage = "usp_Users_GetByPage";
                public const string GetTotal = "usp_Users_GetTotal";
                public const string GetById = "usp_Users_GetById";
            }

            public static class RefreshTokens
            {
                public const string Create = "usp_RefreshTokens_Create";
                public const string Delete = "usp_RefreshTokens_Delete";
                public const string GetByTokenValue = "usp_RefreshTokens_GetByTokenValue";
            }
        }

        public static class UDT
        {
            public static string IdCollection = "IdCollection";
            public static string StringCollection = "StringCollection";
            public static string KeyValuePairCollection = "KeyValuePairCollection";
        }
    }
}
