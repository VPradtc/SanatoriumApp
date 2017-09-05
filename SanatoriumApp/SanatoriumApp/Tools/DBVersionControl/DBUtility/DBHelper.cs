using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

using DBVersionControl.CustomSection;

namespace DBVersionControl.DBUtility
{
    public class DBHelper
    {
        private const string TABLE_PREFERENCE = "_DbVersion";

        private const string DB_VERSION_KEY = "Version";

        private static readonly DBHelper _instance = new DBHelper();
        private DBHelper()
        {
        }

        public static DBHelper Instance
        {
            get
            {
                return _instance;
            }
        }

        public string GetDBVersion(string connectionString)
        {
            SqlConnection connection = null;
            string version = null;
            try 
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                var cmd =
                    new SqlCommand(
                        string.Format("SELECT Value FROM {0} WHERE Name = \'{1}\'", TABLE_PREFERENCE, DB_VERSION_KEY),
                        connection);
                version = (string) cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Cannot open database"))
                {
                    version = "NoDB";
                }
            }
            finally
            {
                CloseConnection(connection);
            }

            return version;
        }

        /// <summary>
        /// Sets target database version
        /// </summary>
        /// <param name="version">Version to be set</param>
        /// <param name="connectionString">Connection string to be used</param>
        public void UpdateDBVersion(string version, string connectionString)
        {
            SqlConnection connection = null;
            try
            {
                if (!string.IsNullOrEmpty(version) && version.Length <= 50)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    var cmd = new SqlCommand(string.Format("UPDATE {0} SET Value = '{1}' WHERE Name = \'{2}\'", TABLE_PREFERENCE, version, DB_VERSION_KEY), connection);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                CloseConnection(connection);
            }
        }

        /// <summary>
        /// Update database with the SQL-scripts
        /// </summary>
        /// <param name="scripts">Collection of SQL scripts</param>
        /// <param name="location">path to scripts folder</param>
        /// <param name="connectionString">Connection string to be used</param>
        /// <param name="isUnitTest"><c>true</c> - unit-testing mode, <c>false</c> - otherwise</param>
        /// <returns>Updating result</returns>
        public ExecutionResult UpdateDatabase(
            List<ScriptElement> scripts,
            string location,
            string connectionString,
            bool isUnitTest)
        {
            ExecutionResult result = ExecutionResult.SuccessfulResult;
            SqlConnection connection = null;
            SqlTransaction transaction = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                // Start a local transaction
                if (!isUnitTest)
                {
                    transaction = connection.BeginTransaction();
                }

                foreach (var script in scripts)
                {
                    var statements = GetStatements(script, location);
                    result = ExecuteStatements(statements, connection, transaction);
                    if (!result.IsSuccessful)
                    {
                        break;
                    }
                }

                // Commit a local transaction
                if (!isUnitTest && result.IsSuccessful)
                {
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                result = new ExecutionResult(String.Empty, ex);
            }
            finally
            {
                if (!result.IsSuccessful && transaction != null)
                {
                    transaction.Rollback();
                }

                CloseConnection(connection);
            }

            return result;
        }

        /// <summary>
        /// Executes specified statement on the database with specified connection
        /// </summary>
        /// <param name="statements">Statement to execute</param>
        /// <param name="connection">Connection to database</param>
        /// <param name="transaction">Transaction to be used during statement execution</param>
        /// <returns>ExecutionResult</returns>
        public ExecutionResult ExecuteStatements(
            List<string> statements,
            SqlConnection connection,
            SqlTransaction transaction)
        {
            ExecutionResult result = ExecutionResult.SuccessfulResult;
            foreach (var statement in statements)
            {
                if (!string.IsNullOrEmpty(statement.Trim()))
                {
                    try
                    {
                        var cmd = new SqlCommand
                        {
                            CommandText = statement.Trim(),
                            Connection = connection,
                            CommandTimeout = 900,
                            Transaction = transaction
                        };

                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        result = new ExecutionResult(statement, ex);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Reads SQL statements from the file system
        /// </summary>
        /// <param name="scriptElement">Target ScriptElement</param>
        /// <param name="location">File system relative path</param>
        /// <returns>List of statements to execute</returns>
        private static List<string> GetStatements(ScriptElement scriptElement, string location)
        {
            var list = new List<string>();
            var file = new FileInfo(Environment.CurrentDirectory + "\\" + location + "\\" + scriptElement.Name);
            string script = file.OpenText().ReadToEnd();

            string[] lines = Regex.Split(script, "GO");
            list.AddRange(lines);

            return list;
        }

        private static void CloseConnection(DbConnection connection)
        {
            if (connection != null && ConnectionState.Closed != connection.State)
            {
                connection.Close();
            }
        }
    }
}