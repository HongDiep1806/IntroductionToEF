using IntroductionToEF.DAL;
using IntroductionToEF.HostCommon.Middleware;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSerilog();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SchoolContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
var logger = new LoggerConfiguration()
     .Enrich.FromLogContext()
     .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
     .CreateLogger();

Log.Logger = logger;


app.UseMiddleware<CustomeMiddleware>();
app.UseMiddleware<CustomeMiddleware2>();
app.UseMiddleware<APIRequestMiddleware>();  

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
