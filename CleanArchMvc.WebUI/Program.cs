using CleanArchMvc.Domain.Account;
using CleanArchMvc.WebUI;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

//startup.Configure(app,app.Environment);
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

SeedUserRoles(app);

          
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();



void SeedUserRoles(IApplicationBuilder app) 
{
    using (var serviceScope = app.ApplicationServices.CreateScope())
    {
        var services = serviceScope.ServiceProvider;
        var seed = services.GetRequiredService<ISeedUserRoleInitial>();
        seed.SeedRoles();
        seed.SeedUsers();
    }    
}