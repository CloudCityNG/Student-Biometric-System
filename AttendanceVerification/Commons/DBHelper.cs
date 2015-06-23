using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AttendanceVerification
{
    public static class DBHelper
    {
        /// <summary>
        /// [METHOD] connect to the db
        /// </summary>
        /// <returns>TRUE, if it is saved</returns>
        public static string ConnectionString()
        {
            try
            {
                return System.Configuration.ConfigurationManager.AppSettings["connectionString"];

            }
            catch (Exception ce)
            {

                throw new ApplicationException("Unable to get DB Connection string from Config File. Contact Administrator" + ce);
            }
        }
        /// <summary>
        /// creates and open a sqlconnection
        /// </summary>
        /// <param name="connectionString">
        /// A <see cref="System.String"/> that contains the sql connectin parameters
        /// </param>
        /// <returns>
        /// A <see cref="SqlConnection"/> 
        /// </returns>
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(ConnectionString());
                connection.Open();
            }
            catch (Exception ex)
            {
                //ex should be written into a error log
                Console.WriteLine("{0}", ex.Message);
                // dispose of the connection to avoid connections leak
                if (connection != null)
                {
                    connection.Dispose();
                }
            }
            return connection;
        }

        /// <summary>
        /// Creates a sqlcommand
        /// </summary>
        /// <param name="connection">
        /// A <see cref="SqlConnection"/>
        /// </param>
        /// <param name="commandText">
        /// A <see cref="System.String"/> of the sql query.
        /// </param>
        /// <param name="commandType">
        /// A <see cref="CommandType"/> of the query type.
        /// </param>
        /// <returns>
        /// A <see cref="SqlCommand"/>
        /// </returns>
        public static SqlCommand GetCommand(this SqlConnection connection, string commandText, CommandType commandType)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandTimeout = connection.ConnectionTimeout;
            command.CommandType = commandType;
            command.CommandText = commandText;
            return command;
        }

        /// <summary>
        /// Adds a parameter to the command parameter array.
        /// </summary>
        /// <param name="command">
        /// A <see cref="SqlCommand"/> 
        /// </param>
        /// <param name="parameterName">
        /// A <see cref="System.String"/> of the named parameter in the sql query.
        /// </param>
        /// <param name="parameterValue">
        /// A <see cref="System.Object"/> of the parameter value.
        /// </param>
        /// <param name="parameterSqlType">
        /// A <see cref="SqlDbType"/>
        /// </param>
        public static void AddParameter(this SqlCommand command, string parameterName, object parameterValue, SqlDbType parameterSqlType)
        {
            if (!parameterName.StartsWith("@"))
            {
                parameterName = "@" + parameterName;
            }
            command.Parameters.Add(parameterName, parameterSqlType);
            command.Parameters[parameterName].Value = parameterValue;
        }
    }
}
