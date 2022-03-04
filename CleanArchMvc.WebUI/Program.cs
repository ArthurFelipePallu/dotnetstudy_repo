using CleanArchMvc.WebUI;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

startup.Configure(app,app.Environment);

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
    name: "api",
    pattern: "{controller}/{action}/{id?}");
    //---------------------------------------------
    // name: "default",
    // pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
