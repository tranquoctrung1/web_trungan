using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisores_alarm_SettingAlarm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cboIds_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        string siteid = cboIds.SelectedValue;

        cboChannels.SelectedIndex = -1;
        cboChannels.Text = "";

        List<string> channelsId = new List<string>();

        string connectionString = ConfigurationManager.ConnectionStrings["web_dht_r02ConnectionString"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string sqlQuery = "select t.Id from t_Devices_ChannelsConfigs t join t_Devices_SitesConfigs ds on ds.Id = t.LoggerId join t_Site_Sites s on s.Id = ds.SiteId where s.Id = '" + siteid + "'";

            connection.Open();

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string channel = "";

                        try
                        {
                            channel = reader["Id"].ToString();
                        }
                        catch (Exception ex)
                        {
                            channel = "";
                        }

                        channelsId.Add(channel);
                    }
                }
            }
        }

        cboChannels.DataSource = channelsId;
        cboChannels.DataBind();

    }

    protected void cboChannels_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        string channelid = cboChannels.SelectedValue;


        string connectionString = ConfigurationManager.ConnectionStrings["web_dht_r02ConnectionString"].ConnectionString;

        string basemin = "";
        string basemax = "";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string sqlQuery = "select BaseMin, BaseMax from [t_Devices_ChannelsConfigs] where Id = '" + channelid + "'";

            connection.Open();

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        try
                        {
                            basemax = reader["BaseMax"].ToString();
                        }
                        catch (Exception ex)
                        {
                            basemax = "";
                        }

                        try
                        {
                            basemin = reader["BaseMin"].ToString();
                        }
                        catch (Exception ex)
                        {
                            basemin = "";
                        }

                    }
                }
            }
        }
        txtbasemax.Text = basemax;
        txtbasemin.Text = basemin;
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        if (cboChannels.Text == "")
        {
            ntf.Text = "Mã kênh trống";
            return;
        }
        else
        {
            string updateBaseMax = "";
            string updateBaseMin = "";
            if (txtbasemax.Text != "")
            {
                updateBaseMax = txtbasemax.Text;
            }
            else
            {
                updateBaseMax = "null";
            }
            if (txtbasemin.Text != "")
            {
                updateBaseMin = txtbasemin.Text;
            }
            else
            {
                updateBaseMin = "null";
            }

            string connectionString = ConfigurationManager.ConnectionStrings["web_dht_r02ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "update t_Devices_ChannelsConfigs set BaseMax = " + updateBaseMax + " , BaseMin = " + updateBaseMin + " where Id = '" + cboChannels.SelectedValue + "'";

                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    int nRows = command.ExecuteNonQuery();

                    if (nRows != 0)
                    {
                        ntf.Text = "Cập nhật thành công";
                    }
                    else
                    {
                        ntf.Text = "Không cập nhật được dòng nào";
                    }
                }
            }
        }
        ntf.VisibleOnPageLoad = true;
    }
}