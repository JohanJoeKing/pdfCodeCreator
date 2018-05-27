<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<style>
	.a td{font-family:微软雅黑;color:#003399;font-size:16px}
</style>
<body>
    <form id="form1" runat="server">
    <div>
      <p align="center">单件操作</p>
      <table width="400" border="1" align="center" cellspacing="0" bordercolor="#003399" class="a">
        <tr>
          <td width="200"><div align="center">设备编号</div></td>
          <td width="200">
              <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>          </td>
        </tr>
        <tr>
          <td><div align="center">设备名称</div></td>
          <td>
              <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>          </td>
        </tr>
        <tr>
          <td colspan="2"><div align="center">
              <asp:Image ID="Image1" runat="server" ImageUrl="~/image/temp.png" /></div></td>
        </tr>
        
        <tr>
          <td><asp:Button ID="Button1" runat="server" Text="生成条码" OnClick="buttonCode_Click"/></td>
          <td><asp:Button ID="Button2" runat="server" Text="转为PDF文件" OnClick="buttonPdf_Click"/></td>
        </tr>
      </table>
      <p align="center">批量操作</p>
      <table width="400" border="1" align="center" cellspacing="0" bordercolor="#003399" class="a">
        <tr>
          <td width="200"><div align="center">设备编号前缀（不变部分）</div></td>
          <td width="200">
              <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>          </td>
        </tr>
        <tr>
          <td><div align="center">设备编号后缀首位</div></td>
          <td>
              <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>          </td>
        </tr>
        <tr>
          <td><div align="center">数量</div></td>
          <td>
              <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>          </td>
        </tr>
        <tr>
          <td colspan="2"><asp:Button ID="Button3" runat="server" Text="开始生成" OnClick="batchOperate_Click"/></td>
        </tr>
        <tr>
          <td colspan="2">
              <asp:Label ID="Label1" runat="server" Text="运行状态：停止"></asp:Label>
          </td>
        </tr>
      </table>
      </div>
    </form>
</body>
</html>
