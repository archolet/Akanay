using Akanay.Core.Utilities.Security.Encyption;
using Akanay.Core.Utilities.Security.Jwt;
using Akanay.Service.DependencyResolvers.Autofac;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
<<<<<<< HEAD
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
=======
>>>>>>> d1e71ae5530256531d2e3672820f5c226d710df2
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test01", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."

    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                         new string[] {}
                    }
                });
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",builder => builder.WithOrigins("http://localhost:7040"));
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudiences = tokenOptions.Audience.Split(","),
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",builder => builder.WithOrigins("http://localhost:5145"));
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudiences = tokenOptions.Audience.Split(","),
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
    };
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>{ builder.RegisterModule(new AutofacServiceModule()); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DocExpansion(DocExpansion.None);
        options.DefaultModelRendering(ModelRendering.Model);
        options.DisplayRequestDuration();

        options.EnableDeepLinking();
        options.ShowExtensions();
        options.ShowCommonExtensions();
        options.EnableValidator();
        options.ConfigObject.AdditionalItems["syntaxHighlight"] = true;
    });
}

<<<<<<< HEAD
app.UseCors(builder =>builder.WithOrigins("http://localhost:7040").AllowAnyHeader());
=======
app.UseCors(builder =>builder.WithOrigins("http://localhost:5145").AllowAnyHeader());
>>>>>>> d1e71ae5530256531d2e3672820f5c226d710df2
app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();
app.UseAuthentication();


app.MapControllers();

app.Run();
