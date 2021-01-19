using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class _supervisor_District_SeparateDistrict : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void cboDistrict_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (cboDistrict.Text.Trim() != "" && cboDistrict.Text != null)
        {
            string idDistrict = cboDistrict.Text;

            SiteDistrictBLL siteDistrictBLL = new SiteDistrictBLL();

            List<SiteDistrict> d = siteDistrictBLL.GetSiteDistrictsById(idDistrict);

            if (d.Count > 0)
            {
                SetControllValue(d);
            }
            else
            {
                foreach (RadComboBoxItem itemCheck in cboIds.Items)
                {
                    itemCheck.Checked = false;
                }
            }
        }

    }

    public void SetControllValue(List<SiteDistrict> d)
    {
        cboDistrict.Text = d[0].IdDistrict;
        foreach(RadComboBoxItem itemCheck in cboIds.Items)
        {
            foreach(var item in d)
            {
                if(item.SiteId == itemCheck.Value)
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
        if (cboDistrict.Text.Trim() == "")
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Mã Quận trống!!";

            return;
        }

        SiteDistrictBLL siteDistrictBLL = new SiteDistrictBLL();
        List<SiteDistrict> list = GetControlValue();
        // first delete 
        int nRowD = 0;
        int nRowU = 0;
        nRowD = siteDistrictBLL.Delete(cboDistrict.Text);


        // second insert 
        if (list.Count > 0)
        {
            nRowU = siteDistrictBLL.Insert(list);
        }

        if(nRowD > 0 )
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Cập nhật thành công";

            return;
        }
    }



    public void SetEmpty()
    {
        cboDistrict.SelectedIndex = -1;
        cboDistrict.Text = string.Empty;

        foreach(var item in cboIds.CheckedItems)
        {
            item.Checked = false;
        }
    }

    public List<SiteDistrict> GetControlValue()
    {
        List<SiteDistrict> list = new List<SiteDistrict>();

        foreach(var item in cboIds.CheckedItems)
        {
            SiteDistrict el = new SiteDistrict();
            el.SiteId = item.Value;
            el.IdDistrict = cboDistrict.Text;

            list.Add(el);
        }

        return list;
    }
}