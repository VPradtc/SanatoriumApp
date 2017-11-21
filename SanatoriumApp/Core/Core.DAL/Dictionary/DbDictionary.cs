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
                public const string GetAll = "usp_Users_GetAll";
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
                public const string GetAll = "usp_MedicalProcedures_GetAll";
            }

            public static class ScheduledMedicalProcedures
            {
                public const string Create = "usp_ScheduledMedicalProcedures_Create";
                public const string Delete = "usp_ScheduledMedicalProcedures_Delete";
                public const string Update = "usp_ScheduledMedicalProcedures_Update";
                public const string GetByPage = "usp_ScheduledMedicalProcedures_GetByPage";
                public const string GetTotal = "usp_ScheduledMedicalProcedures_GetTotal";
                public const string GetById = "usp_ScheduledMedicalProcedures_GetById";
            }

            public static class Bookings
            {
                public const string Create = "usp_Bookings_Create";
                public const string Delete = "usp_Bookings_Delete";
                public const string Update = "usp_Bookings_Update";
                public const string GetByPage = "usp_Bookings_GetByPage";
                public const string GetTotal = "usp_Bookings_GetTotal";
                public const string GetById = "usp_Bookings_GetById";
                public const string GetByOverlappingDateRange = "usp_Bookings_GetByOverlappingDateRange";
            }

            public static class Rooms
            {
                public const string Create = "usp_Rooms_Create";
                public const string Delete = "usp_Rooms_Delete";
                public const string Update = "usp_Rooms_Update";
                public const string GetByPage = "usp_Rooms_GetByPage";
                public const string GetTotal = "usp_Rooms_GetTotal";
                public const string GetById = "usp_Rooms_GetById";
                public const string GetAll = "usp_Rooms_GetAll";
            }

            public static class Clients
            {
                public const string Create = "usp_Clients_Create";
                public const string Delete = "usp_Clients_Delete";
                public const string Update = "usp_Clients_Update";
                public const string GetByPage = "usp_Clients_GetByPage";
                public const string GetTotal = "usp_Clients_GetTotal";
                public const string GetById = "usp_Clients_GetById";
                public const string GetByPassport = "usp_Clients_GetByPassport";
                public const string GetAll = "usp_Clients_GetAll";
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
