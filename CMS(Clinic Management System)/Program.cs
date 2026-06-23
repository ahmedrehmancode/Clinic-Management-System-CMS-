using CMS.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
// Add DBcontext Services 
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

await app.Services.SeedRoleDatabaseAsync();
await app.Services.SeedAdminAddAsync();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

