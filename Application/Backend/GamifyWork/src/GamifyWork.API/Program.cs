using GamifyWork.API.Middleware;
using GamifyWork.ContractLayer.Interfaces;
using GamifyWork.DataAccessLibrary.Data;
using GamifyWork.DataAccessLibrary.Interfaces;
using GamifyWork.DataAccessLibrary.Repositories;
using GamifyWork.MapperLayer;
using GamifyWork.MapperLayer.Mappers;
using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSpolicy", builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins("http://localhost:5173");
    });
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg => cfg.AllowNullCollections = true, typeof(MappingProfile).Assembly);
builder.Services.AddDbContext<dbContext>();
builder.Services.AddScoped<IRewardService, RewardService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IRewardRepository, RewardRepository>();
builder.Services.AddScoped<ITaskMapperD, TaskMapper>();
builder.Services.AddScoped<ITaskMapperS, TaskMapper>();
builder.Services.AddScoped<IRewardMapperS, RewardMapper>();
builder.Services.AddScoped<IRewardMapperD, RewardMapper>();


var app = builder.Build();

app.UseExceptionHandlerMiddleware();

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
