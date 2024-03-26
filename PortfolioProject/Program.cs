using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using PortfolioProject.Controllers;

namespace PortfolioProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.Services.AddDbContext<Context>(); //Sql ile ba�lant�y� Context'te yapsakta Program.cs'te configurasyon yapmak laz�m.
                                                      //Identity
            builder.Services.AddIdentity<WriterAppUser, AppUserWriterRole>().AddEntityFrameworkStores<Context>();

            builder.Services.AddMvc(config =>
            {
                //Bu sat�rda bir yetki politikas� olu�turuluyor. AuthorizationPolicyBuilder s�n�f�, yetki politikalar�n� olu�turmak i�in kullan�l�r. 
                //RequireAuthenticatedUser() metodu, kullan�c�lar�n kimlik do�rulamas� yapm�� olmalar�n� zorunlu k�lan bir politika olu�turur.
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();


                config.Filters.Add(new AuthorizeFilter(policy));

                //Filtre ekleme ger�ekle�tiriliyor.Add metodu i�ersinde bir AuthorizeFilter t�r�nde �rnek olu�turuluyor sonras�nda policy de�i�kenimiz bu Filter'a atan�yor.
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                //Bu sat�r, olu�turulan �erezin sadece HTTP istemcileri taraf�ndan eri�ilebilir oldu�unu belirtir.
                options.Cookie.HttpOnly = true;

                //Bu sat�r, �erezin ge�erlilik s�resini belirtir. Burada, �erezin 1 g�n (24 saat) boyunca ge�erli olmas�n� sa�lamak i�in TimeSpan s�n�f� kullan�lm��t�r. Bu s�re sonunda �erezin otomatik olarak ge�ersizle�ece�i anlam�na gelir.
                options.ExpireTimeSpan = TimeSpan.FromDays(1);

                //kimlik do�rulama gerektiren bir i�lemde oturumu olmayan bir kullan�c� y�nlendirilece�i sayfay� belirleyebilirsiniz.
                options.LoginPath = "/Writer/Login/Index/";

                options.AccessDeniedPath = "/ErrorPage/Index/";
            });
            //Repository
            builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            builder.Services.AddTransient<IPortfolioRepository, EFPortfolioRepository>();
            builder.Services.AddTransient<IToDoListRepository, EFToDoListRepository>();
            builder.Services.AddTransient<IAnnouncementRepository, EFAnnouncementRepository>();
            builder.Services.AddTransient<ISkillRepository, EFSkillRepository>();
            builder.Services.AddTransient<IWriterMessageRepository, EFWriterMessageRepository>();
            builder.Services.AddTransient<IMessageRepository, EFMessageRepository>();
            builder.Services.AddTransient<ITestimonialRepository, EFTestimonialRepository>();
            builder.Services.AddTransient<IContactRepository, EFContactRepository>();
            builder.Services.AddTransient<ISocialMediaRepository, EFSocialMediaRepository>();
            builder.Services.AddTransient<IWriterUserRepository, EFWriterUserRepository>();
            builder.Services.AddTransient<IExperienceRepository, EFExperienceRepository>();


            //Manager

            builder.Services.AddTransient<IPortfolioService, PortfolioManager>();
            builder.Services.AddTransient<IToDoListService, ToDoListManager>();
            builder.Services.AddTransient<IAnnouncementService, AnnouncementManager>();
            builder.Services.AddTransient<ISkillService, SkillManager>();
            builder.Services.AddTransient<IWriterMessageService, WriterMessageManager>();
            builder.Services.AddTransient<IMessageService, MessageManager>();
            builder.Services.AddTransient<ITestimonialService, TestimonialManager>();
            builder.Services.AddTransient<IContactService, ContactManager>();
            builder.Services.AddTransient<ISocialMediaService, SocialMediaManager>();
            builder.Services.AddTransient<IWriterUserService, WriterUserManager>();
            builder.Services.AddTransient<IExperienceService, ExperienceManager>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();


            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"

                    );
            });
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}