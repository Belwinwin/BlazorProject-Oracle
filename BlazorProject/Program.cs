using BlazorProject.Components;
using BlazorProject.Components.Account;
using BlazorProject.Data;
using BlazorProject.Repository;
using BlazorProject.Repository.iRepository;
using BlazorProject.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Oracle.EntityFrameworkCore.Extensions;
using MySql.Data.MySqlClient;
using Dapper;
using BlazorProject;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<DatabaseConnectionService>();
builder.Services.AddScoped<iEmployeeRepository, OracleEmployeeRepository>();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<IOracleEmployeeRepository, OracleEmployeeRepository>();

builder.Services.AddTransient<IDbConnection>(sp => 
{
    var config = sp.GetRequiredService<IConfiguration>();
    var connStr = config.GetConnectionString("OracleConnection");
    return new OracleConnection(connStr);
});

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (!string.IsNullOrEmpty(connectionString))
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString, sqlOptions => 
            sqlOptions.EnableRetryOnFailure()));
}
else
{
    Console.WriteLine("Warning: SQL Server connection string not found. Using in-memory database for Identity.");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseInMemoryDatabase("BlazorProjectIdentity"));
}

// Add Oracle DbContext
var oracleConnectionString = builder.Configuration.GetConnectionString("OracleConnection") ?? throw new InvalidOperationException("Connection string 'OracleConnection' not found.");
builder.Services.AddDbContext<OracleDbContext>(options =>
    options.UseOracle(oracleConnectionString));

// Add second Oracle DbContext
var oracleConnectionString2 = builder.Configuration.GetConnectionString("OracleConnection2") ?? throw new InvalidOperationException("Connection string 'OracleConnection2' not found.");
builder.Services.AddDbContext<OracleDbContext2>(options =>
    options.UseOracle(oracleConnectionString2));

// Add third Oracle DbContext
var oracleConnectionString3 = builder.Configuration.GetConnectionString("OracleConnection3") ?? throw new InvalidOperationException("Connection string 'OracleConnection3' not found.");
builder.Services.AddDbContext<OracleDbContext3>(options =>
    options.UseOracle(oracleConnectionString3));

builder.Services.AddScoped<IRegistrationService, RegistrationService>();
builder.Services.AddScoped<IUserAccessService, UserAccessService>();


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

using (var scope = app.Services.CreateScope())
{
    var cfg = scope.ServiceProvider.GetRequiredService<IConfiguration>();
    
    // Test Oracle Connection
    var oracleConnStr = cfg.GetConnectionString("OracleConnection");
    if (!string.IsNullOrEmpty(oracleConnStr))
    {
        Console.WriteLine($"Testing Oracle connection: {oracleConnStr}");
        try
        {
            using var conn = new Oracle.ManagedDataAccess.Client.OracleConnection(oracleConnStr);
            conn.Open();
            using var cmd = new Oracle.ManagedDataAccess.Client.OracleCommand("SELECT SYSDATE FROM DUAL", conn);
            var result = cmd.ExecuteScalar();
            Console.WriteLine($"✅ Oracle Connection SUCCESS - Server Time: {result}");
            Console.WriteLine($"Oracle Version: {conn.ServerVersion}");
            conn.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Oracle Connection FAILED: {ex.Message}");
        }
    }
    
    // Test MySQL Connection
    var mysqlConnStr = cfg.GetConnectionString("MySqlConnection");
    if (!string.IsNullOrEmpty(mysqlConnStr))
    {
        try
        {
            using var conn = new MySql.Data.MySqlClient.MySqlConnection(mysqlConnStr);
            conn.Open();
            Console.WriteLine("MySQL Connection SUCCESS");
            conn.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("MySQL Connection FAILED: " + ex.Message);
        }
    }
}


app.Run();
