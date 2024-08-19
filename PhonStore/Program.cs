
using Microsoft.EntityFrameworkCore;
using PhonStore.Data;

namespace PhonStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            string connection = "Data Source=YONATAN;Initial Catalog=FirstApi;User ID=sa;Password=1234;Connect Timeout=30;Encrypt=False;Trust Server Certificate=Yes; database= phoneStore";
            builder.Services.AddDbContext<PhoneStoreDB>(options => options.UseSqlServer(connection));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
