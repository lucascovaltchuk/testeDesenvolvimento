
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using WebAppTestFull.Services;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddControllersWithViews();
        services.AddRazorPages();

        services.AddTransient<ExcelService>();
        services.AddTransient<EmailService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext dbContext)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        dbContext.Database.Migrate();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            endpoints.MapRazorPages();
        });
    }
}
