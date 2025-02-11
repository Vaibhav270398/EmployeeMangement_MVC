var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddHttpClient("ApiClient", client =>
{
#pragma warning disable CS8604 // Possible null reference argument.
    client.BaseAddress = new Uri(uriString: builder.Configuration["AppSetting:ApiBaseUrl"]);
#pragma warning restore CS8604 // Possible null reference argument.
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
