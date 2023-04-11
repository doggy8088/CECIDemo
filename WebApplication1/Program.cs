using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

#region 設定服務

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton(new AppSettings()
{
    SMTPAddress = "127.0.0.1"
});

#endregion

#region 設定 Middleware

var app = builder.Build();

#region Demo
//app.Use(async (context, next) =>
//{
//    if (如果Request是http的話)
//    {
//        轉址到https();
//        return;
//    }
//    else
//    {
//        await next();
//    }
//    //await context.Response.WriteAsync("1");
//    //await next();
//    //await context.Response.WriteAsync("2");
//});

//app.Use(async (context, next) =>
//{
//    try
//    {
//        await next();
//    }
//    catch (Exception ex)
//    {
//        throw;
//    }
//});

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("3");
//    if (false)
//    {
//        await next();
//    }
//    await context.Response.WriteAsync("4");
//});
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("5");
//});
#endregion

//Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

#endregion

app.Run();
