using FakeOffice.Controllers;
using FakeOffice.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddApplicationPart(typeof(RegisterController).Assembly);
builder.Services.AddTransient<IRegisterService, RegisterService>();
var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGet("/", context => context.Response.WriteAsync("Hello World!"));
});
app.Run();