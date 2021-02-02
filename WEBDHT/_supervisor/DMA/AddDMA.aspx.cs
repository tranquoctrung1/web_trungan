using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_DMA_AddDMA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cboCompanies_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if(cboCompanies.Text.Trim() != "" && cboCompanies.Text != null )
        {
            SetControlValue(cboCompanies.Text);
        }
        else
        {
            SetDefaultControlValue();
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (cboCompanies.Text.Trim() != "" && cboCompanies.Text != null)
        {
            DMABLL dMABLL = new DMABLL();
            var dbDMA = dMABLL.GetDMAByID(cboCompanies.Text);

            bool isInsert = false;
            bool isUpdate = false;

            if(dbDMA.Company != null)
            {
                var dma = GetControlValue();

                dMABLL.Update(dma);
                cboCompanies.DataBind();
                isUpdate = true;
            }
            else
            {
                var dma = GetControlValue();

                dMABLL.Insert(dma);
                cboCompanies.DataBind();
                isInsert = true;
            }

            if(isUpdate == true )
            {
                ntf.VisibleOnPageLoad = true;
                ntf.Text = "Cập nhật thành công";
            }
            if (isInsert == true)
            {
                ntf.VisibleOnPageLoad = true;
                ntf.Text = "Thêm thành công";
            }
            if(isUpdate == false && isInsert == false)
            {
                ntf.VisibleOnPageLoad = true;
                ntf.Text = "Thao tác thất bại";
            }
        }
        else
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Chưa có mã DMA";
        }
    }

    protected void btnConfim_Click(object sender, EventArgs e)
    {
        if (cboCompanies.Text.Trim() != "" && cboCompanies.Text != null)
        {
            DMABLL dMABLL = new DMABLL();

            int nRows = dMABLL.Delete(cboCompanies.Text);

            if(nRows != 0)
            {
                ntf.VisibleOnPageLoad = true;
                ntf.Text = "Xóa thành công";
            }
            else
            {
                ntf.VisibleOnPageLoad = true;
                ntf.Text = "Xóa thất bại";
            }                
        }
    }

    protected void SetControlValue(string id)
    {
        DMABLL dMABLL = new DMABLL();

        DMAViewModel dma = dMABLL.GetDMAByID(id);

        if(dma.Company != null)
        {
            cboCompanies.Text = dma.Company;
            txtStatus.Text = dma.Status;
            txtDistrict.Text = dma.District;
            txtWard.Text = dma.Ward;
            amountDHTKH.Text = dma.AmountDHTKH.ToString();
            amountPool.Text = dma.AmountPool.ToString();
            amoutValve.Text = dma.AmountValve.ToString();
            amountTCH.Text = dma.AmountTCH.ToString();
            nrw.Text = dma.NRW.ToString();
            txtDescription.Text = dma.Description;
        }
    }

    protected void SetDefaultControlValue()
    {
        cboCompanies.SelectedIndex = -1;
        cboCompanies.Text = string.Empty;
        txtStatus.Text = string.Empty;
        txtDistrict.Text = string.Empty;
        txtWard.Text = string.Empty;
        amountDHTKH.Text = string.Empty;
        amountPool.Text = string.Empty;
        amoutValve.Text = string.Empty;
        amountTCH.Text = string.Empty;
    }

    protected DMAViewModel GetControlValue()
    {
        DMAViewModel dma = new DMAViewModel();

        dma.Company = cboCompanies.Text;
        dma.Description = txtDescription.Text;
        dma.Status = txtStatus.Text;
        dma.District = txtDistrict.Text;
        dma.Ward = txtWard.Text;
        dma.AmountDHTKH =int.Parse( amountDHTKH.Text);
        dma.AmountPool = int.Parse(amountPool.Text);
        dma.AmountValve = int.Parse(amoutValve.Text);
        dma.AmountTCH = int.Parse(amountTCH.Text);
        dma.NRW = double.Parse(nrw.Text);

        return dma;
    }
}