﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KClinic2._1.Desktop
{
    public partial class K_Permission_Report
    {
        [Key]
        public int Permission_Report_Id { get; set; }
        public int? User_Id { get; set; }
        public int? Report_Id { get; set; }

        [ForeignKey("Report_Id")]
        [InverseProperty("K_Permission_Report")]
        public virtual ProcedureBaoCao Report { get; set; }
        [ForeignKey("User_Id")]
        [InverseProperty("K_Permission_Report")]
        public virtual K_Users User { get; set; }
    }
}