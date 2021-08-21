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
                   TenPB = c.TenPB,
                   MaCV = a.MaCV,
                   MaPB = a.MaPB

                }
                 ).ToList();
        }
        // xóa nhân viên
        public bool XoaNhanvien(String MaNV)
        {
            NhanVien nv = new NhanVien();
            nv = db.NhanViens.Single(x => x.MaNV == MaNV);
            try
            {
                db.NhanViens.DeleteOnSubmit(nv);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
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
                    TenPB = c.TenPB,
                    MaCV = a.MaCV,
                    MaPB = a.MaPB

                }
                 ).ToList();
        }
        // thêm nhân viên
        public bool Themnhanvien(string MaNV, string TenNV, DateTime NgaySinh, string SDT, float Luong, string MaPB, string MaCV)
        {
            NhanVien nv = new NhanVien();
            nv.MaNV = MaNV;
            nv.TenNV = TenNV;
            nv.NgaySinh = NgaySinh;
            nv.SDT = SDT;
            nv.Luong = Luong;
            nv.MaPB = MaPB;
            nv.MaCV = MaCV;
            try
            {
                db.NhanViens.InsertOnSubmit(nv);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // Sửa nhân viên
        public bool Suanhanvien(string MaNV, string TenNV, DateTime NgaySinh, string SDT, float Luong, string MaPB, string MaCV)
        {
            NhanVien nv = new NhanVien();
            nv = db.NhanViens.Single(x => x.MaNV == MaNV);
            nv.MaNV = MaNV;
            nv.TenNV = TenNV;
            nv.NgaySinh = NgaySinh;
            nv.SDT = SDT;
            nv.MaPB = MaPB;
            nv.MaCV = MaCV;
            try
            {             
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
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
        // tìm kiếm chức vụ
        public List<TKChucvu> TKChucvu(string TenCV)
        {
            return (
               
                from a in db.ChucVus
                where a.TenCV.Contains(TenCV)
                select new TKChucvu
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
        // thêm chức vụ
        public bool Themchucvu(string MaCV, string TenCV)
        {
            ChucVu cv = new ChucVu();
            cv.MaCV = MaCV;
            cv.TenCV = TenCV;
            try
            {
                db.ChucVus.InsertOnSubmit(cv);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // sửa chức vụ
        public bool Suachucvu(string MaCV, string TenCV)
        {
            ChucVu cv = new ChucVu();
            cv = db.ChucVus.Single(x => x.MaCV == MaCV);
            cv.MaCV = MaCV;
            cv.TenCV = TenCV;
            try
            {               
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // hiển thị thông tin phòng ban
        public List<HTPhongban> HTPhongban()
        {
            return (
                from a in db.PhongBans
                select new HTPhongban
                {
                    MaPB = a.MaPB,
                    TenPB = a.TenPB
                }
                 ).ToList();
        }
        // tìm kiếm chức vụ
        public List<TKPhongban> TKPhongban(string MaPB)
        {
            return (

                from a in db.PhongBans
                where a.TenPB.Contains(MaPB)
                select new TKPhongban
                {
                  MaPB = a.MaPB,
                  TenPB = a.TenPB
                }
                 ).ToList();
        }
        // xóa phòng ban
        public bool XoaPhongBan(string MaPB)
        {
            PhongBan pb = new PhongBan();
            pb = db.PhongBans.Single(x => x.MaPB == MaPB);
            try
            {
                db.PhongBans.DeleteOnSubmit(pb);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // thêm phòng ban
        public bool Themphongban(string MaPB, string TenPB)
        {
            PhongBan pb = new PhongBan();
            pb.MaPB = MaPB;
            pb.TenPB = TenPB;
            try
            {
                db.PhongBans.InsertOnSubmit(pb);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // sửa phòng ban
        public bool Suaphongban(string MaPB, string TenPB)
        {
            PhongBan pb = new PhongBan();
            pb = db.PhongBans.Single(x => x.MaPB == MaPB);
            pb.MaPB = MaPB;
            pb.TenPB = TenPB;
            try
            {               
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
