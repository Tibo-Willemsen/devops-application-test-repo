var builder = WebApplication.CreateBuilder(args);

// Ensure the server listens on all network interfaces inside the VM
builder.WebHost.UseUrls("http://0.0.0.0:5000");

var app = builder.Build();

app.MapGet("/", () => new { 
    Message = "Hello World from Ubuntu Vagrant VM!", 
    Timestamp = DateTime.UtcNow,
    Machine = Environment.MachineName 
});

app.MapGet("/health", () => Results.Ok("Healthy"));

app.Run();