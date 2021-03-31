using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_logger_DataLoggerByCycle : System.Web.UI.Page
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
}