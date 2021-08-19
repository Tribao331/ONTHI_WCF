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
        // xóa nhân viên
        [OperationContract]
        bool XoaNhanvien(String MaNV);

        // Code chức vụ
        //hiển thị chức vụ
        [OperationContract]
        List<HTChucVu> HTChucVu();
        // tìm chức vụ
        [OperationContract]
        List<TKChucvu> TKChucvu(string TenCV);
        // xóa chức vụ
        [OperationContract]
        bool XoaChucvu(String MaCV);

        // Code phòng ban
        //hiển thị phòng ban
        [OperationContract]
        List<HTPhongban> HTPhongban();
        // tìm phòng ban
        [OperationContract]
        List<TKPhongban> TKPhongban(string MaPB);
        // xóa phòng ban
        [OperationContract]
        bool XoaPhongBan(String MaPB);
    }
}
