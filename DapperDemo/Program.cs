using DapperDemo.DataAccess;
using DapperDemo.IRepository;
using DapperDemo.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddOpenApiDocument(options =>
{
    options.Title = "Dapper Api";
});

builder.Services.AddTransient<ISqlDataAccess, SqlAccess>();
builder.Services.AddTransient<ISuperHeroRepository, SuperHeroRepository>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors(cors =>
{
    cors.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
});

app.UseStaticFiles();

app.UseRouting();

//swagger connection using nswag.aspnetcore
app.UseOpenApi();

app.UseSwaggerUi(c =>
{
    c.Path = "/api";
});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
