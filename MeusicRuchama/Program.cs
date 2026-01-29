

using MeusicRuchama;
using MeusicRuchama.Core;
using MeusicRuchama.Core.Repositories;
using MeusicRuchama.Core.Serivecs;
using MeusicRuchama.Data.Repositories;
using MeusicRuchama.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<IDataContext, DataContext>(); //עבור כל בקשה נוצר מופע חדש
//builder.Services.AddSingleton<DataContext>(); //אותו מופע עבור כל ההרצה
//builder.Services.AddTransient<IDataContext, DataContext>(); //יוצר מופע חדש עבור כל פעם שנדרש (גם אם באותה הבקשה יהיה רשום כמה פעמים יצירת מופע חדש)

builder.Services.AddScoped<IStudentServices, StudentService>();
builder.Services.AddScoped<IStudentRepositories, StudentRepository>();

builder.Services.AddScoped<ITeachersServies, TeachersService>();
builder.Services.AddScoped<ITechersRepositories, TeacherRepositories>();

builder.Services.AddScoped<ILessonsServices, LessonService>();
builder.Services.AddScoped<ILessonsRepositories, LessonRepositories>();

builder.Services.AddAutoMapper(typeof(MappingProfile),typeof(MappingProfileModel));

builder.Services.AddDbContext<DataContext>();

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
