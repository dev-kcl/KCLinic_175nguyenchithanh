﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KClinic2._1.Desktop
{
    public partial class K_Permission
    {
        [Key]
        public int Permission_Id { get; set; }
        public int? User_Id { get; set; }
        public int? Menu_Id { get; set; }

        [ForeignKey("Menu_Id")]
        [InverseProperty("K_Permission")]
        public virtual K_Menu Menu { get; set; }
        [ForeignKey("User_Id")]
        [InverseProperty("K_Permission")]
        public virtual K_Users User { get; set; }
    }
}