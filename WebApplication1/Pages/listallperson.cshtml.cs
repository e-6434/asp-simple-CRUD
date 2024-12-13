using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Pages
{
    public class list_personModel : PageModel
    {      public   DataTable dt_list { get; set; }=new DataTable();
        public string Message { get; set; } = "Initial Request";
        public void OnGet()
        { 
            dt_list.Columns.AddRange(new DataColumn[7] {
                new DataColumn("person_id", typeof(string)),
                new DataColumn("FName", typeof(string)),
                        new DataColumn("LName", typeof(string)),
                new DataColumn("NationalCode", typeof(string))
                ,  new DataColumn("BirthPlace", typeof(string))
              ,  new DataColumn("birthDate", typeof(string))
               ,  new DataColumn("FatherName", typeof(string))});

 


          
     
            SqlConnection connection = new 
                SqlConnection("Server =.\\sqlexpress; Database = erfan; Trusted_Connection = True;"); 
          
            SqlCommand command = new SqlCommand("select * from table", connection);
            connection.Open();
            DataTable dt = new DataTable();  
            SqlDataAdapter sda = new SqlDataAdapter();   
            command.CommandType = CommandType.Text;
            sda.SelectCommand = command;
            sda.Fill(dt);   
            connection.Close();  
            dt_list = dt;   
        }


        public IActionResult OnPost()
        {
            return  RedirectToPage("./NewPerson");
        }

        public void OnPostDelete(string id)
        { 
            SqlConnection connection = new
                SqlConnection("Server =.\\sqlexpress; Database = a; Trusted_Connection = True;");
            SqlCommand command = new
                SqlCommand("delete  from b where person_id='" + id + "'" , connection);
            command.CommandType = CommandType.Text;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close(); 
            OnGet();
        }

      
    }
}
