using Application.Contracts.Repository;
using Application.Contracts.Service;
using Data.Context;
using Infrastructure.Stores;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationLoyMark.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LoyMarkDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LoyMark"));
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IActivityRepository, ActivityStore>();
builder.Services.AddScoped<IUserRepository, UserStore>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    LoyMarkDbContext dataContext = scope.ServiceProvider.GetRequiredService<LoyMarkDbContext>();

    dataContext.Database.Migrate();
}

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