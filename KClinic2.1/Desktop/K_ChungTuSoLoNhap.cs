using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KClinic2._1.Desktop
{
    public partial class K_ChungTuSoLoNhap
    {
        public K_ChungTuSoLoNhap()
        {
            K_Action_ChungTu = new HashSet<K_Action_ChungTu>();
            K_ChungTuChiTiet = new HashSet<K_ChungTuChiTiet>();
            K_DuocTonKho = new HashSet<K_DuocTonKho>();
            K_TiemChung = new HashSet<K_TiemChung>();
        }

        [Key]
        public int SoLoNhap_Id { get; set; }
        [Required]
        [StringLength(15)]
        public string SoLoNhap { get; set; }
        public int Duoc_Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NgayNhap { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? HanSuDung { get; set; }
        public int? NguonDuoc_Id { get; set; }
        [Column(TypeName = "numeric")]
        [DecimalPrecision(18,2)]
        public decimal? DonGiaMua { get; set; }
        [Column(TypeName = "numeric")]
        [DecimalPrecision(18,2)]
        public decimal? DonGiaVon { get; set; }
        [StringLength(3)]
        public string TienTe_Id { get; set; }
        [Column(TypeName = "numeric")]
        [DecimalPrecision(9,2)]
        public decimal? TyGia { get; set; }
        public short? Thang { get; set; }
        public short? Nam { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }
        public int? NguoiTao_Id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NgayCapNhat { get; set; }
        public int? NguoiCapNhat_Id { get; set; }
        [StringLength(20)]
        public string SoKiemSoat { get; set; }
        [StringLength(20)]
        public string SoVisa { get; set; }
        public int? NguonHang_Id { get; set; }
        public int? Huy { get; set; }

        [ForeignKey("Duoc_Id")]
        [InverseProperty("K_ChungTuSoLoNhap")]
        public virtual K_DM_Duoc Duoc { get; set; }
        [ForeignKey("NguonDuoc_Id")]
        [InverseProperty("K_ChungTuSoLoNhap")]
        public virtual K_Dictionary NguonDuoc { get; set; }
        [InverseProperty("SoLoNhap")]
        public virtual ICollection<K_Action_ChungTu> K_Action_ChungTu { get; set; }
        [InverseProperty("SoLoNhap")]
        public virtual ICollection<K_ChungTuChiTiet> K_ChungTuChiTiet { get; set; }
        [InverseProperty("SoLoNhap")]
        public virtual ICollection<K_DuocTonKho> K_DuocTonKho { get; set; }
        [InverseProperty("SoLoNhap")]
        public virtual ICollection<K_TiemChung> K_TiemChung { get; set; }
    }
}