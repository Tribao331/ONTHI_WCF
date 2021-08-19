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
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string a = GridView2.DataKeys[e.RowIndex].Values["MaCV"].ToString();
            if (cd.XoaChucvu(a))
            {                 
                Response.Write("<script> alert ('Đã xóa loại !'); window.location ='default.aspx' </script>");
            }
            else
            {
                Response.Write("<script> alert ('Đã tồn tại liên kết !'); window.location ='default.aspx' </script>");
            }
            
        }
    }
}