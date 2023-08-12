using Microsoft.EntityFrameworkCore;
using TrustyAnalytics.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<TrustyAnalyticContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();   

builder.Services.AddStackExchangeRedisCache(options => {
options.Configuration = builder.Configuration["AZURE_REDIS_CONNECTIONSTRING"];
options.InstanceName = "SampleInstance";
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

/*
if (app.Environment.IsDevelopment())
{
}
*/


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();