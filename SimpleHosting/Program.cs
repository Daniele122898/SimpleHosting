using System.Diagnostics;
using Microsoft.Extensions.Options;
using SimpleHosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ServingConfig>(builder.Configuration.GetSection("Serving"));
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseDefaultFiles();
app.UseStaticFiles();

var servingConfig = app.Services.GetService<IOptions<ServingConfig>>();

if (servingConfig is { Value.IsSpa: true })
{
    app.Logger.LogInformation("SPA serving enabled");
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
        endpoints.MapFallbackToController("Index", "Fallback");
    });
}
else
{
    app.Logger.LogInformation("SPA serving disabled");
}

app.Run();