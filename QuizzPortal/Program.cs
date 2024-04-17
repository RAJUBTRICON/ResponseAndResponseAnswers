using BusinessLogicLayer;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using QuizzPortal.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext and connection string
builder.Services.AddDbContext<ResponseContextDB>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("QuizzPortal")));

var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<ResponseBLL, ResponseModel>().ReverseMap();
    cfg.CreateMap<ResponseAnswerBLL, ResponseAnswerModel>().ReverseMap();
});

var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


// Configure AutoMapper
builder.Services.AddAutoMapper(typeof(Program)); // Or typeof(BLLibrary), or any type within your project

// Add your BLLibrary service
builder.Services.AddScoped<BLLibrary>();


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
