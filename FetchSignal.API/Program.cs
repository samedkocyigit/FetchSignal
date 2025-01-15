using System.Text.Json.Serialization;
using FetchSignal.Application.Extensions;
using FetchSignal.Infrastructure.Extension;
using Hangfire;
using ApplicationExtension = FetchSignal.Application.Extensions.ApplicationExtension;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
//        options.JsonSerializerOptions.WriteIndented = true;
//    });
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureLayer();
builder.Services.AddApplicationLayer();

var app = builder.Build();

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHangfireDashboard("/hangfire");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
