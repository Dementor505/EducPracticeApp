//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EducationAppHabLat.MyBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Speciality
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Speciality()
        {
            this.Claim = new HashSet<Claim>();
            this.Student = new HashSet<Student>();
        }
    
        public int Id_Speciality { get; set; }
        public string Number_Speciality { get; set; }
        public string Direction_Speciality { get; set; }
        public int Id_Cathedra { get; set; }
    
        public virtual Cathedra Cathedra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Claim> Claim { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Student { get; set; }
    }
}