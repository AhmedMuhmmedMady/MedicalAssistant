using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAssistant.Domain.Entities.DoctorsModule
{
    public class Specialty : BaseEntity
    {
        // اسم التخصص مثل Dermatology, Cardiology, etc.
        public string Name { get; set; } = default!;

        // علاقة One-to-Many: التخصص الواحد يضم العديد من الأطباء
        public virtual ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();
    }
}
