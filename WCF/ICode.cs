using System;
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
        //hiển thị nhân viên
        [OperationContract]
        List<HTNhanvien> HTNhanvien();
        //hiển thị chức vụ
        [OperationContract]
        List<HTChucVu> HTChucVu();
        // xóa chức vụ
        [OperationContract]
        bool XoaChucvu(String MaCV);
    }
}
