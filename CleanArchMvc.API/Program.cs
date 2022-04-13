using CleanArchMvc.API;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var startup = new StartupAPI(builder.Configuration);
startup.ConfigureServices(builder.Services);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen(c=>
//     {
//         c.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme()
//         {
//             //definir configurações
//         });

//         c.AddSecurityRequirement(new OpenApiSecurityRequirement
//         {
//             //definir as configurações
//         });
//     });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>{
        options.SwaggerEndpoint("/swagger/v1/swagger.json","v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseStatusCodePages();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
