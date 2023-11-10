using InterviewApi.Models;
using InterviewApi.Repo;
using Microsoft.EntityFrameworkCore;

namespace InterviewApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Allow Cors

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy", builder =>
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                );
            });

            #endregion

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

            #region register dbcontext
            builder.Services.AddDbContext<StudentDbContext>(options =>
               {
                   options.UseSqlServer(builder.Configuration.GetConnectionString("con"));
               });
            #endregion

            
            #region register repo
            builder.Services.AddScoped<IStudentRepo, StudentRepo>(); 
            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("MyPolicy");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}