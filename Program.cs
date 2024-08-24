using ComputerTrainingInstitute.Interfaces;
using Microsoft.EntityFrameworkCore;
using ComputerTrainingInstitute.Services;
using ComputerTrainingInstitute.Models;

namespace ComputerTrainingInstitute
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ComputerInstituteContext>
                        (o => o.UseMySql("server=localhost;user=root;port=3308;password=4811;database=ComputerInstitute",
                        Microsoft.EntityFrameworkCore.ServerVersion
                        .AutoDetect("server=localhost;user=root;port=3308;password=4811;database=ComputerInstitute")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IStudent, StudentService>();
            builder.Services.AddScoped<IDepartment, DepartmentService>();

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