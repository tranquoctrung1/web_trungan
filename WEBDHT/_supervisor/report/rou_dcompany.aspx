<%@ Page Title="" Language="C#" MasterPageFile="~/_supervisor/master_page.master" AutoEventWireup="true" CodeFile="rou_dcompany.aspx.cs" Inherits="_supervisor_report_rou_dcompany" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style3 {
            width: 100%;
        }

        .RadUpload_Office2010Silver input.ruFakeInput {
            width: 62px;
        }

        .RadUpload_Office2010Silver input.ruFakeInput {
            width: 82px;
        }

        .auto-style1 {
            height: 23px;
        }

        .title-company {
            text-transform: uppercase;
            font-size: 2.5rem;
            padding-top: 1rem;
            text-align: center;
            font-weight: 600;
            position: relative;
            margin-bottom: 10px;
        }

        .label {
            font-weight: 500 !important;
            margin-bottom: 2px
        }

            .label.radiob {
                display: block !important;
                margin: 0 auto !important;
            }

            .label.opacity {
                opacity: 0
            }

        .RadComboBox {
            width: 100% !important;
        }

        .RadPicker {
            width: 100% !important;
            height: 33px !important;
        }

        .rctable, .rcSingle, .riSingle {
            width: 100% !important;
            height: 100% !important;
        }

        .rcInputCell {
            width: 100% !important;
            height: 100% !important;
            padding: 0px;
        }

        .riTextBox {
            height: 100% !important;
            border-radius: 4px !important;
            border: 1px solid #999 !important
        }

        .form-control {
            border: 1px solid #999 !important;
            height: 33px !important
        }

            .form-control.opacity {
                opacity: 0
            }

        .RadInput {
            height: 33px !important;
        }

            .RadInput:focus {
                border: 1px solid #999 !important;
            }

        @media only screen and (min-width: 992px) {
            .check-box {
                height: 60px !important;
                display: flex;
                align-items: center
            }
        }

        .RadUpload {
            width: 100% !important;
            height: 33px !important;
            margin-bottom: 3px
        }

        .ruInputs, #ctl00_ContentPlaceHolder1_asyncUploadrow0 {
            height: 100% !important;
        }

        .ruFileWrap {
            width: 100% !important;
            height: 100% !important;
        }

        .ruFakeInput {
            height: 27px !important;
            width: 70% !important;
            border-radius: 4px;
            border: 1px solid #999
        }

        .ruButton {
            height: 33px !important;
            border: none;
            border-radius: 4px;
            color: white !important;
            background: #0984e3 !important
        }

        .riFocused, .riHover {
            border: 1px solid #999 !important
        }

        .button {
            height: 0px
        }

        @media only screen and (min-width: 992px) {

            .des {
                position: relative;
                bottom: 40px;
            }
        }

        @media only screen and (min-width: 992px) {

            .button {
                position: relative;
                bottom: -25px;
                left: 40%
            }
        }

        .title-company::after {
            position: absolute;
            display: block;
            content: '';
            width: 100%;
            height: 2px;
            border-radius: 5px;
            bottom: -10px;
            left: 50%;
            transform: translate(-50%, -50%);
            background: #b2bec3
        }

        #ctl00_ContentPlaceHolder1_cboIstDistributionCompanies, #ctl00_ContentPlaceHolder1_cboQndDistributionCompanies {
            width: 90% !important;
        }

        span.radiob input {
            display: block;
            margin: 0 auto !important
        }
    </style>
    <script type="text/javascript">
        // preventing resubmition form application
        window.history.replaceState('', '', window.location.href)
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-content">
        <div id="main-content-title">
            <h2 class="title-company">Sản lượng các công ty cổ phần</h2>
            <hr class="line" />
        </div>
        <div id="main-content-text">

            <div class="container-config">
                <div class="form-row">
                    <div class="form-group col-md-4">
                        <label for="cboCompanies" class="label">Công ty</label>
                        <telerik:RadComboBox ID="cboCompanies" runat="server" AllowCustomText="True"
                            EnableLoadOnDemand="True" Filter="StartsWith"
                            HighlightTemplatedItems="True" DataSourceID="SiteCompaniesDataSource"
                            DataTextField="Company" DataValueField="Company" DropDownWidth="275px"
                            TabIndex="1">
                            <HeaderTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 70px">Công ty</td>
                                        <td style="width: 200px">Mô tả</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 70px"><%#DataBinder.Eval(Container.DataItem,"Company") %></td>
                                        <td style="width: 200px"><%#DataBinder.Eval(Container.DataItem,"Description") %></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </telerik:RadComboBox>
                        <asp:ObjectDataSource ID="SiteCompaniesDataSource" runat="server"
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetAll"
                            TypeName="SiteCompaniesBLL"></asp:ObjectDataSource>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="dtmStart" class="label">Từ ngày</label>
                        <telerik:RadDatePicker ID="dtmStart" runat="server" Culture="en-GB"
                            TabIndex="2">
                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                ViewSelectorText="x">
                            </Calendar>
                            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                EnableSingleInputRendering="True" LabelWidth="64px" TabIndex="2">
                            </DateInput>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="-1" />
                        </telerik:RadDatePicker>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="dtmEnd" class="label">Đến ngày</label>
                        <telerik:RadDatePicker ID="dtmEnd" runat="server" Culture="en-GB" TabIndex="3">
                            <Calendar UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                ViewSelectorText="x">
                            </Calendar>
                            <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy"
                                EnableSingleInputRendering="True" LabelWidth="64px" TabIndex="3">
                            </DateInput>
                            <DatePopupButton HoverImageUrl="" ImageUrl="" TabIndex="-1" />
                        </telerik:RadDatePicker>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="rdoHorizontal" class="label">Hiển thị ngang</label>
                        <asp:RadioButton ID="rdoHorizontal" runat="server" Checked="True"
                            GroupName="Display" TabIndex="-1" />
                    </div>
                    <div class="form-group col-md-6">
                        <label for="rdoVertical" class="label">Hiển thị dọc</label>
                        <asp:RadioButton ID="rdoVertical" runat="server" GroupName="Display"
                            TabIndex="-1" />
                    </div>
                </div>
                 <div class="form-row">
                        <div class="form-group col-md-4 button">
                           <asp:Button ID="btnReport" runat="server" Text="Biên bản"
                                    OnClick="btnReport_Click" TabIndex="6" CssClass="btn btn-primary"> 
                                </asp:Button>
                                <asp:Button ID="btnOutput" runat="server" Text="Sản lượng"
                                    OnClick="btnOutput_Click" TabIndex="7" CssClass="btn btn-success">
                                </asp:Button>
                                <asp:Button ID="btnOutputLogger" runat="server" Text="Sản lượng logger"
                                    OnClick="btnOutputLogger_Click" TabIndex="8" CssClass="btn btn-info">
                                </asp:Button>
                          </div>
                    </div>
                </div>
            </div>
        </div>
        <telerik:RadWindow ID="win" runat="server" InitialBehaviors="Maximize"
            Modal="True" VisibleStatusbar="False">
            <ContentTemplate>
                <rsweb:ReportViewer ID="rpt" runat="server" AsyncRendering="False"
                    SizeToReportContent="True">
                </rsweb:ReportViewer>
            </ContentTemplate>
        </telerik:RadWindow>
        <telerik:RadNotification ID="ntf" runat="server" Title="Message">
        </telerik:RadNotification>
    </div>
</asp:Content>

