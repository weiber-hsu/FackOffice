using FakeOffice.Controllers;
using FakeOffice.Repository;
using FakeOffice.Service;
using FakeOffice.Service.Interface;
using MySql.Data.MySqlClient;
using NSubstitute.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("appsettings.json");
builder.Configuration.Bind("Database");
string connectionString = builder.Configuration.GetSection("Database:ConnectionString").Value;
builder.Services.AddScoped<MySqlConnection>(_ => new MySqlConnection(connectionString));

builder.Services.AddControllers().AddApplicationPart(typeof(RegisterController).Assembly);
builder.Services.AddTransient<IRegisterService, RegisterService>();
builder.Services.AddTransient<IBorrowFeeService, BorrowFeeService>();
builder.Services.AddTransient<IMemberRepo, MemberRepo>();
builder.Services.AddTransient<IBorrowFeeRepo, BorrowFeeRepo>();

var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGet("/", context => context.Response.WriteAsync("Hello World!"));
});
app.Run();