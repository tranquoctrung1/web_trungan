using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class _supervisor_system_permission_supervisor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cboStaffs_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (cboStaffs.Text.Trim() != "" && cboStaffs.Text != null)
        {
            string idStaff = cboStaffs.Text;

            SupervisorDistrictBLL supervisorDistrictBLL = new SupervisorDistrictBLL();

            List<SupervisorDistrict> d = supervisorDistrictBLL.GetSupervisorDistrictById(idStaff);

            if (d.Count > 0)
            {
                SetControllValue(d);
            }
            else
            {
                foreach (RadComboBoxItem itemCheck in cboDistrict.Items)
                {
                    itemCheck.Checked = false;
                }
            }
        }

    }

    public void SetControllValue(List<SupervisorDistrict> d)
    {
        cboStaffs.Text = d[0].IdStaff;
        foreach (RadComboBoxItem itemCheck in cboDistrict.Items)
        {
            foreach (var item in d)
            {
                if (item.IdDistrict == itemCheck.Value)
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

        SupervisorDistrictBLL supervisorDistrictBLL = new SupervisorDistrictBLL();
        List<SupervisorDistrict> list = GetControlValue();
        // first delete 
        int nRowD = 0;
        int nRowU = 0;
        nRowD = supervisorDistrictBLL.Delete(cboStaffs.Text);


        // second insert 
        if (list.Count > 0)
        {
            nRowU = supervisorDistrictBLL.Insert(list);
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

        foreach (var item in cboDistrict.CheckedItems)
        {
            item.Checked = false;
        }
    }

    public List<SupervisorDistrict> GetControlValue()
    {
        List<SupervisorDistrict> list = new List<SupervisorDistrict>();

        foreach (var item in cboDistrict.CheckedItems)
        {
            SupervisorDistrict el = new SupervisorDistrict();
            el.IdDistrict = item.Value;
            el.IdStaff = cboStaffs.Text;

            list.Add(el);
        }

        return list;
    }
}