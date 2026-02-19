using SoapCore;
//using MockSoapService.Contracts;
using MockSoapService.Services;
using ServiceReference;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();
builder.Services.AddSingleton<NetSuitePortType, NetSuiteMock>();


var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<NetSuitePortType>(
        "/NetSuiteLocal.svc",
        new SoapEncoderOptions(),
        SoapSerializer.XmlSerializer);
});

app.Run();