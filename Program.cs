using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using VRS3LOGIN_AUTHENTICATION.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("VRS3LOGIN_AUTHENTICATIONDbContextConnection") ?? throw new Exception("Connection string 'VRS3LOGIN_AUTHENTICATIONDbContextConnection' not found.");

builder.Services.AddDbContext<VRS3LOGIN_AUTHENTICATIONDbContext>(options =>
     options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false) // ApplicationUser is manages a user registration  validation and logout session and everythings 
    .AddDefaultTokenProviders()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<VRS3LOGIN_AUTHENTICATIONDbContext>();

//set Serializer Settings in ConfigureServices Method SerializerSettings.ContractResolver to DefaultContractResolver.
builder.Services.AddControllersWithViews().AddNewtonsoftJson(
options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());




// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();




// I dont want a password in the upper Case thats why use authentication
builder.Services.Configure<IdentityOptions>(Options =>
{
    Options.Password.RequireUppercase = false;
});

var app = builder.Build();
 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}
 
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}/{id?}"
    );
 
app.MapRazorPages();

app.Run();



