using GamifyWork.DataAccessLibrary.Data;
using GamifyWork.DataAccessLibrary.Repositories;
using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSpolicy", builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .WithOrigins("http://localhost:5173");
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<dbContext>();
builder.Services.AddScoped<ITaskService, TaskService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CORSpolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();