using Microsoft.EntityFrameworkCore;
using spiewosz.Data;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorPages();

// Configure PostgreSQL DbContext for Songs
var connectionString = builder.Configuration.GetConnectionString("Songs");
builder.Services.AddDbContext<SongContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

// apply migrations
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SongContext>();
    db.Database.Migrate();
}

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
