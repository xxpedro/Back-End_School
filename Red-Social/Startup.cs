using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Red_Social.Model.Models.Context;
using Red_Social.Model.Models.Courses;
using Red_Social.Model.Models.MatterAssignment;
using Red_Social.Model.Models.MatterSelection;
using Red_Social.Model.Models.Students;
using Red_Social.Model.Models.Teachers;
using Red_Social.Repository;
using Red_Social.Services.Services.CoursesServices;
using Red_Social.Services.Services.MatterAssignent;
using Red_Social.Services.Services.SelectionCoursesServices;
using Red_Social.Services.Services.StudentServices;
using Red_Social.Services.Services.TeacherService;

namespace Red_Social
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddDbContext<EscuelitaContext>(options=>options
            .UseSqlServer(Configuration.GetConnectionString("DefaultCoonection")));


            services.AddScoped<IBaseRepository<Teachers>, BaseRepository<Teachers>>();
            services.AddScoped<ITeacherService, TeacherService>();

            services.AddScoped<IBaseRepository<Courses>, BaseRepository<Courses>>();
            services.AddScoped<ICourseService, CourseService>();

            services.AddScoped<IBaseRepository<Students>, BaseRepository<Students>>();
            services.AddScoped<IStudentServices, StudentServices>();
            
            services.AddScoped<IBaseRepository<MatterSelection>, BaseRepository<MatterSelection>>();
            services.AddScoped<ISelectionCoursesServices, SelectionCoursesServices>();

            services.AddScoped<IBaseRepository<MatterAssignment>, BaseRepository<MatterAssignment>>();
            services.AddScoped<IMatterAssigmentService, MatterAssigmentService>();



            services.AddCors(options => options.AddPolicy("permiso", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("permiso");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetCore3 API V1");
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
