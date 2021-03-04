using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_data_logger : BasePage
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ntf.VisibleOnPageLoad = false;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string siteid = cboIds.Text;
        DateTime? timeStamp = dtmTimeStamp.SelectedDate;

        DataRawBLL dataRawBLL = new DataRawBLL();

        if (siteid != null && siteid.Trim() != "")
        {
            if (timeStamp.Value != null && timeStamp.Value.ToString().Trim() != "")
            {
                DataRawViewModel dr = new DataRawViewModel();
                dr.SiteId = siteid;
                dr.TimeStamp = timeStamp.Value;
                dr.Value = double.Parse(nmrIndex.Text);
                dr.Description = txtDescription.Text;

                bool check = CheckExistsDataRaw(dr);

                if(check == true)
                {
                    int nRowsUpdate = dataRawBLL.Update(dr);
                    if(nRowsUpdate != 0)
                    {
                        ntf.Text = "Cập nhật thành công";
                        ntf.VisibleOnPageLoad = true;
                    }
                    else
                    {
                        ntf.Text = "Cập nhật không thành công";
                        ntf.VisibleOnPageLoad = true;
                    }
                }
                else
                {
                    int nRowsÍnert = dataRawBLL.Insert(dr);
                    if (nRowsÍnert != 0)
                    {
                        ntf.Text = "Thêm không thành công";
                        ntf.VisibleOnPageLoad = true;
                    }
                }
            }
            else
            {
                ntf.Text = "Thời gian trống";
                ntf.VisibleOnPageLoad = true;
            }
        }
        else
        {
            ntf.Text = "Mã point trống";
            ntf.VisibleOnPageLoad = true;
        }
    }

    protected void btnConfim_Click(object sender, EventArgs e)
    {
        string siteid = cboIds.Text;
        DateTime? timeStamp = dtmTimeStamp.SelectedDate;

        DataRawBLL dataRawBLL = new DataRawBLL();

        if (siteid != null && siteid.Trim() != "")
        {
            if (timeStamp.Value != null && timeStamp.Value.ToString().Trim() != "")
            {
                DataRawViewModel dr = new DataRawViewModel();
                dr.SiteId = siteid;
                dr.TimeStamp = timeStamp;

                int nRowsDelete = dataRawBLL.Delete(dr);

                if(nRowsDelete  != 0)
                {
                    ntf.Text = "Xóa thành công";
                    ntf.VisibleOnPageLoad = true;
                }
                else
                {
                    ntf.Text = "Xóa không thành công";
                    ntf.VisibleOnPageLoad = true;
                }                    
            }
            else
            {
                ntf.Text = "Thời gian trống";
                ntf.VisibleOnPageLoad = true;
            }
        }
        else
        {
            ntf.Text = "Mã point trống";
            ntf.VisibleOnPageLoad = true;
        }
    }

    private bool CheckExistsDataRaw(DataRawViewModel dr)
    {
        bool check = false;

        DataRawBLL dataRawBLL = new DataRawBLL();

        DataRawViewModel drn = dataRawBLL.GetDataRaw(dr.SiteId, dr.TimeStamp.Value);

        if(drn.SiteId != null && drn.TimeStamp != null )
        {
            check = true;
        }
        else
        {
            check = false;
        }

        return check;
    }

}