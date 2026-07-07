using CMS.Application;
using CMS.Infrastructure;
using CMS_Clinic_Management_System_.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
// Add Infrastructure services to the container. 
builder.Services.AddApplication();
// Add Infrastructure services to the container. 
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<SignupProfile>());

var app = builder.Build();

await app.Services.SeedRoleDatabaseAsync();
await app.Services.SeedAdminAddAsync();
// Configure the HTTP request pipeline.

//app.UseExceptionHandler(errorApp =>
//{
//    errorApp.Run(async context =>
//    {
//        context.Response.Redirect("/Home/Error");
//    });
//});
if (!app.Environment.IsDevelopment())
{
//app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}/{id?}");

app.Run();

