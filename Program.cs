using Microsoft.EntityFrameworkCore;
using Task_Interview.Models;
using Task_Interview.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ArmyTechTaskContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("CS")));
builder.Services.AddScoped<IRepositoryInvoiceDetails, InvoiceDetailsRepository>();
builder.Services.AddScoped<IRepositoryCashier, CashierRepository>();
builder.Services.AddScoped<IRepositoryBranch, BranchRepository>();


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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
