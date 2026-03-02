using MedicalAssistant.Domain.Entities.DoctorsModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalAssistant.Persistance.Data.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            // إعدادات الخصائص (Properties Configuration)

            // الاسم الكامل مطلوب وبحد أقصى 100 حرف لضمان عدم تشوه واجهة الكارت
            builder.Property(d => d.FullName)
                   .IsRequired()
                   .HasMaxLength(100);

            // رابط الصورة مطلوب لعرض صور الأطباء في الواجهة
            builder.Property(d => d.ImageUrl)
                   .IsRequired();

            // الوصف (Bio) قد يكون طويلاً لذا نجعله من نوع nvarchar(max)
            builder.Property(d => d.Bio)
                   .IsRequired();

            // سنوات الخبرة لا يمكن أن تكون بالسالب
            builder.Property(d => d.ExperienceYears)
                   .IsRequired();

            // التقييم (Rating) نحدد الدقة لتناسب أرقام مثل 4.9
            builder.Property(d => d.Rating)
                   .HasColumnType("decimal(3,2)")
                   .HasDefaultValue(0.0);

            // حالة التحقق (IsVerified) تظهر افتراضياً كـ false حتى يقبلها الأدمن
            builder.Property(d => d.IsVerified)
                   .HasDefaultValue(false);

            // إعدادات العلاقات (Relationships Configuration)

            // علاقة One-to-Many بين التخصص والأطباء
            builder.HasOne(d => d.Specialty)
                   .WithMany(s => s.Doctors)
                   .HasForeignKey(d => d.SpecialtyId)
                   .OnDelete(DeleteBehavior.Restrict); // منع حذف التخصص إذا كان مرتبطاً بأطباء
        }
    }
}