using AspNetCoreRateLimit;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOptions();
builder.Services.AddMemoryCache();

builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));

builder.Services.AddInMemoryRateLimiting();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();


builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options =>
{
    options.Cookie.Name = "MyCookieAuth";
});
builder.Services.AddRazorPages();





var app = builder.Build();
app.UseIpRateLimiting();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
