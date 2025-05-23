using PlumbingRepairClientApp;
using UniversityBusinessLogic.OfficePackage;
using UniversityBusinessLogic.OfficePackage.Implements;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<AbstractSaveToExcelWorker, SaveToExcelWorker>();
builder.Services.AddTransient<AbstractSaveToWordWorker, SaveToWordWorker>();
builder.Services.AddTransient<AbstractSaveToPdfWorker, SaveToPdfWorker>();

var app = builder.Build();

APIClient.Connect(builder.Configuration);
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
