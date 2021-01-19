using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class _supervisor_DMA_SeparateDMA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cboCompanies_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (cboCompanies.Text.Trim() != "" && cboCompanies.Text != null)
        {
            string idDma = cboCompanies.Text;

            SiteDMABLL siteDMABLL = new SiteDMABLL();

            List<SiteDMA> d = siteDMABLL.GetSiteDMAById(idDma);

            if (d.Count > 0)
            {
                SetControllValue(d);
            }
            else
            {
                foreach (RadComboBoxItem itemCheck in cboSiteIds.Items)
                {
                    itemCheck.Checked = false;
                }
            }
        }
    }

    public void SetControllValue(List<SiteDMA> d)
    {
        cboCompanies.Text = d[0].IdDMA;
        foreach (RadComboBoxItem itemCheck in cboSiteIds.Items)
        {
            foreach (var item in d)
            {
                if (item.SiteId == itemCheck.Value)
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
        if (cboCompanies.Text.Trim() == "")
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Mã DMA trống!!";

            return;
        }

        SiteDMABLL siteDMABLL = new SiteDMABLL();
        List<SiteDMA> list = GetControlValue();
        // first delete 
        int nRowD = 0;
        int nRowU = 0;
        nRowD = siteDMABLL.Delete(cboCompanies.Text);


        // second insert 
        if (list.Count > 0)
        {
            nRowU = siteDMABLL.Insert(list);
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
        cboCompanies.SelectedIndex = -1;
        cboCompanies.Text = string.Empty;

        foreach (var item in cboSiteIds.CheckedItems)
        {
            item.Checked = false;
        }
    }

    public List<SiteDMA> GetControlValue()
    {
        List<SiteDMA> list = new List<SiteDMA>();

        foreach (var item in cboSiteIds.CheckedItems)
        {
            SiteDMA el = new SiteDMA();
            el.SiteId = item.Value;
            el.IdDMA = cboCompanies.Text;

            list.Add(el);
        }

        return list;
    }
}