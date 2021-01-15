using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            DistrictBLL districtBLL = new DistrictBLL();
            District d = districtBLL.GetDistrictById(idDistrict);

            if (d.IdDistrict != null)
            {
                SetControllValue(d);
            }

        }

    }

    public void SetControllValue(District d)
    {
        cboDistrict.Text = d.IdDistrict;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

        bool isUpdate = false;
        bool isInsert = false;

        if (cboDistrict.Text.Trim() == "")
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Mã Quận trống!!";

            return;
        }

        DistrictBLL districtBLL = new DistrictBLL();
        District d = districtBLL.GetDistrictById(cboDistrict.Text);

        if (d.IdDistrict == null)
        {
            d.IdDistrict = cboDistrict.Text;

            int nRow = districtBLL.Insert(d);
            if (nRow != 0)
            {
                cboDistrict.DataBind();
                isInsert = true;
            }
        }
        else
        {
            d.IdDistrict = cboDistrict.Text;
            int nRow = districtBLL.Update(d);
            if (nRow != 0)
            {
                cboDistrict.DataBind();
                isUpdate = true;
            }
        }

        if (isUpdate == true)
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Cập nhật thành công";

            return;
        }
        if (isInsert == true)
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Thêm thành công";

            return;
        }
        if (isUpdate == false && isInsert == false)
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Thao tác thất bại";

            return;
        }
    }

    

    public void SetEmpty()
    {
        cboDistrict.SelectedIndex = -1;
        cboDistrict.Text = string.Empty;
       
    }
}