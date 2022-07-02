using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.LogoutPath = "/Logout";
        options.AccessDeniedPath = "/Denied";
        options.Events = new CookieAuthenticationEvents()
        {
            OnSigningIn = async context =>
            {
                await Task.CompletedTask;
                System.Console.WriteLine("OnSigningIn =>");
            },
            OnSignedIn = async context =>
            {
                await Task.CompletedTask;
                System.Console.WriteLine("OnSignedIn =>");
            },
            OnRedirectToLogin = async context =>
            {
                await Task.CompletedTask;
                System.Console.WriteLine("OnRedirectToLogin =>");
            },
            OnSigningOut = async context =>
            {
                await Task.CompletedTask;
                System.Console.WriteLine("OnSigningOut =>");
            },
            OnRedirectToReturnUrl = async context =>
            {
                await Task.CompletedTask;
                System.Console.WriteLine("OnRedirectToReturnUrl =>");
            },
            OnValidatePrincipal = async context =>
            {
                await Task.CompletedTask;
                System.Console.WriteLine("OnValidatePrincipal =>");
            }
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
