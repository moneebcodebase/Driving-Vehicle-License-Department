using System;
using System.Data.SqlClient;
using System.Data;


namespace DVLD_DataAccess
{
    public class clsTestTypeData
    {

        public static bool GetTestTypeInfoByID(int TestTypeID, 
            ref string TestTypeTitle, ref string TestDescription ,ref float TestFees)
            {
                bool isFound = false;

                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

                string query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        // The record was found
                        isFound = true;

                        TestTypeTitle = (string)reader["TestTypeTitle"];
                        TestDescription = (string)reader["TestTypeDescription"];
                        TestFees = Convert.ToSingle( reader["TestTypeFees"]);

                }
                    else
                    {
                        // The record was not found
                        isFound = false;
                    }

                    reader.Close();


                }
                catch (Exception ex)
                {
                    // Logging the Exception into the Event Logger
                    string message = $"An Exception happend in clsTestTypes class when trying to get Test type info by id. {ex.Message}";
                    clsDataAccessSettings.EventLogger("DVLD", message, clsDataAccessSettings.enEventType.Error);
                    isFound = false;
                }
                finally
                {
                    connection.Close();
                }

                return isFound;
            }

         public static DataTable GetAllTestTypes()
            {

                DataTable dt = new DataTable();
                SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

                string query = "SELECT * FROM TestTypes order by TestTypeID";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)

                    {
                        dt.Load(reader);
                    }

                    reader.Close();


                }

                catch (Exception ex)
                {
                    // Logging the Exception into the Event Logger
                    string message = $"An Exception happend in clsTestTypes class when trying to get all Test type info. {ex.Message}";
                    clsDataAccessSettings.EventLogger("DVLD", message, clsDataAccessSettings.enEventType.Error);
                }
                finally
                {
                    connection.Close();
                }

                return dt;

            }

        public static int AddNewTestType( string Title,string Description, float Fees)
        {
            int TestTypeID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert Into TestTypes (TestTypeTitle,TestTypeTitle,TestTypeFees)
                            Values (@TestTypeTitle,@TestTypeDescription,@ApplicationFees)
                            where TestTypeID = @TestTypeID;
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeTitle", Title);
            command.Parameters.AddWithValue("@TestTypeDescription", Description);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestTypeID = insertedID;
                }
            }

            catch (Exception ex)
            {
                // Logging the Exception into the Event Logger
                string message = $"An Exception happend in clsTestTypes class when trying to add new Test type. {ex.Message}";
                clsDataAccessSettings.EventLogger("DVLD", message, clsDataAccessSettings.enEventType.Error);

            }

            finally
            {
                connection.Close();
            }


            return TestTypeID;

        }

        public static bool UpdateTestType(int TestTypeID,string Title,string Description, float Fees)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  TestTypes  
                            set TestTypeTitle = @TestTypeTitle,
                                TestTypeDescription=@TestTypeDescription,
                                TestTypeFees = @TestTypeFees
                                where TestTypeID = @TestTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@TestTypeTitle", Title);
            command.Parameters.AddWithValue("@TestTypeDescription", Description);
            command.Parameters.AddWithValue("@TestTypeFees", Fees);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Logging the Exception into the Event Logger
                string message = $"An Exception happend in clsTestTypes class when trying to update Test type. {ex.Message}";
                clsDataAccessSettings.EventLogger("DVLD", message, clsDataAccessSettings.enEventType.Error);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }



    }
}
