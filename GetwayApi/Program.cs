using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Polly;
using System.Text;

//https://viblo.asia/p/trien-khai-api-gateway-trong-net-core-voi-ocelot-quan-ly-api-gateway-voi-swagger-L4x5xq1rKBM
//https://viblo.asia/p/trien-khai-api-gateway-trong-net-core-voi-ocelot-tinh-nang-co-ban-phan-1-Qbq5Q7WXZD8
//https://viblo.asia/p/trien-khai-api-gateway-trong-net-core-voi-ocelot-tinh-nang-co-ban-phan-2-Ljy5V2Xj5ra

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("ocelot.json", false, true);

builder.Logging.AddDebug();

// Add services to the container.
var key = Encoding.ASCII.GetBytes("82DDE48C-F4DF-402B-8B1E-B6BF15F919D7");
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
    };
});

builder.Services.AddOcelot(builder.Configuration).AddCacheManager(opt =>
{
    opt.WithDictionaryHandle();
}).AddPolly();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//var files = Directory.GetFiles("./ocelot_config");
//app.Logger.LogInformation(string.Join(',', files));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseOcelot().Wait();

app.UseAuthorization();

app.MapControllers();

app.Run();
