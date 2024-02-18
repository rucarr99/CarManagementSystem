using CarManagementSystem.Infra.ServiceCollectionExtension;
using CarManagementSystem.Services.Services;
using CarManagementSystem.WcfServices.Services;
using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using System.Web.Services.Description;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel((context, options) => { options.AllowSynchronousIO = true; });

// Add WSDL support
builder.Services.AddServiceModelServices().AddServiceModelMetadata();
builder.Services.RegisterDatabaseAccess(builder.Configuration.GetConnectionString("DBConnectionString") ??
                                        throw new InvalidOperationException());
builder.Services.RegisterServices();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();
builder.Services.AddTransient<WcfServices>();

var app = builder.Build();
app.UseServiceModel(builder =>
{
    builder.AddService<WcfServices>((serviceOptions) =>
        {
            serviceOptions.DebugBehavior.IncludeExceptionDetailInFaults = true;
        })
        // Add a BasicHttpBinding at a specific endpoint
        .AddServiceEndpoint<WcfServices, IWcfServices>(new BasicHttpBinding(), "/WcfService/basicHttp");
});


var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
serviceMetadataBehavior.HttpGetEnabled = true;

app.Run();