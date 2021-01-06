using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetDataStatisticLoggerAction
    {
        public List<StatisticLoggerViewModel> GetStatisticLogger(string provider, string mark, string model, string status, string install, string siteStatus, string company)
        {
            List<StatisticLoggerViewModel> list = new List<StatisticLoggerViewModel>();

            try
            {
                List<string> listProvider = provider.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<string> listMark = mark.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<string> listModel = model.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<string> listStatus = status.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<string> listInstall = install.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<bool> listInstall1 = new List<bool>();
                if (listInstall[0] != "none" && listInstall.Count != 0)
                {
                    foreach (string item in listInstall)
                    {
                        if (item == "1")
                        {
                            listInstall1.Add(true);
                        }
                        else
                        {
                            listInstall1.Add(false);
                        }
                    }
                }
                List<string> listSiteStatus = siteStatus.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<string> listCompany = company.Split(new char[] { '|' }, StringSplitOptions.None).ToList();

                int numberSatisfaction = 0;

                if (listProvider[0] != "none" && listProvider.Count != 0)
                {
                    numberSatisfaction++;
                }
                if (listMark[0] != "none" && listMark.Count != 0)
                {
                    numberSatisfaction++;
                }
                if (listModel[0] != "none" && listModel.Count != 0)
                {
                    numberSatisfaction++;
                }
                if (listStatus[0] != "none" && listStatus.Count != 0)
                {
                    numberSatisfaction++;
                }
                if (listInstall[0] != "none" && listInstall.Count != 0)
                {
                    numberSatisfaction++;
                }
                if (listSiteStatus[0] != "none" && listSiteStatus.Count != 0)
                {
                    numberSatisfaction++;
                }
                if (listCompany[0] != "none" && listCompany.Count != 0)
                {
                    numberSatisfaction++;
                }

                string sqlQuery = $"select l.Serial, l.ReceiptDate, l.Provider, l.Marks, l.Model, l.Status, l.Installed, l.Description, s.Id, s.Location, s.Status as SiteStatus, s.Company,s.Logger from t_Site_Sites s join t_Devices_Loggers l on l.Serial = s.Logger";

                Connect.ConnectToDataBase();

                SqlDataReader reader = Connect.Select(sqlQuery);

                int numberordered = 1;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        bool isAdd = false;
                        int countNumberSaticfaction = 0;

                        if (listProvider[0] != "none")
                        {
                            if (listProvider.Contains(reader["Provider"].ToString()))
                            {
                                isAdd = true;
                                countNumberSaticfaction++;
                            }
                        }
                        if (listMark[0] != "none")
                        {
                            if (listMark.Contains(reader["Marks"].ToString()))
                            {
                                isAdd = true;
                                countNumberSaticfaction++;
                            }
                        }
                        if (listModel[0] != "none")
                        {
                            if (listModel.Contains(reader["Model"].ToString()))
                            {
                                isAdd = true;
                                countNumberSaticfaction++;
                            }
                        }
                        if (listStatus[0] != "none")
                        {
                            if (listStatus.Contains(reader["Status"].ToString()))
                            {
                                isAdd = true;
                                countNumberSaticfaction++;
                            }
                        }
                        if (listInstall[0] != "none")
                        {
                            if (listInstall1.Contains(bool.Parse(reader["Installed"].ToString())))
                            {
                                isAdd = true;
                                countNumberSaticfaction++;
                            }
                        }
                        if (listSiteStatus[0] != "none")
                        {
                            if (listSiteStatus.Contains(reader["SiteStatus"].ToString()))
                            {
                                isAdd = true;
                                countNumberSaticfaction++;
                            }
                        }
                        if (listCompany[0] != "none")
                        {
                            if (listCompany.Contains(reader["Company"].ToString()))
                            {
                                isAdd = true;
                                countNumberSaticfaction++;
                            }
                        }

                        if (isAdd == true && countNumberSaticfaction == numberSatisfaction)
                        {
                            StatisticLoggerViewModel el = new StatisticLoggerViewModel();
                            try
                            {
                                el.NumberOrdered = numberordered++;
                            }
                            catch (Exception ex)
                            {
                                el.NumberOrdered = numberordered;
                            }
                            try
                            {
                                el.Serial = reader["Serial"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Serial = "";
                            }
                            try
                            {
                                el.ReceiptDate = DateTime.Parse(reader["ReceiptDate"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.ReceiptDate = null;
                            }
                            try
                            {
                                el.Provider = reader["Provider"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Provider = "";
                            }
                            try
                            {
                                el.Marks = reader["Marks"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Marks = "";
                            }
                            try
                            {
                                el.Model = reader["Model"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Model = "";
                            }
                            try
                            {
                                el.Status = reader["Status"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Status = "";
                            }
                            try
                            {
                                el.Installed = bool.Parse(reader["Installed"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.Installed = null;
                            }
                            try
                            {
                                el.Description = reader["Description"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Description = "";
                            }
                            try
                            {
                                el.SiteId = reader["Id"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.SiteId = "";
                            }
                            try
                            {
                                el.Location = reader["Location"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Location = "";
                            }

                            try
                            {
                                el.SiteCompany = reader["Company"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.SiteCompany = "";
                            }
                            try
                            {
                                el.SiteStatus = reader["SiteStatus"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.SiteStatus = "";
                            }
                            try
                            {
                                el.LoggerId = reader["Logger"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.LoggerId = "";
                            }
                            list.Add(el);
                        }
                    }
                }

            }
            catch(SqlException ex)
            {

            }
            finally
            {
                Connect.DisconnectToDataBase();
            }

            return list;
        }
    }
}