using API.Persistence.Configuration;
using API.Business.Features.CQRS.Commands.Category;
using API.Business.Features.CQRS.Commands.Product;
using API.Business.Service.Concrete;
using API.Business.Service.Contracts;
using API.Business.Validations.Concrete;
using API.Business.Validations.Contracts;
using API.Model.Configuration;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Configure settings
services.ConfigureSettings<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

// Configure services.
services.ConfigureDbContext();
services.ConfigureRepository();
services.ConfigureAutoMapper();
services.ConfigureMediatR();
services.AddRouting(options => options.LowercaseUrls = true);

#region Application Services
services.ConfigureScopedService<IValidatorService, ValidatorService>();
services.ConfigureSingletonService<IMessageProvider, MessageProvider>();
#endregion

#region Validation Services
services.ConfigureValidator<CreateCategoryCommand>();
services.ConfigureValidator<UpdateCategoryCommand>();
services.ConfigureValidator<DeleteCategoryCommand>();

services.ConfigureValidator<CreateProductCommand>();
services.ConfigureValidator<UpdateProductCommand>();
services.ConfigureValidator<DeleteProductCommand>();
#endregion

services.AddControllers();
services.AddEndpointsApiExplorer();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(opt =>
    {
        opt.Theme = ScalarTheme.DeepSpace;
        opt.DarkMode = true;
        opt.WithTitle("CQRS MediatR API");
        opt.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();