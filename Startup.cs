using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication3.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Host=localhost;Port=5432;Database=DBATransport;Username=postgres;Password=1234;";
builder.Services.AddDbContext<DBContext>(options =>
    options.UseNpgsql(connectionString));

// Настройка служб
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.MapControllerRoute(
    name: "register",
    pattern: "{controller=Account}/{action=Register}");


app.Run();
