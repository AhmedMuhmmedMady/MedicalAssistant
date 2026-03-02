using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAssistant.Domain.Entities.DoctorsModule
{
    public class Doctor : BaseEntity
    {
        // الاسم الكامل للطبيب
        public string FullName { get; set; } = default!;

        // رابط الصورة الشخصية للطبيب
        public string ImageUrl { get; set; } = default!;

        // نبذة عن الطبيب وخبراته
        public string Bio { get; set; } = default!;

        // عدد سنوات الخبرة
        public int ExperienceYears { get; set; }

        // متوسط التقييم (مثلاً 4.8)
        public double Rating { get; set; }

        // حالة التحقق من الطبيب بواسطة الأدمن
        public bool IsVerified { get; set; }

        // الربط مع جدول التخصصات
        #region Doctor - Speciality
        public int SpecialtyId { get; set; }
        public virtual Specialty Specialty { get; set; } = default!;
        #endregion
    }
}