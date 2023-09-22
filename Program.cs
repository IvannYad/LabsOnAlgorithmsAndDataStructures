using Laba.Services;
using Laba.Services.Interfaces;
using Laba.Services.Interfaces.InterfacesLab1;
using Laba.Services.Interfaces.InterfacesLab2;
using Laba.Services.SortingServicesLab1;
using Laba.Services.SortingServicesLab2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IOrdinarySortingService1, OrdinarySortingService1>();
builder.Services.AddScoped<ICustomSortingService1, CustomSortingService1>();
builder.Services.AddScoped<IOrdinarySortingService2, OrdinarySortingService2>();
builder.Services.AddScoped<ICustomSortingService2, CustomSortingService2>();
builder.Services.AddScoped<IPrepareCollectionService<string, string[]>, PrepareCollectionServiceLab1>();
builder.Services.AddScoped<IPrepareCollectionService<string[], double[][]>, PrepareCollectionServiceLab2>();

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
