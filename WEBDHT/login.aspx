<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Cấp Nước Trung An
    </title>
    <%--<script type="text/javascript" language="javascript">
        var scrl = "Tổng công ty Cấp nước Sài Gòn - Xí nghiệp Truyền dẫn Nước sạch. ";
        function scrlsts() {
            scrl = scrl.substring(1, scrl.length) + scrl.substring(0, 1);
            document.title = scrl;
            setTimeout("scrlsts()", 300);
        }
    </script>--%>
    <style type="text/css">
        html,body{
        height:100%;}
        .style1
        {
            width: 100%;
        }
        .hl{
        color:White;
        background-color:#007FFF;
        opacity:0.9;
        }
        form, .container
        {
            height: 100%
        }
        .flex 
        {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100%
        }
        .validate-form 
        {
            background: white;

            padding: 3rem 5rem;

            border-radius: 10px;
            box-shadow: 0 0 5px 0 rgba(0,0,0, .2);
        }
        .logo 
        {
            width: 100px;
            display: block;
            margin: 0 auto
        }
        .login100-form-btn 
        {
            background: #0984e3;
        }
    </style>
    <link href="css/login-main.css" rel="stylesheet" />
    <link href="css/login-util.css" rel="stylesheet" />
    <script src="bower_components/jquery/dist/jquery.slim.min.js"></script>

</head>
    <%--onload="scrlsts();--%>
<body class="start" ">
    <form id="form1" runat="server">
    <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/logo.png" 
        style="margin:60px 0 0 60px" Height="150px" Width="150px" />--%>
    <%--<div style="color:#007FFF; font-size:40px; font-weight:bold; text-align:center;margin-top:-100px; ">HỆ THỐNG QUẢN LÝ ĐỒNG HỒ TỔNG</div>--%>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
        <div class="container">
            <div class="row flex">
                <div class="col">
                    <div class="box-login">
                        <div class="login100-form validate-form">
					        <span class="login100-form-title p-b-26">
						        Cấp Nước Trung An
					        </span>
                            <img src="../App_Themes/logo.png" alt="logo Trung An" class="logo" />
					        <span class="login100-form-title p-b-48">
						        <i class="zmdi zmdi-font"></i>
					        </span>

					        <div class="wrap-input100 validate-input" ><%--data-validate = "Valid email is: a@b.c"--%>
						        <%--<input class="input100" type="text" name="email">--%>
                                <asp:TextBox ID="txtUid" Runat="server" CssClass="input100">
                                </asp:TextBox>
						        <span class="focus-input100" data-placeholder="Định danh"></span>
					        </div>

					        <div class="wrap-input100 validate-input" > <%--data-validate="Enter password"--%>
						       
						        <%--<input class="input100" type="password" name="pass">--%>
                                <asp:TextBox ID="txtPwd" Runat="server" TextMode="Password" CssClass="input100">
                                </asp:TextBox>
						        <span class="focus-input100" data-placeholder="Mật khẩu"></span>
					        </div>

					        <div class="container-login100-form-btn">
						        <div class="wrap-login100-form-btn">
							        <div class="login100-form-bgbtn"></div>
							        <%--<button class="login100-form-btn">
								        Đăng Nhập
							        </button>--%>
                                    <asp:Button ID="btnOk" runat="server" Text="Đăng nhập"  CssClass="login100-form-btn"
                                        onclick="btnOk_Click">
                                    </asp:Button>
						        </div>
					        </div>

				        </div>
                    </div>
                </div>
            </div>
        </div>
    <%--<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" >
    <div class="box" style="top:50%" >
        <table class="style1">
            <tr>
                <td>
                    <div class="hl">Ký danh:</div></td>
                <td>
                    <telerik:RadTextBox ID="txtUid" Runat="server">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="hl">Mật khẩu:</div></td>
                <td>
                    <telerik:RadTextBox ID="txtPwd" Runat="server" TextMode="Password">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp</td>
                <td align="center">
                    <telerik:RadButton ID="btnOk" runat="server" Text="Đăng nhập" 
                        onclick="btnOk_Click">
                    </telerik:RadButton>
                </td>
            </tr>
        </table>
    </div>
    </telerik:RadAjaxPanel>--%>
    <telerik:RadNotification ID="ntf" runat="server" Title="Message">
    </telerik:RadNotification>

    </form>
    <script>

        (function ($) {
            "use strict";


            /*==================================================================
            [ Focus input ]*/
            $('.input100').each(function () {
                $(this).on('blur', function () {
                    if ($(this).val().trim() != "") {
                        $(this).addClass('has-val');
                    }
                    else {
                        $(this).removeClass('has-val');
                    }
                })
            })


            /*==================================================================
            [ Validate ]*/
            var input = $('.validate-input .input100');

            $('.validate-form').on('submit', function () {
                var check = true;

                for (var i = 0; i < input.length; i++) {
                    if (validate(input[i]) == false) {
                        showValidate(input[i]);
                        check = false;
                    }
                }

                return check;
            });


            $('.validate-form .input100').each(function () {
                $(this).focus(function () {
                    hideValidate(this);
                });
            });

            function validate(input) {
                if ($(input).attr('type') == 'email' || $(input).attr('name') == 'email') {
                    if ($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                        return false;
                    }
                }
                else {
                    if ($(input).val().trim() == '') {
                        return false;
                    }
                }
            }

            function showValidate(input) {
                var thisAlert = $(input).parent();

                $(thisAlert).addClass('alert-validate');
            }

            function hideValidate(input) {
                var thisAlert = $(input).parent();

                $(thisAlert).removeClass('alert-validate');
            }

            /*==================================================================
            [ Show pass ]*/
            var showPass = 0;
            $('.btn-show-pass').on('click', function () {
                if (showPass == 0) {
                    $(this).next('input').attr('type', 'text');
                    $(this).find('i').removeClass('zmdi-eye');
                    $(this).find('i').addClass('zmdi-eye-off');
                    showPass = 1;
                }
                else {
                    $(this).next('input').attr('type', 'password');
                    $(this).find('i').addClass('zmdi-eye');
                    $(this).find('i').removeClass('zmdi-eye-off');
                    showPass = 0;
                }

            });


        })(jQuery);
    </script>
</body>
</html>
