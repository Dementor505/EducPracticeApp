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
    
    public partial class Dicipline
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dicipline()
        {
            this.Exam = new HashSet<Exam>();
            this.Claim = new HashSet<Claim>();
        }
    
        public int Code_Dicipline { get; set; }
        public Nullable<int> Space_Dicipline { get; set; }
        public string Name_Dicipline { get; set; }
        public Nullable<int> Id_Cathedra { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual Cathedra Cathedra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exam> Exam { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Claim> Claim { get; set; }
    }
}
