using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting.Server;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1.Pages
{
    public class NewPersonModel : PageModel
    {
        [BindProperty] public required string FName { get; set; }
        [BindProperty] public required string LName { get; set; }
        [BindProperty] public required string NationalCode { get; set; }
        [BindProperty] public required string BirthPlace { get; set; }
        [BindProperty] public required string birthDate { get; set; }
        [BindProperty] public required string FatherName { get; set; }
        public IActionResult OnPost()
        {
            SqlConnection connection = new 
                SqlConnection("Server =.\\sqlexpress; Database = a; Trusted_Connection = True;");
            SqlCommand command = new SqlCommand("INSERT INTO[b]" +
                "  ([FName],[LName],[NationalCode],[BirthPlace],[birth_date],[FatherName])" +
               " VALUES (@FName ,@LName ,@NationalCode,@BirthPlace,@birth_date,@FatherName)", connection);

            command.Parameters.AddWithValue("@FName", FName);  
            command.Parameters.AddWithValue("@LName", LName);
            command.Parameters.AddWithValue("@NationalCode", NationalCode);
            command.Parameters.AddWithValue("@BirthPlace", BirthPlace);
            command.Parameters.AddWithValue("@birth_date", birthDate);
            command.Parameters.AddWithValue("@FatherName", FatherName);
            command.CommandType = CommandType.Text;
            connection.Open();
            command.ExecuteNonQuery();  
            connection.Close(); 
            
            return RedirectToPage("list_person");    
        }
    }
}
