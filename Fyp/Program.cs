using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Fyp.Data;
using Fyp.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FypContextConnection") ?? throw new InvalidOperationException("Connection string 'FypContextConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FypContextConnection")));
builder.Services.AddDbContext<FypContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<Fypuser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<FypContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapGet("/", ctx =>
{
    if (ctx.User.Identity.IsAuthenticated)
    {
        // User is already authenticated, redirect to another page
        ctx.Response.Redirect("/Kycs/Create");
    }
    else
    {
        // User is not authenticated, redirect to the login page
        ctx.Response.Redirect("/Identity/Account/Login");
    }

    return Task.CompletedTask;
});
app.Run();
