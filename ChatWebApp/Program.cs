var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Додаємо SignalR
builder.Services.AddSignalR();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// Маршрут для SignalR
app.MapHub<ChatWebApp.Hubs.ChatHub>("/chatHub");

app.Run();
