using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfAlarmData.Model;
using WcfAlarmData.ULT;
using WcfLoggerData.Action;

namespace WcfAlarmData.Action
{
    class InsertAndUpdateAlarmForLoggerAction
    {
        public int[] InsertAndUpdateAlarmForLogger()
        {
            int nRowInsert = 0;
            int nRowUpdate = 0;

            List<AlarmForLoggerViewModel> list = new List<AlarmForLoggerViewModel>();

            CheckAccreditationLoggerAction checkAccreditationLoggerAction = new CheckAccreditationLoggerAction();
            CheckYearBatteryAction checkYearBatteryAction = new CheckYearBatteryAction();

            InsertAlarmLoggerDBAction insertAlarmLoggerDBAction = new InsertAlarmLoggerDBAction();
            UpdateAlarmForLoggerDBAction updateAlarmForLoggerDBAction = new UpdateAlarmForLoggerDBAction();

            GetAllAlarmLoggerAction getAllAlarmLoggerAction = new GetAllAlarmLoggerAction();
            GetDeviceLoggerAction getDeviceLoggerAction = new GetDeviceLoggerAction();
            BinarySearch binarySearch = new BinarySearch();

            List<LoggerViewModel> listLoggers = getDeviceLoggerAction.GetLogger();
            List<AlarmForLoggerViewModel> listAlarm = getAllAlarmLoggerAction.GetAllAlarmForLogger();

            foreach(var item in listLoggers)
            {
                if (item.DateAccreditation != null)
                {
                    var resultForAccreditation = checkAccreditationLoggerAction.CheckAccreditationLogger(item.DateAccreditation.Value);
                    if(resultForAccreditation.Result != -1)
                    {
                        if(resultForAccreditation.Result == 0)
                        {
                            nRowUpdate += updateAlarmForLoggerDBAction.Update(item.Serial, 1);
                        }
                        else if(resultForAccreditation.Result == 1)
                        {
                            AlarmForLoggerViewModel el = new AlarmForLoggerViewModel();
                            el.Serial = item.Serial;
                            el.Type = 1;
                            el.StartDate = DateTime.Now;
                            el.EndDate = null;
                            el.IsFinish = false;
                            el.Content = $"Logger {item.Serial} sắp đến hạn kiểm định còn lại "+ resultForAccreditation.DayRemain.ToString() + " ngày";

                            int isFind = binarySearch.BinarySearchInterativeForLogger(listAlarm, el.StartDate.Value);

                            if(isFind == -1)
                            {
                                list.Add(el);
                            }
                        }
                        else if(resultForAccreditation.Result == 2)
                        {
                            AlarmForLoggerViewModel el = new AlarmForLoggerViewModel();
                            el.Serial = item.Serial;
                            el.Type = 1;
                            el.StartDate = DateTime.Now;
                            el.EndDate = null;
                            el.IsFinish = false;
                            el.Content = $"Logger {item.Serial} quá hạn kiểm định " + resultForAccreditation.DayRemain.ToString() + " ngày";

                            int isFind = binarySearch.BinarySearchInterativeForLogger(listAlarm, el.StartDate.Value);

                            if (isFind == -1)
                            {
                                list.Add(el);
                            }
                        }
                    }
                }
                if(item.DateInstallBattery != null && item.YearBattery != null)
                {
                   var resultForBatteryYear = checkYearBatteryAction.CheckYearBattery(item.DateInstallBattery.Value, item.YearBattery.Value);

                    if(resultForBatteryYear.Result != -1)
                    {
                        if(resultForBatteryYear.Result == 0)
                        {
                            nRowUpdate += updateAlarmForLoggerDBAction.Update(item.Serial, 2);
                        }
                        else if(resultForBatteryYear.Result == 1)
                        {
                            AlarmForLoggerViewModel el = new AlarmForLoggerViewModel();
                            el.Serial = item.Serial;
                            el.Type = 2;
                            el.StartDate = DateTime.Now;
                            el.EndDate = null;
                            el.IsFinish = false;
                            el.Content = $"Logger {item.Serial} sắp đến hạn kiểm định pin còn lại " + resultForBatteryYear.DayRemain.ToString() + " ngày";

                            int isFind = binarySearch.BinarySearchInterativeForLogger(listAlarm, el.StartDate.Value);

                            if (isFind == -1)
                            {
                                list.Add(el);
                            }
                        }
                        else if(resultForBatteryYear.Result == 2)
                        {
                            AlarmForLoggerViewModel el = new AlarmForLoggerViewModel();
                            el.Serial = item.Serial;
                            el.Type = 2;
                            el.StartDate = DateTime.Now;
                            el.EndDate = null;
                            el.IsFinish = false;
                            el.Content = $"Logger {item.Serial} quá hạn kiểm định pin " + resultForBatteryYear.DayRemain.ToString() + " ngày";

                            int isFind = binarySearch.BinarySearchInterativeForLogger(listAlarm, el.StartDate.Value);

                            if (isFind == -1)
                            {
                                list.Add(el);
                            }
                        }
                    }
                }
                Console.WriteLine(item.Serial);
            }

            if(list.Count != 0 )
            {
                nRowInsert = insertAlarmLoggerDBAction.Insert(list);
            }

            return new int[] { nRowInsert, nRowUpdate };
        }
    }
}
