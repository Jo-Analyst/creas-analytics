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
                "[CPF] VARCHAR(MAX) NULL, " +
                "[birth] VARCHAR (10)    NULL," +
                "[phone] VARCHAR(20) NULL," +
                "[address] VARCHAR(200) NULL," +
                "[number_address] VARCHAR(MAX) NULL," +
                "[family_reference] VARCHAR(200) NULL);" +
                "" +
                "CREATE TABLE [dbo].[Paefi_Services] (" +
                "[Id] INT IDENTITY (1, 1) NOT NULL," +
                "[insertion_in_PAEFI] VARCHAR (MAX) NULL," +
                "[general_services] VARCHAR (MAX) NULL," +
                "[type_of_service] VARCHAR (MAX) NULL," +
                "[Summary_of_demand] VARCHAR (MAX) NULL," +
                "[case_of_violation] VARCHAR (MAX) NULL," +
                "[type_of_benefit] VARCHAR (MAX) NULL," +
                "[entrance_door] VARCHAR (MAX) NULL," +
                "[is_there_follow_up] TINYINT NULL," +
                "[does_the_patient_have_special_needs] TINYINT NULL," +
                "[interventions_performed] VARCHAR (MAX) NULL," +
                "[referrals_made] VARCHAR (MAX) NULL," +
                "[summary_description_of_the_case] VARCHAR (MAX) NULL," +
                "[user_id] INT NOT NULL," +
                "[date_insertion] VARCHAR (MAX) NULL," +
                "PRIMARY KEY CLUSTERED ([Id] ASC)," +
                "FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([id]) ON DELETE CASCADE);";

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