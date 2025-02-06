using System.Data.SqlClient;

namespace DataBase
{
    public class DB
    {
        static public bool ExistsDataBase()
        {
            bool existsDataBase = false;

            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionStringMaster))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Sys.Databases WHERE name = 'dbCREAS'", connection);
                try
                {
                    connection.Open();
                    comando.ExecuteNonQuery();
                    SqlDataReader dr = comando.ExecuteReader();
                    if (dr.Read())
                    {
                        existsDataBase = true;
                    }

                }
                catch
                {
                    throw;
                }
            }

            return existsDataBase;
        }

        static public void CreateTables()
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
            {
                string sql = "CREATE TABLE [dbo].[Users] (" +
                "[id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), " +
                "[name] VARCHAR(200) NULL, " +
                "[CPF] VARCHAR(14) NULL, " +              
                "[birth] VARCHAR (10)    NULL," +
                "[phone] VARCHAR(20) NULL," +
                "[address] VARCHAR(200) NULL," +
                "[number_address] VARCHAR(MAX) NULL," +
                "[phone] VARCHAR(20) NULL)," +
                "[family_reference] VARCHAR(200) NULL;";

                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandText = sql;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }

        static public void CreateDatabase()
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionStringMaster))
            {
                string sql = "CREATE DATABASE dbCREAS";
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandText = sql;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}