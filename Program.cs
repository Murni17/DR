using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using DRBAPI.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DRBAPIContext>(
options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DRDB"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
});

builder.Services.AddDbContext<DRContextProcedures>(
options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DRDB"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql"));
});


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

app.Run();
