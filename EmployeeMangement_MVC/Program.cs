using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddSession();
builder.Services.AddHttpClient("ApiClient", client =>
{
#pragma warning disable CS8604 // Possible null reference argument.
    client.BaseAddress = new Uri(uriString: builder.Configuration["AppSetting:ApiBaseUrl"]);
#pragma warning restore CS8604 // Possible null reference argument.
});

// Add authentication services
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "http://localhost:63044/api/"; // Replace with actual Auth Server
        options.Audience = "VaibhavBhosale123"; // Replace with your API audience
        options.RequireHttpsMetadata=false;
    });
builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
