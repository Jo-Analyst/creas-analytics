using System;
using System.Data;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DataBase
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string CPF { get; set; }
        public string birth { get; set; }
        public string address { get; set; }
        public string numberAddress { get; set; }
        public string phone { get; set; }
        public string familyReference { get; set; }

        public void Save()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string query = id == 0
                        ? "INSERT INTO Users (name, CPF, address, number_address, phone, birth, family_reference) VALUES (@name, @CPF, @address, @number_address, @phone, @birth, @family_reference); SELECT @@identity"
                        : "UPDATE Users SET name = @name, CPF = @CPF, address = @address, number_address = @number_address, phone = @phone, birth = @birth, family_reference = @family_reference WHERE id = @id";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@CPF", CPF);
                    command.Parameters.AddWithValue("@birth", birth);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@number_address", numberAddress);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@family_reference", familyReference);

                    command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }

        public void Delete()
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
            {
                string query = "DELETE FROM Users WHERE id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.CommandText = query;
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


        static public DataTable FindById(int id)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string query = $"SELECT * FROM Users WHERE Users.id = {id}";
                    var adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.CommandText = query;
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch
            {
                throw;
            }
        }

        public DataTable FindByCPF(string CPF)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string query = $"SELECT * FROM Users WHERE CPF = '{CPF}'";
                    var adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.CommandText = query;
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch
            {
                throw;
            }
        }

        static public DataTable FindByCpfForUser(string CPF)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string query = $"SELECT * FROM Users WHERE CPF = '{CPF}'";
                    var adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.CommandText = query;
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch
            {
                throw;
            }
        }

       static public DataTable FindAll(int page = 0, double quantRows = 5)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string query = $"SELECT * FROM Users ORDER BY name OFFSET {page} ROWS FETCH  NEXT {quantRows} ROWS ONLY";
                    var adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.CommandText = query;
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch
            {
                throw;
            }
        } 
        
        static public DataTable FindByName(string name,int page = 0, double quantRows = 5)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string query = $"SELECT * FROM Users WHERE name LIKE '%{name}%' ORDER BY name OFFSET {page} ROWS FETCH  NEXT {quantRows} ROWS ONLY";
                    var adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.CommandText = query;
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch
            {
                throw;
            }
        }

        public static double CountQuantityUsers()
        {
            using (var connection = new SqlConnection(DbConnectionString.connectionString))
            {
                connection.Open();
                string query = $"SELECT COUNT(id) FROM Users";
                var command = new SqlCommand(query, connection);
                command.CommandText = query;

                int count = Convert.ToInt32(command.ExecuteScalar());
                return count;
            }
        }
    }
}