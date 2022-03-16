using CleanArchMvc.WebUI;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

startup.Configure(app,app.Environment, );

app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
                //---------------------------------------------
                // name: "default",
                // pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
