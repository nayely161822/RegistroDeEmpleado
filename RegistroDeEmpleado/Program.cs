using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RegistroDeEmpleado.Data;
using RegistroDeEmpleado.Data.Context;
using RegistroDeEmpleado.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDbContext<RegistrodeEmpleadoDbContext>();
builder.Services.AddScoped<IRegistrodeEmpleadoDbContext, RegistrodeEmpleadoDbContext>();
builder.Services.AddScoped<IEmpleadoServices, EmpleadoServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
