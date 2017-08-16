using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using DBVersionControl.CustomSection;
using DBVersionControl.DBUtility;

namespace DBVersionControl
{
    public class UpdateHelper
    {
        private const int ERROR_EXIT_CODE = -1;

        private const string SKIP_DIALOG_PARAMETER = "-sd";

        private static string _initialVersion = string.Empty;

        /// <summary>
        /// Indicates whether user prompt should be skipped
        /// </summary>
        private static bool _skipDialog;

        public static bool DbExists => _initialVersion != "NoDB";
        public static bool Init => string.IsNullOrWhiteSpace(_initialVersion);

        public static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                var arguments = new List<string>();
                arguments.AddRange(args);
                _skipDialog = arguments.Contains(SKIP_DIALOG_PARAMETER);
            }

            Summary = new Dictionary<string, ExecutionResult>();
            DBVersions = ConfigurationManager.GetSection("DBVersions") as DBVersionsSection;

            var connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            try
            {
                _initialVersion = DBHelper.Instance.GetDBVersion(connectionString);
            }
            catch (Exception)
            {
                // Who cares?
            }

            try
            {
                using (var target = new SqlConnection(connectionString))
                {
                    MainDB = target.Database;
                    WriteMessage("The next Database will be updated to the latest version:");
                    WriteMessage();
                    WriteMessage(string.Format("SQL Server: '{0}', Database Name: '{1}'", target.DataSource, target.Database));
                    WriteMessage();
                    if (DbExists)
                    {
                        WriteMessage(string.Format("Current Database version is '{0}'", _initialVersion));
                    }
                    else
                    {
                        WriteMessage("Unable to retrieve DB version.");

                    }
                    WriteMessage();
                }

                // if "-sd" parameter passed - skip dialog with user
                if (!_skipDialog)
                {
                    DisplayInformation(connectionString);
                }
                else
                {
                    StartUpdating(connectionString);
                    ExitWithSuccess();
                }
            }
            catch (Exception ex)
            {
                WriteUpdateError(string.Empty, "Specified connection string is incorrect or Database is not available", ex);
                if (!_skipDialog)
                {
                    WriteMessage("Press any key to exit.");
                    ReadKey();
                }

                ExitWithError();
            }
        }

        public static Dictionary<string, ExecutionResult> Summary { get; set; }

        public static DBVersionsSection DBVersions { get; private set; }

        public static string MainDB { get; set; }

        private static void DisplayInformation(string connectionString)
        {
            WriteMessage("Do you want to proceed? (Y/N)");
            ConsoleKeyInfo info = ReadKey();

            if (info.KeyChar.Equals('y') || info.KeyChar.Equals('Y'))
            {
                WriteMessage();
                StartUpdating(connectionString);
            }
            else if (info.KeyChar.Equals('n') || info.KeyChar.Equals('N'))
            {
                WriteMessage();
                WriteMessage("No changes have been made. Press any key to exit.");
                ReadKey();

                ExitWithSuccess();
            }
            else
            {
                WriteMessage();
                WriteMessage("Incorrect input.");

                WriteMessage();
                DisplayInformation(connectionString);
            }
        }

        private static void StartUpdating(string connectionString)
        {
            if (DBVersions != null)
            {
                WriteMessage();
                WriteMessage(string.Format("Updating Database {0}...", MainDB));

                if (!DbExists)
                {
                   CreateDB(connectionString);
                }

                if (Init)
                {
                    var rootVersion = DBVersions.RootVersion;
                    var versionNumber = rootVersion.Number;

                    var updateResult = TryUpdateDBVersion(
                        connectionString
                        , ref versionNumber
                        , rootVersion
                        , rootVersion.Scripts.OfType<ScriptElement>().ToList()
                        , true);

                    if (updateResult.IsSuccessful)
                    {
                        _initialVersion = versionNumber;
                    }
                    else
                    {
                        ExitWithError();
                    }
                }

                var result = FindVersion(_initialVersion, DBVersions.Versions, connectionString, false);
                Summary.Add(MainDB, result);

                WriteMessage();
                WriteMessage(string.Format("Database {0} has been SUCCESSFULLY updated to version {1}", MainDB, result.FinalVersion));

                if (!_skipDialog)
                {
                    WriteMessage("Press any key to exit");
                    ReadKey();
                }

                ExitWithSuccess();
            }
            else
            {
                if (!_skipDialog)
                {
                    WriteMessage("There are no any valid sections. Press any key to exit.");
                    ReadKey();
                }

                ExitWithSuccess();
            }
        }

        private static void WriteMessage()
        {
            WriteMessage(String.Empty);
        }

        private static void WriteMessage(string message)
        {
            Console.WriteLine(message);
        }

        private static void WriteUpdateError(string newVersion, string statement, Exception error)
        {
            WriteMessage(String.Format("Unable to update database to version: {0}", newVersion));
            WriteMessage(String.Format("Exception: {0}", error.Message));
            WriteMessage(String.Format("SQL statement: {0}", statement));
        }

        private static ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        private static void ExitWithError()
        {
            Environment.Exit(ERROR_EXIT_CODE);
        }

        private static void ExitWithSuccess()
        {
            Environment.Exit(0);
        }

        public static ExecutionResult FindVersion(
            string currentVersion,
            VersionsCollection versions,
            string connectionString,
            bool isUnitTest)
        {
            var result = ExecutionResult.SuccessfulResult;
            var newVersion = currentVersion;

            for (var i = 0; i < versions.Count; i++)
            {
                if (versions[i].ApplyTo.Equals(currentVersion))
                {
                    var version = versions[i];
                    var scripts = version.Scripts.OfType<ScriptElement>().ToList();
                    if (scripts.Count > 0)
                    {
                        result = TryUpdateDBVersion(connectionString, ref newVersion, version, scripts);

                        if (!result.IsSuccessful)
                        {
                            return result;
                        }
                    }

                    break;
                }
            }

            if (!newVersion.Equals(currentVersion))
            {
                _initialVersion = newVersion;
                result = FindVersion(newVersion, versions, connectionString, false);
            }
            else
            {
                result.FinalVersion = currentVersion;
            }

            return result;
        }

        private static ExecutionResult TryUpdateDBVersion(
            string connectionString,
            ref string newVersion,
            VersionsElement version,
            List<ScriptElement> scripts,
            bool isUnitTest = false)
        {
            ExecutionResult result;
            WriteMessage(String.Format("Updating database to version {0}", version.Number));
            result = DBHelper.Instance.UpdateDatabase(scripts, version.Scripts.Location, connectionString, isUnitTest);

            if (result.IsSuccessful)
            {
                newVersion = version.Number;
                DBHelper.Instance.UpdateDBVersion(newVersion, connectionString);
            }
            else
            {
                WriteUpdateError(version.Number, result.Statement, result.Exception);

                WriteMessage("Press any key to proceed.");
                ReadKey();

                result.FinalVersion = newVersion;
            }

            return result;
        }

        private static ExecutionResult TryCreateDB(
            string connectionString,
            ref string newVersion,
            VersionsElement version,
            List<ScriptElement> scripts,
            bool isUnitTest = false)
        {
            ExecutionResult result;
            WriteMessage(String.Format("Updating database to version {0}", version.Number));
            result = DBHelper.Instance.UpdateDatabase(scripts, version.Scripts.Location, connectionString, isUnitTest);

            if (!result.IsSuccessful)
            {
                WriteUpdateError(version.Number, result.Statement, result.Exception);

                WriteMessage("Press any key to proceed.");
                ReadKey();

                result.FinalVersion = newVersion;
            }

            return result;
        }

        private static void CreateDB(string connectionString)
        {
            var createDb = DBVersions.CreateDB;
            var createDbVersionNo = createDb.Number;

            var sb = new SqlConnectionStringBuilder(connectionString);
            sb.Remove("Initial Catalog");
            var noDbConnectionString = sb.ToString();

            var updateResult = TryCreateDB(
                noDbConnectionString
                , ref createDbVersionNo
                , createDb
                , createDb.Scripts.OfType<ScriptElement>().ToList()
                , true);

            if (!updateResult.IsSuccessful)
            {
                ExitWithError();
            }

            _initialVersion = null;
            Thread.Sleep(1000);
        }
    }
}