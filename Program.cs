using Microsoft.EntityFrameworkCore;
using UnitApi9K.DAL;
using UnitApi9K.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("db");
ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);

builder.Services.AddDbContext<UnitManagementDbContext>(options=>
                            options.UseMySql(connectionString, serverVersion));

builder.Services.AddScoped<IDogsRepository, DogsRepository>();
builder.Services.AddScoped<ITrainingRepository , TrainingRepository> ();
builder.Services.AddScoped<IHandlersRepository, HandlersRepository>();

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
