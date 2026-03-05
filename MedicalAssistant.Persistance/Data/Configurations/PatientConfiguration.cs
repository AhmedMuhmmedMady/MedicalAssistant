using MedicalAssistant.Domain.Entities.PatientModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalAssistant.Persistance.Data.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            // إعدادات الخصائص (Properties Configuration)

            // الاسم الكامل مطلوب وبحد أقصى 100 حرف
            builder.Property(p => p.FullName)
                   .IsRequired()
                   .HasMaxLength(100);

            // البريد الإلكتروني مطلوب وفريد
            builder.Property(p => p.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasIndex(p => p.Email)
                   .IsUnique();

            // رقم الهاتف مطلوب
            builder.Property(p => p.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(20);

            // تاريخ الميلاد مطلوب
            builder.Property(p => p.DateOfBirth)
                   .IsRequired();

            // الجنس مطلوب
            builder.Property(p => p.Gender)
                   .IsRequired()
                   .HasMaxLength(10);

            // العنوان اختياري
            builder.Property(p => p.Address)
                   .HasMaxLength(300);

            // رابط الصورة اختياري
            builder.Property(p => p.ImageUrl);

            // فصيلة الدم اختيارية
            builder.Property(p => p.BloodType)
                   .HasMaxLength(5);

            // الملاحظات الطبية قد تكون طويلة
            builder.Property(p => p.MedicalNotes);

            // تاريخ التسجيل مطلوب مع قيمة افتراضية
            builder.Property(p => p.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETUTCDATE()");

            // حالة التفعيل افتراضياً true
            builder.Property(p => p.IsActive)
                   .HasDefaultValue(true);
        }
    }
}
