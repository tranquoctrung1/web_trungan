using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class DMA_system_permission_staff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cboStaffs_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (cboStaffs.Text.Trim() != "" && cboStaffs.Text != null)
        {
            string idStaff = cboStaffs.Text;

            StaffPointBLL staffPointBLL = new StaffPointBLL();

            List<StaffPoint> d = staffPointBLL.GetStaffPointById(idStaff);

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

    public void SetControllValue(List<StaffPoint> d)
    {
        cboStaffs.Text = d[0].IdStaff;
        foreach (RadComboBoxItem itemCheck in cboSiteIds.Items)
        {
            foreach (var item in d)
            {
                if (item.IdSite == itemCheck.Value)
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

        StaffPointBLL staffPointBLL = new StaffPointBLL();
        List<StaffPoint> list = GetControlValue();
        // first delete 
        int nRowD = 0;
        int nRowU = 0;
        nRowD = staffPointBLL.Delete(cboStaffs.Text);


        // second insert 
        if (list.Count > 0)
        {
            nRowU = staffPointBLL.Insert(list);
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

        foreach (var item in cboSiteIds.CheckedItems)
        {
            item.Checked = false;
        }
    }

    public List<StaffPoint> GetControlValue()
    {
        List<StaffPoint> list = new List<StaffPoint>();

        foreach (var item in cboSiteIds.CheckedItems)
        {
            StaffPoint el = new StaffPoint();
            el.IdSite = item.Value;
            el.IdStaff = cboStaffs.Text;

            list.Add(el);
        }

        return list;
    }
}