using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WCF
{
    public partial class Default : System.Web.UI.Page
    {
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
    }
}