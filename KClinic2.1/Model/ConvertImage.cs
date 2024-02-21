//using Aspose.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClinic2._1.Model
{
    class ConvertImage
    {
        //public static string Imagecv(string _DuongDan, string _HinhAnh, string _HinhAnhChuaSua, int _DoSang, int _DoNet)
        //{
        //    using (Image image = Image.Load(_DuongDan + _HinhAnhChuaSua + ".jpg"))
        //    {
        //        // Cast to raster image
        //        RasterImage rasterImage = (RasterImage)image;

        //        // Cache RasterImage for better performance
        //        if (!rasterImage.IsCached)
        //        {
        //            rasterImage.CacheData();
        //        }

        //        // Adjust the brightness
        //        rasterImage.AdjustBrightness(_DoSang);
        //        rasterImage.AdjustContrast(_DoNet);
        //        // Save image
        //        image.Save(_DuongDan + _HinhAnh + ".jpg");
        //        return null;
        //    }
        //}
        //public static string Imagecut(string _DuongDan, string _HinhAnh, string _HinhAnhChuaSua, int leftShift, int rightShift, int topShift, int bottomShift)
        //{
        //    // Tải hình ảnh được cắt.
        //    using (RasterImage rasterImage = (RasterImage)Image.Load(_DuongDan + _HinhAnhChuaSua + ".jpg"))
        //    {
        //        // Trước khi cắt, hình ảnh nên được lưu vào bộ nhớ đệm để có hiệu suất tốt hơn.
        //        if (!rasterImage.IsCached)
        //        {
        //            rasterImage.CacheData();
        //        }

        //        // Xác định giá trị dịch chuyển cho cả bốn mặt.
        //        //int leftShift = 10;
        //        //int rightShift = 10;
        //        //int topShift = 50;
        //        //int bottomShift = 50;

        //        // Dựa trên các giá trị dịch chuyển, hãy áp dụng cắt trên hình ảnh. Phương pháp xén sẽ dịch chuyển giới hạn hình ảnh về phía trung tâm của hình ảnh.
        //        rasterImage.Crop(leftShift, rightShift, topShift, bottomShift);

        //        // Lưu hình ảnh đã cắt.
        //        rasterImage.Save(_DuongDan + _HinhAnh + ".jpg");
        //        return null;
        //    }
        //}
    }
}
