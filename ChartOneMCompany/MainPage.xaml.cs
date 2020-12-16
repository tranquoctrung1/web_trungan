using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ChartOneMCompany
{

    public partial class MainPage : UserControl
    {
        public List<ServiceReference1.SiteCompany> AllCompanies = new List<ServiceReference1.SiteCompany>();

        public MainPage()
        {
            InitializeComponent();
            ServiceReference1.SitesServiceSoapClient proxy = new ServiceReference1.SitesServiceSoapClient();
            proxy.Endpoint.Address = new System.ServiceModel.EndpointAddress("http://" + System.Windows.Browser.HtmlPage.Document.DocumentUri.Host + ":" + HtmlPage.Document.DocumentUri.Port + "/SitesService.asmx");
            proxy.GetAllCompaniesCompleted += Proxy_GetAllCompaniesCompleted;
            proxy.GetAllCompaniesAsync();
        }

        private void Proxy_GetAllCompaniesCompleted(object sender, ServiceReference1.GetAllCompaniesCompletedEventArgs e)
        {
            AllCompanies = e.Result.ToList();
            cboCompanies.ItemsSource = AllCompanies;
            return;
            throw new NotImplementedException();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cboCompanies.Text))
            {
                MessageBox.Show("Chưa nhập công ty.");
                cboCompanies.Focus();
                return;
            }
            if (dtmStart.SelectedDate == null)
            {
                MessageBox.Show("Chưa nhập ngày bắt đầu.");
                dtmStart.Focus();
                return;
            }
            if (dtmEnd.SelectedDate == null)
            {
                MessageBox.Show("Chưa nhập ngày kết thúc.");
                dtmEnd.Focus();
                return;
            }

            ServiceReference2.ChartDataServiceSoapClient proxy = new ServiceReference2.ChartDataServiceSoapClient();
            proxy.Endpoint.Address = new System.ServiceModel.EndpointAddress("http://" + System.Windows.Browser.HtmlPage.Document.DocumentUri.Host + ":" + HtmlPage.Document.DocumentUri.Port + "/ChartDataService.asmx");
            proxy.GetMCompanyDataCompleted += Proxy_GetMCompanyDataCompleted;
            proxy.GetMCompanyDataAsync(cboCompanies.Text, (DateTime)dtmStart.SelectedDate, (DateTime)dtmEnd.SelectedDate);
        }

        private void Proxy_GetMCompanyDataCompleted(object sender, ServiceReference2.GetMCompanyDataCompletedEventArgs e)
        {
            var list = e.Result.OrderBy(d => d.TimeStamp).ToList();
            chart.Series.Clear();
            DateTime start = (DateTime)dtmStart.SelectedDate;
            DateTime end = (DateTime)dtmEnd.SelectedDate;
            List<string> listName = new List<string>();
            if (((DateTime)dtmStart.SelectedDate).Day == 21 && ((DateTime)dtmEnd.SelectedDate).Day == 20)
            {
                List<Visiblox.Charts.DataSeries<string, double>> listSeries = new List<Visiblox.Charts.DataSeries<string, double>>();
                int j = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    //change multi lines to 3 lines: listSeries.Count <= 2
                    if (i != 0 && (list[i].TimeStamp.Day == ((DateTime)dtmStart.SelectedDate).Day || i == list.Count - 1))
                    {
                        Visiblox.Charts.DataSeries<string, double> s = new Visiblox.Charts.DataSeries<string, double>();
                        for (int k = j; k < i; k++)
                        {
                            s.Add(new Visiblox.Charts.DataPoint<string, double>(list[k].TimeStamp.Day.ToString(), list[k].Value));
                        }
                        if (i == list.Count - 1)
                        {
                            s.Add(new Visiblox.Charts.DataPoint<string, double>(list[i].TimeStamp.Day.ToString(), list[i].Value));
                        }
                        j = i;
                        listSeries.Add(s);
                        listName.Add(list[i].TimeStamp.ToString("MM/yyyy"));
                    }
                }

                for (int i = 0; i < listSeries.Count; i++)
                {
                    if (listSeries[i].Count == 31)
                    {
                        Visiblox.Charts.LineSeries lineSeries = new Visiblox.Charts.LineSeries();
                        lineSeries.Name = listName[i];
                        lineSeries.DataSeries = listSeries[i];
                        lineSeries.DataSeries.Title = listName[i];
                        lineSeries.LineStrokeThickness = 1.2;
                        //Add color
                        switch (i)
                        {
                            case 0:
                                lineSeries.LineStroke = new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0x00, 0xff));
                                break;
                            case 1:
                                lineSeries.LineStroke = new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0xff, 0x00));
                                break;
                            default:
                                break;
                        }
                        chart.Series.Add(lineSeries);
                    }
                }
                for (int i = 0; i < listSeries.Count; i++)
                {
                    if (listSeries[i].Count == 30)
                    {
                        Visiblox.Charts.LineSeries lineSeries = new Visiblox.Charts.LineSeries();
                        lineSeries.Name = listName[i];
                        lineSeries.DataSeries = listSeries[i];
                        lineSeries.DataSeries.Title = listName[i];
                        lineSeries.LineStrokeThickness = 1.2;
                        //Add color
                        switch (i)
                        {
                            case 0:
                                lineSeries.LineStroke = new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0x00, 0xff));
                                break;
                            case 1:
                                lineSeries.LineStroke = new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0xff, 0x00));
                                break;
                            default:
                                break;
                        }
                        chart.Series.Add(lineSeries);
                    }
                }
                for (int i = 0; i < listSeries.Count; i++)
                {
                    if (listSeries[i].Count == 29)
                    {
                        Visiblox.Charts.LineSeries lineSeries = new Visiblox.Charts.LineSeries();
                        lineSeries.Name = listName[i];
                        lineSeries.DataSeries = listSeries[i];
                        lineSeries.DataSeries.Title = listName[i];
                        lineSeries.LineStrokeThickness = 1.2;
                        //Add color
                        switch (i)
                        {
                            case 0:
                                lineSeries.LineStroke = new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0x00, 0xff));
                                break;
                            case 1:
                                lineSeries.LineStroke = new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0xff, 0x00));
                                break;
                            default:
                                break;
                        }
                        chart.Series.Add(lineSeries);
                    }
                }
                for (int i = 0; i < listSeries.Count; i++)
                {
                    if (listSeries[i].Count == 28)
                    {
                        Visiblox.Charts.LineSeries lineSeries = new Visiblox.Charts.LineSeries();
                        lineSeries.Name = listName[i];
                        lineSeries.DataSeries = listSeries[i];
                        lineSeries.DataSeries.Title = listName[i];
                        lineSeries.LineStrokeThickness = 1.2;
                        //Add color
                        switch (i)
                        {
                            case 0:
                                lineSeries.LineStroke = new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0x00, 0xff));
                                break;
                            case 1:
                                lineSeries.LineStroke = new SolidColorBrush(Color.FromArgb(0xff, 0x00, 0xff, 0x00));
                                break;
                            default:
                                break;
                        }
                        chart.Series.Add(lineSeries);
                    }
                }
                if (listSeries.Count == 2)
                {
                    double leak;
                    double sumLeak = 0;
                    int count = 0;
                    Visiblox.Charts.DataSeries<string, double> seriesLeak = new Visiblox.Charts.DataSeries<string, double>();
                    for (int i = 0; i < listSeries[0].Count; i++)
                    {
                        if (listSeries[0][i].Y != 0)
                        {
                            foreach (var item in listSeries[1])
                            {
                                if (item.X == listSeries[0][i].X)
                                {
                                    leak = (item.Y / listSeries[0][i].Y - 1) * 100;
                                    sumLeak += leak;
                                    count++;
                                    seriesLeak.Add(new Visiblox.Charts.DataPoint<string, double>(listSeries[0][i].X, leak));
                                }
                            }
                        }
                    }
                    string strLineSeries3 = "Chênh lệch " + string.Format("{0:0.00}", sumLeak / count) + "%";
                    Visiblox.Charts.LineSeries lineSeries3 = new Visiblox.Charts.LineSeries();
                    lineSeries3.Name = strLineSeries3;
                    lineSeries3.DataSeries = seriesLeak;
                    lineSeries3.DataSeries.Title = strLineSeries3;
                    lineSeries3.LineStrokeThickness = 1.2;
                    lineSeries3.LineStroke = new SolidColorBrush(Color.FromArgb(0xff, 0xff, 0x00, 0x00));
                    chart.Series.Add(lineSeries3);
                    chart.Series[2].YAxis = chart.SecondaryYAxis;
                }
            }
            else
            {
                Visiblox.Charts.DataSeries<string, double> s = new Visiblox.Charts.DataSeries<string, double>();
                for (int i = 0; i < list.Count; i++)
                {
                    s.Add(list[i].TimeStamp.ToString("dd/MM/yy"), list[i].Value);
                }
                Visiblox.Charts.LineSeries lineSeries = new Visiblox.Charts.LineSeries();
                lineSeries.Name = ((DateTime)dtmStart.SelectedDate).ToString("dd/MM/yy") + " to " + ((DateTime)dtmEnd.SelectedDate).ToString("dd/MM/yy");
                lineSeries.DataSeries = s;
                lineSeries.DataSeries.Title = lineSeries.Name;
                lineSeries.LineStrokeThickness = 1.2;
                chart.Series.Add(lineSeries);
                //throw;
            }
            ServiceReference1.SiteCompany company = AllCompanies.SingleOrDefault(s => s.Company == cboCompanies.Text);
            string location = "";
            if (company != null)
            {
                location = company.Description;
            }
            chart.Title = "Sản lượng công ty " + location + " (" + cboCompanies.Text + ")" + " từ " + ((DateTime)dtmStart.SelectedDate).ToString("dd/MM/yyyy") + " đến " + ((DateTime)dtmEnd.SelectedDate).ToString("dd/MM/yyyy");
            /////
            //System.Globalization.CultureInfo culture =new System.Globalization.CultureInfo("en-GB");
            //int t = end.Month - start.Month;
            //DateTime start1 = start;
            //DateTime end1 = DateTime.Parse("20/" + start1.AddMonths(1).ToString("MM/yyyy"), culture);
            //DateTime start2 = end1.AddDays(1);
            //DateTime end2 = end;
            //var list1 = list.Select(d => d.TimeStamp >= start1 && d.TimeStamp <= end1);
            //var list2 = list.Select(d => d.TimeStamp >= start2 && d.TimeStamp <= end2);
            //if ((t == 2 || t == -10) && start.Day == 21 && end.Day == 20)
            //{
            //    Visiblox.Charts.DataSeries<string, double> s = new Visiblox.Charts.DataSeries<string, double>();
            //    for (int i = 0; i < 31; i++)
            //    {

            //    }
            //}
            return;
            throw new NotImplementedException();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "PNG File|*.png";

            if (dlg.ShowDialog() == true)
            {
                Stream image_stream = ImageHelper.CreateImage(chart).GetStream();
                int length = (int)image_stream.Length;
                byte[] bytes = new byte[length];
                image_stream.Read(bytes, 0, length);
                image_stream.Close();

                Stream file_stream = dlg.OpenFile();
                file_stream.Write(bytes, 0, length);
                file_stream.Flush();
                file_stream.Close();
            }
        }
    }

    public class ImageHelper
    {
        public static EditableImage CreateImage(FrameworkElement element)
        {
            WriteableBitmap bmp = new WriteableBitmap(element, null);
            EditableImage img = new EditableImage(bmp.PixelWidth, bmp.PixelHeight);

            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    int pixel = bmp.Pixels[(i * img.Width) + j];
                    img.SetPixel(j, i,
                            (byte)((pixel >> 16) & 0xFF),
                            (byte)((pixel >> 8) & 0xFF),
                            (byte)(pixel & 0xFF),
                            (byte)((pixel >> 24) & 0xFF)
                    );
                }
            }

            return img;
        }
    }
}
