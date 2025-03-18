using _20250317.Factories;
using _20250317.Services;
using _20250317.Interfaces;
using _20250317.Data;
using Microsoft.EntityFrameworkCore;
using _20250317.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient();

builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<AccountFactory>();

builder.Services.AddSingleton<PostFactory>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    }); ;
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
