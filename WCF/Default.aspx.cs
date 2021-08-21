using System;
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
            this.lb_manv.Text = HttpUtility.HtmlDecode(row.Cells[0].Text);
            this.txt_tennv.Text = HttpUtility.HtmlDecode(row.Cells[3].Text);
            this.txt_ngaysinh.Text = HttpUtility.HtmlDecode(row.Cells[4].Text);
            this.txt_sdt.Text = HttpUtility.HtmlDecode(row.Cells[5].Text);
            this.txt_luong.Text = HttpUtility.HtmlDecode(row.Cells[6].Text);
            this.DropDownList_mapb.Text = HttpUtility.HtmlDecode(row.Cells[1].Text);
            this.DropDownList_macv.Text = HttpUtility.HtmlDecode(row.Cells[2].Text);
            lb_nv.Text = "Mã nhân viên bạn vừa chọn là:";
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
            GridViewRow row = GridView2.SelectedRow;
            this.lb_macv.Text = HttpUtility.HtmlDecode(row.Cells[0].Text);        
            this.txt_tencv.Text = HttpUtility.HtmlDecode(row.Cells[1].Text);      
            lb_cv.Text = "Mã chức vụ bạn vừa chọn là:";
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
            else if (DropDownList_timnv.Text == "")
            {
                Response.Write("<script> alert ('Vui lòng chọn phương thức tìm kiếm!');  window.location ='default.aspx'</script>");
            }
            else if (DropDownList_timnv.Text == "0")
            {
                GridView1.DataSource = cd.TKNhanvienMA(TextBox1.Text);
                GridView1.DataBind();
            }
            else if (DropDownList_timnv.Text == "1")
            {
                GridView1.DataSource = cd.TKNhanvien(TextBox1.Text);
                GridView1.DataBind();
            }
            else if (DropDownList_timnv.Text == "2")
            {
                GridView1.DataSource = cd.TKNhanvienMACV(TextBox1.Text);
                GridView1.DataBind();
            }
            else if (DropDownList_timnv.Text == "3")
            {
                GridView1.DataSource = cd.TKNhanvienCV(TextBox1.Text);
                GridView1.DataBind();
            }
            else if (DropDownList_timnv.Text == "4")
            {
                GridView1.DataSource = cd.TKNhanvienMAPB(TextBox1.Text);
                GridView1.DataBind();
            }
            else if (DropDownList_timnv.Text == "5")
            {
                GridView1.DataSource = cd.TKNhanvienPB(TextBox1.Text);
                GridView1.DataBind();
            }
            else if (DropDownList_timnv.Text == "6")
            {
                GridView1.DataSource = cd.TKNhanvienSDT(TextBox1.Text);
                GridView1.DataBind();
            }
            else if (DropDownList_timnv.Text == "7")
            {
                GridView1.DataSource = cd.TKNhanvienLUONG(float.Parse(TextBox1.Text));
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
            else if (DropDownList_timcv.Text =="0")
            {
                GridView2.DataSource = cd.TKChucvuMA(TextBox2.Text);
                GridView2.DataBind();
            }
            else if (DropDownList_timcv.Text == "1")
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
            else if (DropDownList_timpb.Text == "0")
            {
                GridView3.DataSource = cd.TKPhongbanMA(TextBox3.Text);
                GridView3.DataBind();
            }
            else if (DropDownList_timpb.Text == "1")
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
            GridViewRow row = GridView3.SelectedRow;
            this.lb_mapb.Text = HttpUtility.HtmlDecode(row.Cells[0].Text);
            this.txt_tenpb.Text = HttpUtility.HtmlDecode(row.Cells[1].Text);
            lb_pb.Text = "Mã phòng ban bạn vừa chọn là:";
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
            else if (txt_ngaysinh.Text == "")
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
               
                Response.Write("<script> alert ('Mã nhân viên đã tồn tại!'); </script>");
                hienthi();
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {           
            if (txt_macv.Text == "")
            {
                Response.Write("<script> alert ('Vui lòng nhập mã chức vụ!'); </script>");
                hienthi();
            }
            else if (txt_tencv.Text == "")
            {
                Response.Write("<script> alert ('Vui lòng nhập tên chức vụ!'); </script>");
                hienthi();
            }          
            else if (cd.Themchucvu(txt_macv.Text, txt_tencv.Text))
            {
                Response.Write("<script> alert ('Thêm chức vụ thành công!'); window.location ='default.aspx' </script>");
            }
            else
            {

                Response.Write("<script> alert ('Mã chức vụ đã tồn tại!'); </script>");
                hienthi();
            }
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            if (txt_mapb.Text == "")
            {
                Response.Write("<script> alert ('Vui lòng nhập mã phòng ban!'); </script>");
                hienthi();
            }
            else if (txt_tenpb.Text == "")
            {
                Response.Write("<script> alert ('Vui lòng nhập tên phòng ban!'); </script>");
                hienthi();
            }
            else if (cd.Themphongban(txt_mapb.Text, txt_tenpb.Text))
            {
                Response.Write("<script> alert ('Thêm phòng ban thành công!'); window.location ='default.aspx' </script>");
            }
            else
            {

                Response.Write("<script> alert ('Mã phòng ban đã tồn tại!'); </script>");
                hienthi();
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (lb_manv.Text == "")
            {
                Response.Write("<script> alert ('Vui lòng chọn nhân viên muốn sửa!'); </script>");
                hienthi();
            }
            else if (txt_tennv.Text == "")
            {
                Response.Write("<script> alert ('Vui lòng nhập tên nhân viên!'); </script>");
                hienthi();
            }
            else if (txt_ngaysinh.Text == "")
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
            else if (cd.Suanhanvien(lb_manv.Text, txt_tennv.Text, DateTime.Parse(txt_ngaysinh.Text), txt_sdt.Text, float.Parse(txt_luong.Text), DropDownList_mapb.Text, DropDownList_macv.Text))
            {
                Response.Write("<script> alert ('Sửa nhân viên thành công!'); window.location ='default.aspx' </script>");
            }
            else
            {

                Response.Write("<script> alert ('Xuất hiện lỗi rồi!'); </script>");
                hienthi();
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            if (lb_macv.Text == "")
            {
                Response.Write("<script> alert ('Vui lòng chọn chức vụ muốn sửa!'); </script>");
                hienthi();
            }
            else if (txt_tencv.Text == "")
            {
                Response.Write("<script> alert ('Vui lòng nhập tên chức vụ!'); </script>");
                hienthi();
            }
            else if (cd.Suachucvu(lb_macv.Text, txt_tencv.Text))
            {
                Response.Write("<script> alert ('Sửa chức vụ thành công!'); window.location ='default.aspx' </script>");
            }
            else
            {

                Response.Write("<script> alert ('Xuất hiện lỗi rồi!'); </script>");
                hienthi();
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            if (lb_mapb.Text == "")
            {
                Response.Write("<script> alert ('Vui lòng chọn phòng ban muốn sửa!'); </script>");
                hienthi();
            }
            else if (txt_tenpb.Text == "")
            {
                Response.Write("<script> alert ('Vui lòng nhập tên phòng ban!'); </script>");
                hienthi();
            }
            else if (cd.Suaphongban(lb_mapb.Text, txt_tenpb.Text))
            {
                Response.Write("<script> alert ('Sửa phòng ban thành công!'); window.location ='default.aspx' </script>");
            }
            else
            {

                Response.Write("<script> alert ('Xuất hiện lỗi rồi!'); </script>");
                hienthi();
            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Response.Write("<script> window.location ='http://tribao.somee.com/' </script>");
        }
    }
}