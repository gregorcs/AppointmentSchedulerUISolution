using AppointmentSchedulerUI.ServiceLayer.Implementations;
using AppointmentSchedulerUI.ServiceLayer.Interfaces;
using AppointmentSchedulerUILibrary.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IAccountService, AccountService>();
builder.Services.AddSingleton<IAppointmentService, AppointmentService>();
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddAuthentication(CookieHandler.CookieName).AddCookie(CookieHandler.CookieName, options =>
{
    options.Cookie.Name = CookieHandler.CookieName;
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminAccess", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UseAccess", policy => policy.RequireAssertion(context =>
            context.User.IsInRole("Admin") || context.User.IsInRole("User")));
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
