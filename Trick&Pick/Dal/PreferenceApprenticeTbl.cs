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
    
    public partial class PreferenceApprenticeTbl
    {
        public int PreferenceApprenticeID { get; set; }
        public int PreferenceID { get; set; }
        public int ApprenticeID { get; set; }
        public Nullable<int> Status { get; set; }
    
        public virtual ApprenticeTbl ApprenticeTbl { get; set; }
        public virtual PreferenceTbl PreferenceTbl { get; set; }
    }
}