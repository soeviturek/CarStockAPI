using CarStockAPI;
using CarStockAPI.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IDealers,DealerService>();
builder.Services.AddSingleton<IDealers, DealerService>();
builder.Services.AddSingleton<ICar, CarService>();

//skip visioning

builder.Services.AddSwaggerGen(
    options =>
    {
        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "Title",
            Version = "v1",
            Description = "Description",
        });

        /*options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "apiKey", //basic
            In = ParameterLocation.Header,
            Description = "ApiKey Auth Header"
        });*/
        options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
        {
            Name = "x-api-key",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "ApiKeyScheme",
            In = ParameterLocation.Header,
            Description = "ApiKey Auth Header"
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement{
            {
                new OpenApiSecurityScheme
                {
                    Reference=new OpenApiReference
                    { Type=ReferenceType.SecurityScheme,
                        Id="ApiKey"
                    }
                },new string[]{ }
            }
        });
    });

builder.Services.AddAuthentication("ApiKeyAuthentication").AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>("ApiKeyAuthentication", null);
builder.Services.AddRouting();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//app.UseMiddleware<ApiKeyMiddleware>();

app.Run();

