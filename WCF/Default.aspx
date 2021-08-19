<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WCF.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="MaNV" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="MaNV" HeaderText="Mã nhân viên" />
                                <asp:BoundField DataField="TenNV" HeaderText="Tên nhân viên" />
                                <asp:BoundField DataField="NgaySinh" HeaderText="Ngày sinh" />
                                <asp:BoundField DataField="SDT" HeaderText="Số điện thoại" />
                                <asp:BoundField DataField="Luong" HeaderText="Lương" />
                                <asp:BoundField DataField="TenPB" HeaderText="Tên phòng ban" />
                                <asp:BoundField DataField="TenCV" HeaderText="Chức vụ" />
                                <asp:CommandField DeleteText="Xóa" ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Tìm kiếm" />
                        </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="MaCV" OnRowDeleting="GridView2_RowDeleting" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="MaCV" HeaderText="Mã chức vụ" />
                                <asp:BoundField DataField="TenCV" HeaderText="Tên chức vụ" />
                                <asp:CommandField DeleteText="Xóa" ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Tìm kiếm" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GridView3" runat="server">
                        </asp:GridView>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Tìm kiếm" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
