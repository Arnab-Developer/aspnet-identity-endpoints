using ApiAuth.WebApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var constr = builder.Configuration.GetConnectionString("StudentDb");
builder.Services.AddDbContext<StudentContext>(option => option.UseSqlServer(constr));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var group = app.MapGroup("/student").WithOpenApi();

group.MapPost("/", async (string firstName, string lastName, StudentContext context) =>
{
    var student = new Student(firstName, lastName);
    await context.Students.AddAsync(student);
    await context.SaveChangesAsync();
})
.WithName("CreateStudents");

group.MapGet("/", async (StudentContext context) =>
{
    var students = await context.Students.OrderBy(s => s.FirstName).ToListAsync();
    return students;
})
.WithName("GetStudents");

app.Run();