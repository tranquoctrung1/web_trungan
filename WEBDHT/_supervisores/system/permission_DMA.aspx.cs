using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class _supervisores_system_permission_DMA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cboStaffs_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (cboStaffs.Text.Trim() != "" && cboStaffs.Text != null)
        {
            string idStaff = cboStaffs.Text;

            DMADMABLL dMADMABLL = new DMADMABLL();

            List<DMADMA> d = dMADMABLL.GetDMADMAById(idStaff);

            if (d.Count > 0)
            {
                SetControllValue(d);
            }
            else
            {
                foreach (RadComboBoxItem itemCheck in cboCompanies.Items)
                {
                    itemCheck.Checked = false;
                }
            }
        }

    }

    public void SetControllValue(List<DMADMA> d)
    {
        cboStaffs.Text = d[0].IdStaff;
        foreach (RadComboBoxItem itemCheck in cboCompanies.Items)
        {
            foreach (var item in d)
            {
                if (item.IdDMA == itemCheck.Value)
                {
                    itemCheck.Checked = true;
                    break;
                }
                else
                {
                    itemCheck.Checked = false;
                }
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (cboStaffs.Text.Trim() == "")
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Mã nhân viên trống!!";

            return;
        }

        DMADMABLL dMADMABLL = new DMADMABLL();
        List<DMADMA> list = GetControlValue();
        // first delete 
        int nRowD = 0;
        int nRowU = 0;
        nRowD = dMADMABLL.Delete(cboStaffs.Text);


        // second insert 
        if (list.Count > 0)
        {
            nRowU = dMADMABLL.Insert(list);
        }

        if (nRowD > 0)
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Cập nhật thành công";

            return;
        }
    }

    public void SetEmpty()
    {
        cboStaffs.SelectedIndex = -1;
        cboStaffs.Text = string.Empty;

        foreach (var item in cboCompanies.CheckedItems)
        {
            item.Checked = false;
        }
    }

    public List<DMADMA> GetControlValue()
    {
        List<DMADMA> list = new List<DMADMA>();

        foreach (var item in cboCompanies.CheckedItems)
        {
            DMADMA el = new DMADMA();
            el.IdDMA = item.Value;
            el.IdStaff = cboStaffs.Text;

            list.Add(el);
        }

        return list;
    }
}