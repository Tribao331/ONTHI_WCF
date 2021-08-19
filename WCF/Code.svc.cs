using Nest;
using Rhino.Mocks.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Code" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Code.svc or Code.svc.cs at the Solution Explorer and start debugging.
    public class Code : ICode
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        // hiển thị thông tin nhân viên
        public List<HTNhanvien> HTNhanvien()
        {
            return (
                from a in db.NhanViens
                from b in db.ChucVus
                from c in db.PhongBans
                where a.MaCV == b.MaCV
                where a.MaPB == c.MaPB
                select new HTNhanvien
                {
                   MaNV = a.MaNV,
                   TenNV = a.TenNV,
                   NgaySinh = a.NgaySinh,
                   SDT = a.SDT,
                   Luong = a.Luong,
                   TenCV = b.TenCV,
                   TenPB = c.TenPB

                }
                 ).ToList();
        }
        // tìm kiếm nhân viên
        public List<TKNhanvien> TKNhanvien(string TenNV)
        {
            return (
                from a in db.NhanViens
                from b in db.ChucVus
                from c in db.PhongBans
                where a.MaCV == b.MaCV
                where a.MaPB == c.MaPB
                where a.TenNV.Contains(TenNV)
                select new TKNhanvien
                {
                    MaNV = a.MaNV,
                    TenNV = a.TenNV,
                    NgaySinh = a.NgaySinh,
                    SDT = a.SDT,
                    Luong = a.Luong,
                    TenCV = b.TenCV,
                    TenPB = c.TenPB

                }
                 ).ToList();
        }      
        // hiển thị thông tin chức vụ
        public List<HTChucVu> HTChucVu()
        {
            return (
                from a in db.ChucVus
                select new HTChucVu
                {
                    MaCV = a.MaCV,
                    TenCV = a.TenCV
                }
                 ).ToList();
        }
        // xóa chức vụ
        public bool XoaChucvu(String MaCV)
        {
            ChucVu cv = new ChucVu();
            cv = db.ChucVus.Single(x => x.MaCV == MaCV);
            try
            {
                db.ChucVus.DeleteOnSubmit(cv);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
