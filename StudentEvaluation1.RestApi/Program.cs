using Microsoft.EntityFrameworkCore;
using StudentEvaluation1.Persistanse.EF;
using StudentEvaluation1.Persistanse.EF.Courses;
using StudentEvaluation1.Persistanse.EF.StudentCourses;
using StudentEvaluation1.Persistanse.EF.Students;
using StudentEvaluation1.Persistanse.EF.Teachers;
using StudentEvaluation1.Services.Contracts;
using StudentEvaluation1.Services.Courses;
using StudentEvaluation1.Services.Courses.contracts;
using StudentEvaluation1.Services.StudentCourses;
using StudentEvaluation1.Services.StudentCourses.Contracts;
using StudentEvaluation1.Services.Students;
using StudentEvaluation1.Services.Students.Contracts;
using StudentEvaluation1.Services.Teachers;
using StudentEvaluation1.Services.Teachers.Contracts;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// AddAsync services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EFDataContext>(_ =>
    _.UseSqlServer(configuration.GetConnectionString("sqlServer")));

builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();

builder.Services.AddScoped<TeacherService , TeacherAppService>();
builder.Services.AddScoped<TeacherRepository, EFTeacherRepository>();

builder.Services.AddScoped<CourseService, CourseAppServic>();
builder.Services.AddScoped<CourseRepository,EFCourseRepository>();

builder.Services.AddScoped<StudentService,StudentAppService>();
builder.Services.AddScoped<StudentRepository,EFStudentRepository>();

builder.Services.AddScoped<StudentCourseService,StudentCourseAppService>();
builder.Services.AddScoped<StudentCourseRepository,EFStudentCourseRepository>();



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
