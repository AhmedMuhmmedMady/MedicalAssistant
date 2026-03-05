namespace MedicalAssistant.Domain.Entities.PatientModule
{
    public class Patient : BaseEntity
    {
        // الاسم الكامل للمريض
        public string FullName { get; set; } = default!;

        // البريد الإلكتروني للمريض
        public string Email { get; set; } = default!;

        // رقم الهاتف
        public string PhoneNumber { get; set; } = default!;

        // تاريخ الميلاد
        public DateTime DateOfBirth { get; set; }

        // الجنس (Male/Female)
        public string Gender { get; set; } = default!;

        // العنوان
        public string? Address { get; set; }

        // رابط الصورة الشخصية (اختياري)
        public string? ImageUrl { get; set; }

        // فصيلة الدم (اختياري)
        public string? BloodType { get; set; }

        // ملاحظات طبية أو حالات مزمنة
        public string? MedicalNotes { get; set; }

        // تاريخ التسجيل
        public DateTime CreatedAt { get; set; }

        // حالة تفعيل الحساب
        public bool IsActive { get; set; }
    }
}
