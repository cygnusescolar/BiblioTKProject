//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BiblioTK.DAL.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class tbl_BiblioTK_Idiomas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_BiblioTK_Idiomas()
        {
            this.tbl_BiblioTK_Catalogo = new HashSet<tbl_BiblioTK_Catalogo>();
        }
        [Key]
        public string idioma_id { get; set; }
        public string idioma_nombre { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_BiblioTK_Catalogo> tbl_BiblioTK_Catalogo { get; set; }
    }
}
