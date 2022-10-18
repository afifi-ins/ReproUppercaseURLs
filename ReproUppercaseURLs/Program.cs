using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
app.UseRouting();

app.MapGet("/", () =>
{
    // Get Server address using Server Features...
    var server = app.Services.GetRequiredService<IServer>();
    var addressFeature = server.Features.Get<IServerAddressesFeature>();
    // Uppercase addresses - using IIS/IIS Express
    var addresses = addressFeature!.Addresses.ToList();
    return "Listing on addresses: \n" + string.Join("\n", addresses);
});

app.Run();
