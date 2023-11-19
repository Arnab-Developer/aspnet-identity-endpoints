using ApiAuth.WebApi;
using ApiAuth.WebApi.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddSingleton<IValidator<Student>, StudentValidator>();

var studentDb = builder.Configuration.GetConnectionString("StudentDb");
builder.Services.AddDbContext<StudentContext>(option => option.UseSqlServer(studentDb));

var apiIdentityDb = builder.Configuration.GetConnectionString("ApiIdentityDb");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(apiIdentityDb));

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();
app.MapIdentityApi<IdentityUser>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapStudentApi();
app.Run();