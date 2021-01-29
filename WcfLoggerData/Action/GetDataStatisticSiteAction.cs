using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfLoggerData.ConnectDB;
using WcfLoggerData.Models;

namespace WcfLoggerData.Action
{
    public class GetDataStatisticSiteAction
    {
        public List<StatisticSiteViewModel> GetStatisticSite(string level, string group, string group2s, string meterModel, string companies, string status, string availability, string calc, string property, string takeover, string usingLogger, string modelLogger, string accre, string approve)
        {
            List<StatisticSiteViewModel> list = new List<StatisticSiteViewModel>();
            Connect connect = new Connect();
            try
            {

                List<string> listLevels = level.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<string> listGroups = group.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<string> listGroup2s = group2s.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<string> listMeterModel = meterModel.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<string> listCompanies = companies.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<string> listStatus = status.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<string> listAvailability = availability.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<string> listCalc = calc.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<string> listPro = property.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<bool> listPro1 = new List<bool>();
                if(listPro[0] != "none" && listPro.Count != 0)
                {
                    foreach (string item in listPro)
                    {
                        if (item == "1")
                        {
                            listPro1.Add(true);
                        }
                        else
                        {
                            listPro1.Add(false);
                        }
                    }
                }
                
                List<string> listTake = takeover.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<bool> listTake1 = new List<bool>();
                if (listTake[0] != "none" && listTake.Count != 0)
                {
                    foreach (string item in listTake)
                    {
                        if (item == "1")
                        {
                            listTake1.Add(true);
                        }
                        else
                        {
                            listTake1.Add(false);
                        }
                    }
                }
                    
                List<string> listUsingLogger = usingLogger.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<bool> listUsingLogger1 = new List<bool>();
                if (listUsingLogger[0] != "none" && listUsingLogger.Count != 0)
                {
                    foreach (string item in listUsingLogger)
                    {
                        if (item == "1")
                        {
                            listUsingLogger1.Add(true);
                        }
                        else
                        {
                            listUsingLogger1.Add(false);
                        }
                    }
                }
                    
                List<string> listModelLogger = modelLogger.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<string> listAccre = accre.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<string> listApprove = approve.Split(new char[] { '|' }, StringSplitOptions.None).ToList();
                List<bool> listApprove1 = new List<bool>();
                if (listApprove[0] != "none" && listApprove.Count != 0)
                {
                    foreach (string item in listApprove)
                    {
                        if (item == "1")
                        {
                            listApprove1.Add(true);
                        }
                        else
                        {
                            listApprove1.Add(false);
                        }
                    }

                }


                int numberSatisfaction = 0;

                if (listLevels[0] != "none" && listLevels.Count != 0)
                {
                    numberSatisfaction++;
                }
                if (listGroups[0] != "none" && listGroups.Count != 0)
                {
                    numberSatisfaction++;
                }
                if (listGroup2s[0] != "none" && listGroup2s.Count != 0)
                {
                    numberSatisfaction++;
                }
                if (listMeterModel[0] != "none" && listMeterModel.Count != 0)
                {
                    numberSatisfaction++;
                }
                if (listCompanies[0] != "none" && listCompanies.Count != 0)
                {
                    numberSatisfaction++;
                }
                if (listStatus[0] != "none" && listStatus.Count != 0)
                {
                    numberSatisfaction++;
                }
                if (listAvailability[0] != "none" && listAvailability.Count != 0)
                {
                    numberSatisfaction++;
                }
                if (listCalc[0] != "none" && listCalc.Count != 0)
                {
                    numberSatisfaction++;
                }
                if (listPro[0] != "none" && listPro.Count != 0)
                {
                    numberSatisfaction++;
                }
                if (listTake[0] != "none" && listTake.Count != 0)
                {
                    numberSatisfaction++;
                }
                if (listUsingLogger[0] != "none" && listUsingLogger.Count != 0)
                {
                    numberSatisfaction++;
                }
                if (listModelLogger[0] != "none" && listModelLogger.Count != 0)
                {
                    numberSatisfaction++;
                }
                if (listAccre[0] != "none" && listAccre.Count != 0)
                {
                    numberSatisfaction++;
                }
                if (listApprove[0] != "none" && listApprove.Count != 0)
                {
                    numberSatisfaction++;
                }

                string sqlQuery = $"select s.Id,s.Level, m.Provider, m.Marks, m.Size, s.StaffId, m.ApprovalDecision, m.Model, s.Location, s.[Group], s.Group2, s.Company, s.Status, s.Availability, s.IstDistributionCompany, s.QndDistributionCompany, s.ProductionCompany, s.Property, s.Takeovered, s.UsingLogger, s.Description, l.Model as LoggerModel, s.Meter, s.Transmitter, s.Logger, m.AccreditationDocument, m.AccreditedDate, m.ExpiryDate, s.DateOfMeterChange, s.TakeoverDate, m.AccreditationType, m.Approved from t_Site_Sites s join t_Devices_Meters m on s.Meter = m.Serial join t_Devices_Loggers l on s.Logger = l.Serial";
                connect.Connected();
                SqlDataReader reader = connect.Select(sqlQuery);

                int numberordered = 1;

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        bool isAdd = false;
                        int countNumberSaticfaction = 0;

                        if(listLevels[0] != "none")
                        {
                            if(listLevels.Contains(reader["Level"].ToString()))
                            {
                                isAdd = true;
                                countNumberSaticfaction++;
                            }
                        }
                        if(listGroups[0] != "none")
                        {
                            if (listGroups.Contains(reader["Group"].ToString()))
                            {
                                isAdd = true;
                                countNumberSaticfaction++;
                            }
                        }
                        if(listCompanies[0] != "none")
                        {
                            if (listCompanies.Contains(reader["Company"].ToString()))
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
                        if (listAvailability[0] != "none")
                        {
                            if (listAvailability.Contains(reader["Availability"].ToString()))
                            {
                                isAdd = true;
                                countNumberSaticfaction++;
                            }
                        }
                        if (listTake[0] != "none")
                        {
                            if (listTake1.Contains(bool.Parse(reader["Takeovered"].ToString())))
                            {
                                isAdd = true;
                                countNumberSaticfaction++;
                            }
                        }
                        if (listPro[0] != "none")
                        {
                            if (listPro1.Contains(bool.Parse(reader["Property"].ToString())))
                            {
                                isAdd = true;
                                countNumberSaticfaction++;
                            }
                        }
                        if (listUsingLogger[0] != "none")
                        {
                            if (listUsingLogger1.Contains(bool.Parse(reader["UsingLogger"].ToString())))
                            {
                                isAdd = true;
                                countNumberSaticfaction++;
                            }
                        }
                        if (listMeterModel[0] != "none")
                        {
                            if (listMeterModel.Contains(reader["Model"].ToString()))
                            {
                                isAdd = true;
                                countNumberSaticfaction++;
                            }
                        }
                        if (listAccre[0] != "none")
                        {
                            if (listAccre.Contains(reader["AccreditationType"].ToString()))
                            {
                                isAdd = true;
                                countNumberSaticfaction++;
                            }
                        }
                        if (listApprove[0] != "none")
                        {
                            if (listApprove1.Contains(bool.Parse(reader["Approved"].ToString())))
                            {
                                isAdd = true;
                                countNumberSaticfaction++;
                            }
                        }
                        if (listCalc[0] != "none")
                        {
                            if (listCalc.Contains(reader["ProductionCompany"].ToString()) || listCalc.Contains(reader["QndDistributionCompany"].ToString()) || listCalc.Contains(reader["IstDistributionCompany"].ToString()))
                            {
                                isAdd = true;
                                countNumberSaticfaction++;
                            }
                        }
                        if (listGroup2s[0] != "none")
                        {
                            if (listGroup2s.Contains(reader["Group2"].ToString()))
                            {
                                isAdd = true;
                                countNumberSaticfaction++;
                            }
                        }
                        if (isAdd == true && numberSatisfaction == countNumberSaticfaction)
                        {
                            StatisticSiteViewModel el = new StatisticSiteViewModel();
                            try
                            {
                                el.NumberOrdered = numberordered++;
                            }
                            catch(Exception ex)
                            {
                                el.NumberOrdered = numberordered;
                            }
                            try
                            {
                                el.Level = reader["Level"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Level = "";
                            }
                            try
                            {
                                el.Id = reader["Id"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Id = "";
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
                                el.StaffId = reader["StaffId"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.StaffId = "";
                            }
                            try
                            {
                                el.ApprovalDecision = reader["ApprovalDecision"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.ApprovalDecision = "";
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
                                el.Location = reader["Location"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Location = "";
                            }
                            try
                            {
                                el.Group = reader["Group"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Group = "";
                            }
                            try
                            {
                                el.Group2 = reader["Group2"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Group2 = "";
                            }
                            try
                            {
                                el.Company = reader["Company"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Company = "";
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
                                el.Availability = reader["Availability"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Availability = "";
                            }
                            try
                            {
                                el.IstDistributionCompany = reader["IstDistributionCompany"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.IstDistributionCompany = "";
                            }
                            try
                            {
                                el.QndDistributionCompany = reader["QndDistributionCompany"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.QndDistributionCompany = "";
                            }
                            try
                            {
                                el.ProductionCompany = reader["ProductionCompany"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.ProductionCompany = "";
                            }
                            try
                            {
                                el.Property = bool.Parse(reader["Property"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.Property = null;
                            }
                            try
                            {
                                el.Takeovered = bool.Parse(reader["Takeovered"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.Takeovered = null;
                            }
                            try
                            {
                                el.UsingLogger = bool.Parse(reader["UsingLogger"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.UsingLogger = null;
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
                                el.LoggerModel = reader["LoggerModel"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.LoggerModel = "";
                            }
                            try
                            {
                                el.Meter = reader["Meter"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Meter = "";
                            }
                            try
                            {
                                el.Transmitter = reader["Transmitter"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Transmitter = "";
                            }
                            try
                            {
                                el.Logger = reader["Logger"].ToString();
                            }
                            catch (Exception ex)
                            {
                                el.Logger = "";
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
                                el.DateOfMeterChange = DateTime.Parse(reader["DateOfMeterChange"].ToString());
                            }
                            catch (Exception ex)
                            {
                                el.DateOfMeterChange = null;
                            }
                            if (el.DateOfMeterChange == null)
                            {
                                try
                                {
                                    el.DateOfMeterChange = DateTime.Parse(reader["TakeoverDate"].ToString());
                                }
                                catch (Exception ex)
                                {
                                    el.DateOfMeterChange = null;
                                }
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