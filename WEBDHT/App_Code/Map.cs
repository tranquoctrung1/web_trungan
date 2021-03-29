using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Text;
using System.Data;

/// <summary>
/// Summary description for Map
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Map : System.Web.Services.WebService
{
    System.Globalization.CultureInfo cu = new System.Globalization.CultureInfo("en-GB");
    public Map()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod] 
    public List<GroupLogger> GetLimitData(string username)
    {
        var siteBL = new SiteBL();
        UserBL _userBL = new UserBL();

        var user = _userBL.GetUser(username);
        List<t_SiteCustomer> sites;
        if (user.Role == "consumer")
        {
            sites = siteBL.GetSitesForMapByConsumerIdCustomLimit(user.StaffId);
        }
        else if (user.Role == "staff")
        {
            sites = siteBL.GetSitesForMapByStaffIdCustomLimit(user.StaffId);
        }
        else if (user.Role == "supervisor")
        {
            sites = siteBL.GetSiteForMapBySupervisorCustomLimit(user.StaffId);
        }
        else if (user.Role == "DMA")
        {
            sites = siteBL.GetSiteForMapByDMACustomLimit(user.StaffId);
        }
        else
        {
            sites = siteBL.GetSitesForMapCustomLimit().ToList();
            // sites = null;
        }
        List<GroupLogger> groupLoggers = new List<GroupLogger>();
        var index = 0;
        foreach (var item in sites)
        {
            var flag = true;
            GroupLogger groupLogger = new GroupLogger();
            if (index == 0)
            {
                groupLogger.DisplayGroup = item.Company;
                groupLogger.Name = "DH";
                groupLoggers.Add(groupLogger);
            }
            else
            {
                foreach (var gr in groupLoggers)
                {
                    if (gr.DisplayGroup == item.Company)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    groupLogger.DisplayGroup = item.Company;
                    groupLogger.Name = "DH";
                    groupLoggers.Add(groupLogger);
                }
            }
            index++;
        }

        foreach (var gr in groupLoggers)
        {
            var x = from s in sites
                    where s.Company == gr.DisplayGroup
                    select new DataAll
                    {
                        SiteId = s.Id,
                        SiteAliasName = s.Location,
                        Location = s.Address,
                        Latitude = (s.Latitude == null ? 0 : (double)s.Latitude),
                        Longitude = (s.Longitude == null ? 0 : (double)s.Longitude),
                        LoggerId = s.Logger,
                        District = s.District
                    };
            gr.lstDataAll = x.ToList();
            var channelConfigurationBL = new ChannelConfigurationBL();
            foreach (var item in gr.lstDataAll)
            {

                var groupchannel = channelConfigurationBL.GetChannelConfigurationsByLoggerID(item.LoggerId).ToList();
                var countGroupCN = 0;
                List<GroupChannels> groupChannels = new List<GroupChannels>();
                foreach (var cn in groupchannel)
                {
                    var flag = true;
                    GroupChannels groupChannel = new GroupChannels();
                    if (countGroupCN == 0)
                    {
                        groupChannel.GroupChannel = cn.GroupChannel;
                        groupChannels.Add(groupChannel);
                    }
                    else
                    {
                        foreach (var grc in groupChannels)
                        {
                            if (grc.GroupChannel == cn.GroupChannel)
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (flag)
                        {
                            groupChannel.GroupChannel = cn.GroupChannel;
                            groupChannels.Add(groupChannel);
                        }
                    }
                    countGroupCN++;
                }

                item.lstGroupChannels = groupChannels;

                var s = sites.Find(site => site.Logger == item.LoggerId);
                int? setDelayTime = s.SetDelayTime != null ? s.SetDelayTime : 60;
                double? setDiffValue = s.SetDiffValue != null ? s.SetDiffValue : 0.3;
                int status = 0;

                foreach (var itemCN in item.lstGroupChannels)
                {
                    var st = from c in channelConfigurationBL.GetChannelConfigurationsByLoggerID(item.LoggerId)
                             where c.GroupChannel == itemCN.GroupChannel
                             select new MChannel
                             {
                                 Status = setStatus(c.ChannelId, c.LastValue, c.TimeStamp, setDelayTime, setDiffValue, c.Pressure1, c.Pressure2),
                             };
                    foreach (var itemST in st)
                    {
                        if (itemST.Status > 1)
                        {
                            status = itemST.Status;
                            break;
                        }
                    }
                }
                foreach (var itemCN in item.lstGroupChannels)
                {
                    var y = from c in channelConfigurationBL.GetChannelConfigurationsByLoggerID(item.LoggerId)
                            where c.GroupChannel == itemCN.GroupChannel
                            select new MChannel
                            {
                                ChannelId = c.ChannelId,
                                LoggerId = c.LoggerId,
                                ChannelName = c.ChannelName,
                                Unit = c.Unit,
                                Description = c.Description,
                                ForwardFlow = c.ForwardFlow,
                                ReverseFlow = c.ReverseFlow,

                                TimeStamp = c.TimeStamp == null ? "NO DATA" : ((DateTime)c.TimeStamp).ToString("dd/MM/yyyy HH:mm"),
                                yyyy = c.TimeStamp == null ? "NO DATA" : ((DateTime)c.TimeStamp).Year.ToString(),
                                MM = c.TimeStamp == null ? "NO DATA" : ((DateTime)c.TimeStamp).Month.ToString(),
                                dd = c.TimeStamp == null ? "NO DATA" : ((DateTime)c.TimeStamp).Day.ToString(),
                                HH = c.TimeStamp == null ? "NO DATA" : ((DateTime)c.TimeStamp).Hour.ToString(),
                                mm = c.TimeStamp == null ? "NO DATA" : ((DateTime)c.TimeStamp).Minute.ToString(),

                                LastValue = c.LastValue == null ? "NO DATA" : ((double)c.LastValue).ToString("0.00"),
                                LastIndex = c.LastIndex == null ? "" : ((double)c.LastIndex).ToString(),
                                Status = status,
                            };
                    itemCN.Channels = y.ToList();
                }
            }
        }

        return groupLoggers;
    }


    [WebMethod]
    public List<GroupLogger> GetDataAll(string username)
    {
        var siteBL = new SiteBL();
        UserBL _userBL = new UserBL();

        var user = _userBL.GetUser(username);
        List<t_SiteCustomer> sites;
        if (user.Role == "consumer")
        {
            sites = siteBL.GetSitesForMapByConsumerIdCustom(user.StaffId);
        }
        else if (user.Role == "staff")
        {
            sites = siteBL.GetSitesForMapByStaffIdCustom(user.StaffId);
        }
        else if (user.Role == "supervisor")
        {
            sites = siteBL.GetSiteForMapBySupervisorCustom(user.StaffId);
        }
        else if (user.Role == "DMA")
        {
            sites = siteBL.GetSiteForMapByDMACustom(user.StaffId);
        }
        else
        {
            sites = siteBL.GetSitesForMapCustom().ToList();
            // sites = null;
        }
        List<GroupLogger> groupLoggers = new List<GroupLogger>();
        var index = 0;
        foreach (var item in sites)
        {
            var flag = true;
            GroupLogger groupLogger = new GroupLogger();
            if (index == 0)
            {
                groupLogger.DisplayGroup = item.Company;
                groupLogger.Name = "DH";
                groupLoggers.Add(groupLogger);
            }
            else
            {
                foreach (var gr in groupLoggers)
                {
                    if (gr.DisplayGroup == item.Company)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    groupLogger.DisplayGroup = item.Company;
                    groupLogger.Name = "DH";
                    groupLoggers.Add(groupLogger);
                }
            }
            index++;
        }

        foreach (var gr in groupLoggers)
        {
            var x = from s in sites
                    where s.Company == gr.DisplayGroup
                    select new DataAll
                    {
                        SiteId = s.Id,
                        SiteAliasName = s.Location,
                        Location = s.Address,
                        Latitude = (s.Latitude == null ? 0 : (double)s.Latitude),
                        Longitude = (s.Longitude == null ? 0 : (double)s.Longitude),
                        LoggerId = s.Logger,
                        District = s.District
                    };
            gr.lstDataAll = x.ToList();
            var channelConfigurationBL = new ChannelConfigurationBL();
            foreach (var item in gr.lstDataAll)
            {

                var groupchannel = channelConfigurationBL.GetChannelConfigurationsByLoggerID(item.LoggerId).ToList();
                var countGroupCN = 0;
                List<GroupChannels> groupChannels = new List<GroupChannels>();
                foreach (var cn in groupchannel)
                {
                    var flag = true;
                    GroupChannels groupChannel = new GroupChannels();
                    if (countGroupCN == 0)
                    {
                        groupChannel.GroupChannel = cn.GroupChannel;
                        groupChannels.Add(groupChannel);
                    }
                    else
                    {
                        foreach (var grc in groupChannels)
                        {
                            if (grc.GroupChannel == cn.GroupChannel)
                            {
                                flag = false;
                                break;
                            }
                        }
                        if (flag)
                        {
                            groupChannel.GroupChannel = cn.GroupChannel;
                            groupChannels.Add(groupChannel);
                        }
                    }
                    countGroupCN++;
                }

                item.lstGroupChannels = groupChannels;

                var s = sites.Find(site => site.Logger == item.LoggerId);
                int? setDelayTime = s.SetDelayTime != null ? s.SetDelayTime : 60;
                double? setDiffValue = s.SetDiffValue != null ? s.SetDiffValue : 0.3;
                int status = 0;

                foreach (var itemCN in item.lstGroupChannels)
                {
                    var st = from c in channelConfigurationBL.GetChannelConfigurationsByLoggerID(item.LoggerId)
                             where c.GroupChannel == itemCN.GroupChannel
                             select new MChannel
                             {
                                 Status = setStatus(c.ChannelId, c.LastValue, c.TimeStamp, setDelayTime, setDiffValue, c.Pressure1, c.Pressure2),
                             };
                    foreach (var itemST in st)
                    {
                        if (itemST.Status > 1)
                        {
                            status = itemST.Status;
                            break;
                        }
                    }
                }
                foreach (var itemCN in item.lstGroupChannels)
                {
                    var y = from c in channelConfigurationBL.GetChannelConfigurationsByLoggerID(item.LoggerId)
                            where c.GroupChannel == itemCN.GroupChannel
                            select new MChannel
                            {
                                ChannelId = c.ChannelId,
                                LoggerId = c.LoggerId,
                                ChannelName = c.ChannelName,
                                Unit = c.Unit,
                                Description = c.Description,
                                ForwardFlow = c.ForwardFlow,
                                ReverseFlow = c.ReverseFlow,

                                TimeStamp = c.TimeStamp == null ? "NO DATA" : ((DateTime)c.TimeStamp).ToString("dd/MM/yyyy HH:mm"),
                                yyyy = c.TimeStamp == null ? "NO DATA" : ((DateTime)c.TimeStamp).Year.ToString(),
                                MM = c.TimeStamp == null ? "NO DATA" : ((DateTime)c.TimeStamp).Month.ToString(),
                                dd = c.TimeStamp == null ? "NO DATA" : ((DateTime)c.TimeStamp).Day.ToString(),
                                HH = c.TimeStamp == null ? "NO DATA" : ((DateTime)c.TimeStamp).Hour.ToString(),
                                mm = c.TimeStamp == null ? "NO DATA" : ((DateTime)c.TimeStamp).Minute.ToString(),

                                LastValue = c.LastValue == null ? "NO DATA" : ((double)c.LastValue).ToString("0.00"),
                                LastIndex = c.LastIndex == null ? "" : ((double)c.LastIndex).ToString(),
                                Status = status,
                            };
                    itemCN.Channels = y.ToList();
                }
            }
        }

        return groupLoggers;
    }
    private int setStatus(string channelID, double? value, DateTime? timestamp, int? delayTime, double? diffValue, bool? pressure1, bool? pressure2)
    {
        if (timestamp != null && (DateTime.Now - (DateTime)timestamp).TotalMinutes >= delayTime)
        {
            return 2;
        }
        if (pressure1 == true || pressure2 == true)
        {
            if (value <= 0 || value == null)
            {
                return 4;
            }
            if (timestamp != null && value != null)
            {
                DataLoggerGetBL dataLoggerGetBL = new DataLoggerGetBL();

                var result = dataLoggerGetBL.GetValuePrevDay(timestamp.Value.AddDays(-1), channelID);
                try
                {
                    if (value != null && (((double)value <= ((double)result.Value) * (1 - diffValue)) || ((double)value >= ((double)result.Value) * (1 + diffValue))))
                    {
                        return 3;
                    }
                }
                catch
                {
                    return 4;
                }

            }
        }
        return 1;
    }

    [WebMethod]
    public List<SiteDatAll> GetDataAllNew(string username)
    {
        List<SiteDatAll> list = new List<SiteDatAll>();

        var siteBL = new SiteBL();
        UserBL _userBL = new UserBL();

        var channelConfigurationBL = new ChannelConfigurationBL();

        var user = _userBL.GetUser(username);
        List<t_SiteCustomer> sites;
        if (user.Role == "consumer")
        {
            sites = siteBL.GetSitesForMapByConsumerIdCustom(user.StaffId);
        }
        else if (user.Role == "staff")
        {
            sites = siteBL.GetSitesForMapByStaffIdCustom(user.StaffId);
        }
        else if (user.Role == "supervisor")
        {
            sites = siteBL.GetSiteForMapBySupervisorCustom(user.StaffId);
        }
        else if (user.Role == "DMA")
        {
            sites = siteBL.GetSiteForMapByDMACustom(user.StaffId);
        }
        else
        {
            sites = siteBL.GetSitesForMapCustom().ToList();
            // sites = null;
        }

        foreach(var item in sites)
        {
            SiteDatAll el = new SiteDatAll();
            el.SiteId = item.Id;
            el.Location = item.Address;
            el.SiteAliasName = item.Location;
            el.DisplayGroup = item.Company;
            el.District = item.District;
            el.Longitude = (item.Longitude == null ? 0 : double.Parse(item.Longitude.ToString()));
            el.Latitude = (item.Latitude == null ? 0 : double.Parse(item.Latitude.ToString()));
            el.LoggerId = item.Logger;

            double index = 0;


            List<t_Channel_Configurations> listChannel = channelConfigurationBL.GetChannelConfigurationsByLoggerID(el.LoggerId);
            List<MChannel> listMChannel = new List<MChannel>();
            foreach(var channel in listChannel)
            {
                MChannel c = new MChannel();
                c.ChannelId = channel.ChannelId;
                c.ChannelName = channel.ChannelName;
                c.Description = channel.Description;
                c.DisplayOnLabel = (channel.DisplayOnLabel == null ? true : channel.DisplayOnLabel.Value);
                c.Unit = channel.Unit;
                c.GroupChannel = channel.GroupChannel;
                c.Pressure1 = channel.Pressure1;
                c.Pressure2 = channel.Pressure2;
                c.ForwardFlow = channel.ForwardFlow;
                c.ReverseFlow = channel.ReverseFlow;
                c.LastIndex = (channel.LastIndex == null ? "NO DATA" : channel.LastIndex.Value.ToString());
                c.LastValue = (channel.LastValue == null ? "NO DATA" : channel.LastValue.Value.ToString());
                c.TimeStamp = (channel.TimeStamp == null ? "NO DATA" : channel.TimeStamp.Value.ToString("dd/MM/yyyy HH:mm"));
                c.IndexTimeStamp = (channel.IndexTimeStamp == null ? "NO DATA" : channel.IndexTimeStamp.Value.ToString("dd/MM/yyyy HH:mm"));

                c.yyyy = (channel.TimeStamp == null ? "NO DATA" : channel.TimeStamp.Value.Year.ToString());
                c.MM = (channel.TimeStamp == null ? "NO DATA" : channel.TimeStamp.Value.Month.ToString());
                c.dd = (channel.TimeStamp == null ? "NO DATA" : channel.TimeStamp.Value.Day.ToString());
                c.HH = (channel.TimeStamp == null ? "NO DATA" : channel.TimeStamp.Value.Hour.ToString());
                c.mm = (channel.TimeStamp == null ? "NO DATA" : channel.TimeStamp.Value.Minute.ToString());


                if(channel.ForwardFlow != null )
                {
                    if(channel.LastIndex != null)
                    {
                        index += channel.LastIndex.Value;

                    }
                }
                else if(channel.ReverseFlow != null)
                {
                    if(channel.LastIndex != null)
                    {
                        index -= channel.LastIndex.Value;
                    }
                }

                int status = 0;
                bool check = false;
                if(channel.TimeStamp == null)
                {
                    status = 4;
                    check = true;
                }
                if(check == false)
                {
                    if (channel.TimeStamp != null)
                    {
                        if ((DateTime.Now - channel.TimeStamp.Value).TotalMinutes > 60)
                        {
                            status = 2;
                            check = true;
                        }
                    }
                }
                if(check == false )
                {
                    if(channel.basemax != null)
                    {
                        if(channel.LastValue != null)
                        {
                            if(channel.LastValue.Value >channel.basemax.Value)
                            {
                                status = 4;
                                check = true;
                            }
                        }
                    }
                }
                if (check == false)
                {
                    if (channel.basemin != null)
                    {
                        if (channel.LastValue != null)
                        {
                            if (channel.LastValue.Value < channel.basemin.Value)
                            {
                                status = 4;
                                check = true;
                            }
                        }
                    }
                }
                if(check == false )
                {
                    status = 1;
                }

                c.Status = status;
                listMChannel.Add(c);
            }
            el.Index = index;
            el.ListChannels = listMChannel;
            list.Add(el);
        }

        return list;
    }

    [WebMethod]
    public List<SiteDatAll> GetDataAllLimitNew(string username)
    {
        List<SiteDatAll> list = new List<SiteDatAll>();

        var siteBL = new SiteBL();
        UserBL _userBL = new UserBL();

        var channelConfigurationBL = new ChannelConfigurationBL();

        var user = _userBL.GetUser(username);
        List<t_SiteCustomer> sites;
        if (user.Role == "consumer")
        {
            sites = siteBL.GetSitesForMapByConsumerIdCustomLimit(user.StaffId);
        }
        else if (user.Role == "staff")
        {
            sites = siteBL.GetSitesForMapByStaffIdCustomLimit(user.StaffId);
        }
        else if (user.Role == "supervisor")
        {
            sites = siteBL.GetSiteForMapBySupervisorCustomLimit(user.StaffId);
        }
        else if (user.Role == "DMA")
        {
            sites = siteBL.GetSiteForMapByDMACustomLimit(user.StaffId);
        }
        else
        {
            sites = siteBL.GetSitesForMapCustomLimit().ToList();
            // sites = null;
        }

        foreach (var item in sites)
        {
            SiteDatAll el = new SiteDatAll();
            el.SiteId = item.Id;
            el.Location = item.Address;
            el.SiteAliasName = item.Location;
            el.DisplayGroup = item.Company;
            el.District = item.District;
            el.Longitude = (item.Longitude == null ? 0 : double.Parse(item.Longitude.ToString()));
            el.Latitude = (item.Latitude == null ? 0 : double.Parse(item.Latitude.ToString()));
            el.LoggerId = item.Logger;

            double index = 0;


            List<t_Channel_Configurations> listChannel = channelConfigurationBL.GetChannelConfigurationsByLoggerID(el.LoggerId);
            List<MChannel> listMChannel = new List<MChannel>();
            foreach (var channel in listChannel)
            {
                MChannel c = new MChannel();
                c.ChannelId = channel.ChannelId;
                c.ChannelName = channel.ChannelName;
                c.Description = channel.Description;
                c.DisplayOnLabel = (channel.DisplayOnLabel == null ? true : channel.DisplayOnLabel.Value);
                c.Unit = channel.Unit;
                c.GroupChannel = channel.GroupChannel;
                c.Pressure1 = channel.Pressure1;
                c.Pressure2 = channel.Pressure2;
                c.ForwardFlow = channel.ForwardFlow;
                c.ReverseFlow = channel.ReverseFlow;
                c.LastIndex = (channel.LastIndex == null ? "NO DATA" : channel.LastIndex.Value.ToString());
                c.LastValue = (channel.LastValue == null ? "NO DATA" : channel.LastValue.Value.ToString());
                c.TimeStamp = (channel.TimeStamp == null ? "NO DATA" : channel.TimeStamp.Value.ToString("dd/MM/yyyy HH:mm"));
                c.IndexTimeStamp = (channel.IndexTimeStamp == null ? "NO DATA" : channel.IndexTimeStamp.Value.ToString("dd/MM/yyyy HH:mm"));

                c.yyyy = (channel.TimeStamp == null ? "NO DATA" : channel.TimeStamp.Value.Year.ToString());
                c.MM = (channel.TimeStamp == null ? "NO DATA" : channel.TimeStamp.Value.Month.ToString());
                c.dd = (channel.TimeStamp == null ? "NO DATA" : channel.TimeStamp.Value.Day.ToString());
                c.HH = (channel.TimeStamp == null ? "NO DATA" : channel.TimeStamp.Value.Hour.ToString());
                c.mm = (channel.TimeStamp == null ? "NO DATA" : channel.TimeStamp.Value.Minute.ToString());


                if (channel.ForwardFlow != null)
                {
                    if (channel.LastIndex != null)
                    {
                        index += channel.LastIndex.Value;

                    }
                }
                else if (channel.ReverseFlow != null)
                {
                    if (channel.LastIndex != null)
                    {
                        index -= channel.LastIndex.Value;
                    }
                }

                int status = 0;
                bool check = false;
                if (channel.TimeStamp == null)
                {
                    status = 4;
                    check = true;
                }
                if (check == false)
                {
                    if (channel.TimeStamp != null)
                    {
                        if ((DateTime.Now - channel.TimeStamp.Value).TotalMinutes > 60)
                        {
                            status = 2;
                            check = true;
                        }
                    }
                }
                if (check == false)
                {
                    if (channel.basemax != null)
                    {
                        if (channel.LastValue != null)
                        {
                            if (channel.LastValue.Value > channel.basemax.Value)
                            {
                                status = 4;
                                check = true;
                            }
                        }
                    }
                }
                if (check == false)
                {
                    if (channel.basemin != null)
                    {
                        if (channel.LastValue != null)
                        {
                            if (channel.LastValue.Value < channel.basemin.Value)
                            {
                                status = 4;
                                check = true;
                            }
                        }
                    }
                }
                if (check == false)
                {
                    status = 1;
                }

                c.Status = status;
                listMChannel.Add(c);
            }
            el.Index = index;
            el.ListChannels = listMChannel;
            list.Add(el);
        }

        return list;
    }
    [WebMethod]
    public List<LoggerData> Getchanneldetail(string channel, string startDate, string endDate, bool isGraph)
    {
        DataLoggerGetBL dataLoggerGetBL = new DataLoggerGetBL();

        if (isGraph == true)
        {
            return dataLoggerGetBL.GetLoggerData(channel, startDate, endDate).OrderBy(d => d.TimeStamp).ToList();
        }
        else
        {
            return dataLoggerGetBL.GetLoggerData(channel, startDate, endDate).OrderByDescending(d => d.TimeStamp).ToList();
        }
    }

    [WebMethod]
    public toado LatLng(string userName)
    {
        toado list = new toado();
        var siteBL = new SiteBL();
        UserBL _userBL = new UserBL();

        var user = _userBL.GetUser(userName);
        List<t_SiteCustomer> sites;
        if (user.Role == "consumer")
        {
            sites = siteBL.GetSitesForMapByConsumerIdCustom(user.StaffId);
        }
        else if (user.Role == "staff")
        {
            sites = siteBL.GetSitesForMapByStaffIdCustom(user.StaffId);
        }
        else if (user.Role == "supervisor")
        {
            sites = siteBL.GetSiteForMapBySupervisorCustom(user.StaffId);
        }
        else if (user.Role == "DMA")
        {
            sites = siteBL.GetSiteForMapByDMACustom(user.StaffId);
        }
        else
        {
            sites = siteBL.GetSitesForMapCustom().ToList();
            // sites = null;
        }
        if (sites.ToList().Count > 0)
        {
            list.Lat = sites.ToList()[0].Latitude.ToString();
            list.Lng = sites.ToList()[0].Longitude.ToString();
        }
        else
        {
            list.Lat = "10.844305";
            list.Lng = "106.658138";
        }
        return list;
    }
    [WebMethod]
    public logo Logo(string path)
    {
        logo list = new logo();

        list.Path = "http://113.161.76.112:6767/logo_consumer125.png";


        return list;
    }
    [WebMethod]
    public mySite GetSite(string siteID)
    {
        SiteBL _siteBL = new SiteBL();
        mySite ms = new mySite();
        var s = _siteBL.GetSite(siteID);
        ms.SiteID = s[0].Location;
        return ms;
    }
    [WebMethod]
    public myLogin Dologin(string user, string pass)
    {
        myLogin list = new myLogin();
        UserBL _userBL = new UserBL();
        StringUT _stringUT = new StringUT();
        t_Users dbUser = _userBL.GetUser(user);
        if (dbUser != null)
        {
            string hashedPassword = _stringUT.HashMD5(_stringUT.HashMD5(pass) + dbUser.Salt);
            if (string.Equals(hashedPassword, dbUser.Password))
                list.username = dbUser.Username;
        }
        return list;
    }

    [WebMethod]
    public List<AlarmForPointViewModel> GetDataHistoryAlarmForPoint(string uid)
    {
        AlarmForPointBLL alarmForPointBLL = new AlarmForPointBLL();

        return alarmForPointBLL.GetAlarmForPoint(uid);
    }

    [WebMethod]
    public List<AlarmForLoggerViewModel> GetDataHistoryAlarmForLogger(string uid)
    {
        AlarmForLoggerBLL alarmForLoggerBLL = new AlarmForLoggerBLL();

        return alarmForLoggerBLL.GetAlarmForLogger(uid);
    }

    [WebMethod]
    public List<AlarmForDMAViewModel> GetDataHistoryAlarmForDMA(string uid)
    {
        AlarmForDMABLL alarmForDMABLL = new AlarmForDMABLL();

        return alarmForDMABLL.GetAlarmForDMA(uid);
    }

    [WebMethod]
    public List<MSite> GetSitesForMap(string username)
    {
        var siteBL = new SiteBL();
        UserBL _userBL = new UserBL();

        var user = _userBL.GetUser(username);
        List<t_SiteCustomer> sites;
        if (user.Role == "consumer")
        {
            sites = siteBL.GetSitesForMapByConsumerIdCustom(user.StaffId);
        }
        else if (user.Role == "staff")
        {
            sites = siteBL.GetSitesForMapByStaffIdCustom(user.StaffId);
        }
        else if (user.Role == "supervisor")
        {
            sites = siteBL.GetSiteForMapBySupervisorCustom(user.StaffId);
        }
        else if (user.Role == "DMA")
        {
            sites = siteBL.GetSiteForMapByDMACustom(user.StaffId);
        }
        else
        {
            sites = siteBL.GetSitesForMapCustom().ToList();
            // sites = null;
        }
        // var x = from s in siteBL.GetSitesForMap()
        var x = from s in sites
                select new MSite
                {
                    SiteId = s.Id,
                    SiteAliasName = s.Address,
                    Location = s.Location,
                    Latitude = (s.Latitude == null ? 0 : (double)s.Latitude),
                    Longitude = (s.Longitude == null ? 0 : (double)s.Longitude),
                    LoggerId = s.Logger,
                    LabelAnchorX = 40,
                    LabelAnchorY = 10,
                    DisplayGroup = s.Company
                };

        List<MSite> t = x.ToList();
        var loggerBL = new LoggerConfigurationBLL();
        foreach (MSite item in t)
        {
            var y = loggerBL.GetLoggerConfiguration(item.LoggerId);
        }

        return t.OrderBy(d => d.DisplayGroup).ThenBy(n => n.SiteAliasName).ToList();

    }

    [WebMethod]
    public string GetRoleByUid(string uid)
    {
        var siteBL = new SiteBL();
        UserBL _userBL = new UserBL();

        var user = _userBL.GetUser(uid);

        return user.Role;
    }


    [WebMethod]
    public List<MSite> GetSitesByUid(string username)
    {
        UserBL _userBL = new UserBL();
        var siteBL = new SiteBL();
        var user = _userBL.GetUser(username);

        List<MSite> lst = new List<MSite>();
        List<t_SiteCustomer> sites;
        if (user.Role == "consumer")
        {
            sites = siteBL.GetSitesForMapByConsumerIdCustom(user.StaffId);
        }
        else if (user.Role == "staff")
        {
            sites = siteBL.GetSitesForMapByStaffIdCustom(user.StaffId);
        }
        else if (user.Role == "supervisor")
        {
            sites = siteBL.GetSiteForMapBySupervisorCustom(user.StaffId);
        }
        else if (user.Role == "DMA")
        {
            sites = siteBL.GetSiteForMapByDMACustom(user.StaffId);
        }
        else
        {
            sites = siteBL.GetSitesForMapCustom().ToList();
            // sites = null;
        }

        var x = from s in sites
                select new MSite
                {
                    SiteId = s.Id,
                    SiteAliasName = s.Address,
                    Location = s.Location,
                    Latitude = (s.Latitude == null ? 0 : (double)s.Latitude),
                    Longitude = (s.Longitude == null ? 0 : (double)s.Longitude),
                    LoggerId = s.Logger,
                    LabelAnchorX = 40,
                    LabelAnchorY = 40,
                    DisplayGroup = s.Company
                };
        lst = x.ToList();
        return lst;
    }

    [WebMethod]
    public List<DMAMobileViewModel> GetDMAByUid(string uid)
    {
        DMAMobileBLL dMAMobileBLL = new DMAMobileBLL();

        return dMAMobileBLL.GetDMAMobileByUid(uid);
    }

    [WebMethod]
    public List<DataQuantityAndChartViewModel> GetDataQuantityAndChartPointHourly(string siteid, string start, string end)
    {
        QuantityPointBLL quantityPointBLL = new QuantityPointBLL();

        return quantityPointBLL.GetDataQuantityAndChart(siteid, start, end);
    }

    [WebMethod]
    public List<DataQuantityAndChartViewModel> GetDataQuantityAndChartPointDaily(string siteid, string start, string end)
    {
        QuantityPointBLL quantityPointBLL = new QuantityPointBLL();

        return quantityPointBLL.GetDataQuantityAndChartDaily(siteid, start, end);
    }

    [WebMethod]
    public List<DataQuantityAndChartViewModel> GetDataQuantityAndChartPointMonthly(string siteid, string start, string end)
    {
        QuantityPointBLL quantityPointBLL = new QuantityPointBLL();

        return quantityPointBLL.GetDataQuantityAndChartMonthly(siteid, start, end);
    }

    [WebMethod]
    public List<DataQuantityAndChartViewModel> GetDataQuantityAndChartChannel(string channelid, string start, string end)
    {
        QuantityChannelBLL quantityChannelBLL = new QuantityChannelBLL();

        return quantityChannelBLL.dataQuantityAndChartChannel(channelid, start, end);
    }


    [WebMethod]
    public List<DataQuantityAndChartViewModel> GetDataQuantityAndChartDMAHourly(string dmaid, string start, string end)
    {
        QuantityDMABLL quantityDMABLL = new QuantityDMABLL();

        return quantityDMABLL.GetDataQuantityAndChartDMA(dmaid, start, end);
    }

    [WebMethod]
    public List<DataQuantityAndChartViewModel> GetDataQuantityAndChartDMADaily(string dmaid, string start, string end)
    {
        QuantityDMABLL quantityDMABLL = new QuantityDMABLL();

        return quantityDMABLL.GetDataQuantityAndChartDMADaily(dmaid, start, end);
    }

    [WebMethod]
    public List<DataQuantityAndChartViewModel> GetDataQuantityAndChartDMAMonthly(string dmaid, string start, string end)
    {
        QuantityDMABLL quantityDMABLL = new QuantityDMABLL();

        return quantityDMABLL.GetDataQuantityAndChartDMAMonthly(dmaid, start, end);
    }




    [WebMethod]
    public List<tUnits> GetUnits()
    {
        UnitBLL unitBLL = new UnitBLL();
        var result = unitBLL.GetUnits();
        return (from g in result
                select new tUnits
                {
                    Description = g.Description,
                    Unit = g.Unit
                }).ToList();
    }


    [WebMethod]
    public result_sampler ResetSampler(string ip, string port, string partnerid)
    {
        result_sampler r = new result_sampler();
        string host_name = ip;
        int PORT_NUMBER = int.Parse(port);
        TcpClient clientreset = new TcpClient();

        // 1. connect
        clientreset.Connect(host_name, PORT_NUMBER);
        Stream stream2 = clientreset.GetStream();
        while (true)
        {
            string str = partnerid;
            var reader = new StreamReader(stream2);
            var writer = new StreamWriter(stream2);
            writer.AutoFlush = true;

            // 2. send
            string strcm = "$CMD03," + str + ",SMPRST#AB*";
            writer.WriteLine(strcm);
            r.Result = "Reset";
            break;
        }

        // 4. close
        stream2.Close();
        clientreset.Close();
        return r;
    }


    [WebMethod]
    public List<tChannelConfigurations> GetChannelConfigByLoggerID(string loggerId)
    {
        ChannelConfigurationBL channelConfigurationBL = new ChannelConfigurationBL();
        var result = channelConfigurationBL.GetChannelConfigurationsByLoggerID(loggerId);
        return (from c in result
                select new tChannelConfigurations
                {
                    Baseline = c.Baseline.ToString(),
                    ChannelId = c.ChannelId,
                    LoggerId = c.LoggerId,
                    ChannelName = c.ChannelName,
                    Unit = c.Unit,
                    Description = c.Description,
                    Pressure1 = c.Pressure1,
                    Pressure2 = c.Pressure2,
                    ForwardFlow = c.ForwardFlow,
                    ReverseFlow = c.ReverseFlow,
                    TimeStamp = c.TimeStamp.ToString(),
                    LastValue = c.LastValue.ToString(),
                    IndexTimeStamp = c.IndexTimeStamp.ToString(),
                    LastIndex = c.LastIndex.ToString(),
                    DisplayOnLabel = c.DisplayOnLabel,
                    ChannelOther = c.ChannelOther,
                    basemin = c.basemin.ToString(),
                    basemax = c.basemax.ToString(),
                    GroupChannel = c.GroupChannel,
                    DisplayOnGraph = c.DisplayOnGraph,
                }).ToList();

    }

    [WebMethod]
    public List<LevelAlarmMobile> GetLevelAlarms()
    {
        LevelAlarmMobileBLL levelAlarmMobileBLL = new LevelAlarmMobileBLL();

        return levelAlarmMobileBLL.GetLevelAlarms();
    }

    [WebMethod]
    public int InsertLevelAlarm(string level, string value)
    {
        LevelAlarmMobile al = new LevelAlarmMobile();
        al.Level = level;
        al.Value = double.Parse(value);

        LevelAlarmMobileBLL levelAlarmMobileBLL = new LevelAlarmMobileBLL();

        return levelAlarmMobileBLL.Insert(al);
    }

    [WebMethod]
    public int UpdateLevelAlarm(string level, string value)
    {
        LevelAlarmMobile al = new LevelAlarmMobile();
        al.Level = level;
        al.Value = double.Parse(value);

        LevelAlarmMobileBLL levelAlarmMobileBLL = new LevelAlarmMobileBLL();

        return levelAlarmMobileBLL.Update(al);
    }

    [WebMethod]
    public int DeleteLevelAlarm(string level)
    {
        LevelAlarmMobileBLL levelAlarmMobileBLL = new LevelAlarmMobileBLL();

        return levelAlarmMobileBLL.Delete(level);
    }

    [WebMethod]
    public bool CheckExistsLevelAlarm(string level)
    {
        LevelAlarmMobileBLL levelAlarmMobileBLL = new LevelAlarmMobileBLL();


        var result = levelAlarmMobileBLL.GetLevelAlarmById(level);

        if (result.Level != "" && result.Level != null)
        {
            return true;
        }
        return false;
    }

    [WebMethod]
    public string  GetDeviceTokenFromApp(string username, string deviceToken)
    {
        DeciveTokenAppBLL deciveTokenAppBLL = new DeciveTokenAppBLL();
        string result = "";
        try
        {
            result = deciveTokenAppBLL.InsertDeviceTokenApp(username, deviceToken).ToString();
        }
        catch(SqlException ex)
        {
            result = ex.ToString();
        }
         
        return result;

    }

    [WebMethod] 
    public bool CheckExistsPointConfig(string siteid)
    {
        SitesBLL _sitesBLL = new SitesBLL();

        var db = _sitesBLL.GetById(siteid);

        if(db.Id != "" && db.Id != null)
        {
            return true;
        }
        return false;
    }

    [WebMethod]
    public bool InsertPointConfig(string avai, string dma, string dateOfLoggerBatteryChange, string dateOfLoggerChange, string dateOfMeterChange, string dateOfTransmitterBatteryChange, string dateOfTransmitterChange, string descriptionOfChange, string siteid, string latitude, string longtitude, string location, string logger, string meter, string oldId, string status, string transmitter, string address, string district, string dmaout)
    {
        Site site = new Site();

        site.Availability = avai;
        site.Company = dma;
        if(dateOfLoggerBatteryChange != null && dateOfLoggerBatteryChange.Trim() != "")
        {
            site.DateOfLoggerBatteryChange = new DateTime(1970, 01, 01).AddSeconds(int.Parse(dateOfLoggerBatteryChange)).AddHours(7);
        }
        if (dateOfLoggerChange != null && dateOfLoggerChange.Trim() != "")
        {
            site.DateOfLoggerChange = new DateTime(1970, 01, 01).AddSeconds(int.Parse(dateOfLoggerChange)).AddHours(7);
        }
        if (dateOfMeterChange != null && dateOfMeterChange.Trim() != "")
        {
            site.DateOfMeterChange = new DateTime(1970, 01, 01).AddSeconds(int.Parse(dateOfMeterChange)).AddHours(7);
        }
        if (dateOfTransmitterBatteryChange != null && dateOfTransmitterBatteryChange.Trim() != "")
        {
            site.DateOfTransmitterBatteryChange = new DateTime(1970, 01, 01).AddSeconds(int.Parse(dateOfTransmitterBatteryChange)).AddHours(7);
        }
        if (dateOfTransmitterChange != null && dateOfTransmitterChange.Trim() != "")
        {
            site.DateOfTransmitterChange = new DateTime(1970, 01, 01).AddSeconds(int.Parse(dateOfTransmitterChange)).AddHours(7);
        }
        site.DescriptionOfChange = descriptionOfChange;
        site.Id = siteid;
        site.Latitude = (latitude != "" ? double.Parse(latitude) : 0);
        site.Longitude = (longtitude != "" ? double.Parse(longtitude) : 0);
        site.Location = location;
        site.Logger = logger;
        site.Meter = meter;
        site.OldId = oldId;
        site.Status = status;
        site.Transmitter = transmitter;
        site.Address = address;
        site.District = district;
        site.DMAOut = dmaout;

        CommandStatus command = new CommandStatus();

        SitesBLL _sitesBLL = new SitesBLL();

        command = _sitesBLL.Insert(site);

        return command.Inserted;
    }


    [WebMethod]
    public bool UpdatePointConfig(string avai, string dma, string dateOfLoggerBatteryChange, string dateOfLoggerChange, string dateOfMeterChange, string dateOfTransmitterBatteryChange, string dateOfTransmitterChange, string descriptionOfChange, string siteid, string latitude, string longtitude, string location, string logger, string meter, string oldId, string status, string transmitter, string address, string district, string dmaout)
    {
        Site site = new Site();

        site.Availability = avai;
        site.Company = dma;
        if (dateOfLoggerBatteryChange != null && dateOfLoggerBatteryChange.Trim() != "")
        {
            site.DateOfLoggerBatteryChange = new DateTime(1970, 01, 01).AddSeconds(int.Parse(dateOfLoggerBatteryChange)).AddHours(7);
        }
        if (dateOfLoggerChange != null && dateOfLoggerChange.Trim() != "")
        {
            site.DateOfLoggerChange = new DateTime(1970, 01, 01).AddSeconds(int.Parse(dateOfLoggerChange)).AddHours(7);
        }
        if (dateOfMeterChange != null && dateOfMeterChange.Trim() != "")
        {
            site.DateOfMeterChange = new DateTime(1970, 01, 01).AddSeconds(int.Parse(dateOfMeterChange)).AddHours(7);
        }
        if (dateOfTransmitterBatteryChange != null && dateOfTransmitterBatteryChange.Trim() != "")
        {
            site.DateOfTransmitterBatteryChange = new DateTime(1970, 01, 01).AddSeconds(int.Parse(dateOfTransmitterBatteryChange)).AddHours(7);
        }
        if (dateOfTransmitterChange != null && dateOfTransmitterChange.Trim() != "")
        {
            site.DateOfTransmitterChange = new DateTime(1970, 01, 01).AddSeconds(int.Parse(dateOfTransmitterChange)).AddHours(7);
        }
        site.DescriptionOfChange = descriptionOfChange;
        site.Id = siteid;
        site.Latitude = (latitude != "" ? double.Parse(latitude) : 0);
        site.Longitude = (longtitude != "" ? double.Parse(longtitude) : 0);
        site.Location = location;
        site.Logger = logger;
        site.Meter = meter;
        site.OldId = oldId;
        site.Status = status;
        site.Transmitter = transmitter;
        site.Address = address;
        site.District = district;
        site.DMAOut = dmaout;

        CommandStatus command = new CommandStatus();

        SitesBLL _sitesBLL = new SitesBLL();

        command = _sitesBLL.Update(site);

        return command.Updated;
    }


    [WebMethod]
    public bool DeletePointConfig(string siteid)
    {
        CommandStatus command = new CommandStatus();

        SitesBLL _sitesBLL = new SitesBLL();

        command = _sitesBLL.Delete(siteid);

        return command.Deleted;
    }

    [WebMethod]
    public void PushNotification(List<string> fcmToken, string titleNoti, string bodyNoti)
    {
        for (int i = 0; i < fcmToken.Count; i++)
        {
            //check status sound
            try
            {
                //server key meesapp
                //cannot update applicationID
                var applicationID = "AAAAY4pNtjc:APA91bEYrBM1iYGDzGE0yMwR0Lw3CjIgpdiALHjeEscQKJh5vS51cLS14-zkUK4O29Bk0GPb3FwejsQ9r9nvM_AScW9MzTuVbY9NhlfJdw9hoOrTef_lZwplHsrxa54EgEyNYlpiePmf";
                var senderId = "427522111031";
                HttpWebRequest tRequest = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = fcmToken[i],
                    notification = new
                    {
                        body = bodyNoti,
                        title = titleNoti,
                        // android_sound = "",
                        // Volume = 0.0
                        icon = "ic_launcher.png"
                    }
                };

                var serializer = new JavaScriptSerializer();

                var json = serializer.Serialize(data);

                Byte[] byteArray = Encoding.UTF8.GetBytes(json);

                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));

                tRequest.ContentLength = byteArray.Length;
                //add new
                tRequest.UseDefaultCredentials = true;
                tRequest.PreAuthenticate = true;
                tRequest.Credentials = CredentialCache.DefaultCredentials;
                //add new
                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                string str = sResponseFromServer;
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {

                string str = ex.Message;

            }
        }
    }

    private string serverKey = "AAAAY4pNtjc:APA91bEYrBM1iYGDzGE0yMwR0Lw3CjIgpdiALHjeEscQKJh5vS51cLS14-zkUK4O29Bk0GPb3FwejsQ9r9nvM_AScW9MzTuVbY9NhlfJdw9hoOrTef_lZwplHsrxa54EgEyNYlpiePmf";
    private string senderId = "427522111031";
    private string webAddr = "https://fcm.googleapis.com/fcm/send";

    [WebMethod]
    public string SendNotification(string DeviceToken, string title, string msg)
    {
        var result = "-1";
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
        httpWebRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
        httpWebRequest.Method = "POST";

        var payload = new
        {
            to = DeviceToken,
            priority = "high",
            content_available = true,
            notification = new
            {
                body = msg,
                title = title
            },
        };
        var serializer = new JavaScriptSerializer();
        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = serializer.Serialize(payload);
            streamWriter.Write(json);
            streamWriter.Flush();
        }

        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            result = streamReader.ReadToEnd();
        }
        return result;
    }

    [WebMethod]
    public bool RemoveTokenLogoutApp(string token)
    {
        DeciveTokenAppBLL deviceTokenAppBLL = new DeciveTokenAppBLL();
        int result = deviceTokenAppBLL.RemoveDeviceTokenApp(token);
        return true;
    }
    public List<string> GetListDeviceTokenByUsers(string SiteId)
    {
        var listString = new List<string>();

        DeciveTokenAppBLL deviceTokenAppBLL = new DeciveTokenAppBLL();

        var result = deviceTokenAppBLL.GetDeviceTokenApps(SiteId);

        foreach (var item in result)
        {
            listString.Add(item.DeviceToken.ToString());
        }
        return listString;
    }

    [WebMethod]
    public bool SubmitNotification(string loggerID, string title, string body)
    {
        LoggerConfigurationBLL loggerConfigurationBLL = new LoggerConfigurationBLL();
         var loggerConfiguration = loggerConfigurationBLL.GetLoggerConfiguration(loggerID);
        var SiteId = loggerConfiguration.SiteId;
        var listToken = GetListDeviceTokenByUsers(SiteId);
        PushNotification(listToken, title, body);
        return true;
    }

    [WebMethod]
    public bool UpdateStatusPushNoti(string token, bool status)
    {
        DeciveTokenAppBLL deviceTokenAppBLL = new DeciveTokenAppBLL();

        int result = deviceTokenAppBLL.UpdatePushNotification(token, status);

        return true;

    }

    [WebMethod]
    public List<MChannel> GetChannelConfigurationsByLoggerID(string loggerId)
    {
        var channelConfigurationBL = new ChannelConfigurationBL();
        var x = from c in channelConfigurationBL.GetChannelConfigurationsByLoggerID(loggerId)
                select new MChannel
                {
                    ChannelId = c.ChannelId,
                    LoggerId = c.LoggerId,
                    ChannelName = c.ChannelName,
                    Unit = c.Unit,
                    Description = c.Description,

                    TimeStamp = c.TimeStamp == null ? "NO DATA" : ((DateTime)c.TimeStamp).ToString("dd/MM/yyyy HH:mm"),
                    yyyy = c.TimeStamp == null ? "NO DATA" : ((DateTime)c.TimeStamp).Year.ToString(),
                    MM = c.TimeStamp == null ? "NO DATA" : ((DateTime)c.TimeStamp).Month.ToString(),
                    dd = c.TimeStamp == null ? "NO DATA" : ((DateTime)c.TimeStamp).Day.ToString(),
                    HH = c.TimeStamp == null ? "NO DATA" : ((DateTime)c.TimeStamp).Hour.ToString(),
                    mm = c.TimeStamp == null ? "NO DATA" : ((DateTime)c.TimeStamp).Minute.ToString(),

                    LastValue = c.LastValue == null ? "NO DATA" : ((double)c.LastValue).ToString("0.00"),
                    LastIndex = c.LastIndex == null ? "" : ((double)c.LastIndex).ToString("0,0"),
                    // DisplayOnLabel = c.DisplayOnLabel == null ? false : bool.Parse(c.DisplayOnLabel.ToString())
                };

        return x.OrderBy(d => d.ChannelName).ToList();
    }
    [WebMethod]
    public List<MChannelNew> GetChannelLoggerID(string loggerId)
    {
        var channelConfigurationBL = new ChannelConfigurationBL();
        var x = from c in channelConfigurationBL.GetChannelConfigurationsByLoggerID(loggerId)
                select new MChannelNew
                {
                    ChannelId = c.ChannelId,
                    LoggerId = c.LoggerId,
                    ChannelName = c.ChannelName,





                };
        return x.OrderBy(d => d.ChannelName).ToList();
    }


    [WebMethod]
    public Site GetPointByIdInfo(string siteId)
    {
        Site s = new Site();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select s.[Id], s.[OldId], s.[Location] ,s.[Longitude], s.[Latitude], s.[Meter] , s.[Transmitter], ds.[Id] as Logger, s.[DateOfMeterChange] , s.[DateOfLoggerChange] , s.[DateOfTransmitterChange], s.[DateOfBatteryChange] , s.[DateOfTransmitterBatteryChange], s.[DateOfLoggerBatteryChange], s.[Company], s.[Status], s.[Availability], s.[Description], s.[Address], s.[District], s.[DMAOut] FROM [t_Site_Sites] s join [t_Devices_SitesConfigs] ds on ds.[SiteId] = s.Id where s.Id = '"+siteId+"'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    try
                    {
                        s.Id = reader["Id"].ToString();
                    }
                    catch(Exception ex)
                    {
                        s.Id = "";
                    }
                    try
                    {
                        s.OldId = reader["OldId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        s.OldId = "";
                    }
                    try
                    {
                        s.Latitude = double.Parse(reader["Latitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        s.Latitude = null;
                    }
                    try
                    {
                        s.Longitude = double.Parse(reader["Longitude"].ToString());
                    }
                    catch (Exception ex)
                    {
                        s.Longitude = null;
                    }
                    try
                    {
                        s.Meter = reader["Meter"].ToString();
                    }
                    catch (Exception ex)
                    {
                        s.Meter = "";
                    }
                    try
                    {
                        s.Transmitter = reader["Transmitter"].ToString();
                    }
                    catch (Exception ex)
                    {
                        s.Transmitter = "";
                    }
                    try
                    {
                        s.Logger = reader["Logger"].ToString();
                    }
                    catch (Exception ex)
                    {
                        s.Logger = "";

                    }
                    try
                    {
                        s.DateOfMeterChange = DateTime.Parse( reader["DateOfMeterChange"].ToString());
                    }
                    catch (Exception ex)
                    {
                        s.DateOfMeterChange = null;
                    }
                    try
                    {
                        s.DateOfLoggerChange = DateTime.Parse(reader["DateOfLoggerChange"].ToString());
                    }
                    catch (Exception ex)
                    {
                        s.DateOfLoggerChange = null;
                    }
                    try
                    {
                        s.DateOfBatteryChange = DateTime.Parse(reader["DateOfBatteryChange"].ToString());
                    }
                    catch (Exception ex)
                    {
                        s.DateOfBatteryChange = null;
                    }
                    try
                    {
                        s.DateOfTransmitterBatteryChange = DateTime.Parse(reader["DateOfTransmitterBatteryChange"].ToString());
                    }
                    catch (Exception ex)
                    {
                        s.DateOfTransmitterBatteryChange = null;
                    }
                    try
                    {
                        s.DateOfLoggerBatteryChange = DateTime.Parse(reader["DateOfLoggerBatteryChange"].ToString());
                    }
                    catch (Exception ex)
                    {
                        s.DateOfLoggerBatteryChange = null;
                    }
                    try
                    {
                        s.Company = reader["Company"].ToString();
                    }
                    catch (Exception ex)
                    {
                        s.Company = "";
                    }
                    try
                    {
                        s.Status = reader["Status"].ToString();
                    }
                    catch (Exception ex)
                    {
                        s.Status = "";
                    }
                    try
                    {
                        s.Availability = reader["Availability"].ToString();
                    }
                    catch (Exception ex)
                    {
                        s.Availability = "";
                    }
                    try
                    {
                        s.Address = reader["Address"].ToString();
                    }
                    catch (Exception ex)
                    {
                        s.Address = "";
                    }
                    try
                    {
                        s.District = reader["District"].ToString();
                    }
                    catch (Exception ex)
                    {
                        s.District = "";
                    }
                    try
                    {
                        s.DMAOut = reader["DMAOut"].ToString();
                    }
                    catch (Exception ex)
                    {
                        s.DMAOut = "";
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

        return s;
    }

    [WebMethod]

    public Meter GetMeterBuIdInfo(string id)
    {
        Meter m = new Meter();
        Connect connect = new Connect();
        try
        {
            string sqlQuery = "select [Serial], [ReceiptDate], [AccreditedDate], [ExpiryDate], [AccreditationDocument], [AccreditationType], [Provider], [Marks], [Size], [Model], [Status], [Installed], [InitialIndex], [Description], [ApprovalDate], [Approved], [ApprovalDecision], [SerialTransmitter], [Nationality] from [t_Devices_Meters] where [Serial] = '"+id+"'";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    try
                    {
                        m.Serial = reader["Serial"].ToString();
                    }
                    catch(Exception ex)
                    {
                        m.Serial = "";
                    }
                    try
                    {
                        m.ReceiptDate =DateTime.Parse( reader["ReceiptDate"].ToString());
                    }
                    catch (Exception ex)
                    {
                        m.ReceiptDate = null;
                    }
                    try
                    {
                        m.AccreditedDate = DateTime.Parse(reader["AccreditedDate"].ToString());
                    }
                    catch (Exception ex)
                    {
                        m.AccreditedDate = null;
                    }
                    try
                    {
                        m.ExpiryDate = DateTime.Parse(reader["ExpiryDate"].ToString());
                    }
                    catch (Exception ex)
                    {
                        m.ExpiryDate = null;
                    }
                    try
                    {
                        m.AccreditationDocument =reader["AccreditationDocument"].ToString();
                    }
                    catch (Exception ex)
                    {
                        m.AccreditationDocument = "";
                    }
                    try
                    {
                        m.AccreditationType = reader["AccreditationType"].ToString();
                    }
                    catch (Exception ex)
                    {
                        m.AccreditationType = "";
                    }
                    try
                    {
                        m.Provider = reader["Provider"].ToString();
                    }
                    catch (Exception ex)
                    {
                        m.Provider = "";
                    }
                    try
                    {
                        m.Marks = reader["Marks"].ToString();
                    }
                    catch (Exception ex)
                    {
                        m.Marks = "";
                    }
                    try
                    {
                        m.Marks = reader["Marks"].ToString();
                    }
                    catch (Exception ex)
                    {
                        m.Marks = "";
                    }
                    try
                    {
                        m.Size =short.Parse( reader["Size"].ToString());
                    }
                    catch (Exception ex)
                    {
                        m.Size = null;
                    }
                    try
                    {
                        m.Status = reader["Status"].ToString();
                    }
                    catch (Exception ex)
                    {
                        m.Status = "";
                    }
                    try
                    {
                        m.Installed =bool.Parse( reader["Installed"].ToString());
                    }
                    catch (Exception ex)
                    {
                        m.Installed = null;
                    }
                    try
                    {
                        m.InitialIndex = double.Parse(reader["InitialIndex"].ToString());
                    }
                    catch (Exception ex)
                    {
                        m.InitialIndex = null;
                    }
                    try
                    {
                        m.Description = reader["Description"].ToString();
                    }
                    catch (Exception ex)
                    {
                        m.Description = "";
                    }
                    try
                    {
                        m.AccreditedDate = DateTime.Parse( reader["AccreditedDate"].ToString());
                    }
                    catch (Exception ex)
                    {
                        m.AccreditedDate = null;
                    }
                    try
                    {
                        m.Approved = bool.Parse(reader["Approved"].ToString());
                    }
                    catch (Exception ex)
                    {
                        m.Approved = null;
                    }
                    try
                    {
                        m.ApprovalDecision = reader["ApprovalDecision"].ToString();
                    }
                    catch (Exception ex)
                    {
                        m.ApprovalDecision = "";
                    }
                    try
                    {
                        m.SerialTransmitter = reader["SerialTransmitter"].ToString();
                    }
                    catch (Exception ex)
                    {
                        m.SerialTransmitter = "";
                    }
                    try
                    {
                        m.Nationality = reader["Nationality"].ToString();
                    }
                    catch (Exception ex)
                    {
                        m.Nationality = "";
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

        return m;
    }

    [WebMethod]

    public List<string> GetListMeter()
    {
        List<string> list = new List<string>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select Serial from t_Devices_Meters order by Serial";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    string el = "";

                    try
                    {
                        el = reader["Serial"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el = "";
                    }
                    list.Add(el);
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

    [WebMethod]

    public List<string> GetListTransmitter()
    {
        List<string> list = new List<string>();

        Connect connect = new Connect();

        try
        {
            string sqlQuery = "select Serial from t_Devices_Transmitters order by Serial";

            connect.Connected();

            SqlDataReader reader = connect.Select(sqlQuery);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string el = "";

                    try
                    {
                        el = reader["Serial"].ToString();
                    }
                    catch (Exception ex)
                    {
                        el = "";
                    }
                    list.Add(el);
                }
            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            connect.DisConnected();
        }

        return list;
    }


    [WebMethod]
    public bool CheckExistsLoggerPoint(string siteid)
    {
        LoggerConfigurationBLL loggerConfigurationBLL = new LoggerConfigurationBLL();

        return loggerConfigurationBLL.CheckExistsLoggerPoint(siteid);
    }

    [WebMethod]

    public SiteConfig GetLoggerPointConfig(string siteid)
    {
        LoggerConfigurationBLL loggerConfigurationBLL = new LoggerConfigurationBLL();

        return loggerConfigurationBLL.GetLoggerPointConfigById(siteid);
    }

    [WebMethod]
    public bool InsertLoggerConfig(string serial, string siteid, string interval, string begintime)
    {
        SiteConfig siteConfig = new SiteConfig();

        siteConfig.Id = serial;
        siteConfig.SiteId = siteid;
        if(begintime.Trim() != "")
        {
            DateTime tempBeginTime = new DateTime(1970, 01, 01).AddHours(7).AddSeconds(int.Parse(begintime));

            siteConfig.BeginTime = tempBeginTime;
        }
        if(interval.Trim() != "")
        {
            siteConfig.Interval = short.Parse(interval);
        }

        CommandStatus command = new CommandStatus();

        SiteConfigsBLL _siteConfigsBLL = new SiteConfigsBLL();

        command = _siteConfigsBLL.Insert(siteConfig);

        return command.Inserted;
    }

    [WebMethod]
    public bool UpdateLoggerConfg(string serial, string siteid, string interval, string begintime, string pressure, string pressure1, string forward, string reverse)
    {

        SiteConfig siteConfig = new SiteConfig();

        siteConfig.Id = serial;
        siteConfig.SiteId = siteid;
        if (begintime.Trim() != "")
        {
            DateTime tempBeginTime = new DateTime(1970, 01, 01).AddHours(7).AddSeconds(int.Parse(begintime));

            siteConfig.BeginTime = tempBeginTime;
        }
        if (interval.Trim() != "")
        {
            siteConfig.Interval = short.Parse(interval);
        }
        if(pressure.Trim() != "")
        {
            siteConfig.Pressure = byte.Parse(pressure);
        }
        if (pressure1.Trim() != "")
        {
            siteConfig.Pressure1 = byte.Parse(pressure1);
        }
        if (forward.Trim() != "")
        {
            siteConfig.Forward = byte.Parse(forward);
        }
        if(reverse.Trim() != "")
        {
            siteConfig.Reverse = byte.Parse(reverse);
        }

        CommandStatus command = new CommandStatus();

        SiteConfigsBLL _siteConfigsBLL = new SiteConfigsBLL();

        command = _siteConfigsBLL.Update(siteConfig);

        return command.Updated;

    }

    [WebMethod]
    public bool DeleteLoggerConfig(string siteid)
    {
        SiteConfigsBLL _siteConfigsBLL = new SiteConfigsBLL();
        CommandStatus command = new CommandStatus();

        LoggerConfigurationBLL loggerConfigurationBLL = new LoggerConfigurationBLL();

        SiteConfig site =  loggerConfigurationBLL.GetLoggerPointConfigById(siteid);

        command = _siteConfigsBLL.Delete(site);

        return command.Deleted;
    }

    [WebMethod] 
    public List<string> GetListLoggerId()
    {
        LoggerConfigurationBLL loggerConfigurationBLL = new LoggerConfigurationBLL();

        return loggerConfigurationBLL.GetListLoggerId();
    }

    [WebMethod]
    public List<t_Channel_Configurations> GetChannelByLoggerId(string loggerid)
    {

        LoggerConfigurationBLL loggerConfigurationBLL = new LoggerConfigurationBLL();

        return loggerConfigurationBLL.GetChannelByLoggerId(loggerid);

    }

    [WebMethod]
    public bool CheckExistsChannel(string loggerid, string channelid)
    {
        ChannelConfigurationBL channelConfigurationBL = new ChannelConfigurationBL();

        return channelConfigurationBL.CheckExistsChannel(channelid, loggerid);
    }

    [WebMethod]
    public int InsertChannelConfig(string loggerid, string channelid, string channelname, string unit)
    {
        ChannelConfigurationBL channelConfigurationBL = new ChannelConfigurationBL();

        return channelConfigurationBL.Insert(loggerid, channelid, channelname, unit);
    }

    [WebMethod]
    public int UpdateChannelConfig(string loggerid, string channelid, string channelname, string unit)
    {
        ChannelConfigurationBL channelConfigurationBL = new ChannelConfigurationBL();

        return channelConfigurationBL.Update(loggerid, channelid, channelname, unit);
    }

    [WebMethod]
    public int DeleteChannelConfig(string loggerid, string channelid)
    {
        ChannelConfigurationBL channelConfigurationBL = new ChannelConfigurationBL();

        return channelConfigurationBL.Delete(loggerid, channelid);
    }

    [WebMethod]
    public int UpdateNumberTypeChannel(string loggerid, string number, string type)
    {
        SiteConfigBLL siteConfigBLL = new SiteConfigBLL();

        return siteConfigBLL.UpdateNumberTypeChannel(loggerid, number, type);
    }

    [WebMethod]
    public Logger GetLoggerById(string loggerid)
    {
        LoggerBLL loggerBLL = new LoggerBLL();

        return loggerBLL.GetLoggerById(loggerid);
    }

    [WebMethod]
    public bool CheckExistsLogger(string loggerid)
    {
        LoggerBLL loggerBLL = new LoggerBLL();

        return loggerBLL.CheckExistsLogger(loggerid);
    }

    [WebMethod]
    public bool InsertLogger(string loggerid, string receiptdate, string provider, string marks, string model, string status, string install, string dateinstallbattery, string dateaccreditation, string yearbattery, string description)
    {
        LoggerBLL loggerBLL = new LoggerBLL();

        return loggerBLL.Insert(loggerid, receiptdate, provider, marks, model, status, install, dateinstallbattery, dateaccreditation, yearbattery, description);
    }

    [WebMethod]
    public bool UpdateLogger(string loggerid, string receiptdate, string provider, string marks, string model, string status, string install, string dateinstallbattery, string dateaccreditation, string yearbattery, string description)
    {
        LoggerBLL loggerBLL = new LoggerBLL();

        return loggerBLL.Update(loggerid, receiptdate, provider, marks, model, status, install, dateinstallbattery, dateaccreditation, yearbattery, description);
    }

    [WebMethod]
    public bool DeleteLogger(string loggerid)
    {
        LoggerBLL loggerBLL = new LoggerBLL();
        return loggerBLL.Delete(loggerid);
    }

    public class MLoggerConfig
    {
        public bool? Status1 { get; set; }
        public bool? Status2 { get; set; }
        public int? TimeDelayAlarm { get; set; }
    }
    public class mySite
    {
        public string SiteID { get; set; }
    }
    //public partial class LoggerData
    //{
    //    public System.DateTime TimeStamp { get; set; }
    //    public Nullable<double> Value { get; set; }
    //}
    public class M_Channel_All
    {
        public string ChannelId { get; set; }
        public string LoggerId { get; set; }
        public string ChannelName { get; set; }

    }
    public class myLogin
    {
        public string username { get; set; }

    }
    public class MSite
    {
        public string SiteId { get; set; }
        public string SiteAliasName { get; set; }
        public string Location { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LoggerId { get; set; }
        public double? LabelAnchorX { get; set; }
        public double? LabelAnchorY { get; set; }
        public string DisplayGroup { get; set; }
        public bool? Status1 { get; set; }
        public bool? Status2 { get; set; }
        public int? TimeDelayAlarm { get; set; }

    }
    public class toado
    {
        public string Lat { get; set; }
        public string Lng { get; set; }

    }
    public class logo
    {
        public string Path { get; set; }


    }

    public class AlarmAll
    {
        public string SiteId { get; set; }
        public string SiteAliasName { get; set; }
        public string LoggerId { get; set; }
        public List<Alarm> Alarms { get; set; }
    }
    public class Alarm
    {
        public string ChannelId { get; set; }
        public string ChannelName { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
        public DateTime? TimeStamp { get; set; }
        public double LastValue { get; set; }
        public string StrTimeStamp { get; set; }
        public string Strvalue { get; set; }
        public bool? StatusViewAlarm { get; set; }

        public string yyyy { get; set; }
        public string MM { get; set; }
        public string dd { get; set; }
        public string HH { get; set; }
        public string mm { get; set; }
    }
    //public class MChannel
    //{
    //    public string ChannelId { get; set; }
    //    public string LoggerId { get; set; }
    //    public string ChannelName { get; set; }
    //    public string Unit { get; set; }
    //    public string Description { get; set; }
    //    public string TimeStamp { get; set; }
    //    public string LastValue { get; set; }
    //    public string IndexTimeStamp { get; set; }
    //    public string LastIndex { get; set; }
    //    public bool DisplayOnLabel { get; set; }
    //    //public double LastIndex { get; set; }
    //    public string StrTimeStamp { get; set; }

    //    public string yyyy { get; set; }
    //    public string MM { get; set; }
    //    public string dd { get; set; }
    //    public string HH { get; set; }
    //    public string mm { get; set; }
    //}
    public class MChannelNew
    {
        public string ChannelId { get; set; }
        public string LoggerId { get; set; }
        public string ChannelName { get; set; }


    }
    public class GroupLogger
    {
        public string DisplayGroup { get; set; }
        public string Name { get; set; }

        public List<DataAll> lstDataAll { get; set; }
    }
    public class DataAll
    {
        public string SiteId { get; set; }
        public string SiteAliasName { get; set; }
        public string Location { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string LoggerId { get; set; }
        public double? LabelAnchorX { get; set; }
        public double? LabelAnchorY { get; set; }

        public string District { get; set; }
        public List<GroupChannels> lstGroupChannels { get; set; }
    }
    public class GroupChannels
    {
        public string GroupChannel { get; set; }
        public List<MChannel> Channels { get; set; }
    }

    public class MSampler
    {
        public string stationId { get; set; }
        public string ipaddress { get; set; }
        public string port { get; set; }
        public string partnerId { get; set; }
        public string time { get; set; }
    }
    public class result_sampler
    {
        public string Result { get; set; }
        public string Knumber { get; set; }
    }
    public class MChannel
    {
        public string ChannelId { get; set; }
        public string LoggerId { get; set; }
        public string ChannelName { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
        public Nullable<bool> ForwardFlow { get; set; }
        public Nullable<bool> ReverseFlow { get; set; }
        public Nullable<bool> Pressure1 { get; set; }
        public Nullable<bool> Pressure2 { get; set; }
        public int Status { get; set; }
        public string TimeStamp { get; set; }
        public string LastValue { get; set; }
        public string IndexTimeStamp { get; set; }
        public string LastIndex { get; set; }
        public bool DisplayOnLabel { get; set; }
        public string StrTimeStamp { get; set; }

        public string yyyy { get; set; }
        public string MM { get; set; }
        public string dd { get; set; }
        public string HH { get; set; }
        public string mm { get; set; }

        public string GroupChannel { get; set; }
    }

    public partial class tSiteAvailabilities
    {

        public string Availability { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }

    }

    public partial class tSiteStatus
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }

    }

    public class tChannelConfigurations
    {
        public string ChannelId { get; set; }
        public string LoggerId { get; set; }
        public string SiteId { get; set; }
        public string TelephoneNumber { get; set; }
        public string StartHour { get; set; }
        public string ChannelName { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
        public bool? Pressure1 { get; set; }
        public bool? Pressure2 { get; set; }
        public bool? ForwardFlow { get; set; }
        public bool? ReverseFlow { get; set; }
        public string TimeStamp { get; set; }
        public string LastValue { get; set; }
        public string IndexTimeStamp { get; set; }
        public string LastIndex { get; set; }
        public bool? DisplayOnLabel { get; set; }
        public bool? ChannelOther { get; set; }
        public string basemin { get; set; }
        public string basemax { get; set; }
        public string GroupChannel { get; set; }
        public bool? DisplayOnGraph { get; set; }
        public string Baseline { get; set; }
    }

    public class DeviceTokenApp
    {
        public string UserName { get; set; }
        public string DeviceToken { get; set; }
        public bool Status { get; set; }
        public bool Sound { get; set; }
    }

    public class tGroupChannel
    {
        public string GroupChannel { get; set; }
        public string Description { get; set; }
    }

    public class DisplayGroup
    {
        public string Group { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
    public class MyCusComer
    {
        public string CuscomerId { get; set; }
        public string Description { get; set; }
    }
    public class ChannelMultipleDataViewModel
    {
        public DateTime Timestamp { get; set; }
        public List<Nullable<double>> Values { get; set; }

    }
    public class tUnits
    {
        public string Unit { get; set; }
        public string Description { get; set; }
    }

    public class ConfigLogger
    {
        public string SiteAliasName { get; set; }
        public string ConsumerId { get; set; }
        public string Description { get; set; }
        public string DisplayGroup { get; set; }
        public string Latitude { get; set; }
        public string Location { get; set; }
        public string LoggerId { get; set; }
        public string Longitude { get; set; }
        public string SiteId { get; set; }
        public string StartDay { get; set; }
        public string StartHour { get; set; }
        public Nullable<int> Zoom { get; set; }
        public string TelephoneNumber { get; set; }
        public string MeterSerial { get; set; }
        public string TransmitterSerial { get; set; }
        public string LoggerSerial { get; set; }
        public string Status { get; set; }
        public string Availability { get; set; }
        public string Staffs { get; set; }
        public string PipeSize { get; set; }
        public string SetDiffValue { get; set; }
        public string SetDelayTime { get; set; }
        public string DMA_In { get; set; }
        public string DMA_Out { get; set; }
        public bool Checked { get; set; }
        public string DateChanged { get; set; }
        public string dtmMeterChanged { get; set; }
        public string dtmTransmitterChanged { get; set; }
        public string dtmLoggerChanged { get; set; }
    }

    public class SiteDatAll
    {
        public string SiteId { get; set; }
        public string SiteAliasName { get; set; }
        public string Location { get; set; }
        public string DisplayGroup { get; set; }
        public string District { get; set; }
        public double Latitude { get; set; }
        public string LoggerId { get; set; }
        public double Longitude { get; set; }
        public double Index { get; set; }
        public List<MChannel> ListChannels { get; set; }
    }
}

