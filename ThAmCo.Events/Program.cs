using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ThAmCo.Events.Data;
using ThAmCo.Events.Services;


var builder = WebApplication.CreateBuilder(args);

// Register the HTTP client and CategoryService for Dependency Injection (DI)
builder.Services.AddHttpClient<AvailabilityService>();

// Add services to the container.
builder.Services.AddRazorPages();

// Register database context with the framework - this needs to be added manually
builder.Services.AddDbContext<EventsContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
