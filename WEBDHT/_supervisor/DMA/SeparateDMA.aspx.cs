using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_DMA_SeparateDMA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cboSiteIds_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        string siteId = "";
        string company = "";
        if (cboSiteIds.Text.Trim() != "" && cboSiteIds.Text != null)
        {
            siteId = cboSiteIds.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["web_dht_r02ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "select t.Company from t_Site_Sites t where t.Id = '" + siteId + "'";
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
                                company = reader["Company"].ToString();
                            }
                            catch (Exception ex)
                            {
                                company = "";
                            }
                        }
                    }
                }
            }
        }

        cboCompanies.Text = company;
    }

    public bool CheckSiteIdExist(string siteid)
    {
        bool check = false;
        
        string connectionString = ConfigurationManager.ConnectionStrings["web_dht_r02ConnectionString"].ConnectionString;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string sqlQuery = "select Id from  t_Site_Sites where Id = '"+siteid+"'";
            connection.Open();
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    string temp = "";
                    while (reader.Read())
                    {
                        try
                        {
                            temp = reader["Id"].ToString();
                        }
                        catch (Exception ex)
                        {
                            temp = "";
                        }
                    }


                    if (temp == siteid)
                    {
                        check =  true;
                    }
                }
            }
        }
        return check;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if(cboSiteIds.Text.Trim() != "" && cboSiteIds.Text != null)
        {
            string siteid = cboSiteIds.Text;
            string company = cboCompanies.Text;

            if(CheckSiteIdExist(siteid))
            {

                string connectionString = ConfigurationManager.ConnectionStrings["web_dht_r02ConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlQuery = "update t_Site_Sites set Company = '" + company + "' where Id = '" + siteid + "'";
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        int nRows = command.ExecuteNonQuery();
                        
                        if(nRows == 0)
                        {
                            ntf.VisibleOnPageLoad = true;
                            ntf.Text = "Chưa cập nhật";
                        }
                        else
                        {
                            ntf.VisibleOnPageLoad = true;
                            ntf.Text = "Cập nhật thành công";
                        }
                    }
                }
            }
            else
            {
                ntf.VisibleOnPageLoad = true;
                ntf.Text = "Mã Point không đúng";
                return;
            }
        }
        else
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Mã Point rỗng";
            return;
        }
    }
}