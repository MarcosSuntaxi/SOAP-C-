using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Configuración de servicios
builder.Services.AddSoapCore();
builder.Services.AddScoped<ICalculatorService, CalculatorService>();

var app = builder.Build();

// Configuración explícita del endpoint SOAP
SoapCore.SoapEndpointExtensions.UseSoapEndpoint<ICalculatorService>(
    app,
    "/Service.svc",
    new SoapEncoderOptions()
);

app.Run();
