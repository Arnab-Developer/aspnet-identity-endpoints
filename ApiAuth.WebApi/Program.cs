using ApiAuth.WebApi;
using ApiAuth.WebApi.Authorization;
using ApiAuth.WebApi.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IValidator<Student>, StudentValidator>();
builder.Services.AddScoped<IAuthorizationHandler, RoleRequirementHandler>();

var studentDb = builder.Configuration.GetConnectionString("StudentDb");
builder.Services.AddDbContext<StudentContext>(option => option.UseSqlServer(studentDb));

var apiIdentityDb = builder.Configuration.GetConnectionString("ApiIdentityDb");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(apiIdentityDb));

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminRole", policy => policy.Requirements.Add(new RoleRequirement("Admin")));
});

var app = builder.Build();
app.MapIdentityApi<IdentityUser>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapStudentApi();
app.Run();