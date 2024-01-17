using GamifyWork.API.Hubs;
using GamifyWork.API.Middleware;
using GamifyWork.ContractLayer.Interfaces;
using GamifyWork.DataAccessLibrary.Data;
using GamifyWork.DataAccessLibrary.Interfaces;
using GamifyWork.DataAccessLibrary.Repositories;
using GamifyWork.MapperLayer;
using GamifyWork.MapperLayer.Mappers;
using GamifyWork.ServiceLibrary.Helpers;
using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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
        .WithOrigins("http://localhost:5173")
        .WithOrigins("http://localhost:8080")
        .AllowCredentials();
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "http://localhost:8080/auth/realms/GamifyWork";
        options.RequireHttpsMetadata = false;
        options.Audience = "account";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
        };
    });

builder.Services.AddHttpClient();

builder.Services.AddSignalR();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg => cfg.AllowNullCollections = true, typeof(MappingProfile).Assembly);
builder.Services.AddScoped<dbContext>();
builder.Services.AddScoped<IRewardService, RewardService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IRewardRepository, RewardRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITaskMapperD, TaskMapper>();
builder.Services.AddScoped<ITaskMapperS, TaskMapper>();
builder.Services.AddScoped<IUserMapperD, UserMapper>();
builder.Services.AddScoped<IRewardMapperS, RewardMapper>();
builder.Services.AddScoped<IRewardMapperD, RewardMapper>();
builder.Services.AddScoped<IUserMapperS, UserMapper>();
builder.Services.AddScoped<IKeycloakLogic, KeycloakLogic>();



var app = builder.Build();

app.UseExceptionHandlerMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHub<ChatHub>("/chatHub");

app.UseHttpsRedirection();

app.UseCors("CORSpolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
