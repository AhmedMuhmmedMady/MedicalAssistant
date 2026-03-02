using MedicalAssistant.Domain.Entities.DoctorsModule;
using MedicalAssistant.Persistance.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace MedicalAssistant.Persistance.Data.DbContexts
{
    public class MedicalAssistantDbContext : DbContext
    {
        public MedicalAssistantDbContext(DbContextOptions<MedicalAssistantDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // تطبيق جميع الإعدادات (Configurations) الموجودة في نفس الـ Assembly الذي يحتوي على DoctorConfiguration
            // هذا يضمن تشغيل قيود البيانات التي حددناها للأطباء والتخصصات
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DoctorConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        // الجداول الأساسية لمديول الأطباء

        // جدول الأطباء الذي يحتوي على البيانات المعروضة في الكروت
        public DbSet<Doctor> Doctors { get; set; }

        // جدول التخصصات لملء قائمة الاختيارات والبحث
        public DbSet<Specialty> Specialties { get; set; }
    }
}