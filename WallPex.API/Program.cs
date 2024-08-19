
using System.Data;
using System.Data.SqlClient;
using WallPex.API.Repositories;
using WallPex.API.Repositories.Contracts;
using WallPex.API.Services;
using WallPex.API.Services.Contracts;

namespace WallPex.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddSingleton<IDbConnection>(sp => new SqlConnection(builder.Configuration.GetConnectionString("Default")));
        builder.Services.AddScoped<ICollectionRepository, CollectionRepository>();
        builder.Services.AddScoped<ICollectionItemRepository, CollectionItemRepository>();
        builder.Services.AddScoped<ICollectionService, CollectionService>();
        builder.Services.AddScoped<ICollectionItemService, CollectionItemService>();

        builder.Services.AddCors(policy =>
        {
            policy.AddPolicy("OpenCorsPolicy", opt =>
            opt.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod());
        });

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

        app.UseCors("OpenCorsPolicy");

        app.MapControllers();

        app.Run();
    }
}
