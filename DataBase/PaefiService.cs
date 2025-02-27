using System;
using System.Data;
using System.Data.SqlClient;

namespace DataBase
{
    public class PaefiService
    {
        public int id { get; set; }
        public string insertionInPaefi { get; set; }
        public string typeOfService { get; set; }
        public string summaryOfDemand { get; set; }
        public string caseOfViolation { get; set; }
        public string typeOfBenefit { get; set; }
        public bool isThereFollowUp { get; set; }
        public bool doesThePatientHaveSpecialNeeds { get; set; }
        public string referralsMade { get; set; }
        public string interventionsPerformed { get; set; }
        public string summaryDescriptionOfTheCase { get; set; }
        public string entranceDoor { get; set; }
        public int userId { get; set; }
        public DateTime dateInsertion { get; set; }

        public void Save()
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
            {
                string query = id == 0
                    ? "INSERT INTO paefi_services (insertion_in_PAEFI, type_of_service, summary_of_demand, case_of_violation, type_of_benefit, is_there_follow_up, does_the_patient_have_special_needs, interventions_performed, referrals_made, summary_description_of_the_case, user_id, date_insertion, entrance_door) VALUES (@insertion_in_PAEFI, @type_of_service, @summary_of_demand, @case_of_violation, @type_of_benefit, @is_there_follow_up, @does_the_patient_have_special_needs, @interventions_performed, @referrals_made, @summary_description_of_the_case, @user_id, @date_insertion, @entrance_door); SELECT @@IDENTITY"
                    : "UPDATE Paefi_services SET insertion_in_PAEFI = @insertion_in_PAEFI, type_of_service = @type_of_service, summary_of_demand = @summary_of_demand, case_of_violation = @case_of_violation, type_of_benefit = @type_of_benefit, is_there_follow_up = @is_there_follow_up, does_the_patient_have_special_needs = @does_the_patient_have_special_needs, interventions_performed = @interventions_performed, referrals_made = @referrals_made, summary_description_of_the_case = @summary_description_of_the_case, user_id = @user_id, date_insertion = @date_insertion, entrance_door = @entrance_door WHERE id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@insertion_in_PAEFI", insertionInPaefi);
                    command.Parameters.AddWithValue("@type_of_service", typeOfService);
                    command.Parameters.AddWithValue("@summary_of_demand", summaryOfDemand);
                    command.Parameters.AddWithValue("@entrance_door", entranceDoor);
                    command.Parameters.AddWithValue("@case_of_violation", caseOfViolation);
                    command.Parameters.AddWithValue("@type_of_benefit", typeOfBenefit);
                    command.Parameters.AddWithValue("@is_there_follow_up", isThereFollowUp);
                    command.Parameters.AddWithValue("@does_the_patient_have_special_needs", doesThePatientHaveSpecialNeeds);
                    command.Parameters.AddWithValue("@interventions_performed", interventionsPerformed);
                    command.Parameters.AddWithValue("@referrals_made", referralsMade);
                    command.Parameters.AddWithValue("@summary_description_of_the_case", summaryDescriptionOfTheCase);
                    command.Parameters.AddWithValue("@user_id", userId);
                    command.Parameters.AddWithValue("@date_insertion", dateInsertion);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        static public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
            {
                string query = "DELETE FROM Paefi_services WHERE id = @id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        static public DataTable FindByUserId(int userId, int page = 0, int quantRows = 5)
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string query = $"SELECT id, CONVERT(VARCHAR, CONVERT(date, date_insertion, 103), 103) as date_insertion, insertion_in_PAEFI, type_of_service, summary_of_demand, case_of_violation, type_of_benefit, is_there_follow_up, does_the_patient_have_special_needs, interventions_performed, referrals_made, summary_description_of_the_case, user_id, entrance_door FROM Paefi_services WHERE user_id = @user_id ORDER BY date_insertion DESC OFFSET {page} ROWS FETCH  NEXT {quantRows} ROWS ONLY";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@user_id", userId);


                        connection.Open();
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return table;
        }

        static public DataTable FindByAll()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string query = $"SELECT Paefi_services.id, CONVERT(VARCHAR, CONVERT(date, date_insertion, 103), 103) as date_insertion, Paefi_services.insertion_in_PAEFI, Paefi_services.type_of_service, Paefi_services.summary_of_demand, Paefi_services.case_of_violation, Paefi_services.type_of_benefit, Paefi_services.is_there_follow_up, Paefi_services.does_the_patient_have_special_needs, Paefi_services.interventions_performed, Paefi_services.referrals_made, Paefi_services.summary_description_of_the_case, Paefi_services.user_id, Paefi_services.entrance_door, Users.name, Users.birth, Users.address, users.number_address, Users.family_reference FROM Paefi_services  INNER JOIN Users ON Users.id = Paefi_services.user_id ORDER BY date_insertion DESC";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        connection.Open();
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return table;
        }

