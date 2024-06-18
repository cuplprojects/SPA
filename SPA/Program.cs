using SPA.Data;
using Microsoft.EntityFrameworkCore;
using SPA.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FirstDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("Database1"),
        new MySqlServerVersion(new Version(8, 0, 2))));

builder.Services.AddDbContext<SecondDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("Database2"),
        new MySqlServerVersion(new Version(8, 0, 2))));

builder.Services.AddScoped<IChangeLogger, Changelogger>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var firstDbContext = services.GetRequiredService<FirstDbContext>();
    firstDbContext.Database.Migrate();

    var secondDbContext = services.GetRequiredService<SecondDbContext>();
    secondDbContext.Database.Migrate();
}

app.Run();
