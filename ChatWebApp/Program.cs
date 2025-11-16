using ChatWebApp.Data;
using ChatWebApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adds MVC controllers and Razor views
builder.Services.AddControllersWithViews();

// Adds SignalR real-time communication
builder.Services.AddSignalR();

// Registers EF Core database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registers Azure sentiment analyzer
builder.Services.AddSingleton<TextAnalysisService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

// Sets default MVC route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// Maps SignalR chat hub
app.MapHub<ChatHub>("/chatHub");

app.Run();
