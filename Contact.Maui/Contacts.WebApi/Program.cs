using Contacts.WebApi.Models;
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

            //  app.UseAuthorization();

            app.MapGet("/api/contacts", async (ApplicationDbContext db) =>
            {
                var contacts = await db.Contacts.ToListAsync();
                return Results.Ok(contacts);
            });

            app.MapPost("/api/contacts", async (Contact contact, ApplicationDbContext db) =>
            {
                db.Contacts.Add(contact);
                await db.SaveChangesAsync();
            });


            app.Run();
        }
    }
}