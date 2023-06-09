using AutoMapper;
using GeekShopping.API.Config;
using GeekShopping.API.Model.Context;
using GeekShopping.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region connection

builder.Services.AddDbContext<AppDbContext>(x => 
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion

#region mapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => 
    x.SwaggerDoc("v1", new OpenApiInfo {Title= "GeekShopping.API" })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
