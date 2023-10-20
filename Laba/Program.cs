using Laba.DataStructures;
using Laba.DataStructures.Interfaces;
using Laba.Models.VM;
using Laba.Services.Interfaces;
using Laba.Services.Interfaces.InterfacesLab1;
using Laba.Services.Interfaces.InterfacesLab2;
using Laba.Services.Interfaces.InterfacesLab3;
using Laba.Services.Interfaces.InterfacesLab4;
using Laba.Services.Interfaces.InterfacesLab5;
using Laba.Services.ServicesLab1;
using Laba.Services.ServicesLab2;
using Laba.Services.ServicesLab3;
using Laba.Services.ServicesLab4;
using Laba.Services.ServicesLab5;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IOrdinarySortingService1, OrdinarySortingService1>();
builder.Services.AddScoped<ICustomSortingService1, CustomSortingService1>();
builder.Services.AddScoped<IOrdinarySortingService2, OrdinarySortingService2>();
builder.Services.AddScoped<ICustomSortingService2, CustomSortingService2>();
builder.Services.AddScoped<IOrdinarySortingService3, OrdinarySortingService3>();
builder.Services.AddScoped<ICustomSortingService3, CustomSortingService3>();
builder.Services.AddScoped<IOrdinarySortingService4, OrdinarySortingService4>();
builder.Services.AddScoped<ICustomSortingService4, CustomSortingService4>();
builder.Services.AddScoped<IOrdinarySortingService5, OrdinarySortingService5>();
builder.Services.AddScoped<ICustomSortingService5, CustomSortingService5>();
builder.Services.AddScoped<IPrepareCollectionService<string, string[]>, PrepareCollectionServiceLab1>();
builder.Services.AddScoped<IPrepareCollectionService<string[], double[][]>, PrepareCollectionServiceLab2>();

builder.Services.AddSingleton<Lab7VM>(lab => new Lab7VM() { Queue = new PriorityQueue()});


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
