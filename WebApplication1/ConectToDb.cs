using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{

    public class ConectToDb
    {
        public DataView Dv;
        public void add_person(string FName, string LName,string NationalCode,string BirthPlace
            ,string  birthDate,string FatherName)
        {
            // save to db
            string strcon = " Server =.; Database = university1; Trusted_Connection = True;";
            string query = "INSERT INTO[Person]  ([FName],[LName],[NationalCode],[BirthPlace],[birthDate],[FatherName])  VALUES (@FName ,@LName ,@NationalCode,@BirthPlace,@birthDate,@FatherName)";

            SqlConnection connection = new SqlConnection(strcon);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FName", FName);
            command.Parameters.AddWithValue("@LName", LName);
            command.Parameters.AddWithValue("@NationalCode", NationalCode);
            command.Parameters.AddWithValue("@BirthPlace", BirthPlace);
            command.Parameters.AddWithValue("@birthDate", birthDate);
            command.Parameters.AddWithValue("@FatherName", FatherName);
            command.CommandType = CommandType.Text;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }

        public void select_all_person()
        {
            string strcon = " Server =.; Database = university1; Trusted_Connection = True;";
            string query = "select * from Person";
            SqlConnection connection = new SqlConnection(strcon);
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter();
            command.CommandType = CommandType.Text;
            sda.SelectCommand = command;
            sda.Fill(dt);
            connection.Close();
            Dv = new DataView();
            Dv = dt.DefaultView;
             
        }





    }
}
