using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;



var builder = WebApplication.CreateBuilder(args);

//Add Infrastructure services
builder.Services.AddInfrastructure();
//Add Core services
builder.Services.AddCore();

//Add Controllers to the service collection
builder.Services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });


builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

//FluentValidation
builder.Services.AddFluentValidationAutoValidation();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cors services
builder.Services.AddCors(options =>
{

    options.AddDefaultPolicy(builder => {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});


var app = builder.Build();


app.UseExceptionHandlingMiddleware();
//Routing
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();


//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();



app.Run();
