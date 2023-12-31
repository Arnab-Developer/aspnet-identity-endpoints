﻿using ApiAuth.WebApi.Contexts;

namespace ApiAuth.WebApi;

internal static class StudentApi
{
    public static RouteGroupBuilder MapStudentApi(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/student").WithOpenApi();

        group.MapPost("/", async (string firstName, string lastName, StudentContext context,
            IValidator<Student> validator) =>
        {
            var student = new Student(firstName, lastName);
            validator.ValidateAndThrow(student);
            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
        })
        .WithName("CreateStudents")
        .RequireAuthorization("AdminRole");

        group.MapGet("/", async (StudentContext context) =>
        {
            var students = await context.Students.OrderBy(s => s.FirstName).ToListAsync();
            return students;
        })
        .WithName("GetStudents")
        .RequireAuthorization();

        return group;
    }
}