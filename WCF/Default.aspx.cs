﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WCF
{
    public partial class Default : System.Web.UI.Page
    {
        DataClasses1DataContext db = new DataClasses1DataContext();       
        Code cd = new Code();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hienthi();
            }
        }
        public void hienthi()
        {
            GridView1.DataSource = cd.HTNhanvien();
            GridView1.DataBind();
            GridView2.DataSource = cd.HTChucVu();
            GridView2.DataBind();
            GridView3.DataSource = cd.HTPhongban();
            GridView3.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            GridViewRow row = GridView1.SelectedRow;
            this.txtma_nv.Text = HttpUtility.HtmlDecode(row.Cells[0].Text);
            this.txt_tennv.Text = HttpUtility.HtmlDecode(row.Cells[3].Text);
            this.txt_ngaysinh.Text = HttpUtility.HtmlDecode(row.Cells[4].Text);
            this.txt_sdt.Text = HttpUtility.HtmlDecode(row.Cells[5].Text);
            this.txt_luong.Text = HttpUtility.HtmlDecode(row.Cells[6].Text);
            this.DropDownList_mapb.Text = HttpUtility.HtmlDecode(row.Cells[1].Text);
            this.DropDownList_macv.Text = HttpUtility.HtmlDecode(row.Cells[2].Text);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string a = GridView1.DataKeys[e.RowIndex].Values["MaNV"].ToString();
            if (cd.XoaNhanvien(a))
            {
                Response.Write("<script> alert ('Đã xóa nhân viên !'); window.location ='default.aspx' </script>");
            }
            else
            {
                Response.Write("<script> alert ('Đã tồn tại liên kết !'); window.location ='default.aspx' </script>");
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        { string a = GridView2.DataKeys[e.RowIndex].Values["MaCV"].ToString();
            if (cd.XoaChucvu(a))
            {                 
                Response.Write("<script> alert ('Đã xóa loại !'); window.location ='default.aspx' </script>");
            }
            else
            {
                Response.Write("<script> alert ('Đã tồn tại liên kết !'); window.location ='default.aspx' </script>");
            }
           
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                Response.Write("<script> alert ('Vui lòng nhập thông tin vào khung tìm kiếm!');  window.location ='default.aspx'</script>");

            }
            else if (TextBox1.Text != "")
            {
                GridView1.DataSource = cd.TKNhanvien(TextBox1.Text);
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script> alert ('Chương trình đang lỗi, vui lòng liên hệ chủ Website để khắc phục!');  window.location ='default.aspx'</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text == "")
            {
                Response.Write("<script> alert ('Vui lòng nhập thông tin vào khung tìm kiếm!');  window.location ='default.aspx'</script>");

            }
            else if (TextBox2.Text != "")
            {
                GridView2.DataSource = cd.TKChucvu(TextBox2.Text);
                GridView2.DataBind();
            }
            else
            {
                Response.Write("<script> alert ('Chương trình đang lỗi, vui lòng liên hệ chủ Website để khắc phục!');  window.location ='default.aspx'</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text == "")
            {
                Response.Write("<script> alert ('Vui lòng nhập thông tin vào khung tìm kiếm!');  window.location ='default.aspx'</script>");

            }
            else if (TextBox3.Text != "")
            {
                GridView3.DataSource = cd.TKPhongban(TextBox3.Text);
                GridView3.DataBind();
            }
            else
            {
                Response.Write("<script> alert ('Chương trình đang lỗi, vui lòng liên hệ chủ Website để khắc phục!');  window.location ='default.aspx'</script>");
            }
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string a = GridView3.DataKeys[e.RowIndex].Values["MaPB"].ToString();
            if (cd.XoaPhongBan(a))
            {
                Response.Write("<script> alert ('Đã xóa phòng ban !'); window.location ='default.aspx' </script>");
            }
            else
            {
                Response.Write("<script> alert ('Đã tồn tại liên kết !'); window.location ='default.aspx' </script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
       
            if (txtma_nv.Text == "" )
            {
                Response.Write("<script> alert ('Vui lòng nhập mã nhân viên!'); </script>");
                hienthi();
            }          
            else if (txt_tennv.Text == "")
            {
                Response.Write("<script> alert ('Vui lòng nhập tên nhân viên!'); </script>");
                hienthi();
            }
            else if (txt_ngaysinh.Text != "")
            {
                Response.Write("<script> alert ('Vui lòng nhập ngày sinh nhân viên!'); </script>");
                hienthi();
            }
            else if (txt_sdt.Text == "")
            {
                Response.Write("<script> alert ('Vui lòng nhập số điện thoại nhân viên!'); </script>");
                hienthi();
            }
            else if (txt_luong.Text == "")
            {
                Response.Write("<script> alert ('Vui lòng nhập lương nhân viên!'); </script>");
                hienthi();
            }
            else if (DropDownList_macv.Text == "0")
            {
                Response.Write("<script> alert ('Vui lòng chọn phòng ban!'); </script>");
                hienthi();
            }
            else if (DropDownList_macv.Text == "")
            {
                Response.Write("<script> alert ('Vui lòng chọn chức vụ!'); </script>");
                hienthi();
            }
            else if (cd.Themnhanvien(txtma_nv.Text, txt_tennv.Text, DateTime.Parse(txt_ngaysinh.Text), txt_sdt.Text, float.Parse(txt_luong.Text), DropDownList_mapb.Text, DropDownList_macv.Text))
            {
                Response.Write("<script> alert ('Thêm nhân viên thành công!'); window.location ='default.aspx' </script>");
            }
            else 
            {
               
                Response.Write("<script> alert ('Mã đã tồn tại!'); </script>");
                hienthi();
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            
        }

        protected void Button8_Click(object sender, EventArgs e)
        {

        }
    }
}