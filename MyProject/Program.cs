using Microsoft.EntityFrameworkCore;
using MyProject.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseMySQL(builder.Configuration["ConnectionStrings:Default"]);
});

//builder.Services.AddScoped<ServiceCollection, ServiceCollection>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

/*app.UseRouting();

app.UseAuthorization();*/

app.MapDefaultControllerRoute();

app.Run();
