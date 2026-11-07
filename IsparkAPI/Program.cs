using IsparkAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient("ispark", c => c.BaseAddress = new Uri(builder.Configuration.GetConnectionString("ispark_base_url")!));

builder.Services.AddSingleton<IParkService, ParkService>();

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/api/ispark", async (IParkService service) => await service.GetListAsync());
app.MapGet("/api/ispark/{id}", async (IParkService service, int id) => await service.GetDetailAsync(id));

app.Run();