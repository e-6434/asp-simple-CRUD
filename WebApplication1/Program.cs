namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();
            var app = builder.Build();
             
            app.MapRazorPages();

            //app.UseSession();

            app.UseStaticFiles();
            app.Run();
        }
    }
}