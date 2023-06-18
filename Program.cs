using MagicVilla.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring /OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsASwaggerpiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddDbContext<SoftlandDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("SistemaWeb"));
    option.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
    option.EnableSensitiveDataLogging();
});

//builder.Services.AddDbContext<SoftDbContext>(option =>
//{
//    option.UseSqlServer(builder.Configuration.GetConnectionString("SistemaWebOR"));
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error");
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
