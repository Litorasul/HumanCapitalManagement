using EmployeesManagingAPI.Data;
using EmployeesManagingAPI.Services.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new NullReferenceException("No ConnectionString in config!");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<EmployeesDbContext>((DbContextOptionsBuilder options) => options.UseNpgsql(connectionString));

builder.Services.AddTransient<IPositionDataAccessService, PositionDataAccessService>();
builder.Services.AddTransient<IDepartmentDataAccessService, DepartmentDataAccessService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Apply Migrations
using (var serviceScope = app.Services.CreateScope())
{ 
    var dbContext  = serviceScope.ServiceProvider.GetRequiredService<EmployeesDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.Run();

