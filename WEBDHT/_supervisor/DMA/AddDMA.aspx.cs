using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _supervisor_DMA_AddDMA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void cboCompanies_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        string dma = "";
        string des = "";
        if (cboCompanies.Text.Trim() != "" && cboCompanies.Text != null)
        {
            dma = cboCompanies.SelectedValue;

            string connectionString = ConfigurationManager.ConnectionStrings["web_dht_r02ConnectionString"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "select t.Description from t_Site_Companies t where t.Company = '" + dma + "'";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            try
                            {
                                des = reader["Description"].ToString();
                            }
                            catch(Exception ex)
                            {
                                des = "";
                            }
                        }
                    }
                }
            }

            txtDescription.Text = des;
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string dma = "";

        if(cboCompanies.Text.Trim() != "" && cboCompanies.Text != null)
        {
            dma = cboCompanies.Text;
            bool isInsert = true;

            string connectionString = ConfigurationManager.ConnectionStrings["web_dht_r02ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "select t.Company from t_Site_Companies t where t.Company = '" +dma+"'";

                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        string dmaCheck = "";

                        while (reader.Read())
                        {
                            try
                            {
                                dmaCheck = reader["Company"].ToString();
                            }
                            catch(Exception ex)
                            {
                                dmaCheck = "";
                            }
                        }

                        if(dmaCheck.Trim() != "" && dmaCheck != null)
                        {
                            if(dmaCheck == dma)
                            {
                                isInsert = false;
                            }
                            else
                            {
                                isInsert = true;
                            }
                        }
                    }
                    command.Dispose();
                }
                if (isInsert == true)
                {
                    string des = "";
                    if (txtDescription.Text.Trim() != "" && txtDescription.Text != null)
                    {
                        des = txtDescription.Text;
                    }
                    else
                    {
                        des = "";
                    }

                    string sqlQueryInsert = "insert into t_Site_Companies values('" + dma + "', null, '" + des + "')";

                    using (SqlCommand command2 = new SqlCommand(sqlQueryInsert, connection))
                    {
                        int nRows = command2.ExecuteNonQuery();

                        if(nRows == 0)
                        {
                            ntf.VisibleOnPageLoad = true;
                            ntf.Text = "Chưa thêm vào";
                        }
                        else
                        {
                            ntf.VisibleOnPageLoad = true;
                            ntf.Text = "Thêm thành công";
                        }                            
                    }
                }
                else
                {
                    string des = "";
                    if (txtDescription.Text.Trim() != "" && txtDescription.Text != null)
                    {
                        des = txtDescription.Text;
                    }
                    else
                    {
                        des = "";
                    }

                    string sqlQueryUpdate = "update t_Site_Companies set Company = '"+dma+"', Description = '"+des+"' where Company = '"+dma+"'";

                    using (SqlCommand command2 = new SqlCommand(sqlQueryUpdate, connection))
                    {
                        int nRows = command2.ExecuteNonQuery();

                        if (nRows == 0)
                        {
                            ntf.VisibleOnPageLoad = true;
                            ntf.Text = "Chưa cập nhật vào";
                        }
                        else
                        {
                            ntf.VisibleOnPageLoad = true;
                            ntf.Text = "Cập nhật thành công";
                        }
                    }
                }

                cboCompanies.DataBind();
            }
        }
        else
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Mã DMA rỗng";
            return;
        }
    }

    protected void btnConfim_Click(object sender, EventArgs e)
    {
        string dma = "";

        if (cboCompanies.Text.Trim() != "" && cboCompanies.Text != null)
        {
            dma = cboCompanies.Text;
            bool isUpdate = false;

            string connectionString = ConfigurationManager.ConnectionStrings["web_dht_r02ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "select t.Company from t_Site_Companies t where t.Company = '" + dma + "'";

                connection.Open();

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        string dmaCheck = "";

                        while (reader.Read())
                        {
                            try
                            {
                                dmaCheck = reader["Company"].ToString();
                            }
                            catch (Exception ex)
                            {
                                dmaCheck = "";
                            }
                        }

                        if (dmaCheck.Trim() != "" && dmaCheck != null)
                        {
                            if (dmaCheck == dma)
                            {
                                isUpdate = true;
                            }
                            else
                            {
                                isUpdate = false;
                            }
                        }
                    }

                    command.Dispose();
                }
                if (isUpdate == true)
                {
                    string sqlQueryDelete = "delete from t_Site_Companies where Company = '" + dma + "'";

                    using (SqlCommand command2 = new SqlCommand(sqlQueryDelete, connection))
                    {
                        int nRows = command2.ExecuteNonQuery();

                        if (nRows == 0)
                        {
                            ntf.VisibleOnPageLoad = true;
                            ntf.Text = "Chưa xóa được";
                        }
                        else
                        {
                            cboCompanies.SelectedIndex = -1;
                            cboCompanies.Text = "";
                            txtDescription.Text = "";
                            ntf.VisibleOnPageLoad = true;
                            ntf.Text = "Xóa thành công";

                        }
                    }
                }
                else
                {
                    ntf.VisibleOnPageLoad = true;
                    ntf.Text = "Không tìm thấy mã DMA";
                }
                cboCompanies.DataBind();

            }
        }
        else
        {
            ntf.VisibleOnPageLoad = true;
            ntf.Text = "Mã DMA rỗng";
            return;
        }
    }

    public List<string> GetCompany()
    {
        List<string> list = new List<string>();
        string connectionString = ConfigurationManager.ConnectionStrings["web_dht_r02ConnectionString"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {

            string sqlQuery = "select t.Company from t_Site_Companies t";

            connection.Open();

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string dma = "";
                        try
                        {
                            dma = reader["Company"].ToString();
                        }
                        catch (Exception ex)
                        {
                            dma = "";
                        }
                        list.Add(dma);
                    }
                }
            }
        }

        return list;
    }
}