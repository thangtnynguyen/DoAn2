

using BUS;
using BUS.Interfaces;
using DAO;
using DAO.Helper;
using DAO.Helper.Interfaces;
using DAO.Interfaces;
using DoAn2.QLKhoaHoc.Api.Admin.Providers;
using Microsoft.OpenApi.Models;
using DoAn2.QLKhoaHoc.Api.Admin.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigins", builder =>
//    {
//        builder.WithOrigins("http://127.0.0.1:5501", "http://localhost:5501")
//               .AllowAnyMethod()
//               .AllowAnyHeader();
//    });
//});

// Add services to the container.
builder.Services.AddTransient<ITruyVanDuLieu, TruyVanDuLieu>();
builder.Services.AddTransient<IKhoaHocDAO, KhoaHocDAO>();
builder.Services.AddTransient<IUserDAO, UserDAO>();
builder.Services.AddTransient<ITacGiaDAO, TacGiaDAO>();
builder.Services.AddTransient<ITaiLieuDAO, TaiLieuDAO>();
builder.Services.AddTransient<ILoaiKhoaHocDAO, LoaiKhoaHocDAO>();
builder.Services.AddTransient<IKhoaHocBUS, KhoaHocBUS>();
builder.Services.AddTransient<IUserBUS, UserBUS>();
builder.Services.AddTransient<ITacGiaBUS, TacGiaBUS>();
builder.Services.AddTransient<ILoaiKhoaHocBUS, LoaiKhoaHocBUS>();



//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("ManageKhoaHoc", policy => policy.RequireClaim("role", "Admin"));
//    // Thêm các policy khác nếu cần
//});
builder.Services.AddIdentityProvider(builder);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(
// );

builder.Services.AddSwaggerGen(c =>
{
    //c.DocumentFilter<SwaggerModule>();
    //c.OperationFilter<SwaggerModule>();
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Quan ly khoa hoc", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        }
      );
});




var app = builder.Build();
app.UseMiddleware<ApiExceptionMiddleware>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(
    x=>x.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
