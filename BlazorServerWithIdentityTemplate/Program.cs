using BlazorServerWithIdentityTemplate.Components;
using BlazorServerWithIdentityTemplate.DataPersistence;
using BlazorServerWithIdentityTemplate.DataPersistence.IdentityModels;
using BlazorServerWithIdentityTemplate.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using TanvirArjel.EFCore.GenericRepository;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

builder.Services.AddGenericRepository<ApplicationDbContext>();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var cs = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite(cs);
});

builder.Services.Configure<DefaultUser>(builder.Configuration.GetSection("DefaultUser"));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.LoginPath = "/Login";
    options.AccessDeniedPath = "/Denied";
    options.SlidingExpiration = true;
});

builder.Services.AddControllers();
//初始化管理员
builder.Services.AddHostedService<DefaultUserInitializer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// ===== 自动迁移 =====
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

app.MapControllers();

app.UseStatusCodePagesWithRedirects("/notfound");

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
