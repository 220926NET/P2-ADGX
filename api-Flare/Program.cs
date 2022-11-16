using DataAccessLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using BusinessLogicLayer;
using System.Configuration;
using BusinessLogicLayer.Services.AuthService;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication((opt) =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = "https://flar-e.azurewebsites.net/",
        ValidAudience = "https://lemon-tree-03b841910.2.azurestaticapps.net/",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecret12345"))
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy
                          .AllowAnyOrigin()
                          .AllowCredentials()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});
// Add services to the container.
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddControllers();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();

builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();

builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();


builder.Services.AddSingleton<BlobStorage>();
builder.Services.AddSingleton<VisionApi>();
builder.Services.AddSingleton<ServerResponse>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();
builder.Services.AddScoped<ILikeRepository, LikeRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(configuration =>
{
    configuration.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Using JWT Bearer Scheme, e.g. \"bearer {token} \"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    configuration.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection("AuthSettings"));



var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