        static public DataTable FindByPeriod(string month, string year)
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string query = $"SELECT Paefi_services.id, CONVERT(VARCHAR, CONVERT(date, date_insertion, 103), 103) as date_insertion, Paefi_services.insertion_in_PAEFI, Paefi_services.type_of_service, Paefi_services.summary_of_demand, Paefi_services.case_of_violation, Paefi_services.type_of_benefit, Paefi_services.is_there_follow_up, Paefi_services.does_the_patient_have_special_needs, Paefi_services.interventions_performed, Paefi_services.referrals_made, Paefi_services.summary_description_of_the_case, Paefi_services.user_id, Paefi_services.entrance_door, Users.name, Users.birth, Users.address, users.number_address, Users.family_reference FROM Paefi_services  INNER JOIN Users ON Users.id = Paefi_services.user_id WHERE date_insertion LIKE '%{month}%' AND date_insertion LIKE '%{year}%' ORDER BY date_insertion DESC";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        connection.Open();
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return table;
        } 
        static public DataTable FindByAll(int page = 0, int quantRows = 5)
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string query = $"SELECT Paefi_services.id, CONVERT(VARCHAR, CONVERT(date, date_insertion, 103), 103) as date_insertion, Paefi_services.insertion_in_PAEFI, Paefi_services.type_of_service, Paefi_services.summary_of_demand, Paefi_services.case_of_violation, Paefi_services.type_of_benefit, Paefi_services.is_there_follow_up, Paefi_services.does_the_patient_have_special_needs, Paefi_services.interventions_performed, Paefi_services.referrals_made, Paefi_services.summary_description_of_the_case, Paefi_services.user_id, Paefi_services.entrance_door, Users.name, Users.birth, Users.address, users.number_address, Users.family_reference FROM Paefi_services  INNER JOIN Users ON Users.id = Paefi_services.user_id ORDER BY date_insertion DESC OFFSET {page} ROWS FETCH  NEXT {quantRows} ROWS ONLY";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        connection.Open();
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return table;
        }

        static public DataTable FindByPeriod(string month, string year, int page = 0, int quantRows = 5)
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string query = $"SELECT Paefi_services.id, CONVERT(VARCHAR, CONVERT(date, date_insertion, 103), 103) as date_insertion, Paefi_services.insertion_in_PAEFI, Paefi_services.type_of_service, Paefi_services.summary_of_demand, Paefi_services.case_of_violation, Paefi_services.type_of_benefit, Paefi_services.is_there_follow_up, Paefi_services.does_the_patient_have_special_needs, Paefi_services.interventions_performed, Paefi_services.referrals_made, Paefi_services.summary_description_of_the_case, Paefi_services.user_id, Paefi_services.entrance_door, Users.name, Users.birth, Users.address, users.number_address, Users.family_reference FROM Paefi_services  INNER JOIN Users ON Users.id = Paefi_services.user_id WHERE date_insertion LIKE '%{month}%' AND date_insertion LIKE '%{year}%' ORDER BY date_insertion DESC OFFSET {page} ROWS FETCH  NEXT {quantRows} ROWS ONLY";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        connection.Open();
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return table;
        } 
        
        static public DataTable GetQuantityCaseOfViolation()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string query = $"SELECT Count(case_of_violation) quantity, case_of_violation FROM Paefi_services GROUP BY case_of_violation";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        connection.Open();
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return table;
        }  
        
        static public DataTable GetQuantityCaseOfViolation(string month, string year)
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    string query = $"SELECT Count(case_of_violation) quantity, case_of_violation FROM Paefi_services WHERE date_insertion LIKE '%{month}%' AND date_insertion LIKE '%{year}%' GROUP BY case_of_violation";

                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                    {
                        connection.Open();
                        adapter.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return table;
        }

        public static double CountQuantityServices(int userId = 0)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    connection.Open();
                    string query = $"SELECT COUNT(id) FROM paefi_services WHERE user_id = {userId}";
                    var command = new SqlCommand(query, connection);
                    command.CommandText = query;

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count;
                }

            }
            catch
            {
                throw;
            }
        }

        public static double CountQuantityServicesAll()
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    connection.Open();
                    string query = $"SELECT COUNT(id) FROM paefi_services";
                    var command = new SqlCommand(query, connection);
                    command.CommandText = query;

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count;
                }
            }
            catch
            {
                throw;
            }

        }

        public static double CountQuantityServicesByPeriod(string month, string year)
        {
            try
            {
                using (var connection = new SqlConnection(DbConnectionString.connectionString))
                {
                    connection.Open();
                    string query = $"SELECT COUNT(id) FROM paefi_services WHERE date_insertion LIKE '%{month}%' AND date_insertion LIKE '%{year}%'";
                    var command = new SqlCommand(query, connection);
                    command.CommandText = query;

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
