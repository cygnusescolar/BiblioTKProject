//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BiblioTKProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_BiblioTK_Temas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_BiblioTK_Temas()
        {
            this.tbl_BiblioTK_Catalogo_Temas = new HashSet<tbl_BiblioTK_Catalogo_Temas>();
        }
    
        public System.Guid tema_uid { get; set; }
        public string tema_nombre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_BiblioTK_Catalogo_Temas> tbl_BiblioTK_Catalogo_Temas { get; set; }
    }
}