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
    
    public partial class tbl_Seguridad_Log
    {
        public System.Guid log_uid { get; set; }
        public System.Guid usuario_uid { get; set; }
        public short usuario_tipo { get; set; }
        public System.DateTime fecha { get; set; }
        public bool mobile { get; set; }
        public string ip { get; set; }
        public string browser { get; set; }
    
        public virtual tbl_Usuarios tbl_Usuarios { get; set; }
    }
}