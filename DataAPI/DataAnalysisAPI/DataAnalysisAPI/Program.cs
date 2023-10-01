using DataAnalysisAPI.Data;
using DataAnalysisAPI.Services;
using DataAnalysisAPI.Services.BusinessLogic;
using DataAnalysisAPI.Services.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new NullReferenceException("No ConnectionString in config!");


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<DataAnalysisDbContext>((DbContextOptionsBuilder options) => options.UseNpgsql(connectionString));

builder.Services.AddTransient<ISalarySpendDetailsDataAccessService, SalarySpendDetailsDataAccessService>();
builder.Services.AddTransient<IEmployeeApiDataAccessService, EmployeeApiDataAccessService>();
builder.Services.AddTransient<IDailySalaryAnalysisBuisnessLogicService, DailySalaryAnalysisBuisnessLogicService>();
builder.Services.AddHttpClient();

builder.Services.AddHostedService<DailyJobService>();

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
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<DataAnalysisDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
