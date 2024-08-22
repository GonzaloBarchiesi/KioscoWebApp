using KioscoWebApp.Data;
using KioscoWebApp.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
namespace KioscoWebApp

{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddRazorPages();


            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            builder.Services.AddTransient<Seed>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnectionStr"));

            });

            var app = builder.Build();


            if (args.Length == 1 && args[0].ToLower() == "seeddata")
                SeedData(app);

            void SeedData(IHost app)
            {
                var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

                using (var scope = scopedFactory.CreateScope())
                {
                    var service = scope.ServiceProvider.GetService<Seed>();
                    service.SeedDataContext();
                }
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();



            app.MapControllerRoute(
             name: "default",
             pattern: "{controller=Home}/{action=Index}/{id?}");



            app.Run();
        }

    }
}
