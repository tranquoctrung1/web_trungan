using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetDataStatisticTransmitterAction
    {
        public List<StatisticTransmitterViewModel> GetStatisticTransmitter(string provider, string mark, string size, string model, string status, string install, string siteStatus, string company)
        {
            List<StatisticTransmitterViewModel> list = new List<StatisticTransmitterViewModel>();
            Connect connect = new Connect();
            try
            {
                List<string> listProvider = provider.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<string> listMark = mark.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<string> listSize = size.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
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
                if (listSize[0] != "none" && listSize.Count != 0)
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

                string sqlQuery = $"Select t.Serial,t.ReceiptDate, t.AccreditedDate, m.ExpiryDate, m.AccreditationDocument, m.AccreditationType, t.Provider, t.Marks, t.Size, t.Model, t.Status, t.Installed, t.InitialIndex, t.Description,t.ApprovalDecision,t.Approved, s.Id, s.Location,s.Company ,  s.Status as SiteStatus  from  t_Site_Sites s join t_Devices_Meters m on s.Meter = m.Serial join t_Devices_Transmitters t on t.Serial = s.Transmitter";

                connect.Connected();

                SqlDataReader reader = connect.Select(sqlQuery);

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
                        if (listSize[0] != "none")
                        {
                            if (listSize.Contains(reader["Size"].ToString()))
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
                            StatisticTransmitterViewModel el = new StatisticTransmitterViewModel();
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
                                el.AccreditedDate = DateTime.Parse(reader["AccreditedDate"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.AccreditedDate = null;
                            }
                            try
                            {
                                el.ExpiryDate = DateTime.Parse(reader["ExpiryDate"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.ExpiryDate = null;
                            }
                            try
                            {
                                el.AccreditationDocument = reader["AccreditationDocument"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.AccreditationDocument = "";
                            }
                            try
                            {
                                el.AccreditationType = reader["AccreditationType"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.AccreditationType = "";
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
                                el.Size = int.Parse(reader["Size"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.Size = null;
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
                                el.InitialIndex = double.Parse(reader["InitialIndex"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.InitialIndex = null;
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

                            list.Add(el);
                        }
                    }
                }

            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                connect.DisConnected();
            }

            return list;
        }
    }
}