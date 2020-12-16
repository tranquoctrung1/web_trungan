<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            font-family:Segoe UI;
            width: 100%;
            table-layout:fixed;
        }
        .style2
        {
            color: #FFFFFF;
            font-weight: bold;
            background-color:Orange;
            text-align:center;
        }
        .style3
        {
            height: 11px;
            color: #FFFFFF;
            background-color:#25A0DA;
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1" border="0" cellpadding="3" cellspacing="0">
            <tr>
                <td class="style2">
                    Kênh</td>
                <td class="style2">
                    Mô tả</td>
                <td class="style2">
                    Ngày giờ</td>
                <td class="style2">
                    Giá trị</td>
                <td class="style2">
                    Đơn vị</td>
            </tr>
            <tr>
                <td class="style3">
                    1001_01</td>
                <td class="style3">
                    Kênh áp lực</td>
                <td class="style3">
                    11/11/2011 12:00 AM</td>
                <td class="style3">
                    12</td>
                <td class="style3">
                    m3/h</td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
