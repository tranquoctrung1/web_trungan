using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_device_cover : System.Web.UI.Page
{
    SiteCoversBLL _siteCoversBLL = new SiteCoversBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = false;
    }

    protected void cboSerials_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        string coverID = cboCoverIDs.Text;
        var cover = _siteCoversBLL.GetCoverByID(coverID);
        if (cover == null)
        {
            SetDefaultValues();
            cboCoverIDs.Text = coverID;
            cboMaterials.Focus();
        }
        else
        {
            SetCoverValues(cover);
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        var cover = GetValues();
        ntf.VisibleOnPageLoad = true;
        CommandStatus status = new CommandStatus();
        if (string.IsNullOrEmpty(cover.CoverID))
        {
            ntf.Text = "Chưa nhập mã nắp hầm.";
            cboCoverIDs.Focus();
        }
        else
        {
            var dbCover = _siteCoversBLL.GetCoverByID(cover.CoverID);
            if (dbCover == null)
            {
                status = _siteCoversBLL.Insert(cover);
                CoverIDsDataSource.DataBind();
                cboCoverIDs.DataBind();
            }
            else
            {
                status = _siteCoversBLL.Update(cover);
            }
            if (status.Inserted)
            {
                ntf.Text = "Đã thêm mới nắp hầm.";
            }
            else if (status.Updated)
            {
                ntf.Text = "Đã cập nhật nắp hầm.";
            }
            else if (status.Error)
            {
                ntf.Text = "Lỗi: " + status.ErrorMessage;
            }
        }
    }

    protected void btnConfim_Click(object sender, EventArgs e)
    {
        ntf.VisibleOnPageLoad = true;
        if (string.IsNullOrEmpty(cboCoverIDs.Text))
        {
            ntf.Text = "Chưa nhập mã nắp hầm.";
        }
        else
        {
            CommandStatus status = _siteCoversBLL.Delete(cboCoverIDs.Text);
            if (status.Deleted)
            {
                ntf.Text = "Đã xóa thông tin nắp hầm.";
                CoverIDsDataSource.DataBind();
                cboCoverIDs.DataBind();
                SetDefaultValues();
            }
            else if(status.Error)
            {
                ntf.Text = "Lỗi: " + status.ErrorMessage;
            }
        }
        cboCoverIDs.Focus();
    }

    public void SetDefaultValues()
    {
        cboCoverIDs.SelectedIndex = -1;
        cboCoverIDs.Text = string.Empty;
        cboCoverH.SelectedIndex = -1;
        cboCoverH.Text = string.Empty;
        cboCoverL.SelectedIndex = -1;
        cboCoverL.Text = string.Empty;
        cboCoverNL.SelectedIndex = -1;
        cboCoverNL.Text = string.Empty;
        cboCoverW.SelectedIndex = -1;
        cboCoverW.Text = string.Empty;
        cboMaterials.SelectedIndex = -1;
        cboMaterials.Text = string.Empty;
    }

    public void SetCoverValues(Cover cover)
    {
        cboCoverIDs.Text = cover.CoverID;
        cboCoverH.Text = cover.CoverH.ToString();
        cboCoverL.Text = cover.CoverL.ToString();
        cboCoverNL.Text = cover.CoverNL.ToString();
        cboCoverW.Text = cover.CoverW.ToString();
        cboMaterials.Text = cover.CoverMaterial;
    }

    public Cover GetValues()
    {
        Cover cover = new Cover();
        int _L = 0;
        int _H = 0;
        int _W = 0;
        int _NL = 0;
        int.TryParse(cboCoverH.Text, out _H);
        int.TryParse(cboCoverW.Text, out _W);
        int.TryParse(cboCoverL.Text, out _L);
        int.TryParse(cboCoverNL.Text, out _NL);
        cover.CoverH = _H;
        cover.CoverL = _L;
        cover.CoverW = _W;
        cover.CoverNL = _NL;
        cover.CoverID = cboCoverIDs.Text;
        cover.CoverMaterial = cboMaterials.Text;
        return cover;
    }
}