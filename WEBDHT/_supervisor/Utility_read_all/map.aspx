<%@ Page Language="C#" AutoEventWireup="true" CodeFile="map.aspx.cs" Inherits="_supervisor_site_map" %>
<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        html, body, form {       
            margin: 0px;     
            padding: 0px;     
            height: 100%; 
            min-height:100%;
            }
            #GMap1Panel{height:100%;}
    </style>
    <style type="text/css">
        .style0{
            font-family:Segoe UI;
            font-weight:bold;
            color:#25A0DA;
            background-color:White;
        }
        .style1
        {
            font-family:Segoe UI;
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
            color: #FFFFFF;
            background-color:#25A0DA;
            text-align:center;
        }
        .style4{
            color: #FFFFFF;
            background-color:#25A0DA;
            text-align:left;
        }
        .style5{
            color: #FFFFFF;
            background-color:#25A0DA;
            text-align:right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <telerik:RadSplitter ID="RadSplitter1" runat="server"  Width="100%" Height="100%">
            <telerik:RadPane ID="RadPane1" runat="server" Width="22px" Scrolling="None">
                <telerik:RadSlidingZone ID="RadSlidingZone1" runat="server" SlideDuration="0">
                    <telerik:RadSlidingPane ID="RadSlidingPane1" runat="server" Title="Sites" Width="250px" EnableDock="true" >
                        <telerik:RadTreeView ID="trvSites" Runat="server" >
                        </telerik:RadTreeView>
                    </telerik:RadSlidingPane>
                    <telerik:RadSlidingPane ID="RadSlidingPane2" runat="server" Title="Menu" Width="250px" >
                        <telerik:RadTreeView ID="RadTreeView1" Runat="server" 
                            DataSourceID="SiteMapDataSource">
                            
                            <ExpandAnimation Duration="0" Type="None" />
                            <CollapseAnimation Duration="0" Type="None" />
                            
                        </telerik:RadTreeView>
                        <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" 
                            ShowStartingNode="False" />
                            <asp:LoginStatus ID="LoginStatus1" runat="server" style="margin-left:5px" 
                                        LogoutPageUrl="~/login.aspx" />
                    </telerik:RadSlidingPane>
                </telerik:RadSlidingZone>
            </telerik:RadPane>
            <telerik:RadPane ID="RadPane2" runat="server">
                <cc1:GMap runat="server" ID="GMap1" Key="AIzaSyCQ0Cx40GYoH4Kiqnen7TnuaLzpeavrWUk" Width="100%" Height="100%">
                </cc1:GMap>
            </telerik:RadPane>
        </telerik:RadSplitter>
        <asp:Panel runat="server">
            <asp:Timer ID="Timer1" runat="server" Interval="300000" ontick="Timer1_Tick">
            </asp:Timer>
        </asp:Panel>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting  AjaxControlID="Timer1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="GMap1" LoadingPanelID="RadAjaxLoadingPanel1" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" 
        HorizontalAlign="Center">
    </telerik:RadAjaxLoadingPanel>
    </form>
</body>
</html>
