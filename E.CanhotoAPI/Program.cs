using E.CanhotoAPI.Data;
using E.CanhotoAPI.Repositorios;
using E.CanhotoAPI.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E.CanhotoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<ECanhotoAPIDBContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                );

            // Adiciona serviços aos contêineres de injeção de dependência
            builder.Services.AddScoped<IUserRepostiorio, UserRepositorio>();
            builder.Services.AddScoped<ILeftHandedRepositorio, LeftHandedRepositorio>();


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Construir o aplicativo
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
