using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisores_alarm_SettingAlarmForPoint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cboLevel_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (cboLevel.Text.Trim() != "" && cboLevel.Text != null)
        {
            string level = cboLevel.Text;

            LevelAlarmBLL levelAlarmBLL = new LevelAlarmBLL();
            LevelAlarm levelAlarm = levelAlarmBLL.GetLevelAlarmById(level);

            if (levelAlarm.Level != null)
            {
                SetControlValue(levelAlarm);
            }
            else
            {
                txtValue.Text = "0";
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (cboLevel.Text.Trim() == "" || cboLevel.Text == null)
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Cấp độ trống!!";

            return;
        }
        if (txtValue.Text.Trim() == "" || txtValue.Text == null)
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Gía trị trống!!";

            return;
        };

        string level = cboLevel.Text;
        LevelAlarmBLL levelAlarmBLL = new LevelAlarmBLL();
        LevelAlarm levelAlarm = levelAlarmBLL.GetLevelAlarmById(level);

        int nRowU = 0;
        int nRowI = 0;

        if (levelAlarm.Level != null)
        {
            LevelAlarm temp = GetControlValue();
            nRowU = levelAlarmBLL.Update(temp);
            cboLevel.DataBind();
        }
        else
        {
            LevelAlarm temp = GetControlValue();
            nRowI = levelAlarmBLL.Insert(temp);
            cboLevel.DataBind();
        }

        if (nRowU != 0)
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Cập nhật thành công";

            return;
        }
        if (nRowI != 0)
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Thêm thành công";

            return;
        }
        if (nRowU == 0 && nRowI == 0)
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Thao tác thất bại";

            return;
        }
    }

    protected void btnConfim_Click(object sender, EventArgs e)
    {
        if (cboLevel.Text.Trim() == "" || cboLevel.Text == null)
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Cấp độ trống!!";

            return;
        }

        int nRowD = 0;
        LevelAlarmBLL levelAlarmBLL = new LevelAlarmBLL();
        nRowD = levelAlarmBLL.Delete(cboLevel.Text);
        cboLevel.DataBind();
        if (nRowD != 0)
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Xóa thành công";

            return;
        }
        else
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Xóa thất bại";

            return;
        }
    }

    public void SetControlValue(LevelAlarm levelAlarm)
    {
        txtValue.Text = levelAlarm.Value.ToString();
    }

    public LevelAlarm GetControlValue()
    {
        LevelAlarm la = new LevelAlarm();
        la.Level = cboLevel.Text;
        la.Value = double.Parse(txtValue.Text);

        return la;
    }
}