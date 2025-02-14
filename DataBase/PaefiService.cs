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

        public static double CountQuantityServices(int userId = 0)
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
    }
}
