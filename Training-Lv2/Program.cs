using Application.Services.Implement;
using Application.Services.Interface;
using Infrastructure.Core.IRepositories;
using Infrastructure.Core.Repositories;
using Infrastructure.Core.UnitOfWork;
using Infrastructure.DataContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddMvcCore().AddApiExplorer();

builder.Services.AddTransient<IMemberRepository, MemberRepository>();
builder.Services.AddTransient<IMemberService, MemberService>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
               .AddEntityFrameworkStores<DatabaseContext>();
//var mapperConfig = new MapperConfiguration(mc =>
//{
//    mc.AddProfile(new AutoMapperConfig());
//});
//IMapper mapper = mapperConfig.CreateMapper();

var app = builder.Build();

app.UseAuthentication();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",

    pattern: "{controller=Members}/{action=Index}/{id?}");

app.Run();
