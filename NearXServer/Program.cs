using Microsoft.EntityFrameworkCore;
using NearXServer.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddCors( policy =>
{
    policy.AddDefaultPolicy( opt => opt
        .WithOrigins("https://localhost:7177")
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});
string connectionString = builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
// add the db context
builder.Services.AddDbContextPool<MariaDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

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
app.UseCors();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
