using System.Text;
using LoansAnalyzerAPI.GoogleProvider;
using LoansAnalyzerAPI.OAuthProvider;using LoansAnalyzerAPI.Security;
using LoansAnalyzerAPI.Users.Clients.AdditionalData.Controllers;
using LoansAnalyzerAPI.Users.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UserContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddTransient<ApiHelper>();
builder.Services.AddTransient<OAuthService>();
builder.Services.AddTransient<JwtTokenService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<OAuthProviderSettings>(
    builder.Configuration.GetSection("OAuthProviderSettings"));
builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtToken"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
}).AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JwtToken:Key"))),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration.GetValue<string>("JwtToken:Issuer"),
        ValidateAudience = true,
        ValidAudience = builder.Configuration.GetValue<string>("JwtToken:Audience"),
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromSeconds(builder.Configuration.GetValue<int>("JwtToken:LifetimeInSeconds"))
    };
});

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();


