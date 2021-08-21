using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICode" in both code and config file together.
    [ServiceContract]
    public interface ICode
    {
        //Code nhân viên
        //hiển thị nhân viên
        [OperationContract]
        List<HTNhanvien> HTNhanvien();
        // tìm nhân viên
        [OperationContract]
        List<TKNhanvien> TKNhanvien(string TenNV);
        // tìm nhân viên theo mã
        [OperationContract]
        List<TKNhanvienMA> TKNhanvienMA(string MaNV);
        // tìm nhân viên theo mã chức vụ
        [OperationContract]
        List<TKNhanvienMACV> TKNhanvienMACV(string MaCV);
        // tìm nhân viên theo tên chức vụ
        [OperationContract]
        List<TKNhanvienCV> TKNhanvienCV(string TenCV);
        // tìm nhân viên theo mã phòng
        [OperationContract]
        List<TKNhanvienMAPB> TKNhanvienMAPB(string MaPB);
        // tìm nhân viên theo tên phòng
        [OperationContract]
        List<TKNhanvienPB> TKNhanvienPB(string TenPB);
        // tìm nhân viên theo số điện thoại
        [OperationContract]
        List<TKNhanvienSDT> TKNhanvienSDT(string SDT);
        // tìm nhân viên theo lương
        [OperationContract]
        List<TKNhanvienLUONG> TKNhanvienLUONG(float Luong);
        // xóa nhân viên
        [OperationContract]
        bool XoaNhanvien(String MaNV);
        //thêm nhân viên
        [OperationContract]
        bool Themnhanvien(string MaNV, string TenNV, DateTime NgaySinh, string SDT, float Luong, string MaPB, string MaCV);
        //sửa nhân viên
        [OperationContract]
        bool Suanhanvien(string MaNV, string TenNV, DateTime NgaySinh, string SDT, float Luong, string MaPB, string MaCV);

        // Code chức vụ
        //hiển thị chức vụ
        [OperationContract]
        List<HTChucVu> HTChucVu();
        // tìm chức vụ
        [OperationContract]
        List<TKChucvu> TKChucvu(string TenCV);
        // tìm chức vụ theo mã
        [OperationContract]
        List<TKChucvuMA> TKChucvuMA(string MaCV);
        // xóa chức vụ
        [OperationContract]
        bool XoaChucvu(string MaCV);
        // thêm chức vụ
        [OperationContract]
        bool Themchucvu(string MaCV, string TenCV);
        // thêm chức vụ
        [OperationContract]
        bool Suachucvu(string MaCV, string TenCV);

        // Code phòng ban
        //hiển thị phòng ban
        [OperationContract]
        List<HTPhongban> HTPhongban();
        // tìm phòng ban
        [OperationContract]
        List<TKPhongban> TKPhongban(string TenPB);
        // tìm phòng ban theo mã
        [OperationContract]
        List<TKPhongbanMA> TKPhongbanMA(string MaPB);
        // xóa phòng ban
        [OperationContract]
        bool XoaPhongBan(String MaPB);
        // thêm phòng ban
        [OperationContract]
        bool Themphongban(string MaPB, string TenPB);
        // sửa phòng ban
        [OperationContract]
        bool Suaphongban(string MaPB, string TenPB);
    }
}
