using MeusicRuchama;
using MeusicRuchama.Core;
using MeusicRuchama.Core.Repositories;
using MeusicRuchama.Core.Serivecs;
using MeusicRuchama.Data.Repositories;
using MeusicRuchama.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});


//builder.Services.AddScoped<IDataContext, DataContext>(); //òáåø ëì á÷ùä ðåöø îåôò çãù
//builder.Services.AddSingleton<DataContext>(); //àåúå îåôò òáåø ëì ääøöä
//builder.Services.AddTransient<IDataContext, DataContext>(); //éåöø îåôò çãù òáåø ëì ôòí ùðãøù (âí àí áàåúä äá÷ùä éäéä øùåí ëîä ôòîéí éöéøú îåôò çãù)

builder.Services.AddScoped<IStudentServices, StudentService>();
builder.Services.AddScoped<IStudentRepositories, StudentRepository>();

builder.Services.AddScoped<ITeachersServies, TeachersService>();
builder.Services.AddScoped<ITechersRepositories, TeacherRepositories>();

builder.Services.AddScoped<ILessonsServices, LessonService>();
builder.Services.AddScoped<ILessonsRepositories, LessonRepositories>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(MappingProfileModel));

builder.Services.AddDbContext<DataContext>();



// Configure the HTTP request pipeline.


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
        };
    });

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowFrontend", policy =>
//    {
//        policy.WithOrigins("http://localhost:8080")
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//              //.AllowCredentials();
//    });
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AnyOrigin", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

//var app = builder.Build();
var app = builder.Build();

// Updated Manual Header Injection
app.Use(async (context, next) =>
{
    // Clear any existing headers and set fresh ones
    context.Response.Headers["Access-Control-Allow-Origin"] = "http://localhost:8080";
    context.Response.Headers["Access-Control-Allow-Headers"] = "Content-Type, Authorization, Accept";
    context.Response.Headers["Access-Control-Allow-Methods"] = "GET, POST, OPTIONS, PUT, DELETE";

    if (context.Request.Method == "OPTIONS")
    {
        context.Response.StatusCode = 200;
        await context.Response.CompleteAsync(); // End the request here for OPTIONS
        return;
    }
    await next();
});


app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();
app.UseRouting();
//app.UseCors("AllowFrontend");
//app.UseCors("AnyOrigin"); 

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
