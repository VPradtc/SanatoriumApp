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

            public static class MedicalProcedures
            {
                public const string Create = "usp_MedicalProcedures_Create";
                public const string Delete = "usp_MedicalProcedures_Delete";
                public const string Update = "usp_MedicalProcedures_Update";
                public const string GetByPage = "usp_MedicalProcedures_GetByPage";
                public const string GetTotal = "usp_MedicalProcedures_GetTotal";
                public const string GetById = "usp_MedicalProcedures_GetById";
            }

            public static class Rooms
            {
                public const string Create = "usp_Rooms_Create";
                public const string Delete = "usp_Rooms_Delete";
                public const string Update = "usp_Rooms_Update";
                public const string GetByPage = "usp_Rooms_GetByPage";
                public const string GetTotal = "usp_Rooms_GetTotal";
                public const string GetById = "usp_Rooms_GetById";
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
