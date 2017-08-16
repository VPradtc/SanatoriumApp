using System;

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
