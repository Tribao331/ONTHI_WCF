<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WCF.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            text-align: center;
        }
        .auto-style3 {
            width: 421px;
        }
        .auto-style4 {
            height: 372px;
        }
        .auto-style5 {
            width: 421px;
            height: 372px;
        }
        .auto-style6 {
            text-align: left;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="Xem code" />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style4">
                        <div class="auto-style6">
                            <br />
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="MaNV" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="MaNV" HeaderText="Mã nhân viên" />
                                <asp:BoundField DataField="MaPB" HeaderText="Mã phòng ban" />
                                <asp:BoundField DataField="MaCV" HeaderText="Mã chức vụ" />
                                <asp:BoundField DataField="TenNV" HeaderText="Tên nhân viên" />
                                <asp:BoundField DataField="NgaySinh" HeaderText="Ngày sinh" DataFormatString="{0:MM/dd/yyyy}" />
                                <asp:BoundField DataField="SDT" HeaderText="Số điện thoại" />
                                <asp:BoundField DataField="Luong" HeaderText="Lương" />
                                <asp:BoundField DataField="TenPB" HeaderText="Phòng ban" />
                                <asp:BoundField DataField="TenCV" HeaderText="Chức vụ" />
                                <asp:CommandField DeleteText="Xóa" ShowDeleteButton="True" />
                                <asp:CommandField SelectText="Chọn" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                            <br />
                        </div>                     
                    </td>                 
                    <td class="auto-style5">
                        <asp:DropDownList ID="DropDownList_timnv" runat="server">
                            <asp:ListItem Value="0">Tìm mã nhân viên</asp:ListItem>
                            <asp:ListItem Value="1">Tìm tên nhân viên</asp:ListItem>
                            <asp:ListItem Value="2">Tìm mã chức vụ</asp:ListItem>
                            <asp:ListItem Value="3">Tìm tên chức vụ</asp:ListItem>
                            <asp:ListItem Value="4">Tìm mã phòng ban</asp:ListItem>
                            <asp:ListItem Value="5">Tìm tên phòng ban</asp:ListItem>
                            <asp:ListItem Value="6">Tìm số điện thoại</asp:ListItem>
                            <asp:ListItem Value="7">Tìm theo mức lương</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="TextBox1" MaxLength ="50" placeholder="Nhập thông tin tìm kiếm" runat="server"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Tìm kiếm" />
                                <br />
                        <asp:Label ID="lb_nv" runat="server"></asp:Label>
                        <asp:Label ID="lb_manv" runat="server"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtma_nv" MaxLength ="10" title="Bao gồm chữ và số độ dài tối đa 10 ký tự" placeholder="Nhập mã" runat="server"></asp:TextBox>
                                <br />
                        <asp:TextBox ID="txt_tennv" MaxLength ="50" title="Bao gồm họ và tên độ dài tối đa 50 ký tự" placeholder="Nhập tên" runat="server"></asp:TextBox>
                                <br />
                        <asp:TextBox ID="txt_ngaysinh" MaxLength ="10" pattern = "^(((0[13-9]|1[012])[-/]?(0[1-9]|[12][0-9]|30)|(0[13578]|1[02])[-/]?31|02[-/]?(0[1-9]|1[0-9]|2[0-8]))[-/]?[0-9]{4}|02[-/]?29[-/]?([0-9]{2}(([2468][048]|[02468][48])|[13579][26])|([13579][26]|[02468][048]|0[0-9]|1[0-6])00))$" title="Có định dạng mm//dd/yyyy" placeholder="Nhập ngày sinh" runat="server" TextMode="DateTime"></asp:TextBox>
                                <br />
                        <asp:TextBox ID="txt_sdt" MaxLength ="10" pattern="0([0-9]{9}||[0-9]{10})" title="Số điện thoại có định dạng 0123456789 hoặc 02943853733" placeholder="Nhập số điện thoại" runat="server"></asp:TextBox>
                                <br />
                        <asp:TextBox ID="txt_luong" min ="500" MaxLength ="1000000000" title="Gồm các chữ số" placeholder="Nhập lương" runat="server" TextMode="Number"></asp:TextBox>
                                <br />
                        <asp:DropDownList ID="DropDownList_mapb" runat="server" Width="165px" DataSourceID="SqlDataSource1" DataTextField="TenPB" DataValueField="MaPB">
                            <asp:ListItem Value="0">Chọn phòng ban</asp:ListItem>
                        </asp:DropDownList>
                                <br />
                        <asp:DropDownList ID="DropDownList_macv" runat="server" Width="165px" DataSourceID="SqlDataSource2" DataTextField="TenCV" DataValueField="MaCV">
                            <asp:ListItem Value="0">Chọn chức vụ</asp:ListItem>
                        </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:QLNVConnectionString %>" SelectCommand="SELECT * FROM [ChucVu]"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:QLNVConnectionString %>" SelectCommand="SELECT * FROM [PhongBan]"></asp:SqlDataSource>
                                <br />
                        <asp:Button ID="Button4" runat="server" Text="Thêm nhân viên" OnClick="Button4_Click" />
                                <asp:Button ID="Button5" runat="server" Text="Sửa nhân viên" OnClick="Button5_Click" />                        
                        <hr />
                        </td>
                </tr>
                
                <tr>
                    <td>
                        <div class="auto-style2">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="MaCV" OnRowDeleting="GridView2_RowDeleting" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="MaCV" HeaderText="Mã chức vụ" />
                                <asp:BoundField DataField="TenCV" HeaderText="Tên chức vụ" />
                                <asp:CommandField DeleteText="Xóa" ShowDeleteButton="True" />
                                <asp:CommandField SelectText="Chọn" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        </div>
                        <br />
                    </td>
                    <td class="auto-style3">
                        <asp:DropDownList ID="DropDownList_timcv" runat="server">
                            <asp:ListItem Value="0">Tìm mã chức vụ</asp:ListItem>
                            <asp:ListItem Value="1">Tìm tên chức vụ</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="TextBox2" placeholder="Nhập thông tin tìm kiếm" runat="server"></asp:TextBox>
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Tìm kiếm" />
                                <br />
                        <asp:Label ID="lb_cv" runat="server"></asp:Label>
                        <asp:Label ID="lb_macv" runat="server"></asp:Label>
                        <br />
                        <asp:TextBox ID="txt_macv" MaxLength ="10" title="Bao gồm chữ và số chứa tối đa 10 ký tự" placeholder="Nhập mã" runat="server"></asp:TextBox>
                                <br />
                        <asp:TextBox ID="txt_tencv" MaxLength ="50" title="Chứa tối đa 50 ký tự" placeholder="Nhập tên" runat="server"></asp:TextBox>
                                <br />
                        <asp:Button ID="Button6" runat="server" Text="Thêm chức vụ" OnClick="Button6_Click" />
                                <asp:Button ID="Button7" runat="server" Text="Sửa chức vụ" OnClick="Button7_Click" />&nbsp;<hr />
                    </td>
                </tr>                
                <tr>
                    <td class="auto-style2">
                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="MaPB" OnRowDeleting="GridView3_RowDeleting" OnSelectedIndexChanged="GridView3_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="MaPB" HeaderText="Mã phòng ban" />
                                <asp:BoundField DataField="TenPB" HeaderText="Tên phòng ban" />
                                <asp:CommandField DeleteText="Xóa" ShowDeleteButton="True" />
                                <asp:CommandField SelectText="Chọn" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                    </td>                   
                    <td class="auto-style3">
                        <asp:DropDownList ID="DropDownList_timpb" runat="server">
                            <asp:ListItem Value="0">Tìm mã phòng</asp:ListItem>
                            <asp:ListItem Value="1">Tìm tên phòng</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox ID="TextBox3" placeholder="Nhập thông tin tìm kiếm" runat="server"></asp:TextBox>
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Tìm kiếm" />
                                <br />
                        <asp:Label ID="lb_pb" runat="server"></asp:Label>
                        <asp:Label ID="lb_mapb" runat="server"></asp:Label>
                        <br />
                        <asp:TextBox ID="txt_mapb" MaxLength ="10" title="Bao gồm chữ và số chứa tối đa 10 ký tự" placeholder="Nhập mã" runat="server"></asp:TextBox>
                                <br />
                        <asp:TextBox ID="txt_tenpb" MaxLength ="10" title="Chứa tối đa 50 ký tự" placeholder="Nhập tên" runat="server"></asp:TextBox>
                                <br />
                        <asp:Button ID="Button8" runat="server" Text="Thêm phòng ban" OnClick="Button8_Click" />
                                <asp:Button ID="Button9" runat="server" Text="Sửa phòng ban" OnClick="Button9_Click" />
                        <hr />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
