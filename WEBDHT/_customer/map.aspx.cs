using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Subgurim.Controles;

public partial class _customer_map : BasePage
{
    SitesBLL _sitesBLL = new SitesBLL();
    ChannelConfigsBLL _channelConfigsBLL = new ChannelConfigsBLL();
    GisSitesBLL _gisSitesBLL = new GisSitesBLL();
    public string _company
    {
        get
        {
            System.Web.Security.FormsIdentity ident = HttpContext.Current.User.Identity as System.Web.Security.FormsIdentity;
            if (ident.IsAuthenticated)
                return ident.Ticket.UserData.Split('|')[1];
            else return null;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string uid = HttpContext.Current.User.Identity.Name;
        if (!IsPostBack)
        {
            GMap1.addGMapUI(new GMapUI());
            GMapDataBind();
        }
    }
    private void GMapDataBind()
    {
        List<SiteViewModel> sites = _sitesBLL.GetAllByCalculatedCompany(_company);
        GisSite gis = _gisSitesBLL.GetByCompany(_company);
        GMap1.GZoom = gis.Zoom;
        if (!IsPostBack)
        {
            List<string> groups = (from s in sites
                                   select s.ViewGroup).Distinct().ToList();
            foreach (string g in groups)
            {
                Telerik.Web.UI.RadTreeNode parent = new Telerik.Web.UI.RadTreeNode(g);
                trvSites.Nodes.Add(parent);
                List<SiteViewModel> gSites = (from s1 in sites
                                              where s1.ViewGroup == g
                                              select s1).ToList();
                foreach (SiteViewModel gS in gSites)
                {
                    Telerik.Web.UI.RadTreeNode child = new Telerik.Web.UI.RadTreeNode(gS.Location, gS.Id);
                    child.NavigateUrl = String.Format("javascript:click_{0}()", gS.Id);
                    parent.Nodes.Add(child);
                }
            }
            trvSites.ExpandAllNodes();
        }
        GLatLngBounds gLatLngBounds = new GLatLngBounds();

        foreach (var s in sites)
        {
            try
            {
                List<ChannelConfig> channels = _channelConfigsBLL.GetByLoggerId(s.LoggerId);
                string label = "";
                label += "<div class=\"style0\">" + s.Location.Replace(' ', '_') + "</div>";
                label += "<table class=\"style1\" border=\"0\" cellpadding=\"3\" cellspacing=\"0\">";
                string html = "";
                html += "<div class=\"style0\">" + s.Location + " (" + s.Id + ")</div>";
                html += "<table class=\"style1\" border=\"0\" cellpadding=\"3\" cellspacing=\"0\">";
                html += "<tr><td class=\"style2\">Kênh</td><td class=\"style2\">Mô tả</td><td class=\"style2\">Ngày giờ</td><td class=\"style2\">Giá trị</td><td class=\"style2\">Đơn vị</td></tr>";
                foreach (var c in channels)
                {
                    html += "<tr><td class=\"style3\">" + c.Id + "</td><td class=\"style3\">" + c.Name + "</td><td class=\"style3\">" + (c.LastTimeStamp == null ? string.Empty : ((DateTime)c.LastTimeStamp).ToString("dd/MM/yyyy hh:mm tt")) + "</td><td class=\"style5\">" + string.Format("{0:0.00}", c.LastValue) + "</td><td class=\"style4\">" + c.Unit + "</td></tr>";
                    label += "<tr>";
                    label += "<td class=\"style5\">" + string.Format("{0:0.00}", c.LastValue) + "</td><td class=\"style2\">[" + c.Unit + "]</td>";
                    label += "</tr>";
                }
                html += "</table>";
                label += "</table>";
                GLatLng loc = new GLatLng((double)s.Latitude, (double)s.Longitude);
                LabeledMarker labeledMarker = new LabeledMarker(loc);
                labeledMarker.ID = "m_" + s.Id.Replace(' ', '_');
                labeledMarker.options.labelText = label;
                labeledMarker.options.labelOffset = new GSize(-40, 0);

                GInfoWindow window = new GInfoWindow(labeledMarker, html);
                GMap1.Add(window);
                gLatLngBounds.extend(loc);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendFormat("function click_{0}()", s.Id.Replace(' ', '_'));
                sb.Append("{");
                sb.AppendFormat("{0}.setCenter({1}.getPoint());", GMap1.GMap_Id, GMap1.getGMapElementById(labeledMarker.ID));
                sb.AppendFormat("{0}.openInfoWindowHtml('{1}');", GMap1.getGMapElementById(labeledMarker.ID), window.html);
                sb.Append("}");
                GMap1.Add(sb.ToString());
            }
            catch { }
        }
        if (!IsPostBack)
        {
            GMap1.setCenter(gLatLngBounds.getCenter());
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        GMap1.resetInfoWindows();
        GMap1.resetMarkers();
        GMap1.resetCustomInsideJS();
        GMap1.resetCustomJS();
        GMap1.resetMarkerClusterer();
        GMap1.resetMarkerManager();
        GMapDataBind();
    }
}