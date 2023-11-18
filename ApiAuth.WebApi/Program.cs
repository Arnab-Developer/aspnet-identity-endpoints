using ApiAuth.WebApi;
using ApiAuth.WebApi.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();

var studentDb = builder.Configuration.GetConnectionString("StudentDb");
builder.Services.AddDbContext<StudentContext>(option => option.UseSqlServer(studentDb));

var identityDb = builder.Configuration.GetConnectionString("IdentityDb");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(identityDb));

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

//Add-Migration InitialCreate -Context ApplicationDbContext -OutputDir Migrations\Identity

var app = builder.Build();
app.MapIdentityApi<IdentityUser>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapStudentApi();
app.Run();