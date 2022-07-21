//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlacementTbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlacementTbl()
        {
            this.ApprenticeTbl = new HashSet<ApprenticeTbl>();
            this.ConstraintTbl = new HashSet<ConstraintTbl>();
            this.TutorForApprenticeTbl = new HashSet<TutorForApprenticeTbl>();
            this.TutorForApprenticeTbl1 = new HashSet<TutorForApprenticeTbl>();
            this.TutorTbl = new HashSet<TutorTbl>();
        }
    
        public int PlacementID { get; set; }
        public string PlacementName { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> NumberOfCandidatesForApprentice { get; set; }
        public Nullable<int> NumberOfCandidatesForTutor { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApprenticeTbl> ApprenticeTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConstraintTbl> ConstraintTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TutorForApprenticeTbl> TutorForApprenticeTbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TutorForApprenticeTbl> TutorForApprenticeTbl1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TutorTbl> TutorTbl { get; set; }
    }
}
