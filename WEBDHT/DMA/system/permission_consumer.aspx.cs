using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class DMA_system_permission_consumer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cboConsumer_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        if (cboConsumer.Text.Trim() != "" && cboConsumer.Text != null)
        {
            string idConsumer = cboConsumer.Text;

            ConsumerPointBLL consumerPointBLL = new ConsumerPointBLL();

            List<ConsumerPoint> d = consumerPointBLL.GetConsumerPointById(idConsumer);

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

    public void SetControllValue(List<ConsumerPoint> d)
    {
        cboConsumer.Text = d[0].ConsumerId;
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
        if (cboConsumer.Text.Trim() == "")
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Mã khách hàng trống!!";

            return;
        }

        ConsumerPointBLL consumerPointBLL = new ConsumerPointBLL();
        List<ConsumerPoint> list = GetControlValue();
        // first delete 
        int nRowD = 0;
        int nRowU = 0;
        nRowD = consumerPointBLL.Delete(cboConsumer.Text);


        // second insert 
        if (list.Count > 0)
        {
            nRowU = consumerPointBLL.Insert(list);
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
        cboConsumer.SelectedIndex = -1;
        cboConsumer.Text = string.Empty;

        foreach (var item in cboSiteIds.CheckedItems)
        {
            item.Checked = false;
        }
    }

    public List<ConsumerPoint> GetControlValue()
    {
        List<ConsumerPoint> list = new List<ConsumerPoint>();

        foreach (var item in cboSiteIds.CheckedItems)
        {
            ConsumerPoint el = new ConsumerPoint();
            el.SiteId = item.Value;
            el.ConsumerId = cboConsumer.Text;

            list.Add(el);
        }

        return list;
    }
}