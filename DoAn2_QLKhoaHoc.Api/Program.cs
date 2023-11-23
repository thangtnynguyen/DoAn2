

using BUS;
using BUS.Interfaces;
using DAO;
using DAO.Helper;
using DAO.Helper.Interfaces;
using DAO.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
// Add services to the container.
builder.Services.AddTransient<IDatabaseHelper, DatabaseHelper>();
builder.Services.AddTransient<IKhoaHocDAO, KhoaHocDAO>();
builder.Services.AddTransient<INguoiDungDAO, NguoiDungDAO>();
builder.Services.AddTransient<ITacGiaDAO, TacGiaDAO>();
builder.Services.AddTransient<ITaiLieuDAO, TaiLieuDAO>();
builder.Services.AddTransient<IKhoaHocBUS, KhoaHocBUS>();




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
