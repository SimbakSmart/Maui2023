using Microsoft.EntityFrameworkCore;

namespace Contacts.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //  builder.Services.AddAuthorization();
            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

        

            app.Run();
        }
    }
}