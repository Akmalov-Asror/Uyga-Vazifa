using FluentValidation.AspNetCore;
using FluentValidation;
using HakatonApi.Extensions;
using HakatonApi.Extensions.AddServiceFromAttribute;
using HakatonApi.Logger;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services._AddCors();
builder.Services._AddDbContext(builder.Configuration.GetConnectionString("Sqlite"));
builder.Services._AddIdentity();
builder._AddSerilogWithConfig();
builder.SerilogConfig();
builder.Services._AddServicesViaAttribute();

builder.Services.AddFluentValidationAutoValidation(o =>
{
    o.DisableDataAnnotationsValidation = false;
});

builder.Services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Program)));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();