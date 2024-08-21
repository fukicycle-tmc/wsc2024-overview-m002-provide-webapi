using Microsoft.EntityFrameworkCore;
using provide_webapi;
using provide_webapi.Authentication;
using provide_webapi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:5000/");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
    policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin()));

builder.Services.AddAuthentication(AccessTokenAuthenticationOptions.DefaultScheme)
                .AddScheme<AccessTokenAuthenticationOptions, AccessTokenAuthenticationHandler>(
                    AccessTokenAuthenticationOptions.DefaultScheme, options => { });

builder.Services.AddDbContext<DB>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DB")));

var app = builder.Build();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();