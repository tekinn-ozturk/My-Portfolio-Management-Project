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
            builder.Services.AddDbContext<Context>(); //Sql ile baðlantýyý Context'te yapsakta Program.cs'te configurasyon yapmak lazým.
                                                      //Identity
            builder.Services.AddIdentity<WriterAppUser, AppUserWriterRole>().AddEntityFrameworkStores<Context>();

            builder.Services.AddMvc(config =>
            {
                //Bu satýrda bir yetki politikasý oluþturuluyor. AuthorizationPolicyBuilder sýnýfý, yetki politikalarýný oluþturmak için kullanýlýr. 
                //RequireAuthenticatedUser() metodu, kullanýcýlarýn kimlik doðrulamasý yapmýþ olmalarýný zorunlu kýlan bir politika oluþturur.
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();


                config.Filters.Add(new AuthorizeFilter(policy));

                //Filtre ekleme gerçekleþtiriliyor.Add metodu içersinde bir AuthorizeFilter türünde örnek oluþturuluyor sonrasýnda policy deðiþkenimiz bu Filter'a atanýyor.
            });

            builder.Services.ConfigureApplicationCookie(options =>
            {
                //Bu satýr, oluþturulan çerezin sadece HTTP istemcileri tarafýndan eriþilebilir olduðunu belirtir.
                options.Cookie.HttpOnly = true;

                //Bu satýr, çerezin geçerlilik süresini belirtir. Burada, çerezin 1 gün (24 saat) boyunca geçerli olmasýný saðlamak için TimeSpan sýnýfý kullanýlmýþtýr. Bu süre sonunda çerezin otomatik olarak geçersizleþeceði anlamýna gelir.
                options.ExpireTimeSpan = TimeSpan.FromDays(1);

                //kimlik doðrulama gerektiren bir iþlemde oturumu olmayan bir kullanýcý yönlendirileceði sayfayý belirleyebilirsiniz.
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