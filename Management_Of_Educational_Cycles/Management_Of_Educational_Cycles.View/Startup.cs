using Management_Of_Educational_Cycles.Logic.Interfaces;
using Management_Of_Educational_Cycles.Logic.Interfaces.IEntityRepository;
using Management_Of_Educational_Cycles.Logic.Interfaces.IEntityViewModelProviders;
using Management_Of_Educational_Cycles.Logic.Services;
using Management_Of_Educational_Cycles.Logic.Services.EntityRepository;
using Management_Of_Educational_Cycles.Logic.Services.EntityViewsProviders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.View
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddTransient<DataManager>();
            services.AddTransient<IDepartmentsRepository, DepartmentsRepository>();
            services.AddTransient<IDisciplinesRepository, DisciplinesRepository>();
            services.AddTransient<IEducationalCyclesRepository, EducationalCyclesRepository>();
            services.AddTransient<IFacultiesRepository, FacultiesRepository>();
            services.AddTransient<IGroupsRepository, GroupsRepository>();
            services.AddTransient<ITeachersRepository, TeachersRepository>();
            services.AddTransient<IWorkManagementCyclesRepository, WorkManagementCyclesRepository>();


            services.AddTransient<IRequestSender, RequestSender>();



            services.AddTransient<EntitieViewModelsManager>();
            services.AddTransient<IDepartmentViewsProvider, DepartmentViewsProvider>();
            services.AddTransient<IDisciplineViewsProvider, DisciplineViewsProvider>();
            services.AddTransient<IEducationalCycleViewsProvider, EducationalCycleViewsProvider>();
            services.AddTransient<IFacultyViewsProvider, FacultyViewsProvider>();
            services.AddTransient<IGroupViewsProvider, GroupViewsProvider>();
            services.AddTransient<ITeacherViewsProvider, TeacherViewsProvider>();
            services.AddTransient<IWorkManagementCycleViewsProvider, WorkManagementCycleViewsProvider>();
            //services.AddTransient(typeof(IPageSeparator<>), typeof(PageSeparator<>));
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
