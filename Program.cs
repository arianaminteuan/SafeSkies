using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using SafeSkies.DataAccess;
using SafeSkies.DataAccess.Repository;
using SafeSkies.DataAccess.Repository.IRepository;
using AspNetCore.Identity.Mongo;
using AspNetCore.Identity.Mongo.Model;
using Microsoft.AspNetCore.Identity;
using SafeSkies.Services;
using SafeSkies.Models.ViewModels;


var builder = WebApplication.CreateBuilder(args);

// MongoDB GUID config
BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

// Mongo Settings
builder.Services.Configure<MongoDBSettings>(
    builder.Configuration.GetSection("MongoDB"));

builder.Services.AddIdentityMongoDbProvider<ApplicationUser, MongoRole>(
    identityOptions => // THIS configures IdentityOptions (password rules, etc.)
    {
        identityOptions.Password.RequireDigit = true;
        identityOptions.Password.RequireLowercase = true;
        identityOptions.Password.RequireUppercase = false;
        identityOptions.Password.RequireNonAlphanumeric = false;
        identityOptions.Password.RequiredLength = 6;
    },
    mongoOptions => // THIS configures MongoIdentityOptions
    {
        mongoOptions.ConnectionString = builder.Configuration["MongoDB:ConnectionURI"];
    });

builder.Services.AddSingleton<IFlightRepository, FlightRepository>();
builder.Services.AddSingleton<IBookingRepository, BookingRepository>();



builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
});


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seeding roles (Admin, User, Company)
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<MongoRole>>();
    await RoleInitializer.SeedRolesAsync(roleManager);
}

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
