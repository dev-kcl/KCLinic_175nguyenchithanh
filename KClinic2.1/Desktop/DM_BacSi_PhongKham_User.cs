using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KClinic2._1.Desktop
{
    public partial class DM_BacSi_PhongKham_User
    {
        [Key]
        public int MapKhamBenh_Id { get; set; }
        public int? User_Id { get; set; }
        public int? BacSi_Id { get; set; }
        public int? PhongBan_Id { get; set; }
        public int? Huy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }
        public int? NguoiTao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        public int? NguoiCapNhat { get; set; }

        [ForeignKey("BacSi_Id")]
        [InverseProperty("DM_BacSi_PhongKham_User")]
        public virtual K_BacSi BacSi { get; set; }
        [ForeignKey("PhongBan_Id")]
        [InverseProperty("DM_BacSi_PhongKham_User")]
        public virtual K_PhongBan PhongBan { get; set; }
        [ForeignKey("User_Id")]
        [InverseProperty("DM_BacSi_PhongKham_User")]
        public virtual K_Users User { get; set; }
    }
}